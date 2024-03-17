using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CM79D3_HFT_2023241.Models;

namespace CM79D3_GUI_2023242.WpfClient.Views.Popups.ViewModels
{
    internal class EQPopUpViewModel
    {
        public List<Firefighter> Firefighters { get; set; }
        public Equipment EQ { get; set; }

        public EQPopUpViewModel()
        {
            Firefighters = new RestService("http://localhost:26947/", "firefighter").Get<Firefighter>("firefighter");
        }
        public void Init(Equipment equipment)
        {
            EQ = equipment;
        }
    }
}
