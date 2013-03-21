using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace TriTowers.DataModel
{
    class Test:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string culture)
        {
            return "aaaa";
        }
        public object ConvertBack(object value, Type targetType, object parameter, string culture)
        {
            throw new NotImplementedException();
        }
    }
}
