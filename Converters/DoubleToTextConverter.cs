using System.Globalization;
using System.Windows.Data;

namespace LazyApiPack.Wpf.Utils.Converters
{
    public class DoubleToTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value?.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
