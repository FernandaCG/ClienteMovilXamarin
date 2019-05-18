using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TT_App1_SL.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TT_App1_SL
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RegistrarContactoConfianza : ContentPage
	{
		public RegistrarContactoConfianza ()
		{
			InitializeComponent ();
		}

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("", "Registro de conctacto de confianza exitoso", "Continuar");
            await Navigation.PushAsync(new MenuDelitos());
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            await DisplayAlert("", "Recuerde registrar más tarde un contacto de confianza para notifcarle, si así lo desea, su cercanía a una zona de delictiva", "Continuar");
            await Navigation.PushAsync(new MenuDelitos());

        }
    }
}