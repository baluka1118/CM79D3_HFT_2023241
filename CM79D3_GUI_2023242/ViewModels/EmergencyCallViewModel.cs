using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CM79D3_HFT_2023241.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CM79D3_GUI_2023242.WpfClient.ViewModels
{
    class EmergencyCallViewModel : ObservableRecipient
    {
        public RestCollection<EmergencyCall> EmergencyCalls { get; set; }

        public EmergencyCallViewModel()
        {
            EmergencyCalls = new RestCollection<EmergencyCall>("http://localhost:26947/", "emergencycall");
        }
    }
}
