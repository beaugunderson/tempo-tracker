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
            this.displayOptionsTab = new System.Windows.Forms.TabPage();
            this.minimizeToTrayCheckBox = new System.Windows.Forms.CheckBox();
            this.showInTaskbarCheckBox = new System.Windows.Forms.CheckBox();
            this.showNotifyIconCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.displayTimeHoursMinutesCheckbox = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.optionsTabControl.SuspendLayout();
            this.serviceInfoTab.SuspendLayout();
            this.notificationsTab.SuspendLayout();
            this.displayOptionsTab.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Enabled = false;
            this.passwordTextBox.Location = new System.Drawing.Point(140, 61);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(114, 20);
            this.passwordTextBox.TabIndex = 3;
            this.passwordTextBox.UseSystemPasswordChar = true;
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Enabled = false;
            this.usernameTextBox.Location = new System.Drawing.Point(6, 61);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(114, 20);
            this.usernameTextBox.TabIndex = 1;
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
            this.saveButton.TabIndex = 6;
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
            this.cancelButton.TabIndex = 5;
            this.cancelButton.Text = "&Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // showTimeReminderCheckBox
            // 
            this.showTimeReminderCheckBox.AutoSize = true;
            this.showTimeReminderCheckBox.Location = new System.Drawing.Point(6, 19);
            this.showTimeReminderCheckBox.Name = "showTimeReminderCheckBox";
            this.showTimeReminderCheckBox.Size = new System.Drawing.Size(201, 17);
            this.showTimeReminderCheckBox.TabIndex = 3;
            this.showTimeReminderCheckBox.Text = "Show time reminder every 10 minutes";
            this.showTimeReminderCheckBox.UseVisualStyleBackColor = true;
            // 
            // warnOnEmptyNotesCheckBox
            // 
            this.warnOnEmptyNotesCheckBox.AutoSize = true;
            this.warnOnEmptyNotesCheckBox.Location = new System.Drawing.Point(6, 19);
            this.warnOnEmptyNotesCheckBox.Name = "warnOnEmptyNotesCheckBox";
            this.warnOnEmptyNotesCheckBox.Size = new System.Drawing.Size(149, 17);
            this.warnOnEmptyNotesCheckBox.TabIndex = 0;
            this.warnOnEmptyNotesCheckBox.Text = "Warn on empty notes field";
            this.warnOnEmptyNotesCheckBox.UseVisualStyleBackColor = true;
            // 
            // resetProjectOnSubmitCheckBox
            // 
            this.resetProjectOnSubmitCheckBox.AutoSize = true;
            this.resetProjectOnSubmitCheckBox.Location = new System.Drawing.Point(6, 42);
            this.resetProjectOnSubmitCheckBox.Name = "resetProjectOnSubmitCheckBox";
            this.resetProjectOnSubmitCheckBox.Size = new System.Drawing.Size(158, 17);
            this.resetProjectOnSubmitCheckBox.TabIndex = 1;
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
            this.serviceApiCheckBox.TabIndex = 8;
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
            this.apiUrlTextBox.TabIndex = 10;
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
            this.optionsTabControl.TabIndex = 12;
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
            this.notificationsTab.Text = "Notifications";
            this.notificationsTab.UseVisualStyleBackColor = true;
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
            // minimizeToTrayCheckBox
            // 
            this.minimizeToTrayCheckBox.AutoSize = true;
            this.minimizeToTrayCheckBox.Location = new System.Drawing.Point(19, 58);
            this.minimizeToTrayCheckBox.Name = "minimizeToTrayCheckBox";
            this.minimizeToTrayCheckBox.Size = new System.Drawing.Size(139, 17);
            this.minimizeToTrayCheckBox.TabIndex = 8;
            this.minimizeToTrayCheckBox.Text = "Minimize to System Tray";
            this.minimizeToTrayCheckBox.UseVisualStyleBackColor = true;
            // 
            // showInTaskbarCheckBox
            // 
            this.showInTaskbarCheckBox.AutoSize = true;
            this.showInTaskbarCheckBox.Location = new System.Drawing.Point(6, 19);
            this.showInTaskbarCheckBox.Name = "showInTaskbarCheckBox";
            this.showInTaskbarCheckBox.Size = new System.Drawing.Size(102, 17);
            this.showInTaskbarCheckBox.TabIndex = 6;
            this.showInTaskbarCheckBox.Text = "Show in taskbar";
            this.showInTaskbarCheckBox.UseVisualStyleBackColor = true;
            // 
            // showNotifyIconCheckBox
            // 
            this.showNotifyIconCheckBox.AutoSize = true;
            this.showNotifyIconCheckBox.Location = new System.Drawing.Point(6, 38);
            this.showNotifyIconCheckBox.Name = "showNotifyIconCheckBox";
            this.showNotifyIconCheckBox.Size = new System.Drawing.Size(179, 17);
            this.showNotifyIconCheckBox.TabIndex = 7;
            this.showNotifyIconCheckBox.Text = "Show Notify Icon in System Tray";
            this.showNotifyIconCheckBox.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.warnOnEmptyNotesCheckBox);
            this.groupBox1.Controls.Add(this.resetProjectOnSubmitCheckBox);
            this.groupBox1.Location = new System.Drawing.Point(7, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(299, 66);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Entry Submissions";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.showTimeReminderCheckBox);
            this.groupBox2.Location = new System.Drawing.Point(7, 73);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(299, 78);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Reminders";
            // 
            // displayTimeHoursMinutesCheckbox
            // 
            this.displayTimeHoursMinutesCheckbox.AutoSize = true;
            this.displayTimeHoursMinutesCheckbox.Location = new System.Drawing.Point(6, 19);
            this.displayTimeHoursMinutesCheckbox.Name = "displayTimeHoursMinutesCheckbox";
            this.displayTimeHoursMinutesCheckbox.Size = new System.Drawing.Size(182, 17);
            this.displayTimeHoursMinutesCheckbox.TabIndex = 9;
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
            this.displayOptionsTab.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
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
    }
}