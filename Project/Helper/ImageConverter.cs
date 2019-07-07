using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using Project.Helper;

namespace Project.Helper
{
    public class ImageConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ResimProvider resimProvaider = new ResimProvider();
            var list = resimProvaider.resimGetir();
            foreach (var item in list)
            {
                if (value.Equals(item.KisiId))
                {
                    string base64 = item.ResimAd;
                    BitmapImage bi = new BitmapImage();

                    bi.BeginInit();
                    bi.StreamSource = new MemoryStream(System.Convert.FromBase64String(base64));
                    bi.EndInit();

                    return bi;
                }

            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
