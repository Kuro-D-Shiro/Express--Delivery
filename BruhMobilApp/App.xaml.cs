using BruhMobilApp.View;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BruhMobilApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new Deliveryman_OrderSelection();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
