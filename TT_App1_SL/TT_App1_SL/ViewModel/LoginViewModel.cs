using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TT_App1_SL.Helpers;
using TT_App1_SL.Service;
using Xamarin.Forms;

namespace TT_App1_SL.ViewModel
{
    public class LoginViewModel
    {
        private AuthService _authService = new AuthService();
        public string username { get; set; }
        public string password { get; set; }

        public ICommand LoginCommand
        {
            get
            {
                return new Command(async() =>
                {
                   var accessToken=  await _authService.LoginAsync(username, password);
                    Settings.userName = username;
                    Settings.password = password;
                    Settings.accessToken = accessToken;
                    if(Settings.accessToken.Equals(""))
                    {
                        await App.Current.MainPage.DisplayAlert("Error", "Verifica tu usuario y contraseña", "OK");
                    }
                    else
                    {
                        await App.Current.MainPage.Navigation.PushAsync(new MenuDelitos());
                    }
                });
            }
        }
    }
}
