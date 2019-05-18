using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TT_App1_SL.Helpers;
using TT_App1_SL.Service;
using Xamarin.Forms;

namespace TT_App1_SL.ViewModel
{
    public class RegistrarViewModel
    {
        private AuthService _authService = new AuthService();

        public String nombre { get; set; }
        public String apellitoPat { get; set; }
        public String apellidoMat { get; set; }
        public DateTime fechaNac { get; set; }
        public String userName { get; set; }
        public String celular { get; set; }
        public String password { get; set; }

        public string Message { get; set; }

        public ICommand RegistrarCommand
        {
            get
            {
                return new Command(async() =>
                {
                    var isSuccess = await _authService.RegistrarAsync(nombre, apellitoPat, apellidoMat, fechaNac, userName, password, celular);
                    
                    if (isSuccess.Equals("Ok"))
                    {
                        Settings.userName = userName;
                        Settings.password = password;
                        await App.Current.MainPage.DisplayAlert("Operacion exitosa", "Se ha registrado el ciudadano exitosamente", "OK");
                        await App.Current.MainPage.Navigation.PushAsync(new RegistrarContactoConfianza());
                    }
                    else if (isSuccess.Equals("Celular"))
                    {
                        await App.Current.MainPage.DisplayAlert("Error", "Celular ya existente, registre un celular diferente para su cuenta", "OK");
                    }
                    else if (isSuccess.Equals("Usuario"))
                    {
                        await App.Current.MainPage.DisplayAlert("Error", "Celular ya existente, registre un celular diferente para su cuenta", "OK");
                    }
                    else
                    {
                        await App.Current.MainPage.DisplayAlert("Error", "Se ha producido un error, verifica tu conexión o intenta más tarde", "OK");
                    }
                });
            }
        }
    }
}
