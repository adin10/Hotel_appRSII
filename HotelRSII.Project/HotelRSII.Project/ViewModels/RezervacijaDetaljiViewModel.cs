using SeminarskiRSII.Model;
using SeminarskiRSII.Model.Requests;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace HotelRSII.Project.ViewModels
{
    public class RezervacijaDetaljiViewModel : BaseViewModel
    {
        private readonly ApiService _gostiService = new ApiService("Gost");
        private readonly ApiService _rezervacijeService = new ApiService("Rezervacija");

        public ICommand Init { get; set; }
        //public ICommand SearchSobe { get; set; }

        public RezervacijaDetaljiViewModel()
        {
            Init = new Command(async () => await SveRezervacije());
            //SearchSobe = new Command(async () => await SearchSoba());
        }

        public ObservableCollection<SeminarskiRSII.Model.Rezervacija> BookingList { get; set; } = new ObservableCollection<SeminarskiRSII.Model.Rezervacija>();

        public SeminarskiRSII.Model.Gost gost { get; set; }

        string _brojSobe = string.Empty;
        public string BrojSobe
        {
            get { return _brojSobe; }
            set { SetProperty(ref _brojSobe, value); }
        }

        DateTime _startDate = DateTime.Now.Date;
        public DateTime StartDate
        {
            get { return _startDate; }
            set { SetProperty(ref _startDate, value); }
        }

        DateTime _endDate = DateTime.Now.Date;
        public DateTime EndDate
        {
            get { return _endDate; }
            set { SetProperty(ref _endDate, value); }
        }

        public async Task SveRezervacije()
        {
            //var Id = await _gostiService.getByID<SeminarskiRSII.Model.Gost>(ApiService.GostId);
            List<Gost> list = await _gostiService.get<List<Gost>>(new GostiSearchRequest() { KorisnickoIme = ApiService.KorisnickoIme });
            var item = list.Where(x => x.KorisnickoIme == ApiService.KorisnickoIme).FirstOrDefault();
            gost = item;
            var request = new RezervacijaSearchRequest
            {
                gostID=gost.Id
            };

            BookingList.Clear();
            var lista = await _rezervacijeService.get<List<SeminarskiRSII.Model.Rezervacija>>(request);

            foreach (var items in lista)
            {
                items.ZavrsetakRezervacije = items.ZavrsetakRezervacije.AddHours(8).Date;
                BookingList.Add(items);
            }

            if (BookingList.Count == 0)
            {
                await Application.Current.MainPage.DisplayAlert("Warning", "You don't have any bookings yet.", "OK");
            }
        }

        //public async Task SearchSoba()
        //{
        //    if (EndDate == StartDate)
        //    {
        //        await Application.Current.MainPage.DisplayAlert("Warning", "The search interval should be at least 1 day", "Try again");
        //        return;
        //    }
        //    if (EndDate <= StartDate)
        //    {
        //        await Application.Current.MainPage.DisplayAlert("Warning", "End date must be greater than start date", "Try again");
        //        return;
        //    }

        //    var request = new RezervacijaSearchRequest
        //    {
        //        BrojSobe = int.Parse(_brojSobe)
        //        // = StartDate,
        //        //EndDate = EndDate
        //    };

        //    var list = await _rezervacijeService.get<IEnumerable<SeminarskiRSII.Model.Rezervacija>>(request);
        //    BookingList.Clear();

        //    foreach (var item in list)
        //    {
        //        item.ZavrsetakRezervacije = item.ZavrsetakRezervacije.AddHours(8).Date;
        //        BookingList.Add(item);
        //    }
        //    if (BookingList.Count == 0)
        //    {
        //        await Application.Current.MainPage.DisplayAlert("Warning", "There are no results for this search", "Try again");
        //    }
        //}
    }
}
