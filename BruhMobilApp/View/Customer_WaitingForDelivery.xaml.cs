using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BruhMobilApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Customer_WaitingForDelivery : ContentPage
    {
        public Customer_WaitingForDelivery()
        {
            InitializeComponent();
        }

        private async void TPButton_Clicked(object sender, EventArgs e)
        {
            Uri uri = new Uri("https://t.me/kuroDshiro");

            await Browser.OpenAsync(uri);
        }

        private void CopyDeliverymansPhoneNumberButton_Clicked(object sender, EventArgs e)
        {

        }
    }
}