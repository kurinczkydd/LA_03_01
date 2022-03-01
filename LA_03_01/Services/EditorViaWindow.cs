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
        public void Edit(SuperHero superHero)
        {
            new HeroEditor().ShowDialog();
        }
    }
}
