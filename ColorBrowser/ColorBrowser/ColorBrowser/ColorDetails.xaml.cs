using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ColorBrowser
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ColorDetails : ContentPage
	{
        ColorModel color;
        public ColorDetails (ColorModel color)
		{
            BindingContext = this.color = color;

            InitializeComponent ();

            NavigationPage.SetTitleIcon(this, (FileImageSource)FileImageSource.FromFile("brush.png"));

            sliderTint.ValueChanged += SliderTintValueChanged;
		}

        void SliderTintValueChanged(object sender, ValueChangedEventArgs e)
        {
            var xfColor = Color.FromHex(color.PrimaryColor);
            var tintAmount = e.NewValue / 100;

            var r = ColorModel.GetTintValue(xfColor.R, tintAmount);
            var g = ColorModel.GetTintValue(xfColor.G, tintAmount);
            var b = ColorModel.GetTintValue(xfColor.B, tintAmount);

            boxTint.Color = Color.FromRgb(r, g, b);
            lblTintColor.Text = boxTint.Color.ToString();
        }
    }
}