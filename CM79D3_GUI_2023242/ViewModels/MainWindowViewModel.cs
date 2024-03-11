﻿using CM79D3_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using CM79D3_GUI_2023242.WpfClient.Views;
using CommunityToolkit.Mvvm.Input;

namespace CM79D3_GUI_2023242.WpfClient.ViewModels
{
    class MainWindowViewModel : ObservableRecipient
    {
        private UserControl currentControl;

        public UserControl CurrentControl
        {
            get { return currentControl; }
            set
            {
                SetProperty(ref currentControl, value);

            }
        }
        public ICommand EmergencyCallCommand { get; set; }
        public MainWindowViewModel()
        {
            EmergencyCallCommand = new RelayCommand(() =>
            {
                CurrentControl = new EmergencyCallView();
            });
        }
    }
}
