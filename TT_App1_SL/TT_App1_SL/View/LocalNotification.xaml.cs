using Plugin.LocalNotifications;
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
	public partial class LocalNotification : ContentPage
	{
		public LocalNotification ()
		{
			InitializeComponent ();
		}

        private void Button_Clicked(object sender, EventArgs e)
        {
            CrossLocalNotifications.Current.Show("TT2018A057", "Estas próximo a una zona delictiva");
        }
    }
}