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
    public partial class RegistrarUsuario : ContentPage
	{
        public RegistrarUsuario ()
		{
			InitializeComponent ();
		}

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("","Registro de usuario exitoso","Continuar");
            await Navigation.PushAsync(new RegistrarContactoConfianza());           
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new IniciarSesion());
        }
    }
}