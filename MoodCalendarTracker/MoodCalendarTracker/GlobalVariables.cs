using System;
using System.Collections.Generic;

namespace MoodCalendarTracker.Models
{
    public static class GlobalVariables
    {
        public static Dictionary<DateTime, string> DateStatus { get; set; } = new Dictionary <DateTime, string>();
    }

}