﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BruhMobilApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Deliveryman_PackagePage : ContentPage
    {
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

        private void CopyCustomerPhoneNumberButton_Clicked(object sender, EventArgs e)
        {

        }

        private void TPButton_Clicked(object sender, EventArgs e)
        {

        }
    }
}