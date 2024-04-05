using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using CM79D3_GUI_2023242.WpfClient.Views.Popups.ViewModels;
using CM79D3_HFT_2023241.Models;
using CommunityToolkit.Mvvm.Messaging;

namespace CM79D3_GUI_2023242.WpfClient.Views.Popups
{
    /// <summary>
    /// Interaction logic for EmergencyCallEditorPopUp.xaml
    /// </summary>
    public partial class EmergencyCallEditorPopUp : Window
    {
        public EmergencyCallEditorPopUp(EmergencyCall emergencyCall, IMessenger messenger)
        {
            InitializeComponent();
            var viewModel = new ECPopUpViewModel(); 
            this.DataContext = viewModel;
            viewModel.Init(emergencyCall, () => { this.DialogResult = true;}, messenger);
        }
    }
}
