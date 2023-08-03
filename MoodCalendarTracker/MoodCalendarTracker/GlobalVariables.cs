using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace MoodCalendarTracker
{
    public static class GlobalVariables
    {
        // Store both the mood and description for each date
        public static Dictionary<DateTime, Tuple<string, string>> DateStatus { get; set; } = new Dictionary<DateTime, Tuple<string, string>>();

        // Command to save the mood, description, and date
        public static ICommand SaveCommand => new Command<Tuple<string, string, DateTime>>(SaveDateStatus);

        private static void SaveDateStatus(Tuple<string, string, DateTime> dateStatus)
        {
            // Save the mood and description for the date
            DateStatus[dateStatus.Item3] = new Tuple<string, string>(dateStatus.Item1, dateStatus.Item2);
        }

        public static Color GetMoodColor(DateTime date)
        {
            Tuple<string, string> dateStatus;
            if (DateStatus.TryGetValue(date, out dateStatus))
            {
                switch (dateStatus.Item1) // Mood is the first item in the tuple
                {
                    case "Good":
                        return Color.Green;
                    case "Neutral":
                        return Color.Yellow;
                    case "Bad":
                        return Color.Red;
                    default:
                        return Color.White; // Default color
                }
            }
            else
            {
                return Color.White; // Default color for dates without a mood
            }
        }
    }
}
