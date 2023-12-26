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
    public partial class GoodJobPage : ContentPage
    {
        public GoodJobPage()
        {
            InitializeComponent();
        }

        private async void ChooseNewDeliveryButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Deliveryman_OrderSelection());
        }

        private async void TPButton_Clicked(object sender, EventArgs e)
        {
            Uri uri = new Uri("https://t.me/kuroDshiro");

            await Browser.OpenAsync(uri);
        }
    }
}