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
    public partial class RezervacijaDetaljiPage : ContentPage
    {
        private RezervacijaDetaljiViewModel model = null;

        public RezervacijaDetaljiPage()
        {
            
            InitializeComponent();
            BindingContext = model = new RezervacijaDetaljiViewModel();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.SveRezervacije();
        }
        private async void RecezijaBoravka(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RecenzijaPage());

        }
    }
}