using MoodCalendarTracker.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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
    }
}