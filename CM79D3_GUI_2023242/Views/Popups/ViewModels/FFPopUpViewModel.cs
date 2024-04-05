using CM79D3_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;

namespace CM79D3_GUI_2023242.WpfClient.Views.Popups.ViewModels
{
    internal class FFPopUpViewModel
    {
        public List<FireStation> FireStations { get; set; }
        public Firefighter FF { get; set; }
        private int id;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Rank { get; set; }
        public string ContactInfo { get; set; }
        public FireStation _FireStation { get; set; }
        public ICommand CloseCommand { get; set; }
        public FFPopUpViewModel()
        {
            FireStations = new RestService("http://localhost:26947/", "firestation").Get<FireStation>("firestation");
        }
        public void Init(Firefighter ff, Action action, IMessenger messenger)
        {
            id = ff.Id;
            FirstName = ff.FirstName;
            LastName = ff.LastName;
            Rank = ff.Rank;
            ContactInfo = ff.ContactInformation;
            _FireStation = ff.FireStation;
            CloseCommand = new RelayCommand(() =>
                {
                    int fsid = 0;
                    if (_FireStation != null)
                    {
                        fsid = _FireStation.Id;
                    }
                    messenger.Send(new Firefighter()
                    {
                        Id = id,
                        FirstName = FirstName,
                        LastName = LastName,
                        Rank = Rank,
                        ContactInformation = ContactInfo,
                        FireStation_ID = fsid
                    }, "FirefighterUpdatedOrAdded");
                    action();
                }
                           );
        }
    }
}
