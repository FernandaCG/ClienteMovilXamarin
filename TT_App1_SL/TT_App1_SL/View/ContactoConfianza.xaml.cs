using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TT_App1_SL.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TT_App1_SL
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ContactoConfianza : ContentPage
	{
        internal string nombre;
        internal string apellitoPat;
        internal string apellidoMat;
        internal string celular;
        internal Ciudadano ciudadano;

        public ContactoConfianza ()
		{
			InitializeComponent ();
            Init();
		}

        void Init()
        {
            List<Menu> menu = new List<Menu>()
            {
                new Menu { MenuTitle = "Agregar o cambiar Contacto de Confianza"}
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

        private void ListMenu_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var menu = e.SelectedItem as Menu;
            if (menu != null)
            {
                ((ListView)sender).SelectedItem = null;

                if (menu.MenuTitle.Equals("Agregar o cambiar Contacto de Confianza"))
                {
                    Navigation.PushAsync(new RegistrarContactoConfianza());
                }

            }
        }

        private void Switch_Toggled_SMS(object sender, ToggledEventArgs e)
        {
            bool isToogled = e.Value;
            labelSMS.Text = isToogled.ToString();
        }

    }
}