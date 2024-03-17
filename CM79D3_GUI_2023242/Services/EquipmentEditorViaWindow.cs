using CM79D3_GUI_2023242.WpfClient.Views.Popups;
using CM79D3_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM79D3_GUI_2023242.WpfClient.Services
{
    internal class EquipmentEditorViaWindow : IEquipmentEditor
    {
        public bool Add(Equipment eq)
        {
            var window = new EquipmentEditorPopUp(eq);
            return window.ShowDialog().Value;
        }

        public bool Update(Equipment selectedItem)
        {
            var window = new EquipmentEditorPopUp(selectedItem);
            return window.ShowDialog().Value;
        }
    }
}
