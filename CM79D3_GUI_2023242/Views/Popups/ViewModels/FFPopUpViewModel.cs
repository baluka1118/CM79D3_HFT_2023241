using CM79D3_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM79D3_GUI_2023242.WpfClient.Views.Popups.ViewModels
{
    internal class FFPopUpViewModel
    {
        public List<FireStation> FireStations { get; set; }
        public Firefighter FF { get; set; }

        public FFPopUpViewModel()
        {
            FireStations = new RestService("http://localhost:26947/", "firestation").Get<FireStation>("firestation");
        }
        public void Init(Firefighter ff)
        {
            FF = ff;
        }
    }
}
