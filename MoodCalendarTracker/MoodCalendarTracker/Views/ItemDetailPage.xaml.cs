using MoodCalendarTracker.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace MoodCalendarTracker.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}