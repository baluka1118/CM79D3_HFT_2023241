using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CM79D3_HFT_2023241.Models;

namespace CM79D3_GUI_2023242.WpfClient.Services.Interfaces
{
    interface IEmergencyCallEditor
    {
        public bool Add(EmergencyCall ec);
        bool Update(EmergencyCall selectedItem);
    }
}
