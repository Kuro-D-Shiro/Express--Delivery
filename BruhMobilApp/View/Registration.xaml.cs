using BruhMobilApp.View;
using BruhMobilApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BruhMobilApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrationPage : ContentPage
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }

        private async void Registration_Clicked(object sender, EventArgs e)
        {
            DeliverDB deliverDB = new DeliverDB();
            deliverDB.openConnection();
            if (IsDeliverman.IsToggled)
            {
                deliverDB.AddUser(new Deliverman(RegistrationUsersName.Text, RegistrationEmail.Text, RegistrationPassword.Text, $"8{RegistrationNumber.Text}", "deliverman", "free"));
                await Navigation.PushModalAsync(new Deliveryman_OrderSelection());
                deliverDB.closeConnection();
            }
            else
            {
                deliverDB.AddUser(((User)new Customer(RegistrationUsersName.Text, RegistrationEmail.Text, RegistrationPassword.Text, $"8{RegistrationNumber.Text}", "customer", "free")));
                await Navigation.PushModalAsync(new Customer_MakingOrder());
                deliverDB.closeConnection();
            }
        }
    }
}