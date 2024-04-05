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
    internal class EQPopUpViewModel
    {
        public List<Firefighter> Firefighters { get; set; }
        public IEnumerable<EquipmentCondition> Conditions { get; set; }
        private int id;
        public string Type { get; set; }
        public EquipmentCondition _Condition { get; set; }
        public Firefighter _Firefighter { get; set; }
        public ICommand CloseCommand { get; set; }

        public EQPopUpViewModel()
        {
            Firefighters = new RestService("http://localhost:26947/", "firefighter").Get<Firefighter>("firefighter");
        }
        public void Init(Equipment equipment, Action action, IMessenger messenger)
        {
            Conditions = Enum.GetValues(typeof(EquipmentCondition)).Cast<EquipmentCondition>();
            id = equipment.Id;
            Type = equipment.Type;
            _Condition = equipment.Condition;
            _Firefighter = equipment.Firefighter;
            CloseCommand = new RelayCommand(() =>
            {
                int ffid = 0;
                if (_Firefighter!=null)
                {
                    ffid = _Firefighter.Id;
                }
                    if (_Firefighter==null)
                    {
                        
                    }
                    messenger.Send(new Equipment()
                    {
                        Id = id,
                        Type = Type,
                        Condition = _Condition,
                        Firefighter_ID = ffid
                    }, "EquipmentUpdatedOrAdded");
                    action();
                });
        }
    }
}
