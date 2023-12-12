using BruhMobilApp.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BruhMobilApp
{
    public partial class LogInPage : ContentPage
    {
        public LogInPage()
        {
            InitializeComponent();
        }
        private async void GoToTheRegistrationPage_Clicked(object sender, EventArgs e)
        {
           await Navigation.PushModalAsync(new RegistrationPage());
        }

        private void LogInButton_Clicked(object sender, EventArgs e)
        {

        }
        private async void PasswordRecovery_Clicked(object sender, EventArgs e)
        {
            //хз тут как-то логику посылания пароля нужно осуществить
            await Navigation.PushModalAsync(new PasswordRecovery());
            //await DisplayAlert("Уведомление.", "Ваш пароль пришёл вам на электронную почту.", "ОК");
        }
    }
}
