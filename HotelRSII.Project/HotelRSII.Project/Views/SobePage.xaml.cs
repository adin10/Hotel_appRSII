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
    public partial class SobePage : ContentPage
    {
        private SobeViewModel model=null;
        public SobePage()
        {
            InitializeComponent();
            BindingContext = model = new SobeViewModel();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
          await model.Init();
        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as Soba;
            await Navigation.PushAsync(new SobaDetaljiPage(item));    // Prebacivanje na novu stranicu
        }
    }
}