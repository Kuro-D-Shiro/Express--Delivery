using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BruhMobilApp.Model;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BruhMobilApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Customer_MakingOrder : ContentPage
    {
        Package Package;
        public Customer_MakingOrder()
        {
            Package = new Package("1", "1", "1", new DateTime());
            InitializeComponent();
        }

        private void SmallPackageButton_Clicked(object sender, EventArgs e)
        {
            Package.Size = "small";
        }

        private void AvaragePackageButton_Clicked(object sender, EventArgs e)
        {
            Package.Size = "standard";
        }

        private void BigPackageButton_Clicked(object sender, EventArgs e)
        {
            Package.Size = "big";
        }

        private async void PlaceOrderButton_Clicked(object sender, EventArgs e)
        {
            DeliverDB deliverDB = new DeliverDB();
            deliverDB.openConnection();
            if(WhriteStartAddress.Text == null && WhriteFinishAddress.Text == null && Package.Size == "not")
            {
                await DisplayAlert("Уведомление.", "Вы не ввели начальный и конечный адреса и не выбрали размер посылки.", "ОК");
            }
            else if(WhriteStartAddress.Text != null && WhriteFinishAddress.Text == "" && Package.Size == "not")
            {
                await DisplayAlert("Уведомление.", "Вы не ввели конечный адрес и не выбрали размер посылки.", "ОК");
            }
            else if (WhriteStartAddress.Text == "" && WhriteFinishAddress.Text != "" && Package.Size == "not")
            {
                await DisplayAlert("Уведомление.", "Вы не ввели начальный адрес и не выбрали размер посылки.", "ОК");
            }
            else if (WhriteStartAddress.Text == "" && WhriteFinishAddress.Text == "" && Package.Size != "not")
            {
                await DisplayAlert("Уведомление.", "Вы не ввели начальный и конечный адреса.", "ОК");
            }
            else if (WhriteStartAddress.Text == "" && WhriteFinishAddress.Text != "" && Package.Size != "not")
            {
                await DisplayAlert("Уведомление.", "Вы не ввели начальный адрес.", "ОК");
            }
            else if (WhriteStartAddress.Text != "" && WhriteFinishAddress.Text == "" && Package.Size != "not")
            {
                await DisplayAlert("Уведомление.", "Вы не ввели конечный адрес.", "ОК");
            }
            else if (WhriteStartAddress.Text != "" && WhriteFinishAddress.Text != "" && Package.Size == "not")
            {
                await DisplayAlert("Уведомление.", "Вы не выбрали размер посылки.", "ОК");
            }
            else
            {
                Package.StartAddres = WhriteStartAddress.Text;
                Package.EndAddres = WhriteFinishAddress.Text;
                Package.Comment = CommentEditor.Text;
                deliverDB.AddPackege(Package);
                deliverDB.closeConnection();
                await Navigation.PushModalAsync(new Customer_WaitingForDelivery());
            }
        }
    }
}