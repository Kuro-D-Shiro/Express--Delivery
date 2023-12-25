using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace BruhMobilApp.ModelView
{
    internal class PhoneNumber_Validation : Behavior<Entry>
    {
        protected override void OnAttachedTo(Entry bindable)
        {
            bindable.TextChanged += OnEntryTextChange;
            base.OnAttachedTo(bindable);
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            bindable.TextChanged -= OnEntryTextChange;
            base.OnDetachingFrom(bindable);
        }

        void OnEntryTextChange(object sender, TextChangedEventArgs e)
        {
            string str = new Regex(@"\D").Replace(e.NewTextValue, "");

            ((Entry)sender).TextColor = (!str.Contains(" ") && str.Length == 10) ? Color.White : Color.Red;
        }
    }
}
