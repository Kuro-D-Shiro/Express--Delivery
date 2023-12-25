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
    public partial class OrderHasBeenReceived : ContentPage
    {
        public OrderHasBeenReceived()
        {
            InitializeComponent();
        }

        private async void ChooseNewOrderButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Customer_MakingOrder());
        }

        private async void TPButton_Clicked(object sender, EventArgs e)
        {
            Uri uri = new Uri("https://t.me/kuroDshiro");

            await Browser.OpenAsync(uri);
        }
    }
}