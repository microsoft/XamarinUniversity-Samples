using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ColorBrowser
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();

            var collection = ColorFactory.AllColors.OrderBy(c => c.Name);

            BindingContext = collection;

            listColors.ItemTapped += ListColorsItemTapped;
		}

        async void ListColorsItemTapped(object sender, ItemTappedEventArgs e)
        {
            var color = e.Item as ColorModel;

            await this.Navigation.PushAsync(new ColorDetails(color));
        }
    }
}