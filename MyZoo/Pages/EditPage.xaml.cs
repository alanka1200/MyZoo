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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MyZoo.ModelData;

namespace MyZoo.Pages
{
    /// <summary>
    /// Interaction logic for EditPage.xaml
    /// </summary>
    public partial class EditPage : Page
    {
        private Animal _animal;
        public EditPage(Animal animal = null)
        {
            InitializeComponent();
            InitializeAnimal(animal);

        }
        private void InitializeAnimal(Animal anima)
        {
            if (anima != null)
            {
                _animal = anima;
            }
            else
            {
                _animal = new Animal();
            }
        }
        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            App.db.SaveChanges();
            NavigationService.Navigate(new ListPage());
        }
        

    }
}
