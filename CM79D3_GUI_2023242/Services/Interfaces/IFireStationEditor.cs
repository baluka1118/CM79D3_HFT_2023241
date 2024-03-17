using CM79D3_HFT_2023241.Models;

namespace CM79D3_GUI_2023242.WpfClient.Services.Interfaces
{
    internal interface IFireStationEditor
    {
        bool Add(FireStation fs);
        bool Update(FireStation selectedItem);
    }
}