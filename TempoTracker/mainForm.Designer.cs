namespace TempoTracker
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.refreshButton = new System.Windows.Forms.Button();
            this.projectsComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.timerEntryGroupBox = new System.Windows.Forms.GroupBox();
            this.timerStopButton = new System.Windows.Forms.Button();
            this.timerPlayPauseButton = new System.Windows.Forms.Button();
            this.sendTimerEntryButton = new System.Windows.Forms.Button();
            this.timeLinkLabel = new System.Windows.Forms.LinkLabel();
            this.timeLabel = new System.Windows.Forms.Label();
            this.notesTextBox = new System.Windows.Forms.TextBox();
            this.taskTimer = new System.Windows.Forms.Timer(this.components);
            this.manualEntryGroupBox = new System.Windows.Forms.GroupBox();
            this.manualEntryDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.hoursNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.sendManualEntryButton = new System.Windows.Forms.Button();
            this.notesGroupBox = new System.Windows.Forms.GroupBox();
            this.mainStatusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tempoTrackerNotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.optionsButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Tags = new System.Windows.Forms.TextBox();
            this.timerEntryGroupBox.SuspendLayout();
            this.manualEntryGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hoursNumericUpDown)).BeginInit();
            this.notesGroupBox.SuspendLayout();
            this.mainStatusStrip.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // refreshButton
            // 
            this.refreshButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.refreshButton.Location = new System.Drawing.Point(252, 10);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(60, 23);
            this.refreshButton.TabIndex = 50;
            this.refreshButton.Text = "&Refresh";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // projectsComboBox
            // 
            this.projectsComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.projectsComboBox.DropDownHeight = 500;
            this.projectsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.projectsComboBox.FormattingEnabled = true;
            this.projectsComboBox.IntegralHeight = false;
            this.projectsComboBox.Location = new System.Drawing.Point(61, 12);
            this.projectsComboBox.Name = "projectsComboBox";
            this.projectsComboBox.Size = new System.Drawing.Size(185, 21);
            this.projectsComboBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Project:";
            // 
            // timerEntryGroupBox
            // 
            this.timerEntryGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.timerEntryGroupBox.Controls.Add(this.timerStopButton);
            this.timerEntryGroupBox.Controls.Add(this.timerPlayPauseButton);
            this.timerEntryGroupBox.Controls.Add(this.sendTimerEntryButton);
            this.timerEntryGroupBox.Controls.Add(this.timeLinkLabel);
            this.timerEntryGroupBox.Controls.Add(this.timeLabel);
            this.timerEntryGroupBox.Location = new System.Drawing.Point(12, 41);
            this.timerEntryGroupBox.Name = "timerEntryGroupBox";
            this.timerEntryGroupBox.Size = new System.Drawing.Size(364, 65);
            this.timerEntryGroupBox.TabIndex = 4;
            this.timerEntryGroupBox.TabStop = false;
            this.timerEntryGroupBox.Text = "Timer Entry";
            // 
            // timerStopButton
            // 
            this.timerStopButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.timerStopButton.Enabled = false;
            this.timerStopButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.timerStopButton.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.timerStopButton.Image = global::TempoTracker.Resources.Images.control_stop;
            this.timerStopButton.Location = new System.Drawing.Point(241, 19);
            this.timerStopButton.Name = "timerStopButton";
            this.timerStopButton.Size = new System.Drawing.Size(36, 36);
            this.timerStopButton.TabIndex = 3;
            this.timerStopButton.UseVisualStyleBackColor = true;
            this.timerStopButton.Click += new System.EventHandler(this.timerStopButton_Click);
            // 
            // timerPlayPauseButton
            // 
            this.timerPlayPauseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.timerPlayPauseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.timerPlayPauseButton.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.timerPlayPauseButton.Image = global::TempoTracker.Resources.Images.control_play;
            this.timerPlayPauseButton.Location = new System.Drawing.Point(199, 19);
            this.timerPlayPauseButton.Name = "timerPlayPauseButton";
            this.timerPlayPauseButton.Size = new System.Drawing.Size(36, 36);
            this.timerPlayPauseButton.TabIndex = 2;
            this.timerPlayPauseButton.UseVisualStyleBackColor = true;
            this.timerPlayPauseButton.Click += new System.EventHandler(this.timerPlayPauseButton_Click);
            // 
            // sendTimerEntryButton
            // 
            this.sendTimerEntryButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sendTimerEntryButton.Enabled = false;
            this.sendTimerEntryButton.Location = new System.Drawing.Point(283, 19);
            this.sendTimerEntryButton.Name = "sendTimerEntryButton";
            this.sendTimerEntryButton.Size = new System.Drawing.Size(75, 36);
            this.sendTimerEntryButton.TabIndex = 6;
            this.sendTimerEntryButton.Text = "Send Entry";
            this.sendTimerEntryButton.UseVisualStyleBackColor = true;
            this.sendTimerEntryButton.Click += new System.EventHandler(this.sendTimerEntryButton_Click);
            // 
            // timeLinkLabel
            // 
            this.timeLinkLabel.AutoSize = true;
            this.timeLinkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeLinkLabel.Location = new System.Drawing.Point(73, 24);
            this.timeLinkLabel.Name = "timeLinkLabel";
            this.timeLinkLabel.Size = new System.Drawing.Size(0, 24);
            this.timeLinkLabel.TabIndex = 1;
            this.timeLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.timeLinkLabel_LinkClicked);
            // 
            // timeLabel
            // 
            this.timeLabel.AutoSize = true;
            this.timeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeLabel.Location = new System.Drawing.Point(8, 24);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(58, 24);
            this.timeLabel.TabIndex = 0;
            this.timeLabel.Text = "Time:";
            // 
            // notesTextBox
            // 
            this.notesTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.notesTextBox.Location = new System.Drawing.Point(11, 19);
            this.notesTextBox.Multiline = true;
            this.notesTextBox.Name = "notesTextBox";
            this.notesTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.notesTextBox.Size = new System.Drawing.Size(347, 54);
            this.notesTextBox.TabIndex = 5;
            // 
            // taskTimer
            // 
            this.taskTimer.Interval = 1000;
            this.taskTimer.Tick += new System.EventHandler(this.taskTimer_Tick);
            // 
            // manualEntryGroupBox
            // 
            this.manualEntryGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.manualEntryGroupBox.Controls.Add(this.manualEntryDateTimePicker);
            this.manualEntryGroupBox.Controls.Add(this.label3);
            this.manualEntryGroupBox.Controls.Add(this.hoursNumericUpDown);
            this.manualEntryGroupBox.Controls.Add(this.sendManualEntryButton);
            this.manualEntryGroupBox.Location = new System.Drawing.Point(12, 267);
            this.manualEntryGroupBox.Name = "manualEntryGroupBox";
            this.manualEntryGroupBox.Size = new System.Drawing.Size(364, 50);
            this.manualEntryGroupBox.TabIndex = 6;
            this.manualEntryGroupBox.TabStop = false;
            this.manualEntryGroupBox.Text = "Manual Entry";
            // 
            // manualEntryDateTimePicker
            // 
            this.manualEntryDateTimePicker.CustomFormat = "MM/dd/yyyy";
            this.manualEntryDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.manualEntryDateTimePicker.Location = new System.Drawing.Point(118, 19);
            this.manualEntryDateTimePicker.MaxDate = new System.DateTime(2050, 12, 31, 0, 0, 0, 0);
            this.manualEntryDateTimePicker.MinDate = new System.DateTime(1979, 1, 1, 0, 0, 0, 0);
            this.manualEntryDateTimePicker.Name = "manualEntryDateTimePicker";
            this.manualEntryDateTimePicker.Size = new System.Drawing.Size(97, 20);
            this.manualEntryDateTimePicker.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Hours:";
            // 
            // hoursNumericUpDown
            // 
            this.hoursNumericUpDown.DecimalPlaces = 2;
            this.hoursNumericUpDown.Increment = new decimal(new int[] {
            25,
            0,
            0,
            131072});
            this.hoursNumericUpDown.Location = new System.Drawing.Point(46, 19);
            this.hoursNumericUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.hoursNumericUpDown.Name = "hoursNumericUpDown";
            this.hoursNumericUpDown.Size = new System.Drawing.Size(65, 20);
            this.hoursNumericUpDown.TabIndex = 1;
            // 
            // sendManualEntryButton
            // 
            this.sendManualEntryButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sendManualEntryButton.Location = new System.Drawing.Point(283, 18);
            this.sendManualEntryButton.Name = "sendManualEntryButton";
            this.sendManualEntryButton.Size = new System.Drawing.Size(75, 23);
            this.sendManualEntryButton.TabIndex = 3;
            this.sendManualEntryButton.Text = "Send Entry";
            this.sendManualEntryButton.UseVisualStyleBackColor = true;
            this.sendManualEntryButton.Click += new System.EventHandler(this.sendManualEntryButton_Click);
            // 
            // notesGroupBox
            // 
            this.notesGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.notesGroupBox.Controls.Add(this.notesTextBox);
            this.notesGroupBox.Location = new System.Drawing.Point(12, 182);
            this.notesGroupBox.Name = "notesGroupBox";
            this.notesGroupBox.Size = new System.Drawing.Size(364, 79);
            this.notesGroupBox.TabIndex = 5;
            this.notesGroupBox.TabStop = false;
            this.notesGroupBox.Text = "Notes";
            // 
            // mainStatusStrip
            // 
            this.mainStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.mainStatusStrip.Location = new System.Drawing.Point(0, 336);
            this.mainStatusStrip.Name = "mainStatusStrip";
            this.mainStatusStrip.Size = new System.Drawing.Size(388, 22);
            this.mainStatusStrip.TabIndex = 6;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // tempoTrackerNotifyIcon
            // 
            this.tempoTrackerNotifyIcon.Text = "Tempo Tracker";
            this.tempoTrackerNotifyIcon.Visible = true;
            this.tempoTrackerNotifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.tempoTrackerNotifyIcon_MouseDoubleClick);
            // 
            // optionsButton
            // 
            this.optionsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.optionsButton.Location = new System.Drawing.Point(318, 10);
            this.optionsButton.Name = "optionsButton";
            this.optionsButton.Size = new System.Drawing.Size(58, 23);
            this.optionsButton.TabIndex = 50;
            this.optionsButton.Text = "&Options";
            this.optionsButton.UseVisualStyleBackColor = true;
            this.optionsButton.Click += new System.EventHandler(this.optionsButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.Tags);
            this.groupBox1.Location = new System.Drawing.Point(15, 114);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(364, 46);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tags";
            // 
            // Tags
            // 
            this.Tags.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Tags.Location = new System.Drawing.Point(9, 19);
            this.Tags.Name = "Tags";
            this.Tags.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Tags.Size = new System.Drawing.Size(347, 20);
            this.Tags.TabIndex = 4;
            // 
            // MainForm
            // 
            this.AcceptButton = this.sendTimerEntryButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 358);
            this.Controls.Add(this.optionsButton);
            this.Controls.Add(this.mainStatusStrip);
            this.Controls.Add(this.notesGroupBox);
            this.Controls.Add(this.manualEntryGroupBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.projectsComboBox);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.timerEntryGroupBox);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(400, 292);
            this.Name = "MainForm";
            this.Text = "Tempo Tracker";
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.Shown += new System.EventHandler(this.mainForm_Shown);
            this.DoubleClick += new System.EventHandler(this.mainForm_DoubleClick);
            this.timerEntryGroupBox.ResumeLayout(false);
            this.timerEntryGroupBox.PerformLayout();
            this.manualEntryGroupBox.ResumeLayout(false);
            this.manualEntryGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hoursNumericUpDown)).EndInit();
            this.notesGroupBox.ResumeLayout(false);
            this.notesGroupBox.PerformLayout();
            this.mainStatusStrip.ResumeLayout(false);
            this.mainStatusStrip.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.ComboBox projectsComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox timerEntryGroupBox;
        private System.Windows.Forms.TextBox notesTextBox;
        private System.Windows.Forms.Timer taskTimer;
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.GroupBox manualEntryGroupBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown hoursNumericUpDown;
        private System.Windows.Forms.Button sendManualEntryButton;
        private System.Windows.Forms.GroupBox notesGroupBox;
        private System.Windows.Forms.StatusStrip mainStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.LinkLabel timeLinkLabel;
        private System.Windows.Forms.NotifyIcon tempoTrackerNotifyIcon;
        private System.Windows.Forms.Button timerPlayPauseButton;
        private System.Windows.Forms.Button timerStopButton;
        private System.Windows.Forms.Button sendTimerEntryButton;
        private System.Windows.Forms.DateTimePicker manualEntryDateTimePicker;
        private System.Windows.Forms.Button optionsButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox Tags;
    }
}

