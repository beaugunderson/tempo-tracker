using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

using Microsoft.Win32;

namespace TempoTracker
{
    public partial class OptionsForm : Form
    {
        public OptionsForm()
        {
            InitializeComponent();
        }

        // Application settings object
        Properties.Settings AppSettings = Properties.Settings.Default;

        /// <exception cref="Exception">Unable to read registry key.</exception>
        private void optionsForm_Load(object sender, EventArgs e)
        {
            var registryKey = Application.UserAppDataRegistry;

            if (registryKey == null)
            {
                throw new Exception("Unable to read registry key.");
            }

            usernameTextBox.Text = registryKey.GetValue("username", string.Empty).ToString();

            var mainForm = (MainForm)Owner;

            showInTaskbarCheckBox.Checked = mainForm.ShowInTaskbarOption;
            showTimeReminderCheckBox.Checked = mainForm.ShowTimeReminderOption;
            warnOnEmptyNotesCheckBox.Checked = mainForm.WarnOnEmptyNotesOption;
            resetProjectOnSubmitCheckBox.Checked = mainForm.ResetProjectOnSubmitOption;
            displayTimeHoursMinutesCheckbox.Checked = mainForm.DisplayTimeHoursMinutesOption;


            // Load API settings 
            if (string.IsNullOrEmpty(AppSettings.ServiceAPI) == false)
            {
                serviceApiCheckBox.SelectedItem = AppSettings.ServiceAPI;
                apiURLTextBox.Text = AppSettings.apiCustom_URL;
            }
        }

        private void serviceApiCheckBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (serviceApiCheckBox.SelectedItem.ToString())
                {
                    case "Keep Tempo":
                        apiURLTextBox.Text = AppSettings.apiKeepTempo;
                        break;
                    case "Freshbooks":
                        apiURLTextBox.Text = AppSettings.apiFreshbooks;
                        break;
                    case "Freckle":
                        apiURLTextBox.Text = AppSettings.apiFreckle;
                        break;
                    case "Klok":
                        apiURLTextBox.Text = AppSettings.apiKlok;
                        break;
                    default:
                        break;
                }
         
            if (serviceApiCheckBox.SelectedIndex >= 0)
            {
                unlockButton.Enabled = true;
                groupOptions.Enabled = true;
                usernameTextBox.Enabled = true;
                passwordTextBox.Enabled = true; 
            }

        }


        private bool FormVerified()
        {
            if (string.IsNullOrEmpty(usernameTextBox.Text) || string.IsNullOrEmpty(passwordTextBox.Text) || serviceApiCheckBox.SelectedIndex < 0)
            {
                MessageBox.Show("Please enter a username and password, and select an API", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            } 
            
             // Verify the user has modified the custom api url
            if (apiURLTextBox.Text == AppSettings.apiKeepTempo || apiURLTextBox.Text == AppSettings.apiFreckle
                    || apiURLTextBox.Text == AppSettings.apiFreshbooks || apiURLTextBox.Text == AppSettings.apiKlok)
            {
                MessageBox.Show("Please enter your custom API URL.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            // Verification succesful
            return true;

        }

        /// <exception cref="Exception">Unable to read registry key.</exception>
        private void saveButton_Click(object sender, EventArgs e)
        {
            // Verify form, if something doesn't verify, fail out
            if (!FormVerified()){ return;}

            var registryKey = Application.UserAppDataRegistry;

            if (registryKey == null)
            {
                throw new Exception("Unable to read registry key.");
            }

            registryKey.SetValue("username", usernameTextBox.Text, RegistryValueKind.String);

            byte[] entropy = { 0x01, 0x02, 0x03, 0x05, 0x07, 0x11 };

            var secret = Encoding.Unicode.GetBytes(passwordTextBox.Text);
            var protectedSecret = ProtectedData.Protect(secret, entropy, DataProtectionScope.CurrentUser);

            registryKey.SetValue("password", Convert.ToBase64String(protectedSecret, Base64FormattingOptions.None), RegistryValueKind.String);

            registryKey.SetValue("showInTaskbar", Convert.ToInt32(showInTaskbarCheckBox.Checked), RegistryValueKind.DWord);
            registryKey.SetValue("showTimeReminder", Convert.ToInt32(showTimeReminderCheckBox.Checked), RegistryValueKind.DWord);
            registryKey.SetValue("warnOnEmptyNotes", Convert.ToInt32(warnOnEmptyNotesCheckBox.Checked), RegistryValueKind.DWord);
            registryKey.SetValue("resetProjectOnSubmit", Convert.ToInt32(resetProjectOnSubmitCheckBox.Checked), RegistryValueKind.DWord);
            registryKey.SetValue("displayTimeHoursMinutes", Convert.ToInt32(displayTimeHoursMinutesCheckbox.Checked), RegistryValueKind.DWord);

            DialogResult = DialogResult.OK;

               
            // Save Service API / Custom URL
            AppSettings.ServiceAPI = serviceApiCheckBox.SelectedItem.ToString();
            AppSettings.apiCustom_URL = apiURLTextBox.Text;
            AppSettings.Save();

            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;

            Close();
        }

        private void unlockButton_Click(object sender, EventArgs e)
        {
            apiURLTextBox.Enabled = !apiURLTextBox.Enabled;
        }


    }
}