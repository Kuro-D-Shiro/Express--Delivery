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
        Dictionary<string, string> packagesDtata;
        public IList<Package> Packages;
        public Deliveryman_OrderSelection()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            DeliverDB deliverDB = new DeliverDB();
            deliverDB.openConnection();
            Packages = deliverDB.GetStatusPackage();
            BindingContext = Packages;
            deliverDB.closeConnection();
            base.OnAppearing();
        }

        public void AddNewPackageInList(Package package) 
        {
            DeliverDB deliverDB = new DeliverDB();
            deliverDB.openConnection();
            packagesDtata = deliverDB.ReadPackage(package.Id);
            Packages.Add(package);
        }

        private async void PackagesList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Package package = e.CurrentSelection[0] as Package;

            if(await DisplayAlert("Вы хотите взять этот заказ?", $"{package.StartAddres} - {package.EndAddres}", "Да", "Нет"))
            {
                await Navigation.PushModalAsync(new Deliveryman_PackagePage(package));
            }
        }
    }
}