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
        private int goodCountMonth;
        public int GoodCountMonth
        {
            get => goodCountMonth;
            private set
            {
                if (goodCountMonth != value)
                {
                    goodCountMonth = value;
                    OnPropertyChanged(nameof(GoodCountMonth));
                }
            }
        }

        // Similar changes for other properties...

        private int neutralCountMonth;
        public int NeutralCountMonth
        {
            get => neutralCountMonth;
            private set
            {
                if (neutralCountMonth != value)
                {
                    neutralCountMonth = value;
                    OnPropertyChanged(nameof(NeutralCountMonth));
                }
            }
        }

        private int badCountMonth;
        public int BadCountMonth
        {
            get => badCountMonth;
            private set
            {
                if (badCountMonth != value)
                {
                    badCountMonth = value;
                    OnPropertyChanged(nameof(BadCountMonth));
                }
            }
        }

        private int goodCountYear;
        public int GoodCountYear
        {
            get => goodCountYear;
            private set
            {
                if (goodCountYear != value)
                {
                    goodCountYear = value;
                    OnPropertyChanged(nameof(GoodCountYear));
                }
            }
        }

        private int neutralCountYear;
        public int NeutralCountYear
        {
            get => neutralCountYear;
            private set
            {
                if (neutralCountYear != value)
                {
                    neutralCountYear = value;
                    OnPropertyChanged(nameof(NeutralCountYear));
                }
            }
        }

        private int badCountYear;
        public int BadCountYear
        {
            get => badCountYear;
            private set
            {
                if (badCountYear != value)
                {
                    badCountYear = value;
                    OnPropertyChanged(nameof(BadCountYear));
                }
            }
        }

        private double averageMoodMonth;
        public double AverageMoodMonth
        {
            get => averageMoodMonth;
            private set
            {
                if (Math.Abs(averageMoodMonth - value) > 0.01)
                {
                    averageMoodMonth = value;
                    OnPropertyChanged(nameof(AverageMoodMonth));
                }
            }
        }

        private double averageMoodYear;
        public double AverageMoodYear
        {
            get => averageMoodYear;
            private set
            {
                if (Math.Abs(averageMoodYear - value) > 0.01)
                {
                    averageMoodYear = value;
                    OnPropertyChanged(nameof(AverageMoodYear));
                }
            }
        }

        public ItemsViewModel()
        {
            // Get the counts for the past month and year
            CalculateMoodCounts();
        }

        public void CalculateMoodCounts()
        {
            // Get the current date
            DateTime currentDate = DateTime.Now;
            DateTime monthAgo = currentDate.AddMonths(-1);
            DateTime yearAgo = currentDate.AddYears(-1);

            // Reset counts
            GoodCountMonth = NeutralCountMonth = BadCountMonth = 0;
            GoodCountYear = NeutralCountYear = BadCountYear = 0;

            // Trigger the PropertyChanged event for the mood count properties
            OnPropertyChanged(nameof(GoodCountMonth));
            OnPropertyChanged(nameof(NeutralCountMonth));
            OnPropertyChanged(nameof(BadCountMonth));
            OnPropertyChanged(nameof(GoodCountYear));
            OnPropertyChanged(nameof(NeutralCountYear));
            OnPropertyChanged(nameof(BadCountYear));

            // After calculating the counts, update the properties
            GoodCountMonth = goodCountMonth;
            NeutralCountMonth = neutralCountMonth;
            BadCountMonth = badCountMonth;
            GoodCountYear = goodCountYear;
            NeutralCountYear = neutralCountYear;
            BadCountYear = badCountYear;

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
        public void CalculateAverageMoods()
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

            // Trigger the PropertyChanged event for the average mood properties
            OnPropertyChanged(nameof(AverageMoodMonth));
            OnPropertyChanged(nameof(AverageMoodYear));

            // After calculating the averages, update the properties
            AverageMoodMonth = averageMoodMonth;
            AverageMoodYear = averageMoodYear;
        }
    }
}