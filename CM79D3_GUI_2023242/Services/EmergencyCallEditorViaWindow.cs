using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CM79D3_GUI_2023242.WpfClient.Services.Interfaces;
using CM79D3_GUI_2023242.WpfClient.Views.Popups;
using CM79D3_HFT_2023241.Models;
using CommunityToolkit.Mvvm.Messaging;

namespace CM79D3_GUI_2023242.WpfClient.Services
{
    class EmergencyCallEditorViaWindow : IEmergencyCallEditor
    {
        public bool Add(EmergencyCall ec, IMessenger messenger)
        {
            var window = new EmergencyCallEditorPopUp(ec, messenger);
            return window.ShowDialog().Value;
        }

        public bool Update(EmergencyCall selectedItem, IMessenger messenger)
        {
            var window = new EmergencyCallEditorPopUp(selectedItem,messenger);
            return window.ShowDialog().Value;
        }
    }

}
