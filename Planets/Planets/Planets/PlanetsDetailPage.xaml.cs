using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Planets
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlanetsDetailPage : ContentPage
    {
        public PlanetsDetailPage(Planet planet)
        {
            InitializeComponent();

            BindingContext = planet;
        }
    }
}