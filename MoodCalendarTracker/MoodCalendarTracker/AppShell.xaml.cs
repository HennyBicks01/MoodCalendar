﻿using MoodCalendarTracker.ViewModels;
using MoodCalendarTracker.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace MoodCalendarTracker
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}
