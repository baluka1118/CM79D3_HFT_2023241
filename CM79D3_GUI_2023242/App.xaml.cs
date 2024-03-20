using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using CM79D3_GUI_2023242.WpfClient.Services;
using CM79D3_GUI_2023242.WpfClient.Services.Interfaces;
using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace CM79D3_GUI_2023242
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            Ioc.Default.ConfigureServices(
                new ServiceCollection()
                    .AddSingleton<IEmergencyCallEditor, EmergencyCallEditorViaWindow>()
                    .AddSingleton<IFireStationEditor, FireStationEditorViaWindow>()
                    .AddSingleton<IEquipmentEditor, EquipmentEditorViaWindow>()
                    .AddSingleton<IFirefighterEditor, FirefighterEditorViaWindow>()
                    .BuildServiceProvider());
        }
    }
}
