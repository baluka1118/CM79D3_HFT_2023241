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
using CM79D3_GUI_2023242.WpfClient.Services;
using CM79D3_GUI_2023242.WpfClient.Services.Interfaces;
using CommunityToolkit.Mvvm.DependencyInjection;

namespace CM79D3_GUI_2023242.WpfClient.ViewModels
{
    class EmergencyCallViewModel : ObservableRecipient
    {
        public RestCollection<EmergencyCall> EmergencyCalls { get; set; }
        private IEmergencyCallEditor editor;
        public EmergencyCallViewModel()
        {
            
            EmergencyCalls = new RestCollection<EmergencyCall>("http://localhost:26947/", "emergencycall");
            if (editor == null)
            {
                editor = new EmergencyCallEditorViaWindow(); //Ioc throws exception
            }
            AddCommand = new RelayCommand(async () =>
            {
                 var ec = new EmergencyCall();
                 ec.DateTime = DateTime.Now;
                 if (!editor.Add(ec))
                 {
                     return;
                 }

                 try
                 {
                    await EmergencyCalls.Add(ec);
                 }
                 catch (Exception e)
                 {
                     MessageBox.Show("ERROR", e.Message, MessageBoxButton.OK, MessageBoxImage.Error);
                 }
            }, () => true);
            UpdateCommand = new RelayCommand(async () =>
            {
                if (!editor.Update(SelectedItem))
                {
                    return;
                }
                try
                {
                    await EmergencyCalls.Update(SelectedItem);
                }
                catch (Exception e)
                {
                    MessageBox.Show("ERROR", e.Message, MessageBoxButton.OK, MessageBoxImage.Error);
                }
            });
            DeleteCommand = new RelayCommand(Delete);
        }
        private EmergencyCall selectedItem;
        public EmergencyCall SelectedItem
        {
            get { return selectedItem; }
            set
            {
                if (SetProperty(ref selectedItem, value))
                {
                    AddCommand.NotifyCanExecuteChanged();
                    DeleteCommand.NotifyCanExecuteChanged();
                    UpdateCommand.NotifyCanExecuteChanged();
                }
            }
        }
        public RelayCommand AddCommand { get; set; }
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
    }
}
