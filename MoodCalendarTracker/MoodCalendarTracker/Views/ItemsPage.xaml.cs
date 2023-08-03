using MoodCalendarTracker.Models;
using MoodCalendarTracker.ViewModels;
using MoodCalendarTracker.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MoodCalendarTracker.Views
{
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel _viewModel;

        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new ItemsViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            // Assuming your ItemsViewModel is stored in a variable named ViewModel
            _viewModel.CalculateMoodCounts();
            _viewModel.CalculateAverageMoods();
        }
    }
}