using HotelRSII.Project.ViewModels;
using SeminarskiRSII.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HotelRSII.Project.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrujSePage : ContentPage
    {
        private RegistrujSeViewModel model = null;
        public RegistrujSePage()
        {
            InitializeComponent();
            BindingContext = model = new RegistrujSeViewModel();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
            //viewModel.InitCommand.Execute(null);
        }
        private async void RegistrujSe_Clicked(object sender, EventArgs e)
        {
            if (model == null)
                return;


            if (IsValidateText(Ime) && IsValidateText(Prezime) && IsValidateText(KorisnickoIme) && Telefon_Validating() && Email_Validating() && Lozinka_Validating())
            {
                if (model.SelectedGrad == null)
                {
                    await Application.Current.MainPage.DisplayAlert("Greška", "Niste odabrali grad", "Uredu");
                }
              else if (!await model.txtKorisnickoIme_Validating())
                {
                    KorisnickoIme.Placeholder = "Korisničko ime već postoji!";
                    KorisnickoIme.PlaceholderColor = Color.FromHex("#ff4d4d");
                    KorisnickoIme.Text = string.Empty;
                }
                else if (!await model.txtEmail_Validating())
                {
                    Email.Placeholder = "Email već postoji!";
                    Email.PlaceholderColor = Color.FromHex("#ff4d4d");
                    Email.Text = string.Empty;
                }
                else {
                   await model.Registracija();
                }
            }
        }

        private bool Lozinka_Validating()
        {
            if (string.IsNullOrWhiteSpace(Password.Text))
            {
                Password.TextColor = Color.FromHex("#ff4d4d");
                Password.Placeholder = "Obavezno polje!";
                Password.PlaceholderColor = Color.FromHex("#ff4d4d");

                PasswordPotvrda.TextColor = Color.FromHex("#ff4d4d");
                PasswordPotvrda.Placeholder = "Obavezno polje!";
                PasswordPotvrda.PlaceholderColor = Color.FromHex("#ff4d4d");
                return false;
            }
            else if (Password.Text != PasswordPotvrda.Text)
            {
                Password.TextColor = Color.FromHex("#ff4d4d");
                Password.Placeholder = "Obavezno polje!";
                Password.PlaceholderColor = Color.FromHex("#ff4d4d");

                PasswordPotvrda.TextColor = Color.FromHex("#ff4d4d");
                PasswordPotvrda.Placeholder = "Obavezno polje!";
                PasswordPotvrda.PlaceholderColor = Color.FromHex("#ff4d4d");
                return false;
            }
            return true;
        }
        private bool Email_Validating() {
            if (string.IsNullOrWhiteSpace(Email.Text))
            {
                Email.Placeholder = "Obavezno polje!";
                Email.PlaceholderColor = Color.FromHex("#ff4d4d");
                return false;
            }
            else if (!Regex.IsMatch(Email.Text, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"))
            {
                Email.TextColor = Color.FromHex("#ff4d4d");
                return false;
            }
            else
            {
                return true;
            }
        }
        private bool Telefon_Validating()
        {
            if (string.IsNullOrWhiteSpace(Telefon.Text))
            {
                Telefon.Placeholder = "Obavezno polje!";
                Telefon.PlaceholderColor = Color.FromHex("#ff4d4d");
                return false;
            }
            else if (!Regex.IsMatch(Telefon.Text, @"^[+]?\d{3}[ ]?\d{2}[ ]?\d{3}[ ]?\d{3}$") && !Regex.IsMatch(Telefon.Text, @"^[+]?\d{3}[ ]?\d{2}[ ]?\d{3}[ ]?\d{4}$"))
            {
                Telefon.TextColor = Color.FromHex("#ff4d4d");
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool IsValidateText(Entry entry) {
            if (string.IsNullOrEmpty(entry.Text)) {
                entry.Placeholder = "Obavezno polje!";
                entry.PlaceholderColor = Color.FromHex("#ff4d4d");
                return false;
            }
            return true;
        }

        private void Email_Focused(object sender, FocusEventArgs e)
        {
            Email.TextColor = Color.Black;
        }

        private void KorisnickoIme_Focused(object sender, FocusEventArgs e)
        {
            KorisnickoIme.TextColor = Color.Black;
        }
        private void Telefon_Focused(object sender, FocusEventArgs e)
        {
            Telefon.TextColor = Color.Black;
        }
        private void Password_Focused(object sender, FocusEventArgs e)
        {
            Password.TextColor = Color.Black;
            PasswordPotvrda.TextColor = Color.Black;
        }
    }
}