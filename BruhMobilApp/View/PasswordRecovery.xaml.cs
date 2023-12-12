using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BruhMobilApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PasswordRecovery : ContentPage
    {
        public PasswordRecovery()
        {
            InitializeComponent();
        }

        private async void GoToTheRegistrationPage_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Уведомление.", "Ваш пароль пришёл вам на электронную почту.", "ОК");
            await Navigation.PopModalAsync();
        }
    }
}