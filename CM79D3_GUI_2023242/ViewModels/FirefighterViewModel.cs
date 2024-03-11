﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CM79D3_HFT_2023241.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CM79D3_GUI_2023242.WpfClient.ViewModels
{
    class FirefighterViewModel : ObservableRecipient
    {
        public RestCollection<Firefighter> Firefighters { get; set; }

        public FirefighterViewModel()
        {
            Firefighters = new RestCollection<Firefighter>("http://localhost:26947/", "firefighter");
        }
    }
}
