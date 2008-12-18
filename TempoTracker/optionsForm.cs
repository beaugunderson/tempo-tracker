#region Using directives

using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

#endregion

namespace TempoTracker
{
    public partial class OptionsForm : Form
    {
        public OptionsForm()
        {
            InitializeComponent();
        }

        /// <exception cref="Exception">Unable to read registry key.</exception>
        private void saveButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(usernameTextBox.Text) && !string.IsNullOrEmpty(passwordTextBox.Text))
            {
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

                Close();
            }
            else
            {
                MessageBox.Show("Please enter a username and password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

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
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;

            Close();
        }
    }
}
