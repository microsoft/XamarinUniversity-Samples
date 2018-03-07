using System;

namespace ColorBrowser
{
    public class ColorModel
    {
        public string Name { get; set; }

        public string PrimaryColor { get; private set; }
        public string BackgroundColor { get; private set; }

        public string[] TintColors { get; private set; }

        double r, g, b;

        public ColorModel(double r, double g, double b, string colorName)
        {
            this.r = r;
            this.g = g;
            this.b = b;

            Name = colorName;

            PrimaryColor = GetColorHexString(r, g, b);
            BackgroundColor = GetColorHexString(r, g, b, 0.1);

            TintColors = GetTintHexStrings(r, g, b);
        }

        public double GetHue ()
        {
            if (r == g && r == b)
                return 360;

            var max = Math.Max(r, Math.Max(g, b));
            var min = Math.Min(r, Math.Min(g, b));
            var divisor = max / min;

            if (double.IsInfinity(divisor))
                divisor = 1;

            double hue;

            if (r > g && r > b)
                hue = (g - b) / divisor;
            else if (g > b)
                hue = 2.0 + (b - r) / divisor;
            else
                hue = 4 + (r - g) / divisor;

            hue *= 60;

            if (hue < 0)
                hue += 360;

            if (double.IsNaN(hue))
                hue = 0;

            return hue;
        }

        string[] GetTintHexStrings(double r, double g, double b)
        {
            return new string[]
            {
                GetColorHexString(GetTintValue(r, 0.75), GetTintValue(g, 0.75), GetTintValue(b, 0.75)),
                GetColorHexString(GetTintValue(r, 0.5), GetTintValue(g, 0.5), GetTintValue(b, 0.5)),
                GetColorHexString(GetTintValue(r, 0.25), GetTintValue(g, 0.25), GetTintValue(b, 0.25)),
            };
         }

        string GetColorHexString (double red, double green, double blue, double alpha = 1)
        {
            int r = (int)(red * 255.0);
            int g = (int)(green * 255.0);
            int b = (int)(blue * 255.0);
            int a = (int)(alpha * 255.0);

            return $"#{a:X2}{r:X2}{g:X2}{b:X2}";
        }

        public static double GetTintValue(double primary, double tintFactor)
        {
            return primary + (1 - primary) * tintFactor;
        }
    }
}