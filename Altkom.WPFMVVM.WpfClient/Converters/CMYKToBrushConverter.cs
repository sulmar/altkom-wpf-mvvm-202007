using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using System.Linq;

namespace Altkom.WPFMVVM.WpfClient.Converters
{
    public class CMYKToBrushConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Any(v=> v==DependencyProperty.UnsetValue))
            {
                return null;
            }

            float c = (float) (int) values[0] / 100;
            float m = (float) (int) values[1] / 100;
            float y = (float) (int) values[2] / 100;
            float k = (float) (int) values[3] / 100;

            Color color = ConvertCmykToRgb(c, m, y, k);

            return new SolidColorBrush(color);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        private static Color ConvertCmykToRgb(float c, float m, float y, float k)
        {
            int r = (int) (255 * (1 - c) * (1 - k));
            int g = (int) (255 * (1 - m) * (1 - k));
            int b = (int) (255 * (1 - y) * (1 - k));

            return Color.FromRgb((byte) r, (byte) g, (byte) b);
        }
    }
}
