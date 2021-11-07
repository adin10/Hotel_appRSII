using SeminarskiRSII.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace HotelRSII.Project.ViewModels
{
    public class NovostiViewModel
    {
        private readonly ApiService _NovostiService = new ApiService("Novosti");
        private readonly ApiService _gostiNotifikacijeService = new ApiService("GostiNotifikacije");

        public NovostiViewModel()
        {
            //Title = "Novosti";
        }
        public ObservableCollection<Novosti> NovostiList { get; set; } = new ObservableCollection<Novosti>();

        public ICommand InitCommand { get; set; }


        Dictionary<int, int> BrojPregleda = new Dictionary<int, int>();

        public async Task Init()
        {
            try
            {
                var lista = await _NovostiService.get<List<Novosti>>(null);

                var listaNotif = await _gostiNotifikacijeService.get<List<GostiNotifikacije>>(null);
                NovostiList.Clear();



                foreach (var item in lista)
                {
                    item.BrojPregleda = 0;
                    foreach (var item2 in listaNotif)
                    {
                        if (item2.Notifikacije != null && item.Id == item2.Notifikacije.NovostId && item2.Pregledana)//notifikacije su ti null pa puca stavi prvo item2.Notifikacija != null
                        {
                            item.BrojPregleda += 1;
                        }
                    }
                }
                foreach (var item in lista)
                {

                    NovostiList.Add(item);

                }

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
