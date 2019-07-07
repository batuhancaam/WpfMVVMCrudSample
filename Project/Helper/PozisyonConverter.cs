using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Project.Helper
{
    public class PozisyonConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            PozisyonProvider poz = new PozisyonProvider();

            var pozlar = poz.pozisyonGetir();

            foreach (var item in pozlar)
            {
                if (value.Equals(item.PozId)){


                    return item.PozAdi;

                }
              


            }
            return "Veri Yok ";

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}

