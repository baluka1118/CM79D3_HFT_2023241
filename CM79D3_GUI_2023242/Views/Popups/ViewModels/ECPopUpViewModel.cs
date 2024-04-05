using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CM79D3_HFT_2023241.Models;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;

namespace CM79D3_GUI_2023242.WpfClient.Views.Popups.ViewModels
{
    class ECPopUpViewModel
    {
        public List<FireStation> FireStations { get; set; }
        public IEnumerable<IncidentType> IncidentTypes { get; set; }
        private int id;
        public string CName { get; set; }
        public string CPhone { get; set; }
        public string IncidentLocation { get; set; }    
        public IncidentType _IncidentType { get; set; }
        public DateTime IncidentTime { get; set; }
        public FireStation _FireStation { get; set; }

        public ICommand CloseCommand { get; set; }
        public ECPopUpViewModel()
        {
            FireStations = new RestService("http://localhost:26947/", "firestation").Get<FireStation>("firestation");
        }
        public void Init(EmergencyCall emergencyCall, Action action, IMessenger messenger)
        {
            IncidentTypes = Enum.GetValues(typeof(IncidentType)).Cast<IncidentType>();
            id = emergencyCall.Id;
            CName = emergencyCall.CallerName;
            CPhone = emergencyCall.CallerPhone;
            IncidentLocation = emergencyCall.IncidentLocation;
            _IncidentType = emergencyCall.IncidentType;
            IncidentTime = emergencyCall.DateTime;
            _FireStation = emergencyCall.FireStation;
            CloseCommand = new RelayCommand(() =>
                {
                    int fsid = 0;
                    if (_FireStation != null)
                    {
                        fsid = _FireStation.Id;
                    }
                    messenger.Send(new EmergencyCall()
                    {
                        Id = id,
                        CallerName = CName,
                        CallerPhone = CPhone,
                        IncidentLocation = IncidentLocation,
                        IncidentType = _IncidentType,
                        DateTime = IncidentTime,
                        FireStation_ID = fsid
                    }, "EmergencyCallUpdatedOrAdded");
                    action();
                }
            );
        }
    }
}
