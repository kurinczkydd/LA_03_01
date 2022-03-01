using LA_03_01.Logic;
using LA_03_01.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Microsoft.Toolkit.Mvvm.Input;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
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
        public ICommand SaveCommand { get; set; }

        public double AVGPower
        {
            get
            {
                return logic.AVGPower;
            }
        }

        public double AVGSpeed
        {
            get
            {
                return logic.AVGSpeed;
            }
        }

        public ObservableCollection<SuperHero> SuperBarrack { get; set; }
        public ObservableCollection<SuperHero> SuperArmy { get; set; }

        private SuperHero selectedFromBarrack;

        public SuperHero SelectedFromBarrack
        {
            get { return selectedFromBarrack; }
            set
            {
                SetProperty(ref selectedFromBarrack, value);
                (AddToArmyCommand as RelayCommand).NotifyCanExecuteChanged();
                (EditSuperHeroCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }

        private SuperHero selectedFromArmy;

        public SuperHero SelectedFromArmy
        {
            get { return selectedFromArmy; }
            set
            {
                SetProperty(ref selectedFromArmy, value);
                (RemoveFromArmyCommand as RelayCommand).NotifyCanExecuteChanged();
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
            if (File.Exists("superbarrack.json"))
                SuperBarrack = JsonConvert.DeserializeObject<ObservableCollection<SuperHero>>(File.ReadAllText("superbarrack.json"));
            SuperBarrack.Add(new SuperHero() { Name = "Superman", Power = 10, Speed = 10, Wichside = side.Good });
            SuperBarrack.Add(new SuperHero() { Name = "Batman", Power = 6, Speed = 8, Wichside = side.Good });
            SuperBarrack.Add(new SuperHero() { Name = "Joker", Power = 4, Speed = 7, Wichside = side.Bad });
            SuperBarrack.Add(new SuperHero() { Name = "Iron Man", Power = 7, Speed = 9, Wichside = side.Good });
            SuperBarrack.Add(new SuperHero() { Name = "Two Face", Power = 4, Speed = 3, Wichside = side.Bad });
            SuperBarrack.Add(new SuperHero() { Name = "Robin hood", Power = 2, Speed = 5, Wichside = side.Neutral });


            SuperArmy = new ObservableCollection<SuperHero>();
            if (File.Exists("superarmy.json"))
                SuperArmy = JsonConvert.DeserializeObject<ObservableCollection<SuperHero>>(File.ReadAllText("superarmy.json"));

            logic.SetupCollection(SuperBarrack, SuperArmy);

            AddToArmyCommand = new RelayCommand(
                () => logic.AddtoArmy(SelectedFromBarrack),
                () => SelectedFromBarrack != null
                );

            RemoveFromArmyCommand = new RelayCommand(
                () => logic.RemovefromArmy(SelectedFromArmy),
                () => SelectedFromArmy != null
                );

            EditSuperHeroCommand = new RelayCommand(
                () => logic.EditSuperHero(SelectedFromBarrack),
                () => SelectedFromBarrack != null
                );
            
            SaveCommand = new RelayCommand(() => SaveToJson());

            Messenger.Register<MainWindowViewModels, string, string>(this, "SuperHeroInfo", (recipient, msg) =>
            {
                OnPropertyChanged("AVGPower");
                OnPropertyChanged("AVGSpeed");
            });
        }

        private void SaveToJson()
        {
            File.WriteAllText("superbarrack.json", JsonConvert.SerializeObject(SuperBarrack));
            File.WriteAllText("superarmy.json", JsonConvert.SerializeObject(SuperArmy));
        }
    }
}
