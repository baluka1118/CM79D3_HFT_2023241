using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CM79D3_HFT_2023241.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CM79D3_GUI_2023242.WpfClient.ViewModels
{
    class FirefighterViewModel : ObservableRecipient
    {
        public RestCollection<Firefighter> Firefighters { get; set; }

        public FirefighterViewModel()
        {
            Firefighters = new RestCollection<Firefighter>("http://localhost:26947/", "firefighter");
            DeleteCommand = new RelayCommand(Delete);
        }
        private Firefighter selectedItem;
        public Firefighter SelectedItem
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
                Firefighters.Delete(SelectedItem.Id);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("ERROR", ex.Message, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public RelayCommand UpdateCommand { get; set; }

        private void Update()
        {
        }
    }
}
