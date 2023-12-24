using BruhMobilApp.View;
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
            if(IsDeliverman.IsToggled)
            {
                await Navigation.PushModalAsync(new Deliveryman_OrderSelection());
            }
            else await Navigation.PushModalAsync(new Customer_MakingOrder());
        }
    }
}