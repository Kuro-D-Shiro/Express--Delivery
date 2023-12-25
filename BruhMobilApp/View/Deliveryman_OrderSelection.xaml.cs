using BruhMobilApp.Model;
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
    public partial class Deliveryman_OrderSelection : ContentPage
    {
        public IList<Package> Packages;
        public Deliveryman_OrderSelection()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            Packages = new List<Package>();
            Packages.Add(new Package("sdodsf", "adassd", "dsfsdf", "big", new DateTime(TabIndex)));
            Packages.Add(new Package("sdodsf", "adassd", "dsfsdf", "big", new DateTime(TabIndex)));
            BindingContext = Packages;
            base.OnAppearing();
        }

        public void AddNewPackageInPage() // в дальнейшем в метод должен принимать объект типа Package
        {
            Button btn = new Button();
            btn.Text = ""; //здесь будет начальная и конечная точки доставки
            btn.CornerRadius = 15;
            btn.Clicked += GoToTheOrderPage;
            //ListOfOrders.Children.Add(btn);
        }

        private void GoToTheOrderPage(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private async void PackagesList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Package package = e.CurrentSelection[0] as Package;

            if(await DisplayAlert("Вы хотите взять этот заказ?", $"{package.StartAddres} - {package.EndAddres}", "Да", "Нет"))
            {
                await Navigation.PushModalAsync(new Deliveryman_PackagePage());
            }
        }
    }
}