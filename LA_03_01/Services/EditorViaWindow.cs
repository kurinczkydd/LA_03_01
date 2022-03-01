using LA_03_01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LA_03_01.Services
{
    public class EditorViaWindow : ISuperHeroEditorService
    {
        public SuperHero Add()
        {
            SuperHero superHero = new SuperHero();
            HeroEditor he = new HeroEditor(superHero);
            he.ShowDialog();
            return superHero;
        }
    }
}
