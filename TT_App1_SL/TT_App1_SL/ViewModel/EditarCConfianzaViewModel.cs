using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TT_App1_SL.Helpers;
using TT_App1_SL.Model;
using TT_App1_SL.Service;
using Xamarin.Forms;

namespace TT_App1_SL.ViewModel
{
    public class EditarCConfianzaViewModel
    {
        AuthService _authService = new AuthService();
        public CConfianza contacto { get; set; }
        
        public ICommand EditCommand
        {
            get
            {
                return new Command(async() =>
                {
                    await _authService.PutCConfianza(contacto, Settings.accessToken, Settings.userName);
                    await App.Current.MainPage.DisplayAlert("Operacion exitosa", "Se ha modificado el contacto de confianza exitosamente", "OK");
                });
            }
        }
    }
}
