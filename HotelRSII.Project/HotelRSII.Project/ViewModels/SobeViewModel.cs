using SeminarskiRSII.Model;
using SeminarskiRSII.Model.Requests;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace HotelRSII.Project.ViewModels
{
   public class SobeViewModel:BaseViewModel
    {
        private readonly ApiService _Sobaservice = new ApiService("Soba");
        private readonly ApiService _sobaStatusService = new ApiService("SobaStatus");
        public SobeViewModel()
        {
            InitCommand = new Command(async () =>await Init());
        }
        public ObservableCollection<Soba> sobeList { get; set; } = new ObservableCollection<Soba>();
        public ObservableCollection<SobaStatus> sobaStatusList { get; set; } = new ObservableCollection<SobaStatus>();

        SobaStatus _SelectedSobaStatus = null;
        public SobaStatus selectedSobaStatus
        {
            get { return _SelectedSobaStatus; }
            set { SetProperty(ref _SelectedSobaStatus, value);
                if (value != null)
                {
                    InitCommand.Execute(null);
                }
            }
        }
        public ICommand InitCommand { get; set; }

       public async Task Init()
        {
            if (sobaStatusList.Count ==0)
            {
                var sobastatus = await _sobaStatusService.get<List<SobaStatus>>(null);
                foreach(var ss in sobastatus)
                {
                    sobaStatusList.Add(ss);
                }
            }
            if (selectedSobaStatus != null)
            {
                SobaSearchRequest search = new SobaSearchRequest();
                search.SobaStatusId = selectedSobaStatus.Id;
                var list = await _Sobaservice.get<List<Soba>>(search);
                sobeList.Clear();  // Jer ce se vise puta pozivati treba obrisati
                foreach (var soba in list)
                {
                    sobeList.Add(soba);
                }
            }
          
        }
    }
}
