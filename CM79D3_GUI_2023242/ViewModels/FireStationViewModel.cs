using System;
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
        private IErrorHandler errorHandler;
        public FireStation addOrUpdate;
        public FireStationViewModel()
        {
            FireStations = new RestCollection<FireStation>("http://localhost:26947/", "FireStation","hub");
            Messenger.Register<FireStationViewModel, FireStation, string>(this, "FireStationUpdatedOrAdded",
                (recipient, message) =>
                {
                    addOrUpdate = message;
                });
            if (editor == null)
            {
                editor = Ioc.Default.GetService<IFireStationEditor>();
            }

            if (errorHandler == null)
            {
                errorHandler = Ioc.Default.GetService<IErrorHandler>();
            }
            AddCommand = new RelayCommand(async () =>
            {
                var fs = new FireStation();
                if (!editor.Add(fs,Messenger))
                {
                    return;
                }
                try
                {
                    await FireStations.Add(addOrUpdate);
                }
                catch (Exception e)
                {
                    errorHandler.ShowError(e.Message, "ERROR");
                }
            });
            UpdateCommand = new RelayCommand(async () =>
            {
                if (!editor.Update(SelectedItem,Messenger))
                {
                    return;
                }
                var oldselected = SelectedItem;
                try
                {
                    SelectedItem.Name = addOrUpdate.Name;
                    SelectedItem.Location = addOrUpdate.Location;
                    SelectedItem.ContactInformation = addOrUpdate.ContactInformation;
                    await FireStations.Update(SelectedItem);
                }
                catch (Exception e)
                {
                    errorHandler.ShowError(e.Message, "ERROR");
                    SelectedItem = oldselected;
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
                    errorHandler.ShowError(e.Message, "ERROR");
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
