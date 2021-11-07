using HotelRSII.Project.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HotelRSII.Project.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilPodaciPage : ContentPage
    {
        ProfilPodaciViewModel model = null;
        public ProfilPodaciPage()
        {
            InitializeComponent();
            BindingContext = model = new ProfilPodaciViewModel();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }
        private async void Button_Clicked_Edit(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UrediProfilPodaci());
        }
    }
}