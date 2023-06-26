using MoodCalendar.Models;
using MoodCalendar.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MoodCalendar.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }
        Button[] emojiButtons; // Array to store the emoji buttons

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();

            // Add the emoji buttons to the array
            emojiButtons = new Button[]
            {
                emojiButton1,
                emojiButton2,
                emojiButton3,
                emojiButton4,
                emojiButton5
            };
        }

        void Button_Clicked(object sender, EventArgs e)
        {
            // Reset the background color of all emoji buttons to transparent
            foreach (var button in emojiButtons)
            {
                button.BackgroundColor = Color.Transparent;
            }

            // Set the background color of the clicked button to blue
            var clickedButton = (Button)sender;
            clickedButton.BackgroundColor = Color.Blue;
        }
    }
}