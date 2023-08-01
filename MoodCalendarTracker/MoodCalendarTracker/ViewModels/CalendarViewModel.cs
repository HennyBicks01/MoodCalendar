using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using static MoodCalendarTracker.Views.CalendarPage;

namespace MoodCalendarTracker.ViewModels
{
    public class CalendarViewModel : INotifyPropertyChanged
    {
        private DateTime currentDate;
        private Int32 numMonth = 0;

        public DateTime CurrentDate
        {
            get => currentDate;
            set
            {
                if (currentDate != value)
                {
                    currentDate = value;
                    OnPropertyChanged(nameof(CurrentDate));
                    // When the CurrentDate changes, update the calendar
                    numMonth = currentDate.Month;
                    InitializeCalendar(currentDate.Year, currentDate.Month);
                }
            }
        }

        public string CurrentMonthAndYear => $"{DateTimeFormatInfo.CurrentInfo.GetMonthName(CurrentDate.Month)} {CurrentDate.Year}";
        public ObservableCollection<CalendarDay> CalendarDays { get; set; } = new ObservableCollection<CalendarDay>();

        public CalendarViewModel()
        {
            // Set the initial current date to the current month and year
            CurrentDate = DateTime.Now;

        }

        private void InitializeCalendar(int year, int month)
        {
            // Clear previous calendar days
            CalendarDays.Clear();

            // Calculate the number of days in the month and the first day of the month
            int daysInMonth = DateTime.DaysInMonth(year, month);
            DateTime firstDayOfMonth = new DateTime(year, month, 1);
            int startDayOffset = (int)firstDayOfMonth.DayOfWeek;

            // Add previous month days (if any) to fill the first week
            int prevMonthDays = DateTime.DaysInMonth(year, month - 1);
            for (int i = 0; i < startDayOffset; i++)
            {
                CalendarDays.Add(new CalendarDay
                {
                    Day = prevMonthDays - startDayOffset + i + 1,
                    IsSelectable = false
                });
            }

            // Add current month days
            for (int i = 1; i <= daysInMonth; i++)
            {
                CalendarDays.Add(new CalendarDay
                {
                    Day = i,
                    IsSelectable = true
                });
            }



            // Add next month days (if any) to fill the last week
            int totalDays = startDayOffset + daysInMonth;
            int remainingDays = (int)Math.Ceiling(totalDays / 7.0) * 7 - totalDays;
            for (int i = 1; i <= remainingDays; i++)
            {
                CalendarDays.Add(new CalendarDay
                {
                    Day = i,
                    IsSelectable = false
                });
            }
        }

        public void CalendarCollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Handle the selected date
            var selectedDate = (e.CurrentSelection[0] as CalendarDay)?.Day;
            if (selectedDate != null && (bool)e.PreviousSelection[0])
            {
                // Do something with the selected date
                // For example, you could display it in a message box or navigate to another page.
                Application.Current.MainPage.DisplayAlert("Selected Date", $"{CurrentDate.Year}-{CurrentDate.Month}-{selectedDate}", "OK");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public class CalendarDay
        {
            public int Day { get; set; }
            public bool IsSelectable { get; set; }
        }
}
}