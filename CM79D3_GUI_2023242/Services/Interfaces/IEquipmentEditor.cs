using CM79D3_HFT_2023241.Models;

namespace CM79D3_GUI_2023242.WpfClient.Services
{
    internal interface IEquipmentEditor
    {
        bool Add(Equipment eq);
        bool Update(Equipment selectedItem);
    }
}