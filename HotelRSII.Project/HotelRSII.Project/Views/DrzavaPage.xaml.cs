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
    public partial class DrzavaPage : ContentPage
    {
        private DrzavaViewModel model=null;
        public DrzavaPage()
        {
            InitializeComponent();
            BindingContext = model = new DrzavaViewModel();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
           await model.Init();
        }
    }
}