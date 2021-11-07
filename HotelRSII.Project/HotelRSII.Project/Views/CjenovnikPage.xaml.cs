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
    public partial class CjenovnikPage : ContentPage
    {
        private CjenovnikViewModel model=null;
        public CjenovnikPage()
        {
            InitializeComponent();
            BindingContext = model = new CjenovnikViewModel();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
          await model.Init();
        }
    }
}