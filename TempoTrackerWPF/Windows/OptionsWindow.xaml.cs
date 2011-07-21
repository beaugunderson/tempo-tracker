using System.Windows;

namespace TempoTrackerWPF.Windows
{
    /// <summary>
    /// Interaction logic for OptionsWindow.xaml
    /// </summary>
    public partial class OptionsWindow
    {
        private MainWindow MainWindow { get; set; }

        public OptionsWindow()
        {
            InitializeComponent();
        }

        public OptionsWindow(MainWindow mainWindow)
        {
            InitializeComponent();

            MainWindow = mainWindow;
        }

        // Application settings object
        private readonly Properties.Settings _settings = Properties.Settings.Default;

        private bool FormVerified()
        {
            if (string.IsNullOrEmpty(usernameTextBox.Text) || string.IsNullOrEmpty(passwordTextBox.Text) || serviceApiComboBox.SelectedIndex < 0)
            {
                MessageBox.Show("Please enter a username and password, and select an API", "Error", MessageBoxButton.OK, MessageBoxImage.Stop);

                return false;
            }

            // Verify the user has modified the custom api url
            if (apiUrlTextBox.Text == _settings.ApiKeepTempo ||
                apiUrlTextBox.Text == _settings.ApiFreckle ||
                apiUrlTextBox.Text == _settings.ApiFreshbooks ||
                apiUrlTextBox.Text == _settings.ApiKlok)
            {
                MessageBox.Show("Please enter your custom API URL.", "Error", MessageBoxButton.OK, MessageBoxImage.Stop);

                return false;
            }

            // Verification succesful
            return true;
        }

        private void notifyIconSanitation()
        {
            // Do not allow the user to minimize application to try but hide the tray icon
            if (!showNotifyIconCheckBox.IsChecked.GetValueOrDefault())
            {
                minimizeToTrayCheckBox.IsChecked = false;
                minimizeToTrayCheckBox.IsEnabled = false;
            }
            else
            {
                minimizeToTrayCheckBox.IsEnabled = true;
            }
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            // Verify form, if something doesn't verify, fail out
            if (!FormVerified())
            {
                return;
            }

            // TODO: Replace all of this with bindings
            // Save preferences
            _settings.ServiceUsername = usernameTextBox.Text;
            _settings.ServicePassword = passwordTextBox.Text;
            
            _settings.ShowInTaskbar = showInTaskbarCheckBox.IsChecked.GetValueOrDefault();
            _settings.ShowTimeReminder = showTimeReminderCheckBox.IsChecked.GetValueOrDefault();
            _settings.WarnOnEmptyNotes = warnOnEmptyNotesCheckBox.IsChecked.GetValueOrDefault();
            _settings.DisplayTimeHoursMinutes = displayTimeHoursMinutesCheckBox.IsChecked.GetValueOrDefault();
            _settings.NotifyShow = showNotifyIconCheckBox.IsChecked.GetValueOrDefault();
            _settings.NotifyMinimize = minimizeToTrayCheckBox.IsChecked.GetValueOrDefault();
            _settings.ClearProject = resetProjectOnSubmitCheckBox.IsChecked.GetValueOrDefault();
            _settings.ReminderTime = reminderTimeIntegerUpDown.Value.GetValueOrDefault();
            _settings.IdleTimeout = idleTimeoutCheckBox.IsChecked.GetValueOrDefault();
            _settings.IdleTime = idleTimeIntegerUpDown.Value.GetValueOrDefault();

            // Save Service API / Custom URL
            _settings.ServiceApi = serviceApiComboBox.SelectedItem.ToString();
            _settings.CustomApiUrl = apiUrlTextBox.Text;
            _settings.Save();

            DialogResult = true;

            Close();
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;

            Close();
        }

        private void showIconCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            notifyIconSanitation();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // TODO: Replace all of this with bindings
            usernameTextBox.Text = _settings.ServiceUsername;
            passwordTextBox.Text = _settings.ServicePassword;
            
            showInTaskbarCheckBox.IsChecked = _settings.ShowInTaskbar;
            showTimeReminderCheckBox.IsChecked = _settings.ShowTimeReminder;
            warnOnEmptyNotesCheckBox.IsChecked = _settings.WarnOnEmptyNotes;
            displayTimeHoursMinutesCheckBox.IsChecked = _settings.DisplayTimeHoursMinutes;
            resetProjectOnSubmitCheckBox.IsChecked = _settings.ClearProject;
            showNotifyIconCheckBox.IsChecked = _settings.NotifyShow;
            minimizeToTrayCheckBox.IsEnabled = _settings.NotifyShow;
            minimizeToTrayCheckBox.IsChecked = _settings.NotifyMinimize;
            reminderTimeIntegerUpDown.Value = _settings.ReminderTime;
            idleTimeoutCheckBox.IsChecked = _settings.IdleTimeout;
            idleTimeIntegerUpDown.Value = _settings.IdleTime;

            // Load API settings 
            if (string.IsNullOrEmpty(_settings.ServiceApi) == false)
            {
                serviceApiComboBox.SelectedItem = _settings.ServiceApi;
                apiUrlTextBox.Text = _settings.CustomApiUrl;
            }
        }

        private void serviceApiComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            switch (serviceApiComboBox.SelectedItem.ToString())
            {
                case "Keep Tempo":
                    apiUrlTextBox.Text = _settings.ApiKeepTempo;
                    break;
                case "Freshbooks":
                    apiUrlTextBox.Text = _settings.ApiFreshbooks;
                    break;
                case "Freckle":
                    apiUrlTextBox.Text = _settings.ApiFreckle;
                    break;
                case "Klok":
                    apiUrlTextBox.Text = _settings.ApiKlok;
                    break;
            }

            if (serviceApiComboBox.SelectedIndex >= 0)
            {
                usernameTextBox.IsEnabled = true;
                passwordTextBox.IsEnabled = true;
                apiUrlTextBox.IsEnabled = true;
            }
        }
    }
}