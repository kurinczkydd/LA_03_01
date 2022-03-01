using LA_03_01.Models;
using LA_03_01.Services;
using Microsoft.Toolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LA_03_01.Logic
{
    public class SuperHeroLogic : ISuperHeroLogic
    {
        IList<SuperHero> SuperHeroBarrack;
        IList<SuperHero> SuperHeroArmy;
        IMessenger messenger;
        ISuperHeroEditorService heroEditorService;

        public void SetupCollection(IList<SuperHero> barrack, IList<SuperHero> army)
        {
            this.SuperHeroBarrack = barrack;
            this.SuperHeroArmy = army;

        }
        public SuperHeroLogic(IMessenger messenger,ISuperHeroEditorService heroEditorService)
        {
            this.messenger = messenger;
            this.heroEditorService = heroEditorService;
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
            messenger.Send("Superhero Added", "SuperHeroInfo");
        }
        public void RemovefromArmy(SuperHero superHero)
        {
            SuperHeroArmy.Remove(superHero);
            messenger.Send("Superhero Removed", "SuperHeroInfo");
        }
        public void AddSuperHero(SuperHero superHero)
        {
            SuperHeroBarrack.Add(superHero);
            heroEditorService.Add(superHero);
            messenger.Send("Superhero Added", "SuperHeroInfo");
        }



    }
}
