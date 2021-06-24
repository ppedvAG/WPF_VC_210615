using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Data;

namespace MVVM.Converter
{
    public class GenderLocalisationConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (Thread.CurrentThread.CurrentUICulture.Name == "en-US")
            {
                switch (value)
                {
                    case Gender.Männlich:
                        return "Male";
                    case Gender.Weiblich:
                        return "Female";
                    case Gender.Divers:
                        return "Diverse";
                    default:
                        return null;
                }
            }
            else
                return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
