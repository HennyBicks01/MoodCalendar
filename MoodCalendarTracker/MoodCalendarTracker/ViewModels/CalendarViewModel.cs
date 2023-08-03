using MoodCalendarTracker.Views;
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

        public ICommand DateSelectedCommand { get; }

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
                    InitializeCalendar(currentDate.Year, currentDate.Month);

                    // Update the CurrentMonthAndYear property
                    OnPropertyChanged(nameof(CurrentMonthAndYear));
                }
            }
        }

        public string CurrentMonthAndYear => $"{DateTimeFormatInfo.CurrentInfo.GetMonthName(CurrentDate.Month)} {CurrentDate.Year}";
        public ObservableCollection<CalendarDay> CalendarDays { get; set; } = new ObservableCollection<CalendarDay>();

        public CalendarViewModel()
        {
            // Set the initial current date to the current month and year
            CurrentDate = DateTime.Now;

            DateSelectedCommand = new Command<CalendarDay>(OnDateSelected);
        }

        private async void OnDateSelected(CalendarDay selectedDay)
        {
            // Handle the selected date
            if (selectedDay != null && selectedDay.IsSelectable)
            {
                // Navigate to the specific view page based on the selected date
                await Application.Current.MainPage.Navigation.PushAsync(new NewItemPage(selectedDay.Day, CurrentDate.Month, currentDate.Year));
            }
        }

        private void InitializeCalendar(int year, int month)
        {
            // BENTODO: contact DB for dates that already have moods; change the color of the squares based on this; access through DateTime?

            // Check if going past December
            if (month > 12)
            {
                year++;
                month = 1; // Move to January of the next year
            }
            // Check if going past January
            else if (month < 1)
            {
                year--;
                month = 12; // Move to December of the previous year
            }

            // Update the CurrentDate with the adjusted date
            CurrentDate = new DateTime(year, month, 1);

            // Clear the current calendar days
            CalendarDays.Clear();

            // Calculate the first and last days of the month
            DateTime firstDayOfMonth = new DateTime(year, month, 1);
            DateTime lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);

            // Calculate the number of days in the previous month
            int daysInPreviousMonth = DateTime.DaysInMonth(firstDayOfMonth.AddMonths(-1).Year, firstDayOfMonth.AddMonths(-1).Month);

            // Add the previous month days to the calendar
            for (int i = firstDayOfMonth.DayOfWeek == DayOfWeek.Sunday ? 6 : (int)firstDayOfMonth.DayOfWeek - 1; i >= 0; i--)
            {
                CalendarDays.Add(new CalendarDay { Day = daysInPreviousMonth - i, IsSelectable = false });
            }

            // Add the current month days to the calendar
            for (int i = 1; i <= lastDayOfMonth.Day; i++)
            {
                CalendarDays.Add(new CalendarDay { Day = i, IsSelectable = true });
            }

            // Add the next month days to the calendar
            int totalDays = CalendarDays.Count;
            int remainingDays = 42 - totalDays;
            for (int i = 1; i <= remainingDays; i++)
            {
                CalendarDays.Add(new CalendarDay { Day = i, IsSelectable = false });
            }

            // Notify that the CalendarDays collection has changed
            OnPropertyChanged(nameof(CalendarDays));
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
            public Color MoodColor { get; set; } = Color.White; // Default color for dates without a mood

        }
    }
}