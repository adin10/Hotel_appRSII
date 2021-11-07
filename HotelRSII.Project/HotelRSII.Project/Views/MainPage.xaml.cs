using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using HotelRSII.Project.Models;

namespace HotelRSII.Project.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : MasterDetailPage
    {
        Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();
        public MainPage()
        {
            InitializeComponent();

            MasterBehavior = MasterBehavior.Popover;

            MenuPages.Add((int)MenuItemType.Browse, (NavigationPage)Detail);
            MenuPages.Add((int)MenuItemType.Novosti, (NavigationPage)Detail);
        }

        public async Task NavigateFromMenu(int id)
        {
            if (!MenuPages.ContainsKey(id))
            {
                switch (id)
                {
                    //case (int)MenuItemType.Browse:
                    //    MenuPages.Add(id, new NavigationPage(new ItemsPage()));
                    //    break;
                    //case (int)MenuItemType.About:
                    //    MenuPages.Add(id, new NavigationPage(new AboutPage()));
                    //    break;
                    //case (int)MenuItemType.Notifikacije:
                    //    MenuPages.Add(id, new NavigationPage(new NotifikacijePage()));
                    //    break;
                    //case (int)MenuItemType.PretplatiSe:
                    //    MenuPages.Add(id, new NavigationPage(new PretplatiSePage()));
                    //    break;
                    //case (int)MenuItemType.MojePretplate:
                    //    MenuPages.Add(id, new NavigationPage(new MojePretplatePage()));
                    //    break;
                    //case (int)MenuItemType.NovaNarudzba:
                    //    MenuPages.Add(id, new NavigationPage(new NovaNarudzbaPage()));
                    //    break;
                    //case (int)MenuItemType.MojeNarudzbe:
                    //    MenuPages.Add(id, new NavigationPage(new MojeRezervacijePage()));
                    //    break;
                    //case (int)MenuItemType.LicniPodaci:
                    //    MenuPages.Add(id, new NavigationPage(new LicniPodaciPage()));
                    //    break;
                    case (int)MenuItemType.Novosti:
                        MenuPages.Add(id, new NavigationPage(new NovostiPage()));
                        break;
                    case (int)MenuItemType.Sobe:
                        MenuPages.Add(id, new NavigationPage(new SobePage()));
                        break;
                    case (int)MenuItemType.MojeRezervacije:
                        MenuPages.Add(id, new NavigationPage(new RezervacijaDetaljiPage()));
                        break;
                    case (int)MenuItemType.Cjenovnik:
                        MenuPages.Add(id, new NavigationPage(new CjenovnikPage()));
                        break;
                    case (int)MenuItemType.Notifikacije:
                        MenuPages.Add(id, new NavigationPage(new NotifikacijePage()));
                        break;
                    case (int)MenuItemType.ProfilPodaci:
                        MenuPages.Add(id, new NavigationPage(new ProfilPodaciPage()));
                        break;
                    case (int)MenuItemType.Drzave:
                        MenuPages.Add(id, new NavigationPage(new DrzavaPage()));
                        break;
                    case (int)MenuItemType.OdjaviSe:
                        MenuPages.Add(id, new NavigationPage(new OdjaviSePage()));
                        break;
                }
            }

            var newPage = MenuPages[id];

            if (newPage != null && Detail != newPage)
            {
                Detail = newPage;

                if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(100);

                IsPresented = false;
            }
        }
    }
}