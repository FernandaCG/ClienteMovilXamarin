using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Windows.Input;
using PropertyChanged;

namespace TT_App1_SL
{
    [ImplementPropertyChanged]
    public class MainViewModel
    {
        public ICommand CloseTappedCommand { get; set; }

        public ICommand SlideOpenCommand { get; set; }

        public double DefaultHeight { get; set; }

        public bool IsSlide { get; set; }

        public MainViewModel()
        {
            CloseTappedCommand = new Command(CloseMenu);
            SlideOpenCommand = new Command(SlideOpen);
            DefaultHeight = App.Current.MainPage.Height;
            IsSlide = false;
        }

        private void CloseMenu()
        {
            IsSlide = false;
        }

        private void SlideOpen()
        {
            if (IsSlide)
            {
                IsSlide = false;
            }
            else
            {
                IsSlide = true;
            }
        }


    }
}
