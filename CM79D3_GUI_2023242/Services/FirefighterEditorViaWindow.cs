using CM79D3_GUI_2023242.WpfClient.Services.Interfaces;
using CM79D3_GUI_2023242.WpfClient.Views.Popups;
using CM79D3_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM79D3_GUI_2023242.WpfClient.Services
{
    internal class FirefighterEditorViaWindow : IFirefighterEditor
    {
        public bool Add(Firefighter ff)
        {
            var window = new FirefighterEditorPopUp(ff);
            return window.ShowDialog().Value;
        }

        public bool Update(Firefighter ff)
        {
            var window = new FirefighterEditorPopUp(ff);
            return window.ShowDialog().Value;
        }
    }
}
