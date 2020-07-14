using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace Altkom.WPFMVVM.WpfClient.Converters
{
    public class BoolToVisibilityConverter : IValueConverter
    {
        // obiekt -> kontrolka
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool isVisible = (bool)value;

            if (!isVisible)
                return Visibility.Visible;
            else
                return Visibility.Hidden;
        }

        // kontrolka -> obiekt
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
