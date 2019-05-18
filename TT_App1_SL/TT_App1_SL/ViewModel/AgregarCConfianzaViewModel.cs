using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using TT_App1_SL.Helpers;
using TT_App1_SL.Model;
using TT_App1_SL.Service;
using Xamarin.Forms;

namespace TT_App1_SL.ViewModel
{
    public class AgregarCConfianzaViewModel
    {
        AuthService _authService = new AuthService();
        public String nombre { get; set; }
        public String apellitoPat { get; set; }
        public String apellidoMat { get; set; }
        public String celular { get; set; }

        public ICommand AddCommandC
        {
            get
            {
                return new Command(async () =>
               {
                   
                   var contactoEdit = new CConfianza
                   {
                       nombre = nombre,
                       apellitoPat = apellitoPat,
                       apellidoMat = apellidoMat,
                       celular = celular
                   };
                   await _authService.PostCConfianza(contactoEdit, Settings.userName, Settings.accessToken);
                   await App.Current.MainPage.DisplayAlert("Operacion exitosa", "Se ha registrado el contacto de confianza exitosamente", "OK");

               });
            }
        }

        public ICommand GetCiudadano
        {
            get
            {
                return new Command(async () =>
                {
                    var ciudadanoActual = await _authService.GetCiudadano(Settings.accessToken, Settings.userName);
                    Debug.WriteLine("Ciudadano1" + ciudadanoActual);
                });
            }
        }
    }
}
