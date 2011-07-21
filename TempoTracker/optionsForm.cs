using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace TempoTracker
{
    public partial class OptionsForm : Form
    {
        public OptionsForm()
        {
            InitializeComponent();
        }

        // Application settings object
        private readonly Properties.Settings AppSettings = Properties.Settings.Default;

        private void optionsForm_Load(object sender, EventArgs e)
        {
            usernameTextBox.Text = AppSettings.serviceUsername;
            passwordTextBox.Text = AppSettings.servicePassword;
            showInTaskbarCheckBox.Checked = AppSettings.perfShowInTaskbar;
            showTimeReminderCheckBox.Checked = AppSettings.perfShowTimeReminder;
            ReminderTimeNumericBox.Value = AppSettings.perfReminderTime;
            PauseIfIdleCheckBox.Checked = AppSettings.perfIdleTimeout;
            IdleTimeoutNumericBox.Value = AppSettings.perfIdleTime;
            warnOnEmptyNotesCheckBox.Checked = AppSettings.perfWarnOnEmptyNotes;
            displayTimeHoursMinutesCheckbox.Checked = AppSettings.prefDisplayTimeHoursMinutes;
            resetProjectOnSubmitCheckBox.Checked = AppSettings.prefClearProject;
            showNotifyIconCheckBox.Checked = AppSettings.notifyShow;
            minimizeToTrayCheckBox.Enabled = AppSettings.notifyShow;
            minimizeToTrayCheckBox.Checked = AppSettings.notifyMinimize;
            
            // Load API settings 
            if (string.IsNullOrEmpty(AppSettings.ServiceApi) == false)
            {
                serviceApiCheckBox.SelectedItem = AppSettings.ServiceApi;
                apiUrlTextBox.Text = AppSettings.CustomApiUrl;
            }
        }

        private void serviceApiCheckBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (serviceApiCheckBox.SelectedItem.ToString())
                {
                    case "Keep Tempo":
                        apiUrlTextBox.Text = AppSettings.apiKeepTempo;
                        break;
                    case "Freshbooks":
                        apiUrlTextBox.Text = AppSettings.apiFreshbooks;
                        break;
                    case "Freckle":
                        apiUrlTextBox.Text = AppSettings.apiFreckle;
                        break;
                    case "Klok":
                        apiUrlTextBox.Text = AppSettings.apiKlok;
                        break;
                }
         
            if (serviceApiCheckBox.SelectedIndex >= 0)
            {
                usernameTextBox.Enabled = true;
                passwordTextBox.Enabled = true;
                apiUrlTextBox.Enabled = true;
            }
        }

        private bool FormVerified()
        {
            if (string.IsNullOrEmpty(usernameTextBox.Text) || string.IsNullOrEmpty(passwordTextBox.Text) || serviceApiCheckBox.SelectedIndex < 0)
            {
                MessageBox.Show("Please enter a username and password, and select an API", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                optionsTabControl.SelectedTab = serviceInfoTab;
                return false;
            } 
            
             // Verify the user has modified the custom api url
            if (apiUrlTextBox.Text == AppSettings.apiKeepTempo ||
                apiUrlTextBox.Text == AppSettings.apiFreckle ||
                apiUrlTextBox.Text == AppSettings.apiFreshbooks || 
                apiUrlTextBox.Text == AppSettings.apiKlok)
            {
                MessageBox.Show("Please enter your custom API URL.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                optionsTabControl.SelectedTab = serviceInfoTab;
                return false;
            }

            // Verification succesful
            return true;
        }

        
        private void saveButton_Click(object sender, EventArgs e)
        {
            // Verify form, if something doesn't verify, fail out
            if (!FormVerified()){ return;}

            // Save preferences
            AppSettings.serviceUsername = usernameTextBox.Text;
            AppSettings.servicePassword = passwordTextBox.Text;
            AppSettings.perfShowInTaskbar = showInTaskbarCheckBox.Checked;
            AppSettings.perfShowTimeReminder = showTimeReminderCheckBox.Checked;
            AppSettings.perfReminderTime = Convert.ToInt32(ReminderTimeNumericBox.Value);
            AppSettings.perfWarnOnEmptyNotes = warnOnEmptyNotesCheckBox.Checked;
            AppSettings.prefDisplayTimeHoursMinutes = displayTimeHoursMinutesCheckbox.Checked;
            AppSettings.perfIdleTimeout = PauseIfIdleCheckBox.Checked;
            AppSettings.perfIdleTime = Convert.ToInt32(IdleTimeoutNumericBox.Value);
            AppSettings.notifyShow = showNotifyIconCheckBox.Checked;
            AppSettings.notifyMinimize = minimizeToTrayCheckBox.Checked;
            AppSettings.prefClearProject = resetProjectOnSubmitCheckBox.Checked;
            
            // Save Service API / Custom URL
            AppSettings.ServiceApi = serviceApiCheckBox.SelectedItem.ToString();
            AppSettings.CustomApiUrl = apiUrlTextBox.Text;
            AppSettings.Save();

            DialogResult = DialogResult.OK;

            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;

            Close();
        }

        private void unlockButton_Click(object sender, EventArgs e)
        {
            apiUrlTextBox.Enabled = !apiUrlTextBox.Enabled;
        }


        private void notifyIconSanitation(object sender, EventArgs e)
        {
            // Do not allow the user to minimize application to try but hide the tray icon
            if (!showNotifyIconCheckBox.Checked)
            {
                minimizeToTrayCheckBox.Checked = false;
                minimizeToTrayCheckBox.Enabled = false;
            } else
            {
                minimizeToTrayCheckBox.Enabled = true;
            }
        }
    }
}