﻿using CM79D3_GUI_2023242.WpfClient.Services.Interfaces;
using CM79D3_GUI_2023242.WpfClient.Views.Popups;
using CM79D3_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM79D3_GUI_2023242.WpfClient.Services
{
    internal class FireStationEditorViaWindow : IFireStationEditor
    {
        public bool Add(FireStation fs)
        {
            var window = new FireStationEditorPopUp(fs);
            return window.ShowDialog().Value;
        }

        public bool Update(FireStation selectedItem)
        {
            var window = new FireStationEditorPopUp(selectedItem);
            return window.ShowDialog().Value;
        }
    }
}
