using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TT_App1_SL.Helpers;
using TT_App1_SL.Service;
using Xamarin.Forms;

namespace TT_App1_SL.ViewModel
{
    public class CercaniaViewModel
    {
        AuthService _authService = new AuthService();
        public ICommand Cercania
        {
            get
            {
                return new Command(async () =>
                {
                    var dist = "0.02";
                    var punto = "-99.0454845 19.426065";
                    var cercania = await _authService.Cercania( dist, punto, Settings.userName, Settings.accessToken);
                    if (cercania.Equals("true"))
                    {
                        await App.Current.MainPage.DisplayAlert("ALERTA", "Se ha detectado que estás cerca de una zona delictiva", "OK");
                    }
                });
            }
        }
    }
}
