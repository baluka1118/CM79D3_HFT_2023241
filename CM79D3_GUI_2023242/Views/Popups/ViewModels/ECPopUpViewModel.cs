using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CM79D3_HFT_2023241.Models;

namespace CM79D3_GUI_2023242.WpfClient.Views.Popups.ViewModels
{
    class ECPopUpViewModel
    {
        public List<FireStation> FireStations { get; set; } 
        public EmergencyCall EC { get; set; }

        public ECPopUpViewModel()
        {
            FireStations = new RestService("http://localhost:26947/", "firestation").Get<FireStation>("firestation");
        }
        public void Init(EmergencyCall emergencyCall)
        {
            EC = emergencyCall;
            EC.IncidentType = IncidentType.Fire;
        }
    }
}
