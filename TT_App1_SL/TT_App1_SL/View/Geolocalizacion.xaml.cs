using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
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
    public partial class Geolocalizacion : ContentPage
    {
        public Geolocalizacion()
        {
            InitializeComponent();
            InitializePlugin();
        }

        private async void InitializePlugin()
        {
            if (!CrossGeolocator.IsSupported)
            {
                await DisplayAlert("Error","No se ha podido obtener la localización","ok");
                return;
            }

            if (!CrossGeolocator.Current.IsGeolocationEnabled || !CrossGeolocator.Current.IsGeolocationAvailable)
            {
               await DisplayAlert("Advertencia", "Revise la configuración de u dispositivo", "ok");
                return;
            }

            CrossGeolocator.Current.PositionChanged += Current_PositionChanged;
            await CrossGeolocator.Current.StartListeningAsync(new TimeSpan(0,0,1), 0.5);           
        }

        private void Current_PositionChanged(object sender, Plugin.Geolocator.Abstractions.PositionEventArgs e)
        {
            if (!CrossGeolocator.Current.IsListening)
            {
                return;
            }
            var position = CrossGeolocator.Current.GetPositionAsync();

            lat.Text = position.Result.Latitude.ToString();
            lon.Text = position.Result.Longitude.ToString();
            //Llamar modelview de cercania

        }
    }
}