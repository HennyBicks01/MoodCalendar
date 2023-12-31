﻿using MoodCalendarTracker.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Xamarin.Forms;

namespace MoodCalendarTracker.Views
{
    public partial class CalendarPage : ContentPage, INotifyPropertyChanged
    {

        private CalendarViewModel viewModel;

        public CalendarPage()
        {
            InitializeComponent();

            // Create the ViewModel instance and set it as the binding context
            viewModel = new CalendarViewModel();
            BindingContext = viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.RefreshCalendar();
        }

        private void BackButton_Clicked(object sender, EventArgs e)
        {
            // Go back one month
            viewModel.CurrentDate = viewModel.CurrentDate.AddMonths(-1);
        }

        private void ForwardButton_Clicked(object sender, EventArgs e)
        {
            // Go forward one month
            viewModel.CurrentDate = viewModel.CurrentDate.AddMonths(1);
        }

    }
}