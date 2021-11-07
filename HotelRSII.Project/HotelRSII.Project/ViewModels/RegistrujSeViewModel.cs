using HotelRSII.Project.Views;
using SeminarskiRSII.Model.Requests;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace HotelRSII.Project.ViewModels
{
    public class RegistrujSeViewModel : BaseViewModel
    {
        private readonly ApiService _gradoviService = new ApiService("Grad");
        private readonly ApiService _gostiService = new ApiService("Gost");

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
    
        private SeminarskiRSII.Model.Grad _selectedGrad = null;
        public SeminarskiRSII.Model.Grad SelectedGrad
        {
            get { return _selectedGrad; }
            set
            {
                SetProperty(ref _selectedGrad, value);
                if (value != null)
                    InitCommand.Execute(null);
            }
        }
        string _email = string.Empty;
        public string Email
        {
            get { return _email; }
            set { SetProperty(ref _email, value); }
        }
        string _telefon = string.Empty;
        public string Telefon
        {
            get { return _telefon; }
            set { SetProperty(ref _telefon, value); }
        }

        string _korisnickoIme = string.Empty;
        public string KorisnickoIme
        {
            get { return _korisnickoIme; }
            set { SetProperty(ref _korisnickoIme, value); }
        }

        string _password = string.Empty;
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }

        string _passwordPotvrda = string.Empty;
        public string PasswordPotvrda
        {
            get { return _passwordPotvrda; }
            set { SetProperty(ref _passwordPotvrda, value); }
        }

        public ObservableCollection<SeminarskiRSII.Model.Grad> gradoviList { get; set; } = new ObservableCollection<SeminarskiRSII.Model.Grad>();
        public ICommand InitCommand { get; set; }
        public ICommand RegistracijaCommand { get; set; }
        public ICommand PrijaviSeCommand { get; set; }


        public RegistrujSeViewModel()
        {
            RegistracijaCommand = new Command(async () => await Registracija());
            PrijaviSeCommand = new Command(() => PrijaviSe());
            InitCommand = new Command(async () => await Init());
        }
        public async Task Init()
        {
            try
            {
                if (gradoviList.Count == 0)
                {
                    var items = await _gradoviService.get<List<SeminarskiRSII.Model.Grad>>(null);
                    foreach (var item in items)
                    {
                        gradoviList.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
     

        public void PrijaviSe()
        {
            Application.Current.MainPage = new LoginPage();
        }
        public async Task Registracija()
        {
            //if (Password != PasswordPotvrda)
            //{
            //    await Application.Current.MainPage.DisplayAlert("Greska", "Passwordi se ne podudaraju", "Pokusajte ponovo");
            //    return;
            //}
            //if (string.IsNullOrEmpty(Ime) || string.IsNullOrEmpty(Prezime) || string.IsNullOrEmpty(Telefon) || string.IsNullOrEmpty(Email)
            //       || string.IsNullOrEmpty(KorisnickoIme) || string.IsNullOrEmpty(Password) || string.IsNullOrEmpty(PasswordPotvrda))
            //{
            //    await Application.Current.MainPage.DisplayAlert("Greska", "Niste oznacili sva potrebna polja", "Pokusajte ponovo");
            //    return;
            //}
            //var userList = await _gostiService.get<List<SeminarskiRSII.Model.Gost>>(null);
            //foreach (var item in userList)
            //{
            //    if (item.KorisnickoIme == KorisnickoIme)
            //    {
            //        await Application.Current.MainPage.DisplayAlert("Greska", "Korisnicko ime vec postoji !", "Pokusajte ponovo");
            //        return;
            //    }
            //}
            var request = new GostiInsertRequest()
            {
                Ime = Ime,
                Prezime = Prezime,
                Email = Email,
                Telefon = Telefon,
                korisnickoIme = KorisnickoIme,
                Lozinka = Password,
                GradId = _selectedGrad.Id,
                PotvrdiLozinku = PasswordPotvrda,
            };

            try
            {
                var item = await _gostiService.Insert<SeminarskiRSII.Model.Gost>(request);

                await Application.Current.MainPage.DisplayAlert("Obavjest", "Uspješno ste se registrovali!", "Uredu");
                Application.Current.MainPage = new LoginPage();
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Obavjest", ex.Message, "Uredu");
            }
        }
       

        public async Task<bool> txtKorisnickoIme_Validating()
        {
            var result = await _gostiService.get<List<SeminarskiRSII.Model.Gost>>(null);
            foreach (var item in result)
                if (item.KorisnickoIme == KorisnickoIme)
                {
                    return false;
                }
            return true;
        }

        public async Task<bool> txtEmail_Validating()
        {
            var result = await _gostiService.get<List<SeminarskiRSII.Model.Gost>>(null);
            foreach (var item in result)
                if (item.Email == Email)
                {
                    return false;
                }
            return true;
        }
    }
}
