using Plugin.Geolocator;
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
    public partial class MapaHomicidio : ContentPage
    {
        public MapaHomicidio()
        {
            InitializeComponent();
            Webview.Source = "http://tt2018a057.azurewebsites.net/MapaCalorHomicidio.html";
            InitializePlugin();
        }

        //protected override void OnAppearing()
        //{
        //    base.OnAppearing();
        //    this.BindingContext = new MainViewModel();
        //}

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Configuracion());
        }

        private async void InitializePlugin()
        {
            if (!CrossGeolocator.IsSupported)
            {
                await DisplayAlert("Error", "No se ha podido obtener la localización", "ok");
                return;
            }

            if (!CrossGeolocator.Current.IsGeolocationEnabled || !CrossGeolocator.Current.IsGeolocationAvailable)
            {
                await DisplayAlert("Advertencia", "Revise la configuración de su dispositivo", "ok");
                return;
            }

            CrossGeolocator.Current.PositionChanged += Current_PositionChanged;
            await CrossGeolocator.Current.StartListeningAsync(new TimeSpan(0, 0, 1), 0.5);
        }

        private void Current_PositionChanged(object sender, Plugin.Geolocator.Abstractions.PositionEventArgs e)
        {
            if (!CrossGeolocator.Current.IsListening)
            {
                return;
            }
            var position = CrossGeolocator.Current.GetPositionAsync();

            lat.Text = "Latitud: " + position.Result.Latitude.ToString();
            lon.Text = "Longitud: " + position.Result.Longitude.ToString();
        }
    }
}