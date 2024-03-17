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

namespace CM79D3_GUI_2023242.WpfClient.Views.Popups
{
    /// <summary>
    /// Interaction logic for EmergencyCallEditorPopUp.xaml
    /// </summary>
    public partial class EmergencyCallEditorPopUp : Window
    {
        public EmergencyCallEditorPopUp(EmergencyCall emergencyCall)
        {
            InitializeComponent();
            var viewModel = new ECPopUpViewModel(); 
            this.DataContext = viewModel;
            viewModel.Init(emergencyCall);
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            foreach (var item in grid.Children)
            {
                if (item is TextBox tb)
                {
                    tb.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                    continue;
                }

                if (item is DatePicker dp)
                {
                    dp.GetBindingExpression(DatePicker.SelectedDateProperty).UpdateSource();
                    continue;
                }
                if (item is ComboBox cb)
                {
                    cb.GetBindingExpression(ComboBox.SelectedItemProperty).UpdateSource();
                }
            }
            this.DialogResult = true;
        }

        private void EmergencyCallEditorPopUp_OnLoaded(object sender, RoutedEventArgs e)
        {
            cbox.ItemsSource = Enum.GetValues(typeof(IncidentType)).Cast<IncidentType>();
        }
    }
}
