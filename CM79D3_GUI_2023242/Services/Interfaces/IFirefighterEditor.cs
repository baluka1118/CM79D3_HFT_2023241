using CM79D3_HFT_2023241.Models;
using CommunityToolkit.Mvvm.Messaging;

namespace CM79D3_GUI_2023242.WpfClient.Services.Interfaces
{
    internal interface IFirefighterEditor
    {
        bool Add(Firefighter ff, IMessenger messenger);
        bool Update(Firefighter ff, IMessenger messenger);
    }
}