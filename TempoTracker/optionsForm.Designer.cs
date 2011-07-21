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
            this.showTimeReminderCheckBox = new System.Windows.Forms.CheckBox();
            this.warnOnEmptyNotesCheckBox = new System.Windows.Forms.CheckBox();
            this.resetProjectOnSubmitCheckBox = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.serviceApiCheckBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.apiUrlTextBox = new System.Windows.Forms.TextBox();
            this.optionsTabControl = new System.Windows.Forms.TabControl();
            this.serviceInfoTab = new System.Windows.Forms.TabPage();
            this.notificationsTab = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.IdleTimeoutNumericBox = new System.Windows.Forms.NumericUpDown();
            this.PauseIfIdleCheckBox = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ReminderTimeNumericBox = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.displayOptionsTab = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.displayTimeHoursMinutesCheckbox = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.showInTaskbarCheckBox = new System.Windows.Forms.CheckBox();
            this.showNotifyIconCheckBox = new System.Windows.Forms.CheckBox();
            this.minimizeToTrayCheckBox = new System.Windows.Forms.CheckBox();
            this.optionsTabControl.SuspendLayout();
            this.serviceInfoTab.SuspendLayout();
            this.notificationsTab.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IdleTimeoutNumericBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReminderTimeNumericBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.displayOptionsTab.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Enabled = false;
            this.passwordTextBox.Location = new System.Drawing.Point(140, 61);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(114, 20);
            this.passwordTextBox.TabIndex = 4;
            this.passwordTextBox.UseSystemPasswordChar = true;
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Enabled = false;
            this.usernameTextBox.Location = new System.Drawing.Point(6, 61);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(114, 20);
            this.usernameTextBox.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(137, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Password";
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(201, 183);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 7;
            this.saveButton.Text = "&Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(120, 183);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 6;
            this.cancelButton.Text = "&Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // showTimeReminderCheckBox
            // 
            this.showTimeReminderCheckBox.AutoSize = true;
            this.showTimeReminderCheckBox.Location = new System.Drawing.Point(6, 19);
            this.showTimeReminderCheckBox.Name = "showTimeReminderCheckBox";
            this.showTimeReminderCheckBox.Size = new System.Drawing.Size(147, 17);
            this.showTimeReminderCheckBox.TabIndex = 11;
            this.showTimeReminderCheckBox.Text = "Show time reminder every";
            this.showTimeReminderCheckBox.UseVisualStyleBackColor = true;
            // 
            // warnOnEmptyNotesCheckBox
            // 
            this.warnOnEmptyNotesCheckBox.AutoSize = true;
            this.warnOnEmptyNotesCheckBox.Location = new System.Drawing.Point(6, 19);
            this.warnOnEmptyNotesCheckBox.Name = "warnOnEmptyNotesCheckBox";
            this.warnOnEmptyNotesCheckBox.Size = new System.Drawing.Size(149, 17);
            this.warnOnEmptyNotesCheckBox.TabIndex = 9;
            this.warnOnEmptyNotesCheckBox.Text = "Warn on empty notes field";
            this.warnOnEmptyNotesCheckBox.UseVisualStyleBackColor = true;
            // 
            // resetProjectOnSubmitCheckBox
            // 
            this.resetProjectOnSubmitCheckBox.AutoSize = true;
            this.resetProjectOnSubmitCheckBox.Location = new System.Drawing.Point(6, 42);
            this.resetProjectOnSubmitCheckBox.Name = "resetProjectOnSubmitCheckBox";
            this.resetProjectOnSubmitCheckBox.Size = new System.Drawing.Size(158, 17);
            this.resetProjectOnSubmitCheckBox.TabIndex = 10;
            this.resetProjectOnSubmitCheckBox.Text = "Reset project on submission";
            this.resetProjectOnSubmitCheckBox.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 4);
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
            this.serviceApiCheckBox.Location = new System.Drawing.Point(6, 18);
            this.serviceApiCheckBox.Name = "serviceApiCheckBox";
            this.serviceApiCheckBox.Size = new System.Drawing.Size(248, 21);
            this.serviceApiCheckBox.TabIndex = 2;
            this.serviceApiCheckBox.SelectedIndexChanged += new System.EventHandler(this.serviceApiCheckBox_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Custom API url";
            // 
            // apiUrlTextBox
            // 
            this.apiUrlTextBox.Enabled = false;
            this.apiUrlTextBox.Location = new System.Drawing.Point(6, 106);
            this.apiUrlTextBox.Multiline = true;
            this.apiUrlTextBox.Name = "apiUrlTextBox";
            this.apiUrlTextBox.Size = new System.Drawing.Size(248, 39);
            this.apiUrlTextBox.TabIndex = 5;
            // 
            // optionsTabControl
            // 
            this.optionsTabControl.Controls.Add(this.serviceInfoTab);
            this.optionsTabControl.Controls.Add(this.notificationsTab);
            this.optionsTabControl.Controls.Add(this.displayOptionsTab);
            this.optionsTabControl.HotTrack = true;
            this.optionsTabControl.Location = new System.Drawing.Point(2, 0);
            this.optionsTabControl.Name = "optionsTabControl";
            this.optionsTabControl.SelectedIndex = 0;
            this.optionsTabControl.Size = new System.Drawing.Size(274, 181);
            this.optionsTabControl.TabIndex = 15;
            // 
            // serviceInfoTab
            // 
            this.serviceInfoTab.Controls.Add(this.apiUrlTextBox);
            this.serviceInfoTab.Controls.Add(this.passwordTextBox);
            this.serviceInfoTab.Controls.Add(this.usernameTextBox);
            this.serviceInfoTab.Controls.Add(this.label4);
            this.serviceInfoTab.Controls.Add(this.label1);
            this.serviceInfoTab.Controls.Add(this.serviceApiCheckBox);
            this.serviceInfoTab.Controls.Add(this.label2);
            this.serviceInfoTab.Controls.Add(this.label3);
            this.serviceInfoTab.Location = new System.Drawing.Point(4, 22);
            this.serviceInfoTab.Name = "serviceInfoTab";
            this.serviceInfoTab.Padding = new System.Windows.Forms.Padding(3);
            this.serviceInfoTab.Size = new System.Drawing.Size(266, 155);
            this.serviceInfoTab.TabIndex = 0;
            this.serviceInfoTab.Text = "Service Info";
            this.serviceInfoTab.UseVisualStyleBackColor = true;
            // 
            // notificationsTab
            // 
            this.notificationsTab.Controls.Add(this.groupBox2);
            this.notificationsTab.Controls.Add(this.groupBox1);
            this.notificationsTab.Location = new System.Drawing.Point(4, 22);
            this.notificationsTab.Name = "notificationsTab";
            this.notificationsTab.Padding = new System.Windows.Forms.Padding(3);
            this.notificationsTab.Size = new System.Drawing.Size(266, 155);
            this.notificationsTab.TabIndex = 1;
            this.notificationsTab.Text = "Reminders";
            this.notificationsTab.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.IdleTimeoutNumericBox);
            this.groupBox2.Controls.Add(this.PauseIfIdleCheckBox);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.ReminderTimeNumericBox);
            this.groupBox2.Controls.Add(this.showTimeReminderCheckBox);
            this.groupBox2.Location = new System.Drawing.Point(7, 73);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(256, 78);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Reminders / Idle Settings";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(201, 43);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "minutes";
            // 
            // IdleTimeoutNumericBox
            // 
            this.IdleTimeoutNumericBox.Location = new System.Drawing.Point(158, 39);
            this.IdleTimeoutNumericBox.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.IdleTimeoutNumericBox.Name = "IdleTimeoutNumericBox";
            this.IdleTimeoutNumericBox.Size = new System.Drawing.Size(41, 20);
            this.IdleTimeoutNumericBox.TabIndex = 14;
            this.IdleTimeoutNumericBox.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // PauseIfIdleCheckBox
            // 
            this.PauseIfIdleCheckBox.AutoSize = true;
            this.PauseIfIdleCheckBox.Location = new System.Drawing.Point(6, 42);
            this.PauseIfIdleCheckBox.Name = "PauseIfIdleCheckBox";
            this.PauseIfIdleCheckBox.Size = new System.Drawing.Size(155, 17);
            this.PauseIfIdleCheckBox.TabIndex = 13;
            this.PauseIfIdleCheckBox.Text = "Pause time if idle more than";
            this.PauseIfIdleCheckBox.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(201, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "minutes";
            // 
            // ReminderTimeNumericBox
            // 
            this.ReminderTimeNumericBox.Location = new System.Drawing.Point(158, 16);
            this.ReminderTimeNumericBox.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.ReminderTimeNumericBox.Name = "ReminderTimeNumericBox";
            this.ReminderTimeNumericBox.Size = new System.Drawing.Size(41, 20);
            this.ReminderTimeNumericBox.TabIndex = 12;
            this.ReminderTimeNumericBox.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.warnOnEmptyNotesCheckBox);
            this.groupBox1.Controls.Add(this.resetProjectOnSubmitCheckBox);
            this.groupBox1.Location = new System.Drawing.Point(7, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(256, 66);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Entry Submissions";
            // 
            // displayOptionsTab
            // 
            this.displayOptionsTab.Controls.Add(this.groupBox4);
            this.displayOptionsTab.Controls.Add(this.groupBox3);
            this.displayOptionsTab.Location = new System.Drawing.Point(4, 22);
            this.displayOptionsTab.Name = "displayOptionsTab";
            this.displayOptionsTab.Size = new System.Drawing.Size(266, 155);
            this.displayOptionsTab.TabIndex = 2;
            this.displayOptionsTab.Text = "Display Options";
            this.displayOptionsTab.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.displayTimeHoursMinutesCheckbox);
            this.groupBox4.Location = new System.Drawing.Point(6, 88);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(257, 64);
            this.groupBox4.TabIndex = 11;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Formatting";
            // 
            // displayTimeHoursMinutesCheckbox
            // 
            this.displayTimeHoursMinutesCheckbox.AutoSize = true;
            this.displayTimeHoursMinutesCheckbox.Location = new System.Drawing.Point(6, 19);
            this.displayTimeHoursMinutesCheckbox.Name = "displayTimeHoursMinutesCheckbox";
            this.displayTimeHoursMinutesCheckbox.Size = new System.Drawing.Size(182, 17);
            this.displayTimeHoursMinutesCheckbox.TabIndex = 19;
            this.displayTimeHoursMinutesCheckbox.Text = "Display time in HH:MM:SS format";
            this.displayTimeHoursMinutesCheckbox.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.showInTaskbarCheckBox);
            this.groupBox3.Controls.Add(this.showNotifyIconCheckBox);
            this.groupBox3.Controls.Add(this.minimizeToTrayCheckBox);
            this.groupBox3.Location = new System.Drawing.Point(6, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(257, 79);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Taskbar";
            // 
            // showInTaskbarCheckBox
            // 
            this.showInTaskbarCheckBox.AutoSize = true;
            this.showInTaskbarCheckBox.Location = new System.Drawing.Point(6, 19);
            this.showInTaskbarCheckBox.Name = "showInTaskbarCheckBox";
            this.showInTaskbarCheckBox.Size = new System.Drawing.Size(102, 17);
            this.showInTaskbarCheckBox.TabIndex = 16;
            this.showInTaskbarCheckBox.Text = "Show in taskbar";
            this.showInTaskbarCheckBox.UseVisualStyleBackColor = true;
            // 
            // showNotifyIconCheckBox
            // 
            this.showNotifyIconCheckBox.AutoSize = true;
            this.showNotifyIconCheckBox.Location = new System.Drawing.Point(6, 38);
            this.showNotifyIconCheckBox.Name = "showNotifyIconCheckBox";
            this.showNotifyIconCheckBox.Size = new System.Drawing.Size(179, 17);
            this.showNotifyIconCheckBox.TabIndex = 17;
            this.showNotifyIconCheckBox.Text = "Show Notify Icon in System Tray";
            this.showNotifyIconCheckBox.UseVisualStyleBackColor = true;
            // 
            // minimizeToTrayCheckBox
            // 
            this.minimizeToTrayCheckBox.AutoSize = true;
            this.minimizeToTrayCheckBox.Location = new System.Drawing.Point(19, 58);
            this.minimizeToTrayCheckBox.Name = "minimizeToTrayCheckBox";
            this.minimizeToTrayCheckBox.Size = new System.Drawing.Size(139, 17);
            this.minimizeToTrayCheckBox.TabIndex = 18;
            this.minimizeToTrayCheckBox.Text = "Minimize to System Tray";
            this.minimizeToTrayCheckBox.UseVisualStyleBackColor = true;
            // 
            // OptionsForm
            // 
            this.AcceptButton = this.saveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(281, 211);
            this.ControlBox = false;
            this.Controls.Add(this.optionsTabControl);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "OptionsForm";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Options";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.optionsForm_Load);
            this.optionsTabControl.ResumeLayout(false);
            this.serviceInfoTab.ResumeLayout(false);
            this.serviceInfoTab.PerformLayout();
            this.notificationsTab.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IdleTimeoutNumericBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReminderTimeNumericBox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.displayOptionsTab.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.CheckBox warnOnEmptyNotesCheckBox;
        private System.Windows.Forms.CheckBox resetProjectOnSubmitCheckBox;
        private System.Windows.Forms.CheckBox showTimeReminderCheckBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox serviceApiCheckBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox apiUrlTextBox;
        private System.Windows.Forms.TabControl optionsTabControl;
        private System.Windows.Forms.TabPage serviceInfoTab;
        private System.Windows.Forms.TabPage notificationsTab;
        private System.Windows.Forms.TabPage displayOptionsTab;
        private System.Windows.Forms.CheckBox minimizeToTrayCheckBox;
        private System.Windows.Forms.CheckBox showInTaskbarCheckBox;
        private System.Windows.Forms.CheckBox showNotifyIconCheckBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox displayTimeHoursMinutesCheckbox;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.NumericUpDown ReminderTimeNumericBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown IdleTimeoutNumericBox;
        private System.Windows.Forms.CheckBox PauseIfIdleCheckBox;
    }
}