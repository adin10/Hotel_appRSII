using HotelRSII.Project.Services;
using HotelRSII.Project.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HotelRSII.Project
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new LoginPage();
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
