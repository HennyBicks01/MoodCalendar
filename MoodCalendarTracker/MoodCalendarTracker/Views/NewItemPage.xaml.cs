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

        public NewItemPage(int selectedDay, int selectedMonth, int selectedYear)
        {
            InitializeComponent();
            viewModel = new NewItemViewModel(selectedDay, selectedMonth, selectedYear);
            BindingContext = viewModel;
        }

        public static Color DarkenColor(Color color)
        {
            return color.MultiplyAlpha(0.7);
        }


        private void OnMoodButtonClicked(object sender, EventArgs e)
        {
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
