using MoodCalendarTracker.Models;
using MoodCalendarTracker.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using static MoodCalendarTracker.ViewModels.CalendarViewModel;

namespace MoodCalendarTracker.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        private DateTime currentDate;
        public ICommand AddNewMood { get; }

        private int goodCountAll;
        public int GoodCountAll
        {
            get => goodCountAll;
            private set
            {
                if (goodCountAll != value)
                {
                    goodCountAll = value;
                    OnPropertyChanged(nameof(GoodCountAll));
                }
            }
        }

        private int neutralCountAll;
        public int NeutralCountAll
        {
            get => neutralCountAll;
            private set
            {
                if (neutralCountAll != value)
                {
                    neutralCountAll = value;
                    OnPropertyChanged(nameof(NeutralCountAll));
                }
            }
        }

        private int badCountAll;
        public int BadCountAll
        {
            get => badCountAll;
            private set
            {
                if (badCountAll != value)
                {
                    badCountAll = value;
                    OnPropertyChanged(nameof(BadCountAll));
                }
            }
        }

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

        private double averageMoodAll;
        public double AverageMoodAll
        {
            get => averageMoodAll;
            private set
            {
                if (Math.Abs(averageMoodAll - value) > 0.01)
                {
                    averageMoodAll = value;
                    OnPropertyChanged(nameof(AverageMoodAll));
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

            AddNewMood = new Command(AddTodaysMood);
        }

        public async void AddTodaysMood()
        {
            // get today's date
            currentDate = DateTime.Now;
            // Navigate to the specific view page based on the selected date
            await Application.Current.MainPage.Navigation.PushAsync(new NewItemPage(currentDate.Day, currentDate.Month, currentDate.Year));
        }

        public void CalculateMoodCounts()
        {
            // Get the current date
            DateTime currentDate = DateTime.Now;
            DateTime allAgo = currentDate.AddYears(-100);
            DateTime monthAgo = currentDate.AddMonths(-1);
            DateTime yearAgo = currentDate.AddYears(-1);

            // Reset counts
            GoodCountAll = NeutralCountAll = BadCountAll = 0;
            GoodCountMonth = NeutralCountMonth = BadCountMonth = 0;
            GoodCountYear = NeutralCountYear = BadCountYear = 0;

            // Trigger the PropertyChanged event for the mood count properties
            OnPropertyChanged(nameof(GoodCountMonth));
            OnPropertyChanged(nameof(NeutralCountMonth));
            OnPropertyChanged(nameof(BadCountMonth));
            OnPropertyChanged(nameof(GoodCountYear));
            OnPropertyChanged(nameof(NeutralCountYear));
            OnPropertyChanged(nameof(BadCountYear));
            OnPropertyChanged(nameof(GoodCountAll));
            OnPropertyChanged(nameof(NeutralCountAll));
            OnPropertyChanged(nameof(BadCountAll));

            // After calculating the counts, update the properties
            GoodCountAll = goodCountAll;
            NeutralCountAll = neutralCountAll;
            BadCountAll = badCountAll;
            GoodCountMonth = goodCountMonth;
            NeutralCountMonth = neutralCountMonth;
            BadCountMonth = badCountMonth;
            GoodCountYear = goodCountYear;
            NeutralCountYear = neutralCountYear;
            BadCountYear = badCountYear;

            foreach (var dateStatus in GlobalVariables.DateStatus)
            {
                if (dateStatus.Key >= allAgo)
                {
                    switch (dateStatus.Value.Item1)
                    {
                        case "Good":
                            GoodCountAll++;
                            break;
                        case "Neutral":
                            NeutralCountAll++;
                            break;
                        case "Bad":
                            BadCountAll++;
                            break;
                    }
                }

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
            // Calculate the average mood for the past all-time
            int totalMoodsAll = GoodCountAll + NeutralCountAll + BadCountAll;
            if (totalMoodsAll > 0)
            {
                AverageMoodAll = (GoodCountAll - BadCountAll) / (double)totalMoodsAll;
            }

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
            OnPropertyChanged(nameof(AverageMoodAll));
            OnPropertyChanged(nameof(AverageMoodMonth));
            OnPropertyChanged(nameof(AverageMoodYear));

            // After calculating the averages, update the properties
            AverageMoodAll = averageMoodAll;
            AverageMoodMonth = averageMoodMonth;
            AverageMoodYear = averageMoodYear;
        }

    }
}