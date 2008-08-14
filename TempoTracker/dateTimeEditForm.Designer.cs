namespace TempoTracker
{
    partial class dateTimeEditForm
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
            this.entryNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.hoursLabel = new System.Windows.Forms.Label();
            this.dateLabel = new System.Windows.Forms.Label();
            this.entryDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.cancelButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.entryNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // entryNumericUpDown
            // 
            this.entryNumericUpDown.DecimalPlaces = 2;
            this.entryNumericUpDown.Increment = new decimal(new int[] {
            25,
            0,
            0,
            131072});
            this.entryNumericUpDown.Location = new System.Drawing.Point(62, 12);
            this.entryNumericUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.entryNumericUpDown.Name = "entryNumericUpDown";
            this.entryNumericUpDown.Size = new System.Drawing.Size(72, 20);
            this.entryNumericUpDown.TabIndex = 1;
            // 
            // hoursLabel
            // 
            this.hoursLabel.AutoSize = true;
            this.hoursLabel.Location = new System.Drawing.Point(12, 14);
            this.hoursLabel.Name = "hoursLabel";
            this.hoursLabel.Size = new System.Drawing.Size(38, 13);
            this.hoursLabel.TabIndex = 0;
            this.hoursLabel.Text = "Hours:";
            // 
            // dateLabel
            // 
            this.dateLabel.AutoSize = true;
            this.dateLabel.Location = new System.Drawing.Point(12, 46);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(33, 13);
            this.dateLabel.TabIndex = 2;
            this.dateLabel.Text = "Date:";
            // 
            // entryDateTimePicker
            // 
            this.entryDateTimePicker.CustomFormat = "MM/dd/yyyy";
            this.entryDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.entryDateTimePicker.Location = new System.Drawing.Point(62, 42);
            this.entryDateTimePicker.MaxDate = new System.DateTime(2050, 12, 31, 0, 0, 0, 0);
            this.entryDateTimePicker.MinDate = new System.DateTime(1979, 1, 1, 0, 0, 0, 0);
            this.entryDateTimePicker.Name = "entryDateTimePicker";
            this.entryDateTimePicker.Size = new System.Drawing.Size(94, 20);
            this.entryDateTimePicker.TabIndex = 3;
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(62, 68);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 4;
            this.cancelButton.Text = "&Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(143, 68);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 5;
            this.saveButton.Text = "&Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // dateTimeEditForm
            // 
            this.AcceptButton = this.saveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(281, 101);
            this.ControlBox = false;
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.entryDateTimePicker);
            this.Controls.Add(this.dateLabel);
            this.Controls.Add(this.hoursLabel);
            this.Controls.Add(this.entryNumericUpDown);
            this.Name = "dateTimeEditForm";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Edit Current Timer Entry";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.entryNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown entryNumericUpDown;
        private System.Windows.Forms.Label hoursLabel;
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.DateTimePicker entryDateTimePicker;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button saveButton;
    }
}