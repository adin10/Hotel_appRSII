using HotelRSII.Project.Views;
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
   public class UrediProfilPodaciViewModel:BaseViewModel
    {
        private readonly ApiService _gostService = new ApiService("Gost");

        public UrediProfilPodaciViewModel()
        {
            InitCommand = new Command(async () => await Init());
            SaveChanges = new Command(async () => await SaveEditChanges());
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
        public ICommand SaveChanges { get; set; }

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
        // Grad
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

        // Lozinka
        string _password = string.Empty;
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }

        // Potvrdi Lozinku
        string _passwordPotvrda = string.Empty;
        public string PasswordPotvrda
        {
            get { return _passwordPotvrda; }
            set { SetProperty(ref _passwordPotvrda, value); }
        }

        public SeminarskiRSII.Model.Gost gost { get; set; }

        public async Task Init()
        {
            //var gostId = await _gostService.getByID<SeminarskiRSII.Model.Gost>(ApiService.GostId);
            //gost = gostId;
            //FirstName = gost.Ime;
            //LastName = gost.Prezime;
            //Phone = gost.Telefon;
            //Email = gost.Email;
            //Username = gost.KorisnickoIme;
            //City = gost.Grad.NazivGrada;

            List<Gost> list = await _gostService.get<List<Gost>>(new GostiSearchRequest() { KorisnickoIme = ApiService.KorisnickoIme });
            var item = list.Where(x => x.KorisnickoIme == ApiService.KorisnickoIme).FirstOrDefault();
            if (item != null)
            {
                //Application.Current.MainPage = new AppShell();
                FirstName = item.Ime;
                LastName = item.Prezime;
                Phone = item.Telefon;
                Email = item.Email;
                Username = item.KorisnickoIme;
                City = item.Grad.NazivGrada;



            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Greška", "Pogrešno korisničko ime ili lozinka!", "Uredu");
            }
        }
        public async Task SaveEditChanges()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(FirstName) || string.IsNullOrWhiteSpace(LastName) || string.IsNullOrWhiteSpace(Email) ||
                    string.IsNullOrWhiteSpace(Phone) || string.IsNullOrWhiteSpace(Username))
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "All fields are requreid", "Try again");
                    return;
                }

                if (Username.Length < 4)
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Username must have minimum 4 characters", "Try again");
                    return;
                }

                //var userList = await _gostService.get<List<SeminarskiRSII.Model.Gost>>(null);
                //foreach (var item in userList)
                //{
                //    if (item.KorisnickoIme.StartsWith(Username) && ApiService.KorisnickoIme != item.KorisnickoIme)
                //    {
                //        await Application.Current.MainPage.DisplayAlert("Error", "Username already exist", "Try again");
                //        return;
                //    }
                //}

                var gostId = await _gostService.getByID<SeminarskiRSII.Model.Gost>(ApiService.GostId);
                gost = gostId;

                // Password

                var request = new GostiInsertRequest
                {
                    
                    Ime=FirstName,
                    Prezime=LastName,
                    Telefon=Phone,
                    korisnickoIme=Username,
                    GradId=_selectedGrad.Id,
                    Lozinka=Password,
                    PotvrdiLozinku=PasswordPotvrda,
                    Email=Email
                };

                ////ApiService.KorisnickoIme = Username;

                var userUpdate = await _gostService.Update<SeminarskiRSII.Model.Gost>(ApiService.GostId, request);
                await Application.Current.MainPage.DisplayAlert("Succesfull", "Succesfully changed, please log in with new credentials.", "OK");
                await Application.Current.MainPage.Navigation.PushModalAsync(new LoginPage());
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Something went wrong.", "Try again");
            }
        }
    }
}
