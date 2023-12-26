using BruhMobilApp.Model;
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

        private async void LogInButton_Clicked(object sender, EventArgs e)
        {
            DeliverDB deliverDB = new DeliverDB();
            deliverDB.openConnection();
            
            if((LoginingUsersName.Text == null || LoginingUsersName.Text == "") && (LoginingPassword.Text == null || LoginingPassword.Text == ""))
                await DisplayAlert("Уведомление.", "Вы забыли ввести данные.", "ОК");
            else if ((LoginingUsersName.Text != null || LoginingUsersName.Text != "") && (LoginingPassword.Text == null || LoginingPassword.Text == ""))
                await DisplayAlert("Уведомление.", "Вы забыли ввести пароль.", "ОК");
            else if ((LoginingUsersName.Text == null || LoginingUsersName.Text == "") && (LoginingPassword.Text != null || LoginingPassword.Text != ""))
                await DisplayAlert("Уведомление.", "Вы забыли ввести имя пользователя.", "ОК");
            else
            {
                Dictionary<string, string> user = deliverDB.ReadUser(LoginingUsersName.Text);
                if (user["password"] == LoginingPassword.Text)
                {
                    if (user["role"] == "customer") await Navigation.PushModalAsync(new Customer_MakingOrder());
                    else await Navigation.PushModalAsync(new Deliveryman_OrderSelection());
                    deliverDB.closeConnection();
                }
                else await DisplayAlert("Уведомление.", "Неверный пароль.", "ОК");
            }
        }
        private async void PasswordRecovery_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new PasswordRecovery());
        }
    }
}
