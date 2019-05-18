using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TT_App1_SL.Helpers;
using TT_App1_SL.Service;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TT_App1_SL
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ConfiguracionCuenta : ContentPage
	{
		public ConfiguracionCuenta ()
		{
			InitializeComponent ();
            Init();
		}

        void Init()
        {
            List<Menu> menu = new List<Menu>()
            {
                new Menu { MenuTitle = "Cambiar Contraseña"},
                new Menu { MenuTitle = "Eliminar Cuenta"},
            };

            ListMenu.ItemsSource = menu;

            ListMenu.Margin = new Thickness(0, 21, 0, 0);
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

        private async void ListMenu_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var menu = e.SelectedItem as Menu;
            if (menu != null)
            {
                ((ListView)sender).SelectedItem = null;

                if (menu.MenuTitle.Equals("Cambiar Contraseña"))
                {
                    
                }
                else if (menu.MenuTitle.Equals("Eliminar Cuenta"))
                {
                    AuthService _authService = new AuthService();
                    bool response = await DisplayAlert("", "¿Seguro que quiere dar de baja su cuenta?", "Salir", "Cancelar");
                    if (response)
                    {
                        await _authService.SuspenderCuenta(Settings.userName, Settings.accessToken);
                        await Navigation.PushAsync(new Bienvenida());
                    }
                }

            }
        }
    }
}