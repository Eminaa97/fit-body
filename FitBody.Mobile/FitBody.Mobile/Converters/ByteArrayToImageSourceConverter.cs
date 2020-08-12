using System;
using System.Globalization;
using System.IO;
using Xamarin.Forms;

namespace FitBody.Mobile.Converters
{
    public class ByteArrayToImageSourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ImageSource retSource = null;
            if (value != null)
            {
                string base64 = value.ToString();
                if (!string.IsNullOrEmpty(base64))
                {
                    byte[] imageAsBytes = System.Convert.FromBase64String(base64);
                    retSource = ImageSource.FromStream(() => new MemoryStream(imageAsBytes));
                }
            }
            return retSource;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
