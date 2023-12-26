using System;
using BruhMobilApp.Model;
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
    public partial class Deliveryman_PackagePage : ContentPage
    {
        Package package; 
        public Deliveryman_PackagePage()
        {
            InitializeComponent();
        }

        private async void MapButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new MapPage());
        }

        private async void EndOfDeliveryButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new GoodJobPage());
        }

        private async void CopyCustomerPhoneNumberButton_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Уведомление.", "Номер скопирован в буфер обмена.", "ОК");
            await Clipboard.SetTextAsync(CustomersNumber.Text);
        }

        private async void TPButton_Clicked(object sender, EventArgs e)
        {
            Uri uri = new Uri("https://t.me/kuroDshiro");

            await Browser.OpenAsync(uri);
        }

        public Deliveryman_PackagePage(Package package)
        {
            InitializeComponent();
            this.package = package;
            StartAdress.Text += package.StartAddres;
            FinishAdress.Text += package.EndAddres;
            CustomersComment.Text += package.Comment;
        }
    }
}