using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TempoTracker
{
    public partial class dateTimeEditForm : Form
    {
        public dateTimeEditForm(TimeSpan elapsed, DateTime date)
        {
            InitializeComponent();

            entryNumericUpDown.Value = (Decimal)elapsed.TotalHours;
            entryDateTimePicker.Value = date;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            ((mainForm)this.Owner).modifier = new TimeSpan(Convert.ToInt64(10000000L * 60L * 60L * entryNumericUpDown.Value));
            ((mainForm)this.Owner).date = entryDateTimePicker.Value;

            this.DialogResult = DialogResult.OK;

            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;

            this.Close();
        }
    }
}
