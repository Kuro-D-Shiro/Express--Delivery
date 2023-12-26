using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace BruhMobilApp.ModelView
{
    public class E_Mail_Validation : Behavior<Entry>
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

        public void OnEntryTextChange(object sender, TextChangedEventArgs e)
        {
            string str = e.NewTextValue;

            ((Entry)sender).TextColor = (!str.Contains(" ") && Regex.IsMatch(str, @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$", RegexOptions.IgnoreCase)) ? Color.White : Color.Red;
        }
    }
}
