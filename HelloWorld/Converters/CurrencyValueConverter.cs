using System;
using System.Globalization;
using MvvmCross.Platform.Converters;

namespace HelloWorld.Converters
{
    public class CurrencyValueConverter : MvxValueConverter<double, string>
    {
        protected override string Convert(double value, Type targetType, object parameter, CultureInfo culture)
        {
            return value + " $";
        }
    }
}
