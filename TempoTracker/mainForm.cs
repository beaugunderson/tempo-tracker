using System;
using System.Drawing;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

using Microsoft.Win32;

using TempoTracker.Utilities;
using TempoTrackerApi;

namespace TempoTracker
{
    public partial class MainForm : Form
    {
        #region Locals

        private int _balloonTipCount;

        private TimeSpan _elapsed;
        private string _password;

        private bool _paused;
        private DateTime _start;
        private string _username;

        private TempoTrackerApi.TempoTracker _tempoTracker;
        
        #endregion

        #region Properties

        public TimeSpan Modifier { get; set; }
        public DateTime Date { get; set; }

        public bool WarnOnEmptyNotesOption { get; private set; }
        public bool ShowTimeReminderOption { get; private set; }
        public bool ShowInTaskbarOption { get; private set; }
        public bool ResetProjectOnSubmitOption { get; private set; }
        public bool DisplayTimeHoursMinutesOption { get; private set; }

        #endregion

        public MainForm()
        {
            InitializeComponent();
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            UpdateProjects();
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            projectsComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void UpdateProjects()
        {
            projectsComboBox.Items.Clear();
            projectsComboBox.Items.Add("Select project...");

            var projects = _tempoTracker.GetProjects();

            if (projects == null)
            {
                return;
            }

            foreach (var project in projects)
            {
                projectsComboBox.Items.Add(project);
            }

            projectsComboBox.SelectedIndex = projectsComboBox.Items.IndexOf("Select project...");
        }

        private void ReadPreferences()
        {
            var registryKey = Application.UserAppDataRegistry;

            if (registryKey == null)
            {
                MessageBox.Show("There was an error reading the user registry.", Resources.Language.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            _username = registryKey.GetValue("username", string.Empty).ToString();
            _password = ReadPassword(registryKey);

            _tempoTracker = new TempoTrackerApi.TempoTracker(_username, _password, Properties.Settings.Default.CustomApiUrl);

            if (string.IsNullOrEmpty(_username) || string.IsNullOrEmpty(_password) || string.IsNullOrEmpty(Properties.Settings.Default.CustomApiUrl))
            {
                var optionsForm = new OptionsForm();

                if (optionsForm.ShowDialog(this) != DialogResult.OK)
                {
                    MessageBox.Show("Please configure API information.", Resources.Language.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                ReadPreferences();
            }

            ShowInTaskbarOption = Convert.ToBoolean((int)registryKey.GetValue("showInTaskbar", 1));
            ShowTimeReminderOption = Convert.ToBoolean((int)registryKey.GetValue("showTimeReminder", 0));
            WarnOnEmptyNotesOption = Convert.ToBoolean((int)registryKey.GetValue("warnOnEmptyNotes", 1));
            ResetProjectOnSubmitOption = Convert.ToBoolean((int)registryKey.GetValue("resetProjectOnSubmit", 1));
            DisplayTimeHoursMinutesOption = Convert.ToBoolean((int)registryKey.GetValue("displayTimeHoursMinutes", 1));

            ShowInTaskbar = ShowInTaskbarOption;
        }

        private void mainForm_Shown(object sender, EventArgs e)
        {
            // Check to see if previously saved windows position exists, if so, move the form.
            if (Properties.Settings.Default.MainWindowXY.X != 0 && Properties.Settings.Default.MainWindowXY.Y != 0)
            {
                Location = Properties.Settings.Default.MainWindowXY;
            }

            ReadPreferences();

            UpdateProjects();
        }

        private static string ReadPassword(RegistryKey registryKey)
        {
            try
            {
                byte[] entropy = { 0x01, 0x02, 0x03, 0x05, 0x07, 0x11 };
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

            timeLinkLabel.Text = DisplayTimeHoursMinutesOption ? Time.Format(_elapsed) : Time.FuzzyFormat(_elapsed.TotalSeconds);

            if (ShowTimeReminderOption && (int)_elapsed.TotalMinutes / 10 > _balloonTipCount)
            {
                _balloonTipCount++;

                tempoTrackerNotifyIcon.ShowBalloonTip(5000, "Time update", string.Format("You've now worked {0}.", Time.Format(_elapsed)), ToolTipIcon.Info);
            }
        }

        private void sendManualEntryButton_Click(object sender, EventArgs e)
        {
            if (!ValidateManualEntry())
            {
                return;
            }

            var project = (Project)projectsComboBox.SelectedItem;

            if (_tempoTracker.CreateEntry(manualEntryDateTimePicker.Value, hoursNumericUpDown.Value, notesTextBox.Text.Trim(), project.Id, Tags.Text.Trim()).StatusCode == HttpStatusCode.Created)
            {
                toolStripStatusLabel1.Text = Resources.Language.SuccessfullyCreateEvent;

                if (ResetProjectOnSubmitOption)
                {
                    projectsComboBox.SelectedIndex = projectsComboBox.Items.IndexOf("Select project...");
                }
            }
            else
            {
                MessageBox.Show(Resources.Language.UnableToCreateEvent, Resources.Language.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateTimerEntry()
        {
            bool status = true;

            if (WarnOnEmptyNotesOption)
            {
                if (string.IsNullOrEmpty(notesTextBox.Text))
                {
                    var result = MessageBox.Show("Do you want to submit time without a note? It may be hard to remember what you worked on later!", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.No)
                    {
                        status = false;
                    }
                }
            }

            if (projectsComboBox.SelectedItem.ToString() == "Select project...")
            {
                MessageBox.Show("Please make sure that you have selected a project.", Resources.Language.Error, MessageBoxButtons.OK, MessageBoxIcon.Stop);

                status = false;
            }

            if (_elapsed.Minutes < 1)
            {
                MessageBox.Show("Please make sure you've completed at least 1 minute of work.", Resources.Language.Error, MessageBoxButtons.OK, MessageBoxIcon.Stop);

                status = false;
            }

            return status;
        }

        private bool ValidateManualEntry()
        {
            bool status = true;

            if (WarnOnEmptyNotesOption)
            {
                if (String.IsNullOrEmpty(notesTextBox.Text))
                {
                    var result = MessageBox.Show("Do you want to submit time without a note? It may be hard to remember what you worked on later!", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.No)
                    {
                        status = false;
                    }
                }
            }

            if (projectsComboBox.SelectedItem.ToString() == "Select project...")
            {
                MessageBox.Show("Please make sure that you have selected a project.", Resources.Language.Error, MessageBoxButtons.OK, MessageBoxIcon.Stop);

                status = false;
            }

            if (hoursNumericUpDown.Value == 0)
            {
                MessageBox.Show("Please make sure that you have entered a valid time in the hours field.", Resources.Language.Error, MessageBoxButtons.OK, MessageBoxIcon.Stop);

                status = false;
            }

            return status;
        }

        private void sendTimerEntryButton_Click(object sender, EventArgs e)
        {
            if (!ValidateTimerEntry())
            {
                return;
            }

            sendTimerEntryButton.Enabled = false;

            var project = (Project)projectsComboBox.SelectedItem;

            if (_tempoTracker.CreateEntry(Date, Math.Round((Decimal)_elapsed.TotalHours, 2), notesTextBox.Text.Trim(), project.Id, Tags.Text.Trim()).StatusCode == HttpStatusCode.Created)
            {
                toolStripStatusLabel1.Text = Resources.Language.SuccessfullyCreateEvent;

                _paused = false;
                taskTimer.Enabled = false;
                timerPlayPauseButton.Image = Resources.Images.control_play;
                notesTextBox.Text = string.Empty;
                timeLinkLabel.Text = string.Empty;

                if (ResetProjectOnSubmitOption)
                {
                    projectsComboBox.SelectedIndex = projectsComboBox.Items.IndexOf("Select project...");
                }
            }
            else
            {
                MessageBox.Show(Resources.Language.UnableToCreateEvent, Resources.Language.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void timeLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var dateTimeEditForm = new DateTimeEditForm(_elapsed, Date);

            if (dateTimeEditForm.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }

            _start = DateTime.Now;
            _elapsed = new TimeSpan();

            taskTimer_Tick(sender, e);
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

                timerPlayPauseButton.Image = Resources.Images.control_play;

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

                    timerPlayPauseButton.Image = Resources.Images.control_pause;

                    taskTimer.Enabled = true;
                }
                // ... to start the timer for the first time
                else
                {
                    _paused = false;
                    _start = DateTime.Now;
                    _balloonTipCount = 0;

                    sendTimerEntryButton.Enabled = true;
                    taskTimer.Enabled = true;
                    timerStopButton.Enabled = true;

                    timerPlayPauseButton.Image = Resources.Images.control_pause;

                    Date = DateTime.Today;
                    Modifier = new TimeSpan();
                }
            }
        }

        private void timerStopButton_Click(object sender, EventArgs e)
        {
            _paused = false;

            timerPlayPauseButton.Image = Resources.Images.control_play;
            timerStopButton.Enabled = false;

            taskTimer.Enabled = false;
        }

        private void optionsButton_Click(object sender, EventArgs e)
        {
            var optionsForm = new OptionsForm();

            if (optionsForm.ShowDialog(this) == DialogResult.OK)
            {
                ReadPreferences();
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

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Save current X/Y position
            Properties.Settings.Default.MainWindowXY = new Point(Location.X, Location.Y);
            Properties.Settings.Default.Save();
        }
    }
}