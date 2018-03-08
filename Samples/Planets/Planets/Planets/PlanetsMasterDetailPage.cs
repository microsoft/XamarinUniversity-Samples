using Xamarin.Forms;

namespace Planets
{
    public class PlanetsMasterDetail : MasterDetailPage
    {
        public PlanetsMasterDetail()
        {
            var master = new PlanetsMasterPage();
            Master = master;

            master.MasterItemSelected += MasterItemSelected;

            MasterItemSelected(this, PlanetDataRepository.GetPlanetFromId(0));
        }

        void MasterItemSelected(object sender, Planet e)
        {
            Detail = new NavigationPage (new PlanetsDetailPage(e));
            IsPresented = false;
        }
    }
}