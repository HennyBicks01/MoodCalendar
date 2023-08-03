using MoodCalendarTracker.Models;
using MoodCalendarTracker.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static MoodCalendarTracker.ViewModels.NewItemViewModel;

namespace MoodCalendarTracker.Views
{
    public partial class NewItemPage : ContentPage
    {
        private NewItemViewModel viewModel;
        public Item Item { get; set; }

        Color pastelRed = Color.FromHex("#FF6961");
        Color pastelOrange = Color.FromHex("#FDFD96");
        Color pastelGreen = Color.FromHex("#98FB98");

        public NewItemPage(int selectedDay, int selectedMonth, int selectedYear)
        {
            InitializeComponent();
            viewModel = new NewItemViewModel(selectedDay, selectedMonth, selectedYear);
            BindingContext = viewModel;
        }


        private void OnMoodButtonClicked(object sender, EventArgs e)
        {
            if (sender is Button clickedButton)
            {
                switch (clickedButton.Text)
                {
                    case "Bad":
                        this.BackgroundColor = pastelRed;
                        break;
                    case "Neutral":
                        this.BackgroundColor = pastelOrange;
                        break;
                    case "Good":
                        this.BackgroundColor = pastelGreen;
                        break;
                }
            }
            // When a mood button is clicked, update the selected mood in the ViewModel
            Button button = (Button)sender;
            if (Enum.TryParse(button.Text, out _Mood selectedMood))
            {
                viewModel.SelectedMood = selectedMood;
            }
        }

        private void OnSaveButtonClicked(object sender, EventArgs e)
        {
            // When the Save button is clicked, execute the SaveMoodCommand in the ViewModel
            viewModel.SaveCommand.Execute(null);
        }
    }
}
