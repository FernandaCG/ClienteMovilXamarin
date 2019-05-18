using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TT_App1_SL.Helpers;
using TT_App1_SL.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TT_App1_SL
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class IniciarSesion : ContentPage
	{
        private LoginViewModel _loginViewModel = new LoginViewModel();
        public IniciarSesion ()
        { 
            InitializeComponent ();
		}

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegistrarUsuario());
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            if(Settings.accessToken.Equals(""))
            {
                await DisplayAlert("", "Nope", "Continuar");
            }
            else
            {
                await Navigation.PushAsync(new MenuDelitos());
            }
        }
    }
}