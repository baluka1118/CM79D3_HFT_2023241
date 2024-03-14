using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CM79D3_HFT_2023241.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows.Input;

namespace CM79D3_GUI_2023242.WpfClient.ViewModels
{
    class EmergencyCallViewModel : ObservableRecipient
    {
        public RestCollection<EmergencyCall> EmergencyCalls { get; set; }
        public EmergencyCallViewModel()
        {
            EmergencyCalls = new RestCollection<EmergencyCall>("http://localhost:26947/", "emergencycall");
            UpdateCommand = new RelayCommand(Update);
            DeleteCommand = new RelayCommand(Delete);
        }
        private EmergencyCall selectedItem;
        public EmergencyCall SelectedItem
        {
            get { return selectedItem; }
            set
            {
                SetProperty(ref selectedItem, value);
            }
        }
        public RelayCommand AddCommand { get; set; }
        private void Add()
        {
        }

        public RelayCommand DeleteCommand { get; set; }
        private void Delete()
        {
            try
            {
                EmergencyCalls.Delete(SelectedItem.Id);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("ERROR", ex.Message, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public RelayCommand UpdateCommand { get; set; }

        private void Update()
        {
            MessageBox.Show("Update");
        }
    }
}
