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
    /// Interaction logic for FirefighterEditorPopUp.xaml
    /// </summary>
    public partial class FirefighterEditorPopUp : Window
    {
        public FirefighterEditorPopUp(Firefighter ff)
        {
            InitializeComponent();
            var viewModel = new FFPopUpViewModel();
            this.DataContext = viewModel;
            viewModel.Init(ff);
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
                if (item is ComboBox cb)
                {
                    if (cb.SelectedItem is FireStation fs)
                    {
                        (this.DataContext as FFPopUpViewModel).FF.FireStation_ID = fs.Id;
                        continue;
                    }
                    cb.GetBindingExpression(ComboBox.SelectedItemProperty).UpdateSource();
                }
            }
            this.DialogResult = true;
        }
    }
}
