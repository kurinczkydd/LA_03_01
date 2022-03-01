using LA_03_01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LA_03_01.Logic
{
    class SuperHeroLogic : ISuperHeroLogic
    {
        IList<SuperHero> SuperHeroBarrack;
        IList<SuperHero> SuperHeroArmy;

        public void SetupCollection(IList<SuperHero> barrack, IList<SuperHero> army)
        {
            this.SuperHeroBarrack = barrack;
            this.SuperHeroArmy = army;

        }

        public double AVGPower
        {
            get
            {
                return SuperHeroArmy.Count == 0 ? 0 : SuperHeroArmy.Average(t => t.Power);
            }
        }

        public double AVGSpeed
        {
            get
            {
                return SuperHeroArmy.Count == 0 ? 0 : SuperHeroArmy.Average(t => t.Speed);
            }
        }

        public void AddtoArmy(SuperHero superHero)
        {
            SuperHeroArmy.Add(superHero.GetCopy());
        }
        public void RemovefromArmy(SuperHero superHero)
        {
            SuperHeroArmy.Remove(superHero);
        }



    }
}
