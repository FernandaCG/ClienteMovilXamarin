using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using Plugin.Permissions.Abstractions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TT_App1_SL.Helpers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TT_App1_SL
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Notificaciones : ContentPage
    {
        //List<tiempoItem> tiempos;
        bool tracking;
        int count;
        public ObservableCollection<Position> Positions { get; } = new ObservableCollection<Position>();

        public Notificaciones()
        {
            //Settings.distancia = TrackDistancia.Value;
            InitializeComponent();
            initApp();
            Debug.Write(Settings.distancia);
            Debug.Write(TrackDistancia.Value);
        }

        private void initApp()
        {
            
            if (Settings.distancia.Equals(""))
            {
                TrackDistancia.Value = 1.0;
            }
            else
            {
                TrackDistancia.Value = Convert.ToDouble(Settings.distancia);
            }

            if (Settings.tiempo.Equals(""))
            {
                TrackTimeout.Value = 10.0;
            }
            else
            {
                TrackTimeout.Value = Convert.ToDouble(Settings.tiempo);
            }
        }

        private async void ButtonTrack_Clicked(object sender, EventArgs e)
        {
            try
            {
                var hasPermission = await Utils.CheckPermissions(Permission.Location);
                if (!hasPermission)
                    return;

                if (tracking)
                {
                    CrossGeolocator.Current.PositionChanged -= CrossGeolocator_Current_PositionChanged;
                    CrossGeolocator.Current.PositionError -= CrossGeolocator_Current_PositionError;
                }
                else
                {
                    CrossGeolocator.Current.PositionChanged += CrossGeolocator_Current_PositionChanged;
                    CrossGeolocator.Current.PositionError += CrossGeolocator_Current_PositionError;
                }

                if (CrossGeolocator.Current.IsListening)
                {
                    await CrossGeolocator.Current.StopListeningAsync();
                    labelGPSTrack.Text = "Trackeo detenido";
                    ButtonTrack.Text = "Iniciar trackeo de ubicación";
                    tracking = false;
                    count = 0;
                }
                else
                {
                    Positions.Clear();
                    if (await CrossGeolocator.Current.StartListeningAsync(TimeSpan.FromSeconds(TrackTimeout.Value), TrackDistancia.Value,
                        false))
                    {   
                        labelGPSTrack.Text = "Iniciando trackeo...";
                        ButtonTrack.Text = "Detener trackeo de ubicación";
                        tracking = true;
                    }
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Excepcion", "Error", "OK");
            }
        }

        void CrossGeolocator_Current_PositionError(object sender, PositionErrorEventArgs e)
        {
            labelGPSTrack.Text = "Location error: " + e.Error.ToString();
        }

        void CrossGeolocator_Current_PositionChanged(object sender, PositionEventArgs e)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                var position = e.Position;
                Positions.Add(position);
                count++;
                LabelCount.Text = $"{count} updates";
                labelGPSTrack.Text = string.Format("Time: {0} \nLatitud: {1} \nLongitud: {2} \nAccuracy: {3} \nSpeed: {4}",
                    position.Timestamp, position.Latitude, position.Longitude,
                    position.Accuracy, position.Speed);

            });
        }

        /*async void  initApp()
        {
            try
            {
                var hasPermission = await Utils.CheckPermissions(Permission.Location);
                if (!hasPermission)
                    return;
                if (tracking)
                {
                    CrossGeolocator.Current.PositionChanged -= CrossGeolocator_Current_PositionChanged;
                    CrossGeolocator.Current.PositionError -= CrossGeolocator_Current_PositionError;
                }
                else
                {
                    CrossGeolocator.Current.PositionChanged += CrossGeolocator_Current_PositionChanged;
                    CrossGeolocator.Current.PositionError += CrossGeolocator_Current_PositionError;
                }
                if (CrossGeolocator.Current.IsListening)
                {
                    await CrossGeolocator.Current.StopListeningAsync();
                    labelGPSTrack.Text = "Trackeo detenido";
                    //ButtonTrack.Text = "Iniciar trackeo de ubicación";
                    tracking = false;
                    count = 0;
                }
                else
                {
                    Positions.Clear();
                    if (await CrossGeolocator.Current.StartListeningAsync(TimeSpan.FromSeconds(TrackTimeout.Value), 10,
                        false))
                    {
                        labelGPSTrack.Text = "Iniciando trackeo...";
                        //ButtonTrack.Text = "Detener trackeo de ubicación";
                        tracking = true;
                    }
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Excepcion", "Error", "OK");
            }
            
        tiempos = new List<tiempoItem>();
            tiempos.Add(new tiempoItem { Name = "5 minutos" });
            tiempos.Add(new tiempoItem { Name = "10 minutos" });
            tiempos.Add(new tiempoItem { Name = "20 minutos" });
            tiempos.Add(new tiempoItem { Name = "30 minutos" });
            foreach(var tiempo in tiempos)
            {
                pickerTiempo.Items.Add(tiempo.Name);
            }
        }
             private void pickerTiempo_SelectedIndexChanged(object sender, EventArgs e)
             {
                 int position = pickerTiempo.SelectedIndex;
                 if(position > -1)
                 {
                 }
             }*/

        private void Switch_Toggled_Peaton(object sender, ToggledEventArgs e)
        {
            bool isToogled = e.Value;
            labelModePeaton.Text = isToogled.ToString();
            Settings.modoPeaton = labelModePeaton.Text;
        }

        private void OnStepperValueChanged(object sender, ValueChangedEventArgs e)
        {
            //double value = e.NewValue;
            Settings.distancia = e.NewValue.ToString();
        }

        private void OnStepperValueChangedTiempo(object sender, ValueChangedEventArgs e)
        {
            //double value = e.NewValue;
            Settings.tiempo = e.NewValue.ToString();
        }
    }
}