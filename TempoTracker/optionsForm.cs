#region Using directives

using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

#endregion

namespace TempoTracker
{
    public partial class optionsForm : Form
    {
        public optionsForm()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(usernameTextBox.Text) && !String.IsNullOrEmpty(passwordTextBox.Text))
            {
                var rk = Application.UserAppDataRegistry;

                if (rk == null) throw new Exception("Unable to read registry key.");

                rk.SetValue("username", usernameTextBox.Text, RegistryValueKind.String);

                byte[] entropy = { 0x01, 0x02, 0x03, 0x05, 0x07, 0x11 };

                var secret = Encoding.Unicode.GetBytes(passwordTextBox.Text);
                var protectedSecret = ProtectedData.Protect(secret, entropy, DataProtectionScope.CurrentUser);

                rk.SetValue("password", Convert.ToBase64String(protectedSecret, Base64FormattingOptions.None), RegistryValueKind.String);

                rk.SetValue("showInTaskbar", Convert.ToInt32(showInTaskbarCheckBox.Checked), RegistryValueKind.DWord);
                rk.SetValue("showTimeReminder", Convert.ToInt32(showTimeReminderCheckBox.Checked), RegistryValueKind.DWord);
                rk.SetValue("warnOnEmptyNotes", Convert.ToInt32(warnOnEmptyNotesCheckBox.Checked), RegistryValueKind.DWord);
                rk.SetValue("resetProjectOnSubmit", Convert.ToInt32(resetProjectOnSubmitCheckBox.Checked), RegistryValueKind.DWord);

                DialogResult = DialogResult.OK;

                Close();
            }
            else
            {
                MessageBox.Show("Please enter a username and password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void optionsForm_Load(object sender, EventArgs e)
        {
            var rk = Application.UserAppDataRegistry;

            if (rk == null) throw new Exception("Unable to read registry key.");

            usernameTextBox.Text = rk.GetValue("username", "").ToString();

            var mf = (MainForm) Owner;

            showInTaskbarCheckBox.Checked = mf.ShowInTaskbarOption;
            showTimeReminderCheckBox.Checked = mf.ShowTimeReminderOption;
            warnOnEmptyNotesCheckBox.Checked = mf.WarnOnEmptyNotesOption;
            resetProjectOnSubmitCheckBox.Checked = mf.ResetProjectOnSubmitOption;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;

            Close();
        }
    }
}
