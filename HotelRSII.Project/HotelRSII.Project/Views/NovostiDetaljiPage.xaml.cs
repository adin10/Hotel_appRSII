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
    public partial class NovostiDetaljiPage : ContentPage
    {
        NovostiDetaljiViewModel model = null;

        private int _id;
        public NovostiDetaljiPage(Novosti n)
        {
            InitializeComponent();
            BindingContext = model = new NovostiDetaljiViewModel()
            {
                Novost = n
            };
            _id = n.Id;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Pregled(_id);
        }
    }
}