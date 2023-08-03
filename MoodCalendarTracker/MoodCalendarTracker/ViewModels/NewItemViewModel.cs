using System;
using System.Collections.Generic;
using System.Globalization;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
using static MoodCalendarTracker.ViewModels.NewItemViewModel;

namespace MoodCalendarTracker.ViewModels
{
    public class NewItemViewModel : BaseViewModel
    {
        private string description;
        private int localSelectedDay;
        private int localSelectedMonth;
        private int localSelectedYear;

        public enum _Mood { Bad, Neutral, Good };
        private _Mood selectedMood;

        public _Mood SelectedMood
        {
            get { return selectedMood; }
            set
            {
                selectedMood = value;
                OnPropertyChanged();
            }
        }

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        public ObservableCollection<string> PastEntries { get; set; } = new ObservableCollection<string>();

        public bool HasPastEntries => PastEntries.Count > 0;

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        public NewItemViewModel(int selectedDay, int selectedMonth, int selectedYear)
        {
            localSelectedDay = selectedDay;
            localSelectedMonth = selectedMonth;
            localSelectedYear = selectedYear;

            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);

            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();

            // Retrieve the past entries for the current date
            DateTime currentDate = new DateTime(localSelectedYear, localSelectedMonth, localSelectedDay);
            if (GlobalVariables.DateStatus.ContainsKey(currentDate))
            {
                var pastEntry = GlobalVariables.DateStatus[currentDate];
                PastEntries.Add($"{pastEntry.Item1}: {pastEntry.Item2}");
                OnPropertyChanged(nameof(PastEntries));
                OnPropertyChanged(nameof(HasPastEntries));
            }
        }

        public string SelectedDateMMDDYYYY => $"{DateTimeFormatInfo.CurrentInfo.GetMonthName(localSelectedMonth)} {localSelectedDay} {localSelectedYear}";

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(description);
        }

        private async void OnCancel()
        {
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            // Prepare the data to be saved
            Tuple<string, string, DateTime> dateStatus = new Tuple<string, string, DateTime>(
                SelectedMood.ToString(),
                Description,
                new DateTime(localSelectedYear, localSelectedMonth, localSelectedDay)
            );

            // Save the data
            GlobalVariables.SaveDateStatus(dateStatus);

            await Shell.Current.GoToAsync("..");
        }

    }
}
