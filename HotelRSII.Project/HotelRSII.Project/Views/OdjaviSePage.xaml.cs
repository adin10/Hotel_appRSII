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
    public partial class OdjaviSePage : ContentPage
    {
        public OdjaviSePage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            ApiService.KorisnickoIme = string.Empty;
            ApiService.Lozinka = string.Empty;
            Application.Current.MainPage = new PrijaviSePage();
        }
    }
}