using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TT_App1_SL.Helpers;
using TT_App1_SL.Model;
using TT_App1_SL.Service;
using TT_App1_SL.View;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TT_App1_SL
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Configuracion : ContentPage
    {
        public Configuracion()
        {
            InitializeComponent();
            Init();
        }

        void Init()
        {
            List<Menu> menu = new List<Menu>()
            {
                new Menu { MenuTitle = "Notificaciones"},
                new Menu { MenuTitle = "Configuración Contacto de Confianza"},
                new Menu { MenuTitle = "Configurar cuenta"},
                new Menu { MenuTitle = "Ayuda"},
                new Menu { MenuTitle = "Acerca de"},
                new Menu { MenuTitle = "CERCANIAAA"},
                new Menu { MenuTitle = "LAOTRAOPCION"},
                new Menu { MenuTitle = "Cerrar Sesión"}
                
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

                if (menu.MenuTitle.Equals("Notificaciones"))
                {
                    await Navigation.PushAsync(new Notificaciones());
                }
                else if (menu.MenuTitle.Equals("Configuración Contacto de Confianza"))
                {
                    await Navigation.PushAsync(new ContactoConfianza());
                }
                else if (menu.MenuTitle.Equals("Configurar cuenta"))
                {
                    await Navigation.PushAsync(new ConfiguracionCuenta());
                }
                else if (menu.MenuTitle.Equals("Ayuda"))
                {
                    await Navigation.PushAsync(new Ayuda());
                }
                else if (menu.MenuTitle.Equals("Acerca de"))
                {
                    await Navigation.PushAsync(new Acerca());
                }
                else if (menu.MenuTitle.Equals("CERCANIAAA"))
                {
                    await Navigation.PushAsync(new Cercania());
                }
                else if (menu.MenuTitle.Equals("LAOTRAOPCION"))
                {
                    AuthService _authService = new AuthService();
                    var cc = await _authService.GetContactoConfianza(Settings.userName, Settings.accessToken);
                    if (cc == null)
                    {
                        //modificar en el mismo menú al form editar o agregar
                        await Navigation.PushAsync(new ContactoConfianza());
                    }
                    else
                    {
                        await Navigation.PushAsync(new EditCConfianza(cc));
                    }
                }
                else if (menu.MenuTitle.Equals("Cerrar Sesión"))
                {
                    bool response = await DisplayAlert("", "¿Seguro que quiere cerrar la sesión?", "Salir", "Cancelar");
                    if (response)
                    {
                        Settings.accessToken = null;
                        Settings.userName = null;
                        Settings.password = null;
                        await Navigation.PushAsync(new Bienvenida());
                    }
                }

            }
        }

    }
}