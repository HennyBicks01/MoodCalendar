using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace MoodCalendarTracker
{
    public static class GlobalVariables
    {
        public static Dictionary<DateTime, string> DateStatus { get; set; } = new Dictionary<DateTime, string>();

        // Commands
        public static ICommand GoodCommand => new Command(() => DateStatus[DateTime.Now] = "good");
        public static ICommand NeutralCommand => new Command(() => DateStatus[DateTime.Now] = "neutral");
        public static ICommand BadCommand => new Command(() => DateStatus[DateTime.Now] = "bad");
    }


}