using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LA_03_01.ViewModels
{
    public class Super
    {
        public Super()
        {

        }

        public Super(string Name, int Strength, int Speed)
        {
            this.Name = Name;
            this.Strength = Strength;
            this.Speed = Speed;
        }

        public string Name { get; set; }
        public int Strength { get; set; }
        public int Speed { get; set; }
    }

    public class MainWindowViewModels
    {
        ObservableCollection<Super> SuperBarack { get; set; }
        ObservableCollection<Super> SuperArmy { get; set; }

        public MainWindowViewModels()
        {
            SuperBarack = new ObservableCollection<Super>();
            SuperBarack.Add(new Super("asd", 5, 8));
            SuperBarack.Add(new Super("asd", 5, 8));

            SuperArmy = new ObservableCollection<Super>();
        }
    }
}
