﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CM79D3_GUI_2023242.WpfClient.Services;
using CM79D3_GUI_2023242.WpfClient.Views.Popups;
using CM79D3_HFT_2023241.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.Mvvm.Input;
namespace CM79D3_GUI_2023242.WpfClient.ViewModels
{
    class EquipmentViewModel : ObservableRecipient
    {
        public RestCollection<Equipment> Equipments { get; set; }
        private IEquipmentEditor editor;
        private Equipment addOrUpdate;
        public EquipmentViewModel()
        {
            Equipments = new RestCollection<Equipment>("http://localhost:26947/", "Equipment", "hub");
            if (editor == null)
            {
                editor = Ioc.Default.GetService<IEquipmentEditor>();
            }
            Messenger.Register<EquipmentViewModel, Equipment, string>(this, "EquipmentUpdatedOrAdded",
                (recipient, message) =>
                {
                    addOrUpdate = message;
                });
            AddCommand = new RelayCommand(async () =>
            {
                var eq = new Equipment();
                if (!editor.Add(eq,Messenger))
                {
                    return;
                }
                try
                {
                    await Equipments.Add(addOrUpdate);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            });
            UpdateCommand = new RelayCommand(async () =>
            {
                if (!editor.Update(SelectedItem, Messenger))
                {
                    return;
                }
                var oldselected = SelectedItem;
                try
                {
                    SelectedItem.Id = addOrUpdate.Id;
                    SelectedItem.Type = addOrUpdate.Type;
                    SelectedItem.Condition = addOrUpdate.Condition;
                    SelectedItem.Firefighter_ID = addOrUpdate.Firefighter_ID;
                    await Equipments.Update(SelectedItem);
                }
                catch (Exception e)
                {
                    SelectedItem = oldselected;
                    MessageBox.Show(e.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            });
            DeleteCommand = new RelayCommand(async () =>
            {
                try
                {
                    Equipments.Delete(SelectedItem.Id);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            });

        }
        private Equipment selectedItem;
        public Equipment SelectedItem
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
