﻿using System;
using System.Drawing;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

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
        private string _username;

        private bool _paused;
        private DateTime _start;

        // Mouse idle handling
        private Point _oldMousePosition = new Point(0,0);
        private int _totalIdleTime;
        
        private TempoTrackerApi.TempoTracker _tempoTracker;
        private Properties.Settings AppSettings = Properties.Settings.Default;
        
        #endregion

        #region Properties

        public TimeSpan Modifier { get; set; }
        public DateTime Date { get; set; }


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
            _username = AppSettings.serviceUsername;
            _password = AppSettings.servicePassword;

            _tempoTracker = new TempoTrackerApi.TempoTracker(_username, _password,
                                                             Properties.Settings.Default.CustomApiUrl);

            if (string.IsNullOrEmpty(_username) || string.IsNullOrEmpty(_password) ||
                string.IsNullOrEmpty(Properties.Settings.Default.CustomApiUrl))
            {
                var optionsForm = new OptionsForm();

                if (optionsForm.ShowDialog(this) != DialogResult.OK)
                {
                    MessageBox.Show("Please configure API information.", Resources.Language.Error, MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }

                ReadPreferences();
            }


            // Reload preferences to ensure they're running latest settings
            ShowInTaskbar = AppSettings.perfShowInTaskbar;
            tempoTrackerNotifyIcon.Visible = AppSettings.notifyShow;

            // If idle timeout is set, jump out, otherwise disable the idle timer
            if (AppSettings.perfIdleTimeout) return;
            idleTimer.Enabled = false;
            idleTimer.Stop();
        }

        private void mainForm_Shown(object sender, EventArgs e)
        {
            // Check to see if previously saved windows position exists, if so, move the form.
            if (AppSettings.MainWindowXY.X != 0 && AppSettings.MainWindowXY.Y != 0)
            {
                var screenArea = new Point(SystemInformation.WorkingArea.Width, SystemInformation.WorkingArea.Height);
                // Check to see if new location is outside of the primary screen bounds
                if (AppSettings.MainWindowXY.X > screenArea.X || AppSettings.MainWindowXY.Y > screenArea.Y)
                {
                    CenterToScreen();
                }
                else
                {
                    Location = AppSettings.MainWindowXY;    
                }
            }

            ReadPreferences();
            UpdateProjects();
        }

        private void taskTimer_Tick(object sender, EventArgs e)
        {
            _elapsed = (DateTime.Now - _start) + Modifier;

            timeLinkLabel.Text = AppSettings.prefDisplayTimeHoursMinutes ? Time.Format(_elapsed) : Time.FuzzyFormat(_elapsed.TotalSeconds);

            if (AppSettings.perfShowTimeReminder && (int)_elapsed.TotalMinutes / AppSettings.perfReminderTime > _balloonTipCount)
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
                statusTimer.Enabled = true;


                if (AppSettings.prefClearProject)
                {
                    projectsComboBox.SelectedIndex = projectsComboBox.Items.IndexOf("Select project...");
                }

                // reset form for next submission
                SanatizeForm();
            }
            else
            {
                MessageBox.Show(Resources.Language.UnableToCreateEvent, Resources.Language.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateTimerEntry()
        {
            bool status = true;

            if (AppSettings.perfWarnOnEmptyNotes)
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

            if (AppSettings.perfWarnOnEmptyNotes)
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

                if (AppSettings.prefClearProject)
                {
                    projectsComboBox.SelectedIndex = projectsComboBox.Items.IndexOf("Select project...");
                }

                // reset form for next submission
                SanatizeForm();

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
            // Pause button clicked while timer running
            if (taskTimer.Enabled)
            {
                _paused = true;
                Modifier = _elapsed;

                timerPlayPauseButton.Image = Resources.Images.control_play;

                taskTimer.Enabled = false;
                idleTimer.Enabled = false;
                _totalIdleTime = 0;
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
                    if (AppSettings.perfIdleTimeout) idleTimer.Enabled = true;
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
                    if (AppSettings.perfIdleTimeout) idleTimer.Enabled = true;
                }
            }
        }


        private void SanatizeForm()
        {
            // Reset form after submissions
            Tags.Text = "";
            notesTextBox.Text = "";
            hoursNumericUpDown.Value = 0;

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
            WindowState = FormWindowState.Normal;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Save current X/Y position
            AppSettings.MainWindowXY = new Point(Location.X, Location.Y);
            AppSettings.Save();
        }

        private void statusTimer_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
            statusTimer.Enabled = false;

        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized && AppSettings.notifyMinimize)
            {
                Visible = !Visible;
            }
        }

        private void idleTimer_Tick(object sender, EventArgs e)
        {
            if (_oldMousePosition == MousePosition)
            {
                // increment how long system has been idle
                _totalIdleTime++;

                if (_totalIdleTime / 60 >= AppSettings.perfIdleTime)
                {
                    // Pause timer
                    timerPlayPauseButton_Click(sender, e);
                }
            }
            else
            {
                // Set new idle position
                _oldMousePosition = MousePosition;
                _totalIdleTime = 0;
            }
          
        }
    }
}