using System;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using Microsoft.Win32;
using TempoTracker.Properties;

namespace TempoTracker
{
    public partial class MainForm : Form
    {
        #region Locals

        private const string API_URL = "https://app.keeptempo.com";
        private int _balloonTipCount;

        private TimeSpan _elapsed;
        private string _password;

        private bool _paused;
        private DateTime _start;
        private string _username;

        #endregion

        #region Properties

        public TimeSpan Modifier { get; set; }
        public DateTime Date { get; set; }
        public bool WarnOnEmptyNotesOption { get; set; }
        public bool ShowTimeReminderOption { get; set; }
        public bool ShowInTaskbarOption { get; set; }
        public bool ResetProjectOnSubmitOption { get; set; }
        public bool DisplayTimeHoursMinutesOption { get; set; }

        #endregion

        public MainForm()
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
            string eventXml = string.Format("<?xml version=\"1.0\" encoding=\"UTF-8\"?><entry><hours>{0:N2}</hours><notes>{1:S}</notes><project-id>{2:G}</project-id><occurred-on>{3:s}</occurred-on><tag-s>{4}</tag-s></entry>", hours, notes, id, dateTime, tags);

            string url = string.Format("{0}/entries", API_URL);

            HttpWebRequest webRequest = (HttpWebRequest) WebRequest.Create(url);

            webRequest.AllowAutoRedirect = false;
            webRequest.UserAgent = "TempoTracker.NET";
            webRequest.Method = "POST";
            webRequest.Credentials = new NetworkCredential(_username, _password);
            webRequest.Accept = "application/xml";
            webRequest.ContentType = "application/xml";

            byte[] byteData = Encoding.UTF8.GetBytes(eventXml);

            webRequest.ContentLength = byteData.Length;

            using (Stream postStream = webRequest.GetRequestStream())
            {
                postStream.Write(byteData, 0, byteData.Length);
            }

            try
            {
                HttpWebResponse webResponse = (HttpWebResponse) webRequest.GetResponse();
                StreamReader streamReader = new StreamReader(webResponse.GetResponseStream());

                try
                {
                    XmlReader xmlReader = XmlReader.Create(streamReader);

                    while (xmlReader.Read())
                    {
                        if (xmlReader.NodeType != XmlNodeType.Element)
                        {
                            continue;
                        }

                        if (xmlReader.Name == "entry")
                        {
                            return true;
                        }
                    }
                }
                catch (XmlException ex)
                {
                    Console.WriteLine(ex);
                    Console.WriteLine(streamReader.ReadToEnd());
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
            string url = string.Format("{0}/projects.xml?per_page=1000", API_URL);

            HttpWebRequest webRequest = (HttpWebRequest) WebRequest.Create(url);

            webRequest.AllowAutoRedirect = false;
            webRequest.UserAgent = "TempoTracker.NET";
            webRequest.Method = "GET";
            webRequest.Credentials = new NetworkCredential(_username, _password);
            webRequest.Accept = "application/xml";
            webRequest.ContentType = "application/xml";

            HttpWebResponse webResponse = webRequest.GetResponse() as HttpWebResponse;
            StreamReader streamReader = new StreamReader(webResponse.GetResponseStream());

            projectsComboBox.Items.Clear();
            projectsComboBox.Items.Add("Select project...");

            XmlReader xmlReader = XmlReader.Create(streamReader);

            while (xmlReader.Read())
            {
                if (xmlReader.NodeType != XmlNodeType.Element || xmlReader.Name != "project")
                {
                    continue;
                }

                xmlReader.ReadToDescendant("id");

                int id = Convert.ToInt32(xmlReader.ReadString());

                xmlReader.ReadToFollowing("name");

                string name = xmlReader.ReadString();

                projectsComboBox.Items.Add(new Project(id, name));
            }

            projectsComboBox.SelectedIndex = projectsComboBox.Items.IndexOf("Select project...");
        }

        private void readPreferences()
        {
            RegistryKey registryKey = Application.UserAppDataRegistry;

            if (registryKey == null)
            {
                MessageBox.Show("There was an error reading the user registry.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            _username = registryKey.GetValue("username", string.Empty).ToString();
            _password = ReadPassword(registryKey);

            if (string.IsNullOrEmpty(_username) || string.IsNullOrEmpty(_password))
            {
                OptionsForm optionsForm = new OptionsForm();

                if (optionsForm.ShowDialog(this) != DialogResult.OK)
                {
                    MessageBox.Show("You must set a username and password to continue.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                readPreferences();
            }

            ShowInTaskbarOption = Convert.ToBoolean((int) registryKey.GetValue("showInTaskbar", 1));
            ShowTimeReminderOption = Convert.ToBoolean((int) registryKey.GetValue("showTimeReminder", 0));
            WarnOnEmptyNotesOption = Convert.ToBoolean((int) registryKey.GetValue("warnOnEmptyNotes", 1));
            ResetProjectOnSubmitOption = Convert.ToBoolean((int) registryKey.GetValue("resetProjectOnSubmit", 1));
            DisplayTimeHoursMinutesOption = Convert.ToBoolean((int) registryKey.GetValue("displayTimeHoursMinutes", 1));

            ShowInTaskbar = ShowInTaskbarOption;
        }

        private void mainForm_Shown(object sender, EventArgs e)
        {
            readPreferences();

            updateProjects();
        }

        public static string ReadPassword(RegistryKey registryKey)
        {
            try
            {
                byte[] entropy = {0x01, 0x02, 0x03, 0x05, 0x07, 0x11};
                byte[] protectedSecret = Convert.FromBase64String(registryKey.GetValue("password", string.Empty).ToString());
                byte[] secret = ProtectedData.Unprotect(protectedSecret, entropy, DataProtectionScope.CurrentUser);

                return Encoding.Unicode.GetString(secret);
            }
            catch (CryptographicException cryptographicException)
            {
                Console.WriteLine(cryptographicException);

                return null;
            }
        }

        private void taskTimer_Tick(object sender, EventArgs e)
        {
            _elapsed = (DateTime.Now - _start) + Modifier;

            timeLinkLabel.Text = DisplayTimeHoursMinutesOption ? regularFormatTime(_elapsed) : fuzzyFormatTime(_elapsed.TotalSeconds);

            if (ShowTimeReminderOption && (int) _elapsed.TotalMinutes/10 > _balloonTipCount)
            {
                _balloonTipCount++;

                tempoTrackerNotifyIcon.ShowBalloonTip(5000, "Time update", string.Format("You've now worked {0}.", regularFormatTime(_elapsed)), ToolTipIcon.Info);
            }
        }

        private static string fuzzyFormatTime(double seconds)
        {
            if (seconds < 60)
            {
                return string.Format("{0:N0} seconds", Math.Round(seconds, 0));
            }

            if (seconds < 3600)
            {
                return string.Format("{0:N2} minutes", Math.Round(seconds/60, 2));
            }

            return string.Format("{0:N3} hours", Math.Round(seconds/3600, 3));
        }

        private static string regularFormatTime(TimeSpan timeSpan)
        {
            DateTime dateTime = DateTime.MinValue.Add(timeSpan);

            return dateTime.ToString("H:mm:ss");
        }

        private void sendManualEntryButton_Click(object sender, EventArgs e)
        {
            if (!validateManualEntry())
            {
                return;
            }

            Project p = (Project) projectsComboBox.SelectedItem;

            if (createEvent(hoursNumericUpDown.Value, notesTextBox.Text.Trim(), manualEntryDateTimePicker.Value, p.Id, Tags.Text.Trim()))
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

        private bool validateTimerEntry()
        {
            bool status = true;

            if (WarnOnEmptyNotesOption)
            {
                if (string.IsNullOrEmpty(notesTextBox.Text))
                {
                    DialogResult dialogResult = MessageBox.Show("Do you want to submit time without a note? It may be hard to remember what you worked on later!", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (dialogResult == DialogResult.No)
                    {
                        status = false;
                    }
                }
            }

            if (projectsComboBox.SelectedItem.ToString() == "Select project...")
            {
                MessageBox.Show("Please make sure that you have selected a project.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                status = false;
            }

            if (Math.Round((Decimal) _elapsed.TotalHours, 2) == 0)
            {
                MessageBox.Show("Please make sure that you have entered a valid time in the hours field.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                status = false;
            }

            return status;
        }

        private bool validateManualEntry()
        {
            bool status = true;

            if (WarnOnEmptyNotesOption)
            {
                if (String.IsNullOrEmpty(notesTextBox.Text))
                {
                    DialogResult dialogResult = MessageBox.Show("Do you want to submit time without a note? It may be hard to remember what you worked on later!", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (dialogResult == DialogResult.No)
                    {
                        status = false;
                    }
                }
            }

            if (projectsComboBox.SelectedItem.ToString() == "Select project...")
            {
                MessageBox.Show("Please make sure that you have selected a project.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                status = false;
            }

            if (hoursNumericUpDown.Value == 0)
            {
                MessageBox.Show("Please make sure that you have entered a valid time in the hours field.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                status = false;
            }

            return status;
        }

        private void sendTimerEntryButton_Click(object sender, EventArgs e)
        {
            if (!validateTimerEntry())
            {
                return;
            }

            sendTimerEntryButton.Enabled = false;

            Project project = (Project) projectsComboBox.SelectedItem;

            if (createEvent(Math.Round((Decimal) _elapsed.TotalHours, 2), notesTextBox.Text.Trim(), Date, project.Id, Tags.Text.Trim()))
            {
                toolStripStatusLabel1.Text = "Successfully created the event.";

                _paused = false;
                taskTimer.Enabled = false;
                timerPlayPauseButton.Image = Resources.control_play;
                notesTextBox.Text = string.Empty;
                timeLinkLabel.Text = string.Empty;

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
            DateTimeEditForm dateTimeEditForm = new DateTimeEditForm(_elapsed, Date);

            if (dateTimeEditForm.ShowDialog(this) == DialogResult.OK)
            {
                _start = DateTime.Now;
                _elapsed = new TimeSpan();

                taskTimer_Tick(sender, e);
            }
        }

        private void timerPlayPauseButton_Click(object sender, EventArgs e)
        {
            // Since the status message is never cleared as a temp fix clear it here
            toolStripStatusLabel1.Text = "";

            // Pause button clicked while timer running
            if (taskTimer.Enabled)
            {
                _paused = true;
                Modifier = _elapsed;

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

                    _balloonTipCount = 0;
                    Date = DateTime.Today;
                    _start = DateTime.Now;
                    Modifier = new TimeSpan();

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
            OptionsForm optionsForm1 = new OptionsForm();

            if (optionsForm1.ShowDialog(this) == DialogResult.OK)
            {
                readPreferences();
            }
        }

        private void mainForm_DoubleClick(object sender, EventArgs e)
        {
            AboutBox aboutBox = new AboutBox();

            aboutBox.ShowDialog();
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
            Id = id;
            Name = name;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}