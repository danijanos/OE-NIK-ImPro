using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace OE.NIK.ImPro.Logic.UI.Converters
{
    /// <inheritdoc />
    /// <summary>
    /// Class to convert string source path into Image objects
    /// </summary>
    public class SourceToImageConverter : IValueConverter
    {
        /// <inheritdoc />
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return "";
            var image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri(value as string);
            image.EndInit();            
            return image;
        }

        /// <inheritdoc />
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
