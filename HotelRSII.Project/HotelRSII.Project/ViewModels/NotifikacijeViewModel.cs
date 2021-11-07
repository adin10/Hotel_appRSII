using SeminarskiRSII.Model;
using SeminarskiRSII.Model.Requests;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HotelRSII.Project.ViewModels
{
    class NotifikacijeViewModel : BaseViewModel
    {
        private readonly ApiService _notifikacijeService = new ApiService("Notifikacije");
        private readonly ApiService _gostiNotifikacijeService = new ApiService("GostiNotifikacije");
        private readonly ApiService _gostiService = new ApiService("Gost");

        public NotifikacijeViewModel()
        {
            Title = "Notifikacija";
        }
        public ObservableCollection<Notifikacije> NotifikacijeList { get; set; } = new ObservableCollection<Notifikacije>();
        public async Task Init()
        {
            var lista = await _notifikacijeService.get<List<Notifikacije>>(null);

            var searchGost = new GostiSearchRequest()
            {
                KorisnickoIme = ApiService.KorisnickoIme
            };

            var listaGostiju = await _gostiService.get<List<Gost>>(searchGost);

            Gost gost = null;
            foreach (var item in listaGostiju)
            {
                if (item.KorisnickoIme == ApiService.KorisnickoIme)
                {
                    gost = item;
                    break;
                }
            }

            var searchGN = new GostiNotifikacijeSearchRequest()
            {
                GostId = gost.Id

            };

            var listaGN = await _gostiNotifikacijeService.get<List<GostiNotifikacije>>(searchGN);

            NotifikacijeList.Clear();

            foreach (var item in lista)
            {

                foreach (var item2 in listaGN)
                {
                    if (item.Id == item2.NotifikacijeId && !item2.Pregledana)
                    {
                        NotifikacijeList.Add(item);
                    }
                }




            }
        }

        public async Task OznaciProcitano(Notifikacije n)
        {
            try
            {
                var searchPutnik = new GostiSearchRequest()
                {
                    KorisnickoIme = ApiService.KorisnickoIme
                };

                var listaPutnika = await _gostiService.get<List<Gost>>(searchPutnik);

                Gost gost = null;
                foreach (var item in listaPutnika)
                {
                    if (item.KorisnickoIme == ApiService.KorisnickoIme)
                    {
                        gost = item;
                        break;
                    }
                }

                var searchPN = new GostiNotifikacijeSearchRequest()
                {
                    GostId = gost.Id
                };

                var listaPN = await _gostiNotifikacijeService.get<List<GostiNotifikacije>>(searchPN);

                GostiNotifikacije gn = null;
                foreach (var item in listaPN)
                {
                    if (item.NotifikacijeId == n.Id && item.gostID == gost.Id)
                    {
                        gn = item;
                        break;
                    }
                }

                if (gn != null)
                {
                    var request = new GostiNotifikacijeInsertRequest()
                    {
                        NotifikacijaId = n.Id,
                        GostId = gost.Id,
                        Pregledana = true
                    };

                    await _gostiNotifikacijeService.Update<GostiNotifikacije>(gn.Id, request);

                    if (n != null)
                    {
                        NotifikacijeList.Remove(n);

                        await Application.Current.MainPage.DisplayAlert(" ", "Označili ste notifikaciju pročitanom", "OK");
                    }
                }







                //var updateN = new NotifikacijaUpsertRequest()
                //{
                //    DatumSlanja = n.DatumSlanja,
                //    Naslov = n.Naslov,
                //    NovostId = n.NovostId,
                //    Procitano = true
                //};

                //await _notifikacijeService.Update<Notifikacija>(n.Id, updateN);


            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
