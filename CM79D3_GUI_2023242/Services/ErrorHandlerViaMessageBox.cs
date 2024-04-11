using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CM79D3_GUI_2023242.WpfClient.Services.Interfaces;

namespace CM79D3_GUI_2023242.WpfClient.Services
{
    public class ErrorHandlerViaMessageBox : IErrorHandler
    {
        public MessageBoxButton button = MessageBoxButton.OK;
        public MessageBoxImage icon = MessageBoxImage.Error;

        public void ShowError(string message, string caption)
        {
            MessageBox.Show(message, caption, button, icon);
        }
    }
}
