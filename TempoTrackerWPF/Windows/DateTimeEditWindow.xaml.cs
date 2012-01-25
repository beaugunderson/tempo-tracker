using System;
using System.Windows;

namespace TempoTrackerWPF.Windows
{
    /// <summary>
    /// Interaction logic for DateTimeEditWindow.xaml
    /// </summary>
    public partial class DateTimeEditWindow
    {
        private MainWindow MainWindow { get; set; }

        public DateTimeEditWindow()
        {
            InitializeComponent();
        }

        public DateTimeEditWindow(MainWindow mainWindow, TimeSpan elapsed, DateTime date)
        {
            InitializeComponent();

            MainWindow = mainWindow;

            entryDecimalUpDown.Value = (Decimal)elapsed.TotalHours;
            entryDatePicker.SelectedDate = date;
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            if (entryDatePicker.SelectedDate.HasValue)
            {
                MainWindow.Date = entryDatePicker.SelectedDate.Value;
            }
            else
            {
                MessageBox.Show("Please select a date.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                return;
            }

            MainWindow.Modifier = new TimeSpan(Convert.ToInt64(10000000L * 60L * 60L * entryDecimalUpDown.Value));

            DialogResult = true;

            Close();
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;

            Close();
        }
    }
}