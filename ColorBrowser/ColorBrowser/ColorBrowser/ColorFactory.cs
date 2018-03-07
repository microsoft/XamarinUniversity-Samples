using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;
using Xamarin.Forms;

namespace ColorBrowser
{
    public static class ColorFactory
    {
        public static IList<ColorModel> AllColors { get; private set; }
        
        static ColorFactory()
        {
            AllColors = new ObservableCollection<ColorModel>();

            var colorObject = new Color();

            foreach (var fieldInfo in typeof(Color).GetFields(BindingFlags.Public | BindingFlags.Static))
            {
                if(fieldInfo.GetValue(new Color()).GetType() == typeof(Color))
                {
                    var color = (Color)fieldInfo.GetValue(colorObject);
                    AllColors.Add(new ColorModel(color.R, color.G, color.B, fieldInfo.Name));
                }
            }
        }
    }
}