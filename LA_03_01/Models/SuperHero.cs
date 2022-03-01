using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LA_03_01.Models
{
    public enum side { Good, Bad, Neutral }

    class SuperHero : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string s = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(s));
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged(); }
        }

        private int power;

        public int Power
        {
            get { return power; }
            set { power = value; OnPropertyChanged(); }
        }

        private int speed;

        public int Speed
        {
            get { return speed; }
            set { speed = value; OnPropertyChanged(); }
        }

        private side witchside;

        public side Witchside
        {
            {
                get { return wichside; }
                set { wichside = value; OnPropertyChanged(); }
            }
        }
        

        public SuperHero GetCopy()
        {
            return new SuperHero()
            {
                Name = this.Name,
                Power = this.Power,
                Speed = this.Speed,
                Wichside = this.wichside
            };
        }

    }
}
