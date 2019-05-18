using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TT_App1_SL
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuDelitos : MasterDetailPage
    {
        public MenuDelitos()
        {
            InitializeComponent();
            Init();
        }

        void Init()
        {
            List<Menu> menu = new List<Menu>()
            {
                new Menu { MenuTitle = "Homicidio doloso"},
                new Menu { MenuTitle = "Robo a casa habitación con violencia"},
                new Menu { MenuTitle = "Robo a negocio con violencia"},
                new Menu { MenuTitle = "Robo a pasajero en transporte público colectivo con y sin violencia"},
                new Menu { MenuTitle = "Robo a transeunte en via publica con y sin violencia"},
                new Menu { MenuTitle = "Robo de vehículo con y sin violencia"},
                new Menu { MenuTitle = "Violación"}
            };

            ListMenu.ItemsSource = menu;

            ListMenu.Margin = new Thickness(0, 21, 0, 0);

            Detail = new NavigationPage(new MapaHomicidio());
        }

        public class Menu
        {
            public string MenuTitle
            {
                get;
                set;
            }

            public string MenuDetail
            {
                get;
                set;
            }
        }

        private void ListMenu_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var menu = e.SelectedItem as Menu;
            if (menu != null)
            {
                ((ListView)sender).SelectedItem = null;

                if (menu.MenuTitle.Equals("Homicidio doloso"))
                {
                    Detail = new NavigationPage(new MapaHomicidio());
                    IsPresented = false;
                }
                else if (menu.MenuTitle.Equals("Robo a casa habitación con violencia"))
                {
                    Detail = new NavigationPage(new MapaRoboCasa());
                    IsPresented = false;
                }
                else if (menu.MenuTitle.Equals("Robo a negocio con violencia"))
                {
                    Detail = new NavigationPage(new MapaRoboNegocio());
                    IsPresented = false;
                }
                else if (menu.MenuTitle.Equals("Robo a pasajero en transporte público colectivo con y sin violencia"))
                {
                    Detail = new NavigationPage(new MapaRoboTransporte());
                    IsPresented = false;
                }
                else if (menu.MenuTitle.Equals("Robo a transeunte en via publica con y sin violencia"))
                {
                    Detail = new NavigationPage(new MapaRoboTranseunte());
                    IsPresented = false;
                }
                else if (menu.MenuTitle.Equals("Robo de vehículo con y sin violencia"))
                {
                    Detail = new NavigationPage(new MapaRoboVehiculo());
                    IsPresented = false;
                }
                else if (menu.MenuTitle.Equals("Violación"))
                {
                    Detail = new NavigationPage(new MapaViolacion());
                    IsPresented = false;
                }
            }
        }
    }
}