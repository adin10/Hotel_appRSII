using HotelRSII.Project.Views;
using SeminarskiRSII.Model;
using SeminarskiRSII.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace HotelRSII.Project.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        //public Command LoginCommand { get; }

        //public LoginViewModel()
        //{
        //    LoginCommand = new Command(OnLoginClicked);
        //}

        //private async void OnLoginClicked(object obj)
        //{
        //    // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
        //    await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
        //}
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

        public LoginViewModel()
        {
            Title = "Prijavi se";
            PrijaviSeCommand = new Command(async () => await PrijaviSe());
            RegistrirajSeCommand = new Command(() => { RegistrirajSe(); });

        }

        private void RegistrirajSe()
        {
            Application.Current.MainPage = new RegistrujSePage();
        }
        private static string GenerateSalt()
        {
            var buffer = new byte[16];
            (new RNGCryptoServiceProvider()).GetBytes(buffer);
            return Convert.ToBase64String(buffer);
        }

        private static string GenerateHash(string salt, string password)
        {
            byte[] src = Convert.FromBase64String(salt);
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] dst = new byte[src.Length + bytes.Length];

            System.Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            System.Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);

            HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
            byte[] inArray = algorithm.ComputeHash(dst);
            return Convert.ToBase64String(inArray);
        }
        private async Task PrijaviSe()
        {

            IsBusy = true;

            ApiService.KorisnickoIme = _username;
            ApiService.Lozinka = _password;
            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
            {
                await Application.Current.MainPage.DisplayAlert("Greska", "Sva polja su obavezna", "OK");
                return;
            }
            try
            {
                //await _ulogeService.get<dynamic>(null);
                List<Gost> list = await _gostService.get<List<Gost>>(new GostiSearchRequest() { KorisnickoIme = ApiService.KorisnickoIme });
                var item = list.Where(x => x.KorisnickoIme == ApiService.KorisnickoIme).FirstOrDefault();
                if (item != null)
                {
                    Application.Current.MainPage = new AppShell();
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
