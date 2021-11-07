using HotelRSII.Project.ViewModels;
using SeminarskiRSII.Model;
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
    public partial class SobaDetaljiPage : ContentPage
    {
        private readonly ApiService _Sobaservice = new ApiService("Soba");
        SobaDetaljiViewModel model = null;
        public SobaDetaljiPage(Soba sobaID)
        {
            InitializeComponent();
            BindingContext = model = new SobaDetaljiViewModel() { Soba = sobaID };
        }
        //public SobaDetaljiPage(int sobaID)
        //{
        //    InitializeComponent();
        //}
       private async void RezervisiSobu(object sender, EventArgs e)
        {
             await Navigation.PushAsync(new RezervacijaPage());
        }
        //private async void RecezijaBoravka(object sender, EventArgs e)
        //{
        //    await Navigation.PushAsync(new RecenzijaPage());

        //}
    }
}