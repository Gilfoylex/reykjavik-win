using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace UIBase.convert
{
    public class CompareToVisibility : IMultiValueConverter
    {
        private static Lazy<CompareToVisibility> lazyInstance = new Lazy<CompareToVisibility>(() => new CompareToVisibility());
        public static CompareToVisibility Instance => lazyInstance.Value;


        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                if (values[0] != null && values[1] != null)
                {
                    if (parameter == null)
                    {
                        if (values[0].ToString() == values[1].ToString())
                            return Visibility.Visible;
                    }
                    else if (parameter.ToString() == "-")
                    {
                        if (values[0].ToString() == values[1].ToString())
                            return Visibility.Collapsed;
                        else
                            return Visibility.Visible;
                    }
                }
            }
            catch { }
            return Visibility.Collapsed;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
