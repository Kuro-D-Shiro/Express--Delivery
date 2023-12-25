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
        public Customer_MakingOrder()
        {
            InitializeComponent();
        }

        private void SmallPackageButton_Clicked(object sender, EventArgs e)
        {
            
        }

        private void AvaragePackageButton_Clicked(object sender, EventArgs e)
        {

        }

        private void BigPackageButton_Clicked(object sender, EventArgs e)
        {

        }

        private async void PlaceOrderButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Customer_WaitingForDelivery());
        }
    }
}