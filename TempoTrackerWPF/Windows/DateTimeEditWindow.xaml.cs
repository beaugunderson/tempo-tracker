using System;

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
        }
    }
}
