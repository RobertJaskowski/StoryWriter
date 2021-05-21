using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace StoryWriter.Converters
{
    class BoolToValidColorConverter : IValueConverter
    {
        Color validColor;
        Color invalidColor;

        public BoolToValidColorConverter()
        {
            validColor = Color.Green;
            invalidColor = Color.Red;
        }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(parameter is bool)) return invalidColor;

            bool result = (bool)parameter;

            return result ? validColor : invalidColor;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
             throw new NotImplementedException();
        }
    }
}
