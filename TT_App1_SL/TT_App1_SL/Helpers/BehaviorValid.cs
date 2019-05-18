using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace TT_App1_SL.Helpers
{
    public class BehaviorValid: Behavior<Entry>
    {
        protected override void OnAttachedTo(Entry bindable)
        {
            base.OnAttachedTo(bindable);

            bindable.TextChanged += BindableOnTextChanged;
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.TextChanged -= BindableOnTextChanged;
        }

        private void BindableOnTextChanged(object sender, TextChangedEventArgs e)
        {
            var username = e.NewTextValue;
            var usernameEntry = sender as Entry;
            if (username.Length < 3)
            {
                //usernameEntry.Text = "ERRARR";
                // usernameEntry.TextColor = Color.Red;
                usernameEntry.BackgroundColor = Color.Red;
            }
            else
            {
                usernameEntry.BackgroundColor = Color.Red;
            }
        }
    }
}
