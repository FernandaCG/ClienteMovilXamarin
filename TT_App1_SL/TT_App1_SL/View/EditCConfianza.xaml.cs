using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TT_App1_SL.Helpers;
using TT_App1_SL.Model;
using TT_App1_SL.Service;
using TT_App1_SL.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TT_App1_SL.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EditCConfianza : ContentPage
	{
        
        public EditCConfianza(CConfianza contacto)
        {
            var editarCConfianzaViewModel = new EditarCConfianzaViewModel();
            editarCConfianzaViewModel.contacto = contacto;
            BindingContext = editarCConfianzaViewModel;
            InitializeComponent();

           // var editViewModel = BindingContext as EditarCConfianzaViewModel;
           //editViewModel.contacto = contacto;
        }
	}
}