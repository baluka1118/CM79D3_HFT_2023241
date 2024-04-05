using CM79D3_GUI_2023242.WpfClient.Services.Interfaces;
using CM79D3_GUI_2023242.WpfClient.Views.Popups;
using CM79D3_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Messaging;

namespace CM79D3_GUI_2023242.WpfClient.Services
{
    internal class FirefighterEditorViaWindow : IFirefighterEditor
    {
        public bool Add(Firefighter ff, IMessenger messenger)
        {
            var window = new FirefighterEditorPopUp(ff, messenger);
            return window.ShowDialog().Value;
        }

        public bool Update(Firefighter ff, IMessenger messenger)
        {
            var window = new FirefighterEditorPopUp(ff, messenger);    
            return window.ShowDialog().Value;
        }
    }
}
