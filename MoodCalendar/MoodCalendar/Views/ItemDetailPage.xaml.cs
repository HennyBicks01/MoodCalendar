using MoodCalendar.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace MoodCalendar.Views
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