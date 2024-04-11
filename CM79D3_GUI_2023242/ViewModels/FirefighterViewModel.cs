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
        private IErrorHandler errorHandler;
        private Firefighter addOrUpdate;
        public FirefighterViewModel()
        {
            Firefighters = new RestCollection<Firefighter>("http://localhost:26947/", "Firefighter","hub");
            Messenger.Register<FirefighterViewModel, Firefighter, string>(this, "FirefighterUpdatedOrAdded",
                (recipient, message) =>
                {
                    addOrUpdate = message;
                });
            if (editor == null)
            {
                editor = Ioc.Default.GetService<IFirefighterEditor>();
            }

            if (errorHandler == null)
            {
                errorHandler = Ioc.Default.GetService<IErrorHandler>();
            }
            AddCommand = new RelayCommand(async () =>
            {
                var ff = new Firefighter();
                bool x = editor.Add(ff,Messenger);
                if (!x)
                {
                    return;
                }
                try
                {
                    await Firefighters.Add(addOrUpdate);
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
                    SelectedItem.Id = addOrUpdate.Id;
                    SelectedItem.FirstName = addOrUpdate.FirstName;
                    SelectedItem.LastName = addOrUpdate.LastName;
                    SelectedItem.Rank = addOrUpdate.Rank;
                    SelectedItem.ContactInformation = addOrUpdate.ContactInformation;
                    SelectedItem.FireStation_ID = addOrUpdate.FireStation_ID;
                    await Firefighters.Update(SelectedItem);
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
                    await Firefighters.Delete(SelectedItem.Id);
                }
                catch (Exception e)
                {
                    errorHandler.ShowError(e.Message, "ERROR");
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
