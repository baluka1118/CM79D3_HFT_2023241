using CM79D3_HFT_2023241.Models;
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

        private EmergencyCallView emergencyCallView;
        private EquipmentView equipmentView;
        private FirefighterView firefighterView;
        private FireStationView fireStationView;
        private WelcomeView welcomeView;
        public ICommand EmergencyCallNavigate { get; set; }
        public ICommand FireStationNavigate { get; set; }
        public ICommand FirefighterNavigate { get; set; }
        public ICommand EquipmentNavigate { get; set; }
        public MainWindowViewModel()
        {
            welcomeView = new WelcomeView();
            CurrentControl = welcomeView;
            emergencyCallView = new EmergencyCallView();
            equipmentView = new EquipmentView();
            firefighterView = new FirefighterView();
            fireStationView = new FireStationView();
            EmergencyCallNavigate = new RelayCommand(() =>
            {
                CurrentControl = emergencyCallView;
            });
            FireStationNavigate = new RelayCommand(() =>
            {
                CurrentControl = fireStationView;
            });
            FirefighterNavigate = new RelayCommand(() =>
            {
                CurrentControl = firefighterView;
            });
            EquipmentNavigate = new RelayCommand(() =>
            {
                CurrentControl = equipmentView;
            });
            NavigateBack = new RelayCommand(() =>
            {
                CurrentControl = welcomeView;
            });
        }
        public ICommand NavigateBack { get; set; }
        private void PerformNavigateBack()
        {
        }
    }
}
