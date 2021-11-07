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
   public class DrzavaViewModel
    {
        private readonly ApiService _drzavaService = new ApiService("Drzava");

        public DrzavaViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }
        public ObservableCollection<Drzava> drzaveList { get; set; } = new ObservableCollection<Drzava>();

        public ICommand InitCommand { get; set; }

        public async Task Init()
        {
            var list =await _drzavaService.get<List<Drzava>>(null);
            drzaveList.Clear();
            foreach(var drzave in list)
            {
                drzaveList.Add(drzave);
            }
        }
    }
}
