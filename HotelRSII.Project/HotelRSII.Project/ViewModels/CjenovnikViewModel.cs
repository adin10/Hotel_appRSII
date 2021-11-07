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
   public class CjenovnikViewModel
    {
        private readonly ApiService _cjenovnikService = new ApiService("Cjenovnik");
        private readonly ApiService _sobeService = new ApiService("Soba");
        public CjenovnikViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }
        public ObservableCollection<Cjenovnik> CijeneList { get; set; } = new ObservableCollection<Cjenovnik>();
        public ObservableCollection<Soba> SobeList { get; set; } = new ObservableCollection<Soba>();

        public ICommand InitCommand { get; set; }

       public async Task Init()
        {
            if (SobeList.Count == 0)
            {
                var sobe = await _sobeService.get<List<Soba>>(null);

                foreach (var s in sobe)
                {
                    SobeList.Add(s);
                }
            }
          

            var list = await _cjenovnikService.get<List<Cjenovnik>>(null);
            CijeneList.Clear();
            foreach(var cijene in list)
            {
                CijeneList.Add(cijene);
            }
        } 

    }
}
