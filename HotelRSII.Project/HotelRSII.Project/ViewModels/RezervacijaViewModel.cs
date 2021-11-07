using HotelRSII.Project.Views;
using SeminarskiRSII.Model;
using SeminarskiRSII.Model.Requests;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace HotelRSII.Project.ViewModels
{
   public class RezervacijaViewModel:BaseViewModel
    {
        private readonly ApiService _rezervacijaService = new ApiService("Rezervacija");
        private readonly ApiService _sobaService = new ApiService("Soba");
        private readonly ApiService _gostiService = new ApiService("Gost");

        public ObservableCollection<SeminarskiRSII.Model.Soba> sobeList { get; set; } = new ObservableCollection<SeminarskiRSII.Model.Soba>();
        public ObservableCollection<SeminarskiRSII.Model.Gost> gostiList { get; set; } = new ObservableCollection<SeminarskiRSII.Model.Gost>();


        string _ime = string.Empty;
        public string Ime
        {
            get { return _ime; }
            set { SetProperty(ref _ime, value); }
        }

        string _prezime = string.Empty;
        public string Prezime
        {
            get { return _prezime; }
            set { SetProperty(ref _prezime, value); }
        }

        private SeminarskiRSII.Model.Gost _selectedGost = null;
        public SeminarskiRSII.Model.Gost SelectedGost
        {
            get { return _selectedGost; }
            set
            {
                SetProperty(ref _selectedGost, value);
                if (value != null)
                    InitCommand.Execute(null);
            }
        }
        private SeminarskiRSII.Model.Soba _selectedSoba = null;
        public SeminarskiRSII.Model.Soba SelectedSoba
        {
            get { return _selectedSoba; }
            set
            {
                SetProperty(ref _selectedSoba, value);
                if (value != null)
                    InitCommand.Execute(null);
            }
        }
        DateTime _startDate = DateTime.Now;
        public DateTime StartDate
        {
            get { return _startDate; }
            set { SetProperty(ref _startDate, value); }
        }
        DateTime _endDate = DateTime.Now;
        public DateTime EndDate
        {
            get { return _endDate; }
            set { SetProperty(ref _endDate, value); }
        }

        public ICommand InitCommand { get; set; }
        public ICommand RezervisiCommand { get; set; }


        public RezervacijaViewModel()
        {
            InitCommand = new Command(async () => await Init());
            RezervisiCommand = new Command(async () => await Rezervisi());
        }
        public async Task Init()
        {
            try
            {
                if (sobeList.Count == 0)
                {
                    var items = await _sobaService.get<List<SeminarskiRSII.Model.Soba>>(null);
                    foreach (var item in items)
                    {
                        sobeList.Add(item);
                    }
                }
                if (gostiList.Count == 0)
                {
                    var items = await _gostiService.get<List<SeminarskiRSII.Model.Gost>>(null);
                    foreach (var item in items)
                    {
                        gostiList.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
        public async Task Rezervisi()
        {
            var request = new RezervacijaInsertRequest()
            {
                //Ime = Ime,
                //Prezime = Prezime,
                //Email = Email,
                //Telefon = Telefon,
                //korisnickoIme = KorisnickoIme,
                //Lozinka = Password,
                //GradId = _selectedGrad.Id,
                //PotvrdiLozinku = PasswordPotvrda,
                GostId=_selectedGost.Id,
                SobaId=_selectedSoba.Id,
                DatumRezervacije=_startDate,
                ZavrsetakRezervacije=_endDate
            };

            try
            {
                var item = await _rezervacijaService.Insert<SeminarskiRSII.Model.Rezervacija>(request);
                await Application.Current.MainPage.DisplayAlert("Obavjest", "Uspješno ste kreirali rezervaciju!", "Uredu");

                var days = (request.ZavrsetakRezervacije.Date - request.DatumRezervacije.Date).TotalDays;
                var message = string.Format("Trajanje rezervacije {0} dana", days);
                await Application.Current.MainPage.DisplayAlert("Message", message, "OK");

                Application.Current.MainPage = new AppShell();
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Obavjest", ex.Message, "Uredu");
            }
        }
    }
}
