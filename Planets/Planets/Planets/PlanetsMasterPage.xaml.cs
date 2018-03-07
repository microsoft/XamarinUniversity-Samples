using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System;

namespace Planets
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlanetsMasterPage : ContentPage
    {
        public event EventHandler<Planet> MasterItemSelected;

        public PlanetsMasterPage()
        {
            InitializeComponent();

            MenuItemsListView.ItemSelected += MenuItemsListViewItemSelected;

            BindingContext = PlanetDataRepository.Planets;
        }

        void MenuItemsListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            MasterItemSelected?.Invoke(sender, (Planet)e.SelectedItem);    
        }
    }
}