using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Essentials;
using Newtonsoft.Json;  // Make sure to install the Newtonsoft.Json NuGet package

namespace MoodCalendarTracker
{
    public static class GlobalVariables
    {
        // Store both the mood and description for each date
        private static Dictionary<DateTime, Tuple<string, string>> dateStatus;
        public static Dictionary<DateTime, Tuple<string, string>> DateStatus
        {
            get
            {
                if (dateStatus == null)
                {
                    // Retrieve the stored data
                    var dateStatusJson = Preferences.Get("DateStatus", string.Empty);

                    // Log the retrieved data
                    Console.WriteLine("Retrieved data: " + dateStatusJson);

                    if (string.IsNullOrEmpty(dateStatusJson))
                    {
                        // If no data is stored, initialize a new dictionary
                        dateStatus = new Dictionary<DateTime, Tuple<string, string>>();
                    }
                    else
                    {
                        // Otherwise, deserialize the stored data
                        dateStatus = JsonConvert.DeserializeObject<Dictionary<DateTime, Tuple<string, string>>>(dateStatusJson);
                    }
                }

                return dateStatus;
            }
        }

        // Command to save the mood, description, and date
        public static ICommand SaveCommand => new Command<Tuple<string, string, DateTime>>(SaveDateStatus);

        public static void SaveDateStatus(Tuple<string, string, DateTime> dateStatus)
        {
            // Save the mood and description for the date
            DateStatus[dateStatus.Item3] = new Tuple<string, string>(dateStatus.Item1, dateStatus.Item2);

            // Serialize the data
            var dateStatusJson = JsonConvert.SerializeObject(DateStatus);

            // Log the serialized data
            Console.WriteLine("Saving data: " + dateStatusJson);

            // Store the serialized data
            Preferences.Set("DateStatus", dateStatusJson);
        }


        public static Color GetMoodColor(DateTime date)
        {
            Tuple<string, string> dateStatus;
            if (DateStatus.TryGetValue(date, out dateStatus))
            {
                switch (dateStatus.Item1) // Mood is the first item in the tuple
                {
                    case "Good":
                        return Color.FromHex("#98FB98");
                    case "Neutral":
                        return Color.FromHex("#FDFD96");
                    case "Bad":
                        return Color.FromHex("#FF6961");
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
