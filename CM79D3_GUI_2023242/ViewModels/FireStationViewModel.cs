﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CM79D3_GUI_2023242.WpfClient.Services;
using CM79D3_GUI_2023242.WpfClient.Services.Interfaces;
using CM79D3_HFT_2023241.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.Mvvm.Input;

namespace CM79D3_GUI_2023242.WpfClient.ViewModels
{
    class FireStationViewModel : ObservableRecipient
    {

        public RestCollection<FireStation> FireStations { get; set; }
        private IFireStationEditor editor;
        public FireStationViewModel()
        {
            FireStations = new RestCollection<FireStation>("http://localhost:26947/", "FireStation","hub");
            if (editor == null)
            {
                editor = Ioc.Default.GetService<IFireStationEditor>();
            }
            AddCommand = new RelayCommand(async () =>
            {
                var fs = new FireStation();
                if (!editor.Add(fs))
                {
                    return;
                }
                try
                {
                    await FireStations.Add(fs);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            });
            UpdateCommand = new RelayCommand(async () =>
            {
                if (!editor.Update(SelectedItem))
                {
                    return;
                }

                try
                {
                    await FireStations.Update(SelectedItem);
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
                    await FireStations.Delete(SelectedItem.Id);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            });
        }
        private FireStation selectedItem;
        public FireStation SelectedItem
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
