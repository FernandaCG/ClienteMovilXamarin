using System;
using TT_App1_SL.Helpers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace TT_App1_SL
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            setMainPage();
            //MainPage = new NavigationPage(new Bienvenida());
        }

        private void setMainPage()
        {
            if (!string.IsNullOrEmpty(Settings.accessToken))
            {
                MainPage = new NavigationPage(new MenuDelitos());
            }
            else if (!string.IsNullOrEmpty(Settings.userName) && !string.IsNullOrEmpty(Settings.password))
            {
                MainPage = new NavigationPage(new IniciarSesion());
            }
            else
            {
                MainPage = new NavigationPage(new Bienvenida());
            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }     
    }
}
