using Xamarin.Forms;

namespace Planets
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new PlanetsMasterDetail();
        }
    }
}