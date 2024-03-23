using System;
using System.Collections.Generic;
using System.Linq;
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
    class FirefighterViewModel : ObservableRecipient
    {
        public RestCollection<Firefighter> Firefighters { get; set; }
        public IFirefighterEditor editor;
        public FirefighterViewModel()
        {
            Firefighters = new RestCollection<Firefighter>("http://localhost:26947/", "Firefighter","hub");
            if (editor == null)
            {
                editor = Ioc.Default.GetService<IFirefighterEditor>();
            }
            AddCommand = new RelayCommand(async () =>
            {
                var ff = new Firefighter();
                bool x = editor.Add(ff);
                if (!x)
                {
                    return;
                }
                try
                {
                    await Firefighters.Add(ff);
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
                    await Firefighters.Update(SelectedItem);
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
                    await Firefighters.Delete(SelectedItem.Id);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            });
        }
        private Firefighter selectedItem;
        public Firefighter SelectedItem
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
