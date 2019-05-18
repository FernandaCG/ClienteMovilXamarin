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
	public partial class SlideTransportes : ContentView
	{
        public static readonly BindableProperty DefaultHeightProperty =
            BindableProperty.Create<SlideTransportes, double>(p => p.DefaultHeight, 0, BindingMode.TwoWay, propertyChanged: DefaultHeightChanged);

        public static BindableProperty IsSlideOpenProperty =
            BindableProperty.Create<SlideTransportes, bool>(p => p.IsSlideOpen, false, BindingMode.TwoWay, propertyChanged: SlideOpenClose);


        public SlideTransportes ()
		{
			InitializeComponent ();
		}

        public double DefaultHeight
        {
            get { return (double)GetValue(DefaultHeightProperty); }
            set { SetValue(DefaultHeightProperty, value); }
        }

        public bool IsSlideOpen
        {
            get { return (bool)GetValue(IsSlideOpenProperty); }
            set { SetValue(IsSlideOpenProperty, value); }
        }

        private static void DefaultHeightChanged(BindableObject bindableObject, double oldValue, double newValue)
        {
            (bindableObject as SlideTransportes).IsVisible = false;
            (bindableObject as SlideTransportes).TranslationY = newValue;
        }

        private static async void SlideOpenClose(BindableObject bindableObject, bool oldValue, bool newValue)
        {
            if (newValue)
            {
                (bindableObject as SlideTransportes).IsVisible = true;
                await (bindableObject as SlideTransportes).TranslateTo(0, App.Current.MainPage.Height - 550, 250, Easing.SinInOut);//tamaño slide
                newValue = false;
            } else
            {
                await (bindableObject as SlideTransportes).TranslateTo(0, App.Current.MainPage.Height, 250, Easing.SinInOut);
                (bindableObject as SlideTransportes).IsVisible = false;
                newValue = true;
            }
        }
       
	}
}