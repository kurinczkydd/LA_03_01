using LA_03_01.Logic;
using LA_03_01.Services;
using LA_03_01.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Microsoft.Toolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace LA_03_01
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
                        .AddSingleton<ISuperHeroLogic, SuperHeroLogic>()
                        .AddSingleton<ISuperHeroEditorService, EditorViaWindow>()
                        .AddSingleton<IMessenger>(WeakReferenceMessenger.Default)
                        .BuildServiceProvider()
                    );
        }
    }
}
