namespace TempoTracker
{
    partial class OptionsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionsForm));
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.groupOptions = new System.Windows.Forms.GroupBox();
            this.minimizeToTrayCheckBox = new System.Windows.Forms.CheckBox();
            this.showNotifyIconCheckBox = new System.Windows.Forms.CheckBox();
            this.displayTimeHoursMinutesCheckbox = new System.Windows.Forms.CheckBox();
            this.showTimeReminderCheckBox = new System.Windows.Forms.CheckBox();
            this.warnOnEmptyNotesCheckBox = new System.Windows.Forms.CheckBox();
            this.showInTaskbarCheckBox = new System.Windows.Forms.CheckBox();
            this.resetProjectOnSubmitCheckBox = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.serviceApiCheckBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.apiUrlTextBox = new System.Windows.Forms.TextBox();
            this.unlockButton = new System.Windows.Forms.Button();
            this.groupOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Enabled = false;
            this.passwordTextBox.Location = new System.Drawing.Point(146, 64);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(114, 20);
            this.passwordTextBox.TabIndex = 3;
            this.passwordTextBox.UseSystemPasswordChar = true;
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Enabled = false;
            this.usernameTextBox.Location = new System.Drawing.Point(12, 64);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(114, 20);
            this.usernameTextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(143, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Password";
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(144, 370);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 6;
            this.saveButton.Text = "&Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(63, 370);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 5;
            this.cancelButton.Text = "&Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // groupOptions
            // 
            this.groupOptions.Controls.Add(this.minimizeToTrayCheckBox);
            this.groupOptions.Controls.Add(this.showNotifyIconCheckBox);
            this.groupOptions.Controls.Add(this.displayTimeHoursMinutesCheckbox);
            this.groupOptions.Controls.Add(this.showTimeReminderCheckBox);
            this.groupOptions.Controls.Add(this.warnOnEmptyNotesCheckBox);
            this.groupOptions.Controls.Add(this.showInTaskbarCheckBox);
            this.groupOptions.Controls.Add(this.resetProjectOnSubmitCheckBox);
            this.groupOptions.Enabled = false;
            this.groupOptions.Location = new System.Drawing.Point(12, 178);
            this.groupOptions.Name = "groupOptions";
            this.groupOptions.Size = new System.Drawing.Size(248, 186);
            this.groupOptions.TabIndex = 4;
            this.groupOptions.TabStop = false;
            // 
            // minimizeToTrayCheckBox
            // 
            this.minimizeToTrayCheckBox.AutoSize = true;
            this.minimizeToTrayCheckBox.Location = new System.Drawing.Point(33, 157);
            this.minimizeToTrayCheckBox.Name = "minimizeToTrayCheckBox";
            this.minimizeToTrayCheckBox.Size = new System.Drawing.Size(139, 17);
            this.minimizeToTrayCheckBox.TabIndex = 5;
            this.minimizeToTrayCheckBox.Text = "Minimize to System Tray";
            this.minimizeToTrayCheckBox.UseVisualStyleBackColor = true;
            this.minimizeToTrayCheckBox.CheckedChanged += new System.EventHandler(this.notifyIconSanitation);
            // 
            // showNotifyIconCheckBox
            // 
            this.showNotifyIconCheckBox.AutoSize = true;
            this.showNotifyIconCheckBox.Location = new System.Drawing.Point(12, 134);
            this.showNotifyIconCheckBox.Name = "showNotifyIconCheckBox";
            this.showNotifyIconCheckBox.Size = new System.Drawing.Size(179, 17);
            this.showNotifyIconCheckBox.TabIndex = 4;
            this.showNotifyIconCheckBox.Text = "Show Notify Icon in System Tray";
            this.showNotifyIconCheckBox.UseVisualStyleBackColor = true;
            this.showNotifyIconCheckBox.CheckedChanged += new System.EventHandler(this.notifyIconSanitation);
            // 
            // displayTimeHoursMinutesCheckbox
            // 
            this.displayTimeHoursMinutesCheckbox.AutoSize = true;
            this.displayTimeHoursMinutesCheckbox.Location = new System.Drawing.Point(12, 111);
            this.displayTimeHoursMinutesCheckbox.Name = "displayTimeHoursMinutesCheckbox";
            this.displayTimeHoursMinutesCheckbox.Size = new System.Drawing.Size(182, 17);
            this.displayTimeHoursMinutesCheckbox.TabIndex = 3;
            this.displayTimeHoursMinutesCheckbox.Text = "Display time in HH:MM:SS format";
            this.displayTimeHoursMinutesCheckbox.UseVisualStyleBackColor = true;
            // 
            // showTimeReminderCheckBox
            // 
            this.showTimeReminderCheckBox.AutoSize = true;
            this.showTimeReminderCheckBox.Location = new System.Drawing.Point(12, 88);
            this.showTimeReminderCheckBox.Name = "showTimeReminderCheckBox";
            this.showTimeReminderCheckBox.Size = new System.Drawing.Size(201, 17);
            this.showTimeReminderCheckBox.TabIndex = 3;
            this.showTimeReminderCheckBox.Text = "Show time reminder every 10 minutes";
            this.showTimeReminderCheckBox.UseVisualStyleBackColor = true;
            // 
            // warnOnEmptyNotesCheckBox
            // 
            this.warnOnEmptyNotesCheckBox.AutoSize = true;
            this.warnOnEmptyNotesCheckBox.Location = new System.Drawing.Point(12, 19);
            this.warnOnEmptyNotesCheckBox.Name = "warnOnEmptyNotesCheckBox";
            this.warnOnEmptyNotesCheckBox.Size = new System.Drawing.Size(149, 17);
            this.warnOnEmptyNotesCheckBox.TabIndex = 0;
            this.warnOnEmptyNotesCheckBox.Text = "Warn on empty notes field";
            this.warnOnEmptyNotesCheckBox.UseVisualStyleBackColor = true;
            // 
            // showInTaskbarCheckBox
            // 
            this.showInTaskbarCheckBox.AutoSize = true;
            this.showInTaskbarCheckBox.Location = new System.Drawing.Point(12, 65);
            this.showInTaskbarCheckBox.Name = "showInTaskbarCheckBox";
            this.showInTaskbarCheckBox.Size = new System.Drawing.Size(102, 17);
            this.showInTaskbarCheckBox.TabIndex = 2;
            this.showInTaskbarCheckBox.Text = "Show in taskbar";
            this.showInTaskbarCheckBox.UseVisualStyleBackColor = true;
            // 
            // resetProjectOnSubmitCheckBox
            // 
            this.resetProjectOnSubmitCheckBox.AutoSize = true;
            this.resetProjectOnSubmitCheckBox.Location = new System.Drawing.Point(12, 42);
            this.resetProjectOnSubmitCheckBox.Name = "resetProjectOnSubmitCheckBox";
            this.resetProjectOnSubmitCheckBox.Size = new System.Drawing.Size(158, 17);
            this.resetProjectOnSubmitCheckBox.TabIndex = 1;
            this.resetProjectOnSubmitCheckBox.Text = "Reset project on submission";
            this.resetProjectOnSubmitCheckBox.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Service";
            // 
            // serviceApiCheckBox
            // 
            this.serviceApiCheckBox.FormattingEnabled = true;
            this.serviceApiCheckBox.Items.AddRange(new object[] {
            "Select a time tracking service...",
            "Keep Tempo",
            "Freshbooks",
            "Freckle",
            "Klok"});
            this.serviceApiCheckBox.Location = new System.Drawing.Point(12, 23);
            this.serviceApiCheckBox.Name = "serviceApiCheckBox";
            this.serviceApiCheckBox.Size = new System.Drawing.Size(248, 21);
            this.serviceApiCheckBox.TabIndex = 8;
            this.serviceApiCheckBox.SelectedIndexChanged += new System.EventHandler(this.serviceApiCheckBox_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Custom API url";
            // 
            // apiUrlTextBox
            // 
            this.apiUrlTextBox.Enabled = false;
            this.apiUrlTextBox.Location = new System.Drawing.Point(12, 115);
            this.apiUrlTextBox.Multiline = true;
            this.apiUrlTextBox.Name = "apiUrlTextBox";
            this.apiUrlTextBox.Size = new System.Drawing.Size(248, 43);
            this.apiUrlTextBox.TabIndex = 10;
            // 
            // unlockButton
            // 
            this.unlockButton.Enabled = false;
            this.unlockButton.Image = ((System.Drawing.Image)(resources.GetObject("unlockButton.Image")));
            this.unlockButton.Location = new System.Drawing.Point(263, 115);
            this.unlockButton.Name = "unlockButton";
            this.unlockButton.Size = new System.Drawing.Size(34, 34);
            this.unlockButton.TabIndex = 11;
            this.unlockButton.UseVisualStyleBackColor = true;
            this.unlockButton.Click += new System.EventHandler(this.unlockButton_Click);
            // 
            // OptionsForm
            // 
            this.AcceptButton = this.saveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(327, 417);
            this.ControlBox = false;
            this.Controls.Add(this.unlockButton);
            this.Controls.Add(this.apiUrlTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.serviceApiCheckBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupOptions);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.usernameTextBox);
            this.Controls.Add(this.passwordTextBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "OptionsForm";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Options";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.optionsForm_Load);
            this.groupOptions.ResumeLayout(false);
            this.groupOptions.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.GroupBox groupOptions;
        private System.Windows.Forms.CheckBox warnOnEmptyNotesCheckBox;
        private System.Windows.Forms.CheckBox showInTaskbarCheckBox;
        private System.Windows.Forms.CheckBox resetProjectOnSubmitCheckBox;
        private System.Windows.Forms.CheckBox showTimeReminderCheckBox;
        private System.Windows.Forms.CheckBox displayTimeHoursMinutesCheckbox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox serviceApiCheckBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox apiUrlTextBox;
        private System.Windows.Forms.Button unlockButton;
        private System.Windows.Forms.CheckBox minimizeToTrayCheckBox;
        private System.Windows.Forms.CheckBox showNotifyIconCheckBox;
    }
}