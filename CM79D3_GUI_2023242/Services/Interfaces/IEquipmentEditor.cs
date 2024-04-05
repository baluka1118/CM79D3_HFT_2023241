using CM79D3_HFT_2023241.Models;
using CommunityToolkit.Mvvm.Messaging;

namespace CM79D3_GUI_2023242.WpfClient.Services
{
    internal interface IEquipmentEditor
    {
        bool Add(Equipment eq, IMessenger messenger);
        bool Update(Equipment selectedItem, IMessenger messenger);
    }
}