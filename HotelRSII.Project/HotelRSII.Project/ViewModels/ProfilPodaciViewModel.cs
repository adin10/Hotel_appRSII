using SeminarskiRSII.Model;
using SeminarskiRSII.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace HotelRSII.Project.ViewModels
{
   public class ProfilPodaciViewModel:BaseViewModel
    {
        private readonly ApiService _gostService = new ApiService("Gost");

        public ProfilPodaciViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }

        //LOG OUT

        public ICommand Logout
        {
            get
            {
                return new Command(() =>
                {
                    ApiService.KorisnickoIme = "";
                    ApiService.Lozinka = "";
                    ApiService.GostId = 0;
                });
            }
        }

        public ICommand InitCommand { get; set; }

        //FIRST NAME
        string _firstName = string.Empty;
        public string FirstName
        {
            get { return _firstName; }
            set { SetProperty(ref _firstName, value); }
        }

        //LAST NAME
        string _lastName = string.Empty;
        public string LastName
        {
            get { return _lastName; }
            set { SetProperty(ref _lastName, value); }
        }

        // Phone
        string _phone = string.Empty;
        public string Phone
        {
            get { return _phone; }
            set { SetProperty(ref _phone, value); }
        }

        // EMAIL
        string _email = string.Empty;
        public string Email
        {
            get { return _email; }
            set { SetProperty(ref _email, value); }
        }

        //USERNAME
        string _username = string.Empty;
        public string Username
        {
            get { return _username; }
            set { SetProperty(ref _username, value); }
        }

        //CITY
        string _city = string.Empty;
        public string City
        {
            get { return _city; }
            set { SetProperty(ref _city, value); }
        }

        public SeminarskiRSII.Model.Gost gost { get; set; }

        public async Task Init()
        {
            //var list = await _gostService.getByID<SeminarskiRSII.Model.Gost>(ApiService.GostId);
            List<Gost> list = await _gostService.get<List<Gost>>(new GostiSearchRequest() { KorisnickoIme = ApiService.KorisnickoIme });
            var item = list.Where(x => x.KorisnickoIme == ApiService.KorisnickoIme).FirstOrDefault();
            if (item != null)
            {
                //Application.Current.MainPage = new AppShell();
                FirstName = item.Ime;
                LastName =item.Prezime;
                Phone = item.Telefon;
                Email =item.Email;
                Username = item.KorisnickoIme;
                City = item.Grad.NazivGrada;
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Greška", "Pogrešno korisničko ime ili lozinka!", "Uredu");
            }


        }
    }
}
