using LA_03_01.Models;
using LA_03_01.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace LA_03_01
{
    /// <summary>
    /// Interaction logic for HeroEditor.xaml
    /// </summary>
    public partial class HeroEditor : Window
    {
        public HeroEditor(SuperHero hero)
        {
            InitializeComponent();
            this.DataContext = new HeroEditorWindowViewModel();
            (this.DataContext as HeroEditorWindowViewModel).Setup(hero);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in stack.Children)
            {
                if (item is TextBox t)
                {
                    t.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                }
                if (item is ComboBox t2)
                {
                    t2.GetBindingExpression(ComboBox.SelectedItemProperty).UpdateSource();
                }
                
            }
            var a = (DataContext as HeroEditorWindowViewModel).Actual;
            ;
            this.DialogResult = true;
        }
    }
}
