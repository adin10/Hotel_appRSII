using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using HotelRSII.Project.Models;
using HotelRSII.Project.Views;
using SeminarskiRSII.Model;
using SeminarskiRSII.Model.Requests;
using System.Collections.Generic;
using Flurl.Http;
using System.Windows.Input;
using System.Linq;

namespace HotelRSII.Project.ViewModels
{
    public class PrijaviSeViewModel : BaseViewModel
    {
        //private readonly ApiService _ulogeService = new ApiService("OsobljeUloge");
        private readonly ApiService _gostService = new ApiService("Gost");

        string _username = string.Empty;
        public string Username
        {
            get { return _username; }
            set { SetProperty(ref _username, value); }
        }

        string _password = string.Empty;
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }

        public ICommand PrijaviSeCommand { get; set; }
        public ICommand RegistrirajSeCommand { get; set; }

        public PrijaviSeViewModel()
        {
            Title = "Prijavi se";
            PrijaviSeCommand = new Command(async () => await PrijaviSe());
            RegistrirajSeCommand = new Command(() => { RegistrirajSe(); });

        }

        private void RegistrirajSe()
        {
           Application.Current.MainPage = new RegistrujSePage();
        }

        private async Task PrijaviSe()
        {

            IsBusy = true;

            ApiService.KorisnickoIme = _username;
            ApiService.Lozinka = _password;

            try
            {
                //await _ulogeService.get<dynamic>(null);
                List<Gost> list = await _gostService.get<List<Gost>>(new GostiSearchRequest() { KorisnickoIme = ApiService.KorisnickoIme });
                var item = list.Where(x => x.KorisnickoIme == ApiService.KorisnickoIme).FirstOrDefault();
                if (item != null)
                {
                    Application.Current.MainPage =new AppShell();
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Greška", "Pogrešno korisničko ime ili lozinka!", "Uredu");
                }
            }
            catch //(FlurlHttpException ex)
            {
                //await Application.Current.MainPage.DisplayAlert("Greška", "Pogrešno korisničko ime ili lozinka!", "Uredu");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}

