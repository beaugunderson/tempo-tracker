#region Using directives

using System;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using Microsoft.Win32;
using TempoTracker.Properties;

#endregion

namespace TempoTracker
{
    public partial class mainForm : Form
    {
        #region Locals
        private const string _apiUrl = "https://app.keeptempo.com";

        private DateTime _date;

        private TimeSpan _elapsed;
        private TimeSpan _modifier;
        private string _password;

        private bool _paused;
        private DateTime _start;
        private string _username;
        #endregion

        #region Properties
        public TimeSpan modifier
        {
            get
            {
                return _modifier;
            }
            set
            {
                _modifier = value;
            }
        }

        public DateTime date
        {
            get
            {
                return _date;
            }
            set
            {
                _date = value;
            }
        }

        public bool WarnOnEmptyNotesOption { get; set; }

        public bool ShowTimeReminderOption { get; set; }

        public bool ShowInTaskbarOption { get; set; }

        public bool ResetProjectOnSubmitOption { get; set; }

        #endregion

        public mainForm()
        {
            InitializeComponent();
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            updateProjects();
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            projectsComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private bool createEvent(decimal hours, string notes, DateTime dateTime, int id, string tags)
        {
            String eventXml = String.Format(
                "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
                "<entry>" +
                "<hours type=\"decimal\">{0:N2}</hours>" +
                "<notes>{1:S}</notes>" +
                "<project-id type=\"integer\">{2:G}</project-id>" +
                "<occurred-on type=\"datetime\">{3:s}</occurred-on>" +
                //"<tag-s>{3:S}</tag-s>" +
                "</entry>", hours, notes, id, dateTime);

            const string strUrl = _apiUrl + "/entries";

            var webRequest = WebRequest.Create(strUrl) as HttpWebRequest;

            webRequest.AllowAutoRedirect = false;
            webRequest.UserAgent = "TempoTracker.NET";
            webRequest.Method = "POST";
            webRequest.Credentials = new NetworkCredential(_username, _password);
            webRequest.Accept = "application/xml";
            webRequest.ContentType = "application/xml";

            byte[] ByteData = Encoding.UTF8.GetBytes(eventXml);

            webRequest.ContentLength = ByteData.Length;

            using (Stream postStream = webRequest.GetRequestStream())
            {
                postStream.Write(ByteData, 0, ByteData.Length);
            }

            try
            {
                var webResponse = webRequest.GetResponse() as HttpWebResponse;

                var sr = new StreamReader(webResponse.GetResponseStream());

                XmlReader xr = XmlReader.Create(sr);

                while (xr.Read())
                {
                    if (xr.NodeType != XmlNodeType.Element) continue;
                    
                    if (xr.Name == "entry")
                    {
                        return true;
                    }
                }

                return false;
            }
            catch (WebException we)
            {
                Console.WriteLine(we);

                return false;
            }
        }

        private void updateProjects()
        {
            String strUrl = _apiUrl + "/projects";

            var webRequest = WebRequest.Create(strUrl) as HttpWebRequest;

            webRequest.AllowAutoRedirect = false;
            webRequest.UserAgent = "TempoTracker.NET";
            webRequest.Method = "GET";
            webRequest.Credentials = new NetworkCredential(_username, _password);
            webRequest.Accept = "application/xml";
            webRequest.ContentType = "application/xml";

            var webResponse = webRequest.GetResponse() as HttpWebResponse;

            var sr = new StreamReader(webResponse.GetResponseStream());

            XmlReader xr = XmlReader.Create(sr);

            projectsComboBox.Items.Clear();
            projectsComboBox.Items.Add("Select project...");

            while (xr.Read())
            {
                if (xr.NodeType != XmlNodeType.Element || xr.Name != "project") continue;
                
                xr.ReadToDescendant("id");

                int id = Convert.ToInt32(xr.ReadString());

                xr.ReadToFollowing("name");

                string name = xr.ReadString();

                var p = new Project(id, name);

                projectsComboBox.Items.Add(p);
            }

            projectsComboBox.SelectedIndex = projectsComboBox.Items.IndexOf("Select project...");
        }

        private void readPreferences()
        {
            RegistryKey rk = Application.UserAppDataRegistry;

            _username = rk.GetValue("username", "").ToString();
            _password = ReadPassword(rk);

            if (String.IsNullOrEmpty(_username) || String.IsNullOrEmpty(_password))
            {
                var fo = new optionsForm();

                if (fo.ShowDialog(this) != DialogResult.OK)
                {
                    MessageBox.Show("You must set a username and password to continue.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                readPreferences();
            }

            ShowInTaskbarOption = Convert.ToBoolean((int)rk.GetValue("showInTaskbar", 1));
            ShowTimeReminderOption = Convert.ToBoolean((int)rk.GetValue("showTimeReminder", 0));
            WarnOnEmptyNotesOption = Convert.ToBoolean((int)rk.GetValue("warnOnEmptyNotes", 1));
            ResetProjectOnSubmitOption = Convert.ToBoolean((int)rk.GetValue("resetProjectOnSubmit", 1));

            ShowInTaskbar = ShowInTaskbarOption;
        }

        private void mainForm_Shown(object sender, EventArgs e)
        {
            readPreferences();

            updateProjects();
        }

        public static string ReadPassword(RegistryKey rk)
        {
            try
            {
                byte[] entropy = { 0x01, 0x02, 0x03, 0x05, 0x07, 0x11 };

                byte[] protectedSecret = Convert.FromBase64String(rk.GetValue("password", "").ToString());
                byte[] secret = ProtectedData.Unprotect(protectedSecret, entropy, DataProtectionScope.CurrentUser);

                return Encoding.Unicode.GetString(secret);
            }
            catch (CryptographicException ce)
            {
                Console.WriteLine(ce);

                return null;
            }
        }

        private void taskTimer_Tick(object sender, EventArgs e)
        {
            _elapsed = (DateTime.Now - _start) + _modifier;

            timeLinkLabel.Text = fuzzyFormatTime(_elapsed.TotalSeconds);
        }

        private static string fuzzyFormatTime(double seconds)
        {
            if (seconds < 60)
            {
                return String.Format("{0:N0} seconds", Math.Round(seconds, 0));
            }
            else if (seconds < 3600)
            {
                return String.Format("{0:N1} minutes", Math.Round(seconds / 60, 1));
            }
            else
            {
                return String.Format("{0:N2} hours", Math.Round(seconds / 3600, 2));
            }
        }

        private void sendManualEntryButton_Click(object sender, EventArgs e)
        {
            if (validateManualEntry())
            {
                var p = (Project)projectsComboBox.SelectedItem;

                if (createEvent(hoursNumericUpDown.Value, notesTextBox.Text, manualEntryDateTimePicker.Value, p.id, ""))
                {
                    toolStripStatusLabel1.Text = "Successfully created the event.";

                    if (ResetProjectOnSubmitOption)
                    {
                        projectsComboBox.SelectedIndex = projectsComboBox.Items.IndexOf("Select project...");
                    }
                }
                else
                {
                    MessageBox.Show("Unable to create the event.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please make sure that you have entered a valid time in the hours field.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private bool validateManualEntry()
        {
            bool status = true;

            if (WarnOnEmptyNotesOption)
            {
                if (String.IsNullOrEmpty(notesTextBox.Text))
                {
                    DialogResult d = MessageBox.Show("Do you want to submit time without a note? It may be hard to remember what you worked on later!", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (d == DialogResult.No)
                    {
                        status = false;
                    }
                }
            }

            if (hoursNumericUpDown.Value == 0)
            {
                status = false;
            }

            return status;
        }

        private void sendTimerEntryButton_Click(object sender, EventArgs e)
        {
            sendTimerEntryButton.Enabled = false;

            var p = (Project)projectsComboBox.SelectedItem;

            if (createEvent(Math.Round((Decimal)_elapsed.TotalHours, 2), notesTextBox.Text, _date, p.id, ""))
            {
                toolStripStatusLabel1.Text = "Successfully created the event.";

                _paused = false;

                notesTextBox.Text = "";
                timeLinkLabel.Text = "";

                if (ResetProjectOnSubmitOption)
                {
                    projectsComboBox.SelectedIndex = projectsComboBox.Items.IndexOf("Select project...");
                }
            }
            else
            {
                MessageBox.Show("Unable to create the event.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void timeLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var fdte = new dateTimeEditForm(_elapsed, date);

            if (fdte.ShowDialog(this) == DialogResult.OK)
            {
                _start = DateTime.Now;
                _elapsed = new TimeSpan();
            }
        }

        private void timerPlayPauseButton_Click(object sender, EventArgs e)
        {
            // Pause button clicked while timer running
            if (taskTimer.Enabled)
            {
                _paused = true;

                _modifier = _elapsed;

                timerPlayPauseButton.Image = Resources.control_play;

                taskTimer.Enabled = false;
            }
            // Play button clicked...
            else
            {
                // ... while paused
                if (_paused)
                {
                    _paused = false;

                    _start = DateTime.Now;

                    timerPlayPauseButton.Image = Resources.control_pause;

                    taskTimer.Enabled = true;
                }
                // ... to start the timer for the first time
                else
                {
                    _paused = false;

                    timerPlayPauseButton.Image = Resources.control_pause;
                    timerStopButton.Enabled = true;

                    sendTimerEntryButton.Enabled = true;

                    _date = DateTime.Today;
                    _start = DateTime.Now;
                    _modifier = new TimeSpan();

                    taskTimer.Enabled = true;
                }
            }
        }

        private void timerStopButton_Click(object sender, EventArgs e)
        {
            _paused = false;

            timerPlayPauseButton.Image = Resources.control_play;
            timerStopButton.Enabled = false;

            taskTimer.Enabled = false;
        }

        private void optionsButton_Click(object sender, EventArgs e)
        {
            var fo = new optionsForm();

            if (fo.ShowDialog(this) == DialogResult.OK)
            {
                readPreferences();
            }
        }

        private void mainForm_DoubleClick(object sender, EventArgs e)
        {
            var ab = new AboutBox();

            ab.ShowDialog();
        }

        private void tempoTrackerNotifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Visible = !Visible;
        }
    }

    public class Project
    {
        public Project(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public int id { get; set; }

        public string name { get; set; }

        public override string ToString()
        {
            return name;
        }
    }
}
