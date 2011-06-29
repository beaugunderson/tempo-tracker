using System;

namespace TempoTracker.Utilities
{
    public static class Time
    {
        public static string FuzzyFormat(double seconds)
        {
            if (seconds < 60)
            {
                return string.Format("{0:N0} seconds", Math.Round(seconds, 0));
            }

            if (seconds < 3600)
            {
                return string.Format("{0:N2} minutes", Math.Round(seconds / 60, 2));
            }

            return string.Format("{0:N3} hours", Math.Round(seconds / 3600, 3));
        }

        public static string Format(TimeSpan timeSpan)
        {
            var dateTime = DateTime.MinValue.Add(timeSpan);

            return dateTime.ToString("H:mm:ss");
        }
    }
}
