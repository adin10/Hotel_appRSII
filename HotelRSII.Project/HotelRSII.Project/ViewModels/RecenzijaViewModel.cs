using HotelRSII.Project.Views;
using SeminarskiRSII.Model;
using SeminarskiRSII.Model.Requests;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace HotelRSII.Project.ViewModels
{
   public class RecenzijaViewModel:BaseViewModel
    {
        private readonly ApiService _recenzijaService = new ApiService("Recenzija");
        private readonly ApiService _sobaService = new ApiService("Soba");
        private readonly ApiService _gostiService = new ApiService("Gost");

        public ObservableCollection<SeminarskiRSII.Model.Soba> sobeList { get; set; } = new ObservableCollection<SeminarskiRSII.Model.Soba>();
        public ObservableCollection<SeminarskiRSII.Model.Gost> gostiList { get; set; } = new ObservableCollection<SeminarskiRSII.Model.Gost>();


     
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
        string _ocjena =string.Empty ;
        public string Ocjena
        {
            get { return _ocjena; }
            set { SetProperty(ref _ocjena, value); }
        }
        string _komentar = string.Empty;
        public string Komentar
        {
            get { return _komentar; }
            set { SetProperty(ref _komentar, value); }
        }
        public ICommand InitCommand { get; set; }
        public ICommand RecenzijaCommand { get; set; }
        //public ICommand GradSobaCommand { get; set; }


        public RecenzijaViewModel()
        {
            InitCommand = new Command(async () => await Init());
            RecenzijaCommand = new Command(async () => await Recenzija());
            //GradSobaCommand = new Command(async () => await UcitajGostaISobu());

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
        public SeminarskiRSII.Model.Gost gost { get; set; }


        //public async Task UcitajGostaISobu()
        //{
        //    List<Gost> list = await _gostiService.get<List<Gost>>(new GostiSearchRequest() { KorisnickoIme = ApiService.KorisnickoIme });
        //    var item = list.Where(x => x.KorisnickoIme == ApiService.KorisnickoIme).FirstOrDefault();
        //    if (item != null)
        //    {
        //        //Application.Current.MainPage = new AppShell();
        //        SelectedGost = item;
                
        //    }
        //}
        public async Task Recenzija()
        {
            List<Gost> list = await _gostiService.get<List<Gost>>(new GostiSearchRequest() { KorisnickoIme = ApiService.KorisnickoIme });
            var item = list.Where(x => x.KorisnickoIme == ApiService.KorisnickoIme).FirstOrDefault();
            gost = item;
            var request = new RecenzijaInsertRequest()
            {
                gostID = gost.Id,
                sobaID = _selectedSoba.Id,
                Komentar=_komentar,
                Ocjena = int.Parse(_ocjena)
            };

            try
            {
                var items = await _recenzijaService.Insert<SeminarskiRSII.Model.Recenzija>(request);
                await Application.Current.MainPage.DisplayAlert("Obavjest", "Uspješno ste ostavili svoju recenziju!", "Uredu");

               

                Application.Current.MainPage = new AppShell();
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Obavjest", ex.Message, "Uredu");
            }
        }
    }
}
