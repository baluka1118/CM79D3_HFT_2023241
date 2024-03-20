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
            
            EmergencyCalls = new RestCollection<EmergencyCall>("http://localhost:26947/", "EmergencyCall", "hub");
            if (editor == null)
            {
                editor = Ioc.Default.GetService<IEmergencyCallEditor>();
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
                     MessageBox.Show(e.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
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
                    MessageBox.Show(e.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            });
            DeleteCommand = new RelayCommand(async () =>
            {
                try
                {
                    await EmergencyCalls.Delete(SelectedItem.Id);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            });
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
        public RelayCommand DeleteCommand { get; set; }


        public RelayCommand UpdateCommand { get; set; }
    }
}
