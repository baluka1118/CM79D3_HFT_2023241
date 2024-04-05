using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CM79D3_HFT_2023241.Models;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;

namespace CM79D3_GUI_2023242.WpfClient.Views.Popups.ViewModels
{
    internal class FSPopUpViewModel
    {
        public FireStation FS { get; set; }
        public string _Name { get; set; }
        public string _Location { get; set; }
        public string _ContactInformation { get; set; }
        public ICommand CloseCommand { get; set; }

        public void Init(FireStation fs, Action action, IMessenger messenger)
        {
            _Name = fs.Name;
            _Location = fs.Location;
            _ContactInformation = fs.ContactInformation;
            CloseCommand = new RelayCommand(() =>
            {
                messenger.Send(new FireStation()
                {
                    Id = fs.Id,
                    Name = _Name,
                    Location = _Location,
                    ContactInformation = _ContactInformation
                }, "FireStationUpdatedOrAdded");
                action();
            });
        }
    }
}
