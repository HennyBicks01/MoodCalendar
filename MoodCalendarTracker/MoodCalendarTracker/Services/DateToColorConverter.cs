using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MoodCalendarTracker.Services
{
    public class DateToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            DateTime date = (DateTime)value;

            if (date.Date == DateTime.Now.Date)
                return Color.LightBlue; // Today's date is marked with a different color
            else if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                return Color.LightGray; // Weekends are marked with a different color
            else
                return Color.White; // Regular weekdays are marked with the default color
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
