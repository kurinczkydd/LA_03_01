﻿using LA_03_01.Logic;
using LA_03_01.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace LA_03_01.ViewModels
{

    public class MainWindowViewModels : ObservableRecipient
    {
        ISuperHeroLogic logic;

        public ICommand AddToArmyCommand { get; set; }
        public ICommand RemoveFromArmyCommand { get; set; }
        public ICommand EditSuperHeroCommand { get; set; }

        public ObservableCollection<SuperHero> SuperBarrack { get; set; }
        public ObservableCollection<SuperHero> SuperArmy { get; set; }

        private SuperHero selectedFromBarrack;

        public SuperHero SelectedFromBarrack
        {
            get { return selectedFromBarrack; }
            set
            {
                SetProperty(ref selectedFromBarrack, value);
                //(AddToArmyCommand as RelayCommand).NotifyCanExecuteChanged();
                //(EditTrooperCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }

        private SuperHero selectedFromArmy;

        public SuperHero SelectedFromArmy
        {
            get { return selectedFromArmy; }
            set
            {
                SetProperty(ref selectedFromArmy, value);
                //(RemoveFromArmyCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public MainWindowViewModels()
            : this(IsInDesignMode ? null : Ioc.Default.GetService<ISuperHeroLogic>())
        {

        }

        public MainWindowViewModels(ISuperHeroLogic logic)
        {
            this.logic = logic;

            SuperBarrack = new ObservableCollection<SuperHero>();
            SuperBarrack.Add(new SuperHero() { Name = "asd", Power = 2, Speed = 10, Wichside = side.Good });
            SuperBarrack.Add(new SuperHero() { Name = "asd", Power = 5, Speed = 6, Wichside = side.Bad });
            

            SuperArmy = new ObservableCollection<SuperHero>();
            SuperArmy.Add(SuperBarrack[0].GetCopy());

            logic.SetupCollections(Barrack, Army);

            AddToArmyCommand = new RelayCommand(
                () => logic.AddToArmy(SelectedFromBarrack),
                () => SelectedFromBarrack != null
                );

            RemoveFromArmyCommand = new RelayCommand(
                () => logic.RemoveFromArmy(SelectedFromArmy),
                () => SelectedFromArmy != null
                );

            EditSuperHeroCommand = new RelayCommand(
                () => logic.EditTrooper(SelectedFromBarrack),
                () => SelectedFromBarrack != null
                );

            Messenger.Register<MainWindowViewModels, string, string>(this, "SuperHeroInfo", (recipient, msg) =>
            {
                OnPropertyChanged("AllCost");
                OnPropertyChanged("AVGPower");
                OnPropertyChanged("AVGSpeed");
            });
        }
    }
}
