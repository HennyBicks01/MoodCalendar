using MoodCalendarTracker.Models;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MoodCalendarTracker.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        // Existing code...

        public int GoodCountMonth { get; private set; }
        public int NeutralCountMonth { get; private set; }
        public int BadCountMonth { get; private set; }

        public int GoodCountYear { get; private set; }
        public int NeutralCountYear { get; private set; }
        public int BadCountYear { get; private set; }

        public ItemDetailViewModel() // Existing parameters...
        {
            // Existing code...

            // Get the counts for the past month and year
            CalculateMoodCounts();
        }

        private void CalculateMoodCounts()
        {
            // Get the current date
            DateTime currentDate = DateTime.Now;
            DateTime monthAgo = currentDate.AddMonths(-1);
            DateTime yearAgo = currentDate.AddYears(-1);

            // Reset counts
            GoodCountMonth = NeutralCountMonth = BadCountMonth = 0;
            GoodCountYear = NeutralCountYear = BadCountYear = 0;

            foreach (var dateStatus in GlobalVariables.DateStatus)
            {
                if (dateStatus.Key >= monthAgo)
                {
                    switch (dateStatus.Value.Item1)
                    {
                        case "Good":
                            GoodCountMonth++;
                            break;
                        case "Neutral":
                            NeutralCountMonth++;
                            break;
                        case "Bad":
                            BadCountMonth++;
                            break;
                    }
                }

                if (dateStatus.Key >= yearAgo)
                {
                    switch (dateStatus.Value.Item1)
                    {
                        case "Good":
                            GoodCountYear++;
                            break;
                        case "Neutral":
                            NeutralCountYear++;
                            break;
                        case "Bad":
                            BadCountYear++;
                            break;
                    }
                }
            }
        }
    }
}
