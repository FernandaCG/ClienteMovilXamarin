using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Messaging;

namespace TT_App1_SL
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EnviarSMS : ContentPage
    {
        public EnviarSMS()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            bool response = await DisplayAlert("Alerta", "¿Desea notificarle a su contacto de confianza por medio de un sms sobre su ubicación actual?", "Notificar", "Cancelar");
            if (response)
            {
                var smsMessenger = CrossMessaging.Current.SmsMessenger;
                if (smsMessenger.CanSendSmsInBackground)
                    smsMessenger.SendSmsInBackground("+525531907395", "Hola, me encuentro cerca de una zona de peligro");
                //Poner 1 o no despues del 52
            }
        }
    }
}