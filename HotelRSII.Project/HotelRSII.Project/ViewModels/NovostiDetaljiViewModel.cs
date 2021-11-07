using SeminarskiRSII.Model;
using SeminarskiRSII.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRSII.Project.ViewModels
{
    public class NovostiDetaljiViewModel
    {
        private ApiService _notifikacijeGostiService = new ApiService("GostiNotifikacije");
        private ApiService _notifikacijeService = new ApiService("Notifikacije");
        private ApiService _gostiService = new ApiService("Gost");

        public NovostiDetaljiViewModel()
        {
            Title = "Novost";
        }
        public Novosti Novost { get; set; }
        public string Title { get; }

        public async Task Pregled(int novostId)
        {
            //ovdje kazes daj mi sve notifikacije za moju novost, ako novost nema notifikacije vrati se null
            var notif = await _notifikacijeService.get<List<Notifikacije>>(new NotifikacijeSearchRequest()
            {
                NovostId = novostId
            });

            var listaGostiju = await _gostiService.get<List<Gost>>(new GostiSearchRequest()
            {
                KorisnickoIme = ApiService.KorisnickoIme
            });

            Gost gost = listaGostiju.FirstOrDefault(l => l.KorisnickoIme == ApiService.KorisnickoIme);


            var search = new GostiNotifikacijeSearchRequest()
            {
                GostId = gost.Id,
                NotifikacijaId = notif.Count() > 0 ? notif[0].Id : (int?)null//ovdje ne mozes reci notif[0].Id ako ne postoji notifikacija za novost, pa tato smo postavili provjeru
            };

            var lista = await _notifikacijeGostiService.get<List<GostiNotifikacije>>(search);

            var request = new GostiNotifikacijeInsertRequest()
            {
                NotifikacijaId = notif.Count() > 0 ? notif[0].Id : 0,//ovdje zelis da zapises u bazu gosta i notifikacju ali notifikacija je null stoga se u  bazu i sprem null
                Pregledana = true,
                GostId = gost.Id
            };
            // ukoliko je lista prazna tj nema trazenog elementa znaci da putnik nije notificiran
            // pa mu pregled dodajemo preko novosti
            if (lista.Count != 0)
            {
                if (lista[0].Pregledana == false)
                {


                    await _notifikacijeGostiService.Update<GostiNotifikacije>(lista[0].Id, request);
                }
            }
            else
            {
                await _notifikacijeGostiService.Insert<GostiNotifikacije>(request);
            }
        }
    }
}
