using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CM79D3_HFT_2023241.Models;

namespace CM79D3_GUI_2023242.WpfClient.Views.Popups.ViewModels
{
    internal class FSPopUpViewModel
    {
        public FireStation FS { get; set; }

        public void Init(FireStation fs)
        {
            FS = fs;
        }
    }
}
