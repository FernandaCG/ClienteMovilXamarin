using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using TT_App1_SL.Helpers;
using TT_App1_SL.Model;
using TT_App1_SL.Service;
using Xamarin.Forms;

namespace TT_App1_SL.ViewModel
{
    class ContactoViewModel : INotifyPropertyChanged
    {
        AuthService _authService = new AuthService();
        private CConfianza _contacto;
        public int idCiudadano { get; set; }
        public CConfianza contacto {
            get => _contacto;
            set {
                _contacto = value;
                OnPropertyChanged();
            }
        }

        public ICommand GetContacto
        {
            get
            {
                return new Command(async () =>
                {
                    var accessToken = Settings.accessToken;
                    contacto = await _authService.GetContactoConfianza(Settings.userName, Settings.accessToken);
                });
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
