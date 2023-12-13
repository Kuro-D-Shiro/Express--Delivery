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
        public Deliveryman_OrderSelection()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        public void AddNewPackageInPage() // в дальнейшем в метод должен принимать объект типа Package
        {
            Button btn = new Button();
            btn.Text = ""; //здесь будет начальная и конечная точки доставки
            btn.CornerRadius = 15;
            btn.Clicked += GoToTheOrderPage;
            ListOfOrders.Children.Add(btn);
        }

        private void GoToTheOrderPage(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}