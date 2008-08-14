namespace TempoTracker
{
    partial class optionsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(optionsForm));
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.showTimeReminderCheckBox = new System.Windows.Forms.CheckBox();
            this.warnOnEmptyNotesCheckBox = new System.Windows.Forms.CheckBox();
            this.showInTaskbarCheckBox = new System.Windows.Forms.CheckBox();
            this.resetProjectOnSubmitCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(74, 32);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(212, 20);
            this.passwordTextBox.TabIndex = 3;
            this.passwordTextBox.UseSystemPasswordChar = true;
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Location = new System.Drawing.Point(74, 6);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(212, 20);
            this.usernameTextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Password";
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(152, 184);
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
            this.cancelButton.Location = new System.Drawing.Point(71, 184);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 5;
            this.cancelButton.Text = "&Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.showTimeReminderCheckBox);
            this.groupBox1.Controls.Add(this.warnOnEmptyNotesCheckBox);
            this.groupBox1.Controls.Add(this.showInTaskbarCheckBox);
            this.groupBox1.Controls.Add(this.resetProjectOnSubmitCheckBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 58);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(274, 115);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
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
            this.showInTaskbarCheckBox.Size = new System.Drawing.Size(105, 17);
            this.showInTaskbarCheckBox.TabIndex = 2;
            this.showInTaskbarCheckBox.Text = "Show in task bar";
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
            // optionsForm
            // 
            this.AcceptButton = this.saveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(298, 216);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.usernameTextBox);
            this.Controls.Add(this.passwordTextBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "optionsForm";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Options";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.optionsForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox warnOnEmptyNotesCheckBox;
        private System.Windows.Forms.CheckBox showInTaskbarCheckBox;
        private System.Windows.Forms.CheckBox resetProjectOnSubmitCheckBox;
        private System.Windows.Forms.CheckBox showTimeReminderCheckBox;
    }
}