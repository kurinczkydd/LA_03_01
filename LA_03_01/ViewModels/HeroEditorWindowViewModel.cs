using LA_03_01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LA_03_01.ViewModels
{
    public class HeroEditorWindowViewModel
    {
        public SuperHero Actual { get; set; }
        
        public HeroEditorWindowViewModel()
        {

        }
        public void Setup(SuperHero hero)
        {
            this.Actual = hero;

        }
    }
}
