using System;
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
            ((MainForm)Owner).Modifier = new TimeSpan(Convert.ToInt64(10000000L * 60L * 60L * entryNumericUpDown.Value));
            ((MainForm)Owner).Date = entryDateTimePicker.Value;

            DialogResult = DialogResult.OK;

            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;

            Close();
        }
    }
}
