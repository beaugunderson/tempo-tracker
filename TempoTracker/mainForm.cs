﻿using System;
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
        private const string _apiUrl = "https://app.keeptempo.com";

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

        private bool createEvent(decimal hours, string notes, DateTime dateTime, int id)
        {
            string eventXml = string.Format("<?xml version=\"1.0\" encoding=\"UTF-8\"?><entry><hours type=\"decimal\">{0:N2}</hours><notes>{1:S}</notes><project-id type=\"integer\">{2:G}</project-id><occurred-on type=\"datetime\">{3:s}</occurred-on></entry>", hours, notes, id, dateTime);

            string url = string.Format("{0}/entries", _apiUrl);

            var webRequest = WebRequest.Create(url) as HttpWebRequest;

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

                // ReSharper disable PossibleNullReferenceException
                var sr = new StreamReader(webResponse.GetResponseStream());
                // ReSharper restore PossibleNullReferenceException

                try
                {
                    XmlReader xmlReader = XmlReader.Create(sr);

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
                    Console.WriteLine(sr.ReadToEnd());
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
            string url = string.Format("{0}/projects", _apiUrl);

            var webRequest = WebRequest.Create(url) as HttpWebRequest;

            webRequest.AllowAutoRedirect = false;
            webRequest.UserAgent = "TempoTracker.NET";
            webRequest.Method = "GET";
            webRequest.Credentials = new NetworkCredential(_username, _password);
            webRequest.Accept = "application/xml";
            webRequest.ContentType = "application/xml";

            var webResponse = webRequest.GetResponse() as HttpWebResponse;
            var streamReader = new StreamReader(webResponse.GetResponseStream());

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

                var p = new Project(id, name);

                projectsComboBox.Items.Add(p);
            }

            projectsComboBox.SelectedIndex = projectsComboBox.Items.IndexOf("Select project...");
        }

        private void readPreferences()
        {
            RegistryKey registryKey = Application.UserAppDataRegistry;

            // ReSharper disable PossibleNullReferenceException
            _username = registryKey.GetValue("username", "").ToString();
            // ReSharper restore PossibleNullReferenceException
            _password = ReadPassword(registryKey);

            if (string.IsNullOrEmpty(_username) || string.IsNullOrEmpty(_password))
            {
                var optionsForm = new optionsForm();

                if (optionsForm.ShowDialog(this) != DialogResult.OK)
                {
                    MessageBox.Show("You must set a username and password to continue.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                readPreferences();
            }

            ShowInTaskbarOption = Convert.ToBoolean((int)registryKey.GetValue("showInTaskbar", 1));
            ShowTimeReminderOption = Convert.ToBoolean((int)registryKey.GetValue("showTimeReminder", 0));
            WarnOnEmptyNotesOption = Convert.ToBoolean((int)registryKey.GetValue("warnOnEmptyNotes", 1));
            ResetProjectOnSubmitOption = Convert.ToBoolean((int)registryKey.GetValue("resetProjectOnSubmit", 1));

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
            _elapsed = (DateTime.Now - _start) + Modifier;

            timeLinkLabel.Text = fuzzyFormatTime(_elapsed.TotalSeconds);
        }

        private static string fuzzyFormatTime(double seconds)
        {
            if (seconds < 60)
            {
                return string.Format("{0:N0} seconds", Math.Round(seconds, 0));
            }

            if (seconds < 3600)
            {
                return string.Format("{0:N2} minutes", Math.Round(seconds / 60, 2));
            }

            return string.Format("{0:N3} hours", Math.Round(seconds / 3600, 3));
        }

        private void sendManualEntryButton_Click(object sender, EventArgs e)
        {
            if (!validateManualEntry())
            {
                return;
            }

            var p = (Project)projectsComboBox.SelectedItem;

            if (createEvent(hoursNumericUpDown.Value, notesTextBox.Text, manualEntryDateTimePicker.Value, p.Id))
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
                    DialogResult dialogResult = MessageBox.Show(
                            "Do you want to submit time without a note? It may be hard to remember what you worked on later!",
                            "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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

            if (Math.Round((Decimal)_elapsed.TotalHours, 2) == 0)
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
                    DialogResult dialogResult =
                        MessageBox.Show(
                            "Do you want to submit time without a note? It may be hard to remember what you worked on later!",
                            "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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

            var project = (Project)projectsComboBox.SelectedItem;

            if (createEvent(Math.Round((Decimal)_elapsed.TotalHours, 2), notesTextBox.Text, Date, project.Id))
            {
                toolStripStatusLabel1.Text = "Successfully created the event.";

                _paused = false;
                taskTimer.Enabled = false;
                timerPlayPauseButton.Image = Resources.control_play;
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
            var fdte = new dateTimeEditForm(_elapsed, Date);

            if (fdte.ShowDialog(this) == DialogResult.OK)
            {
                _start = DateTime.Now;
                _elapsed = new TimeSpan();

                taskTimer_Tick(sender, e);
            }
        }

        private void timerPlayPauseButton_Click(object sender, EventArgs e)
        {
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
            var optionsForm1 = new optionsForm();

            if (optionsForm1.ShowDialog(this) == DialogResult.OK)
            {
                readPreferences();
            }
        }

        private void mainForm_DoubleClick(object sender, EventArgs e)
        {
            var aboutBox = new AboutBox();

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