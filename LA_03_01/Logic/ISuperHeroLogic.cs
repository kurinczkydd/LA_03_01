using LA_03_01.Models;
using System.Collections.Generic;

namespace LA_03_01.Logic
{
    interface ISuperHeroLogic
    {
        double AVGPower { get; }
        double AVGSpeed { get; }

        void AddtoArmy(SuperHero superHero);
        void RemovefromArmy(SuperHero superHero);
        void SetupCollection(IList<SuperHero> barrack, IList<SuperHero> army);
    }
}