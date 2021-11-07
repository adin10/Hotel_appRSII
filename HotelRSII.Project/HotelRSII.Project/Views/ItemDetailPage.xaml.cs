using HotelRSII.Project.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace HotelRSII.Project.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}