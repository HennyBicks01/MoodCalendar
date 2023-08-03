using MoodCalendarTracker.Models;
using MoodCalendarTracker.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MoodCalendarTracker.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        public int GoodCountMonth { get; private set; }
        public int NeutralCountMonth { get; private set; }
        public int BadCountMonth { get; private set; }

        public int GoodCountYear { get; private set; }
        public int NeutralCountYear { get; private set; }
        public int BadCountYear { get; private set; }

        public ItemsViewModel()
        {
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
        private void CalculateAverageMoods()
        {
            // Calculate the average mood for the past month
            int totalMoodsMonth = GoodCountMonth + NeutralCountMonth + BadCountMonth;
            if (totalMoodsMonth > 0)
            {
                AverageMoodMonth = (GoodCountMonth - BadCountMonth) / (double)totalMoodsMonth;
            }

            // Calculate the average mood for the past year
            int totalMoodsYear = GoodCountYear + NeutralCountYear + BadCountYear;
            if (totalMoodsYear > 0)
            {
                AverageMoodYear = (GoodCountYear - BadCountYear) / (double)totalMoodsYear;
            }
        }
    }
}