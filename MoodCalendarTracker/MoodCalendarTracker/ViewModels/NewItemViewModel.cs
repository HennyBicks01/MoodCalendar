using MoodCalendarTracker.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Text;
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
        public ObservableCollection<string> PastEntries { get; set; } = new ObservableCollection<string>();

        public bool HasPastEntries => PastEntries.Count > 0;

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

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }


        public NewItemViewModel(int selectedDay, int selectedMonth, int selectedYear)
        {

            // connected the local variable here with the variable that was fed into this viewModel

            localSelectedDay = selectedDay;
            localSelectedMonth = selectedMonth;
            localSelectedYear = selectedYear;

            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        public string SelectedDateMMDDYYYY => $"{DateTimeFormatInfo.CurrentInfo.GetMonthName(localSelectedMonth)} {localSelectedDay} {localSelectedYear}";

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(description);
        }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private void OnSave()
        {
            Console.WriteLine($"Selected Mood: {SelectedMood}");

            // Save to global variables
            var dateStatus = new Tuple<string, string, DateTime>(SelectedMood.ToString(), Description, new DateTime(localSelectedYear, localSelectedMonth, localSelectedDay));
            GlobalVariables.SaveCommand.Execute(dateStatus);

            // This will pop the current page off the navigation stack
            Shell.Current.GoToAsync("..");
        }


    }
}
