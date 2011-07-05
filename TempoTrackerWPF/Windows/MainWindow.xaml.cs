using System;
using System.Net;
using System.Timers;
using System.Windows;
using System.Windows.Input;

using Point = System.Drawing.Point;

using TempoTrackerApi;
using TempoTrackerWPF.Utilities;

namespace TempoTrackerWPF.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            _taskTimer = new Timer();
            _statusTimer = new Timer();

            _statusTimer.Elapsed += statusTimer_Tick;
            _taskTimer.Elapsed += taskTimer_Tick;
        }

        #region Locals

        private int _balloonTipCount;

        private TimeSpan _elapsed;
        private string _password;

        private bool _paused;
        private DateTime _start;
        private string _username;

        private TempoTracker _tempoTracker;

        private readonly Properties.Settings _settings = Properties.Settings.Default;

        private readonly Timer _taskTimer;
        private readonly Timer _statusTimer;

        #endregion

        #region Properties

        public TimeSpan Modifier { get; set; }
        public DateTime Date { get; set; }

        #endregion

        private void refreshButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateProjects();
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
            _username = _settings.ServiceUsername;
            _password = _settings.ServicePassword;
            
            _tempoTracker = new TempoTracker(_username, _password, Properties.Settings.Default.CustomApiUrl);

            if (string.IsNullOrEmpty(_username) || string.IsNullOrEmpty(_password) || string.IsNullOrEmpty(Properties.Settings.Default.CustomApiUrl))
            {
                var optionsWindow = new OptionsWindow();

                var result = optionsWindow.ShowDialog(this);

                if (result.HasValue && !result.Value)
                {
                    MessageBox.Show("Please configure API information.", TempoTrackerWPF.Resources.Language.Error, MessageBoxButton.OK, MessageBoxImage.Error);
                }

                ReadPreferences();
            }
            
            ShowInTaskbar = _settings.ShowInTaskbar;

            // Handle notify icon preferences
            //tempoTrackerNotifyIcon.Visible = _settings.NotifyShow;
        }

        private void taskTimer_Tick(object sender, EventArgs e)
        {
            _elapsed = (DateTime.Now - _start) + Modifier;

            timeLinkLabel.Content = _settings.DisplayTimeHoursMinutes ? Time.Format(_elapsed) : Time.FuzzyFormat(_elapsed.TotalSeconds);

            if (_settings.ShowTimeReminder && (int)_elapsed.TotalMinutes / 10 > _balloonTipCount)
            {
                _balloonTipCount++;

                //tempoTrackerNotifyIcon.ShowBalloonTip(5000, "Time update", string.Format("You've now worked {0}.", Time.Format(_elapsed)), ToolTipIcon.Info);
            }
        }

        private void sendManualEntryButton_Click(object sender, EventArgs e)
        {
            if (!ValidateManualEntry())
            {
                return;
            }

            var project = (Project)projectsComboBox.SelectedItem;

            if (hoursDecimalUpDown.Value.HasValue && _tempoTracker.CreateEntry(manualEntryDatePicker.SelectedDate.Value, hoursDecimalUpDown.Value.Value, notesTextBox.Text.Trim(), project.Id, tagsTextBox.Text.Trim()).StatusCode == HttpStatusCode.Created)
            {
                toolBarStatusTextBlock.Text = TempoTrackerWPF.Resources.Language.SuccessfullyCreateEvent;

                _statusTimer.Enabled = true;

                if (_settings.ClearProject)
                {
                    projectsComboBox.SelectedIndex = projectsComboBox.Items.IndexOf("Select project...");
                }

                // Reset form for next submission
                ClearForm();
            }
            else
            {
                MessageBox.Show(TempoTrackerWPF.Resources.Language.UnableToCreateEvent, TempoTrackerWPF.Resources.Language.Error, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool ValidateTimerEntry()
        {
            bool status = true;

            if (_settings.WarnOnEmptyNotes)
            {
                if (string.IsNullOrEmpty(notesTextBox.Text))
                {
                    var result = MessageBox.Show("Do you want to submit time without a note? It may be hard to remember what you worked on later!", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question);

                    if (result == MessageBoxResult.No)
                    {
                        status = false;
                    }
                }
            }

            if (projectsComboBox.SelectedItem.ToString() == "Select project...")
            {
                MessageBox.Show("Please make sure that you have selected a project.", TempoTrackerWPF.Resources.Language.Error, MessageBoxButton.OK, MessageBoxImage.Stop);

                status = false;
            }

            if (_elapsed.Minutes < 1)
            {
                MessageBox.Show("Please make sure you've completed at least 1 minute of work.", TempoTrackerWPF.Resources.Language.Error, MessageBoxButton.OK, MessageBoxImage.Stop);

                status = false;
            }

            return status;
        }

        private bool ValidateManualEntry()
        {
            bool status = true;

            if (_settings.WarnOnEmptyNotes)
            {
                if (String.IsNullOrEmpty(notesTextBox.Text))
                {
                    var result = MessageBox.Show("Do you want to submit time without a note? It may be hard to remember what you worked on later!", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question);

                    if (result == MessageBoxResult.No)
                    {
                        status = false;
                    }
                }
            }

            if (projectsComboBox.SelectedItem.ToString() == "Select project...")
            {
                MessageBox.Show("Please make sure that you have selected a project.", TempoTrackerWPF.Resources.Language.Error, MessageBoxButton.OK, MessageBoxImage.Stop);

                status = false;
            }

            if (!manualEntryDatePicker.SelectedDate.HasValue)
            {
                MessageBox.Show("Please make sure that you have entered a valid date.", TempoTrackerWPF.Resources.Language.Error, MessageBoxButton.OK, MessageBoxImage.Stop);

                status = false;
            }

            if (hoursDecimalUpDown.Value.HasValue &&
                hoursDecimalUpDown.Value.Value == 0)
            {
                MessageBox.Show("Please make sure that you have entered a valid time in the hours field.", TempoTrackerWPF.Resources.Language.Error, MessageBoxButton.OK, MessageBoxImage.Stop);

                status = false;
            }

            return status;
        }

        private void sendTimerEntryButton_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidateTimerEntry())
            {
                return;
            }

            sendTimerEntryButton.IsEnabled = false;

            var project = (Project)projectsComboBox.SelectedItem;

            if (_tempoTracker.CreateEntry(Date, Math.Round((Decimal)_elapsed.TotalHours, 2), notesTextBox.Text.Trim(), project.Id, tagsTextBox.Text.Trim()).StatusCode == HttpStatusCode.Created)
            {
                toolBarStatusTextBlock.Text = TempoTrackerWPF.Resources.Language.SuccessfullyCreateEvent;

                _paused = false;
                _taskTimer.Enabled = false;
                //timerPlayPauseButton.Image = TempoTrackerWPF.Resources.Images.control_play;
                notesTextBox.Text = string.Empty;
                timeLinkLabel.Content = string.Empty;

                if (_settings.ClearProject)
                {
                    projectsComboBox.SelectedIndex = projectsComboBox.Items.IndexOf("Select project...");
                }

                // reset form for next submission
                ClearForm();

            }
            else
            {
                MessageBox.Show(TempoTrackerWPF.Resources.Language.UnableToCreateEvent, TempoTrackerWPF.Resources.Language.Error, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void timeLinkLabel_LinkClicked(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton != MouseButtonState.Pressed)
            {
                return;
            }

            var dateTimeEditForm = new DateEditDialog(_elapsed, Date);

            var result = dateTimeEditForm.ShowDialog(this);

            if (result.HasValue && !result.Value)
            {
                return;
            }

            _start = DateTime.Now;
            _elapsed = new TimeSpan();

            taskTimer_Tick(sender, e);
        }

        private void timerPlayPauseButton_Click(object sender, RoutedEventArgs e)
        {
            // Pause button clicked while timer running
            if (_taskTimer.Enabled)
            {
                _paused = true;
                Modifier = _elapsed;

                //timerPlayPauseButton.Image = TempoTrackerWPF.Resources.Images.control_play;

                _taskTimer.Enabled = false;
            }
            // Play button clicked...
            else
            {
                // ... while paused
                if (_paused)
                {
                    _paused = false;
                    _start = DateTime.Now;

                    //timerPlayPauseButton.Image = TempoTrackerWPF.Resources.Images.control_pause;

                    _taskTimer.Enabled = true;
                }
                // ... to start the timer for the first time
                else
                {
                    _paused = false;
                    _start = DateTime.Now;
                    _balloonTipCount = 0;

                    _taskTimer.Enabled = true;
                    sendTimerEntryButton.IsEnabled = true;
                    timerStopButton.IsEnabled = true;

                    //timerPlayPauseButton.Image = TempoTrackerWPF.Resources.Images.control_pause;

                    Date = DateTime.Today;
                    Modifier = new TimeSpan();
                }
            }
        }

        private void ClearForm()
        {
            // Reset form after submissions
            tagsTextBox.Text = string.Empty;
            notesTextBox.Text = string.Empty;
            hoursDecimalUpDown.Value = 0;
        }

        private void timerStopButton_Click(object sender, RoutedEventArgs e)
        {
            _paused = false;

            //timerPlayPauseButton.Image = TempoTrackerWPF.Resources.Images.control_play;
            timerStopButton.IsEnabled = false;

            _taskTimer.Enabled = false;
        }

        private void optionsButton_Click(object sender, RoutedEventArgs e)
        {
            var optionsWindow = new OptionsWindow();

            var result = optionsWindow.ShowDialog(this);
            
            if (result.HasValue && result.Value)
            {
                ReadPreferences();
            }
        }

        //private void tempoTrackerNotifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        //{
        //    Visibility = Visibility == Visibility.Visible ? Visibility.Hidden : Visibility.Visible;

        //    WindowState = WindowState.Normal;
        //}

        private void statusTimer_Tick(object sender, EventArgs e)
        {
            toolBarStatusTextBlock.Text = string.Empty;

            _statusTimer.Enabled = false;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // Save current X/Y position
            _settings.MainWindowXY = new Point((int)Left, (int)Top);
            _settings.Save();
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (WindowState == WindowState.Minimized && _settings.NotifyMinimize)
            {
                Visibility = Visibility == Visibility.Visible ? Visibility.Hidden : Visibility.Visible;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Check to see if previously saved windows position exists, if so, move the form.
            if (_settings.MainWindowXY.X != 0 && _settings.MainWindowXY.Y != 0)
            {
                Left = _settings.MainWindowXY.X;
                Top = _settings.MainWindowXY.Y;
            }

            ReadPreferences();

            UpdateProjects();
        }
    }
}