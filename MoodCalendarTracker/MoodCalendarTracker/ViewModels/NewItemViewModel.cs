using MoodCalendarTracker.Models;
using System;
using System.Collections.Generic;
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

        private async void OnSave()
        {
            Console.WriteLine($"Selected Mood: {SelectedMood}");
            //Item newItem = new Item()
            //{
            //    Id = Guid.NewGuid().ToString(),
            //    Description = Description
            //};

            //await DataStore.AddItemAsync(newItem);

            //// This will pop the current page off the navigation stack
            //await Shell.Current.GoToAsync("..");
        }
    }
}
