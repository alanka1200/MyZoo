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
    /// Interaction logic for ListPage.xaml
    /// </summary>
    public partial class ListPage : Page
    {

        public ListPage()
        {
            InitializeComponent();
            var animals = App.db.Animal.ToList();
            LVprod.ItemsSource = animals;
            var allTypes = App.db.ListAnimal.ToList();
            allTypes.Insert(0, new ListAnimal());
            NameAni.ItemsSource = allTypes;
            NameAni.SelectedIndex = 0;
            CBproiz.SelectedIndex = 0;
            Refresh();
        }

        public void Refresh()
        {
            var filterAnimal = App.db.Animal.ToList();
            if (CBproiz.SelectedIndex == 1)
                filterAnimal = filterAnimal.OrderBy(x => x.Name).ToList();
            else if (CBproiz.SelectedIndex == 2)
                filterAnimal =
                    filterAnimal.OrderByDescending(x => x.Name).ToList(); //сортировка 
            if (NameAni.SelectedIndex > 0)
            {
                var a = NameAni.SelectedIndex.ToString();
                filterAnimal = filterAnimal.Where(x => x.Name.ToString().Contains(a.ToLower())).ToList(); //фильтрация по названию
            }
        }

        private void BTNdel_Click(object sender, RoutedEventArgs e)
        {
            var animal = LVprod.SelectedItem as Animal;
            if (animal != null)
            {
                if (MessageBox.Show("Вы действительно хотите удалить эту запись?", "Уведомление",
                        MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    App.db.Animal.Remove(animal);
                    App.db.SaveChanges();
                    LVprod.ItemsSource = App.db.Animal.ToList();
                }
            }
        }

        private void BTNedt_Click(object sender, RoutedEventArgs e)
        {
            var select = LVprod.SelectedItem as Animal;
            if (select == null)
            {
                MessageBox.Show("Выберите животное");
                return;
            }
            NavigationService.Navigate(new EditPage(select));
        }
        private void CBproiz_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }
        private void NameAni_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }
    }
}
