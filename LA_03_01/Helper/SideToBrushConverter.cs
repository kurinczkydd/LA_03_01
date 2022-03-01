using LA_03_01.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace LA_03_01.Helper
{
    public class SideToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            side s = (side)value;
            if (s == side.Good)
                return Brushes.LightGreen;
            else if (s == side.Bad)
                return Brushes.Salmon;
            else
                return Brushes.Khaki;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
