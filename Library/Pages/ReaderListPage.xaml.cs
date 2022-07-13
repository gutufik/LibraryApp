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
using Library.Data;

namespace Library.Pages
{
    /// <summary>
    /// Interaction logic for ReaderListPage.xaml
    /// </summary>
    public partial class ReaderListPage : Page
    {
        public List<Reader> Readers { get; set; }
        public ReaderListPage()
        {
            InitializeComponent();
            Readers = DataAccess.GetReaders();
            DataAccess.Refresh += RefreshList;
            DataContext = this;
        }

        private void RefreshList()
        {
            TbSearch.Text = "";
            Readers = DataAccess.GetReaders();
            LvReaders.ItemsSource = Readers;
            LvReaders.Items.Refresh();
        }

        private void TbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Readers = DataAccess.GetReaders().Where(x => x.FirstName.ToLower().Contains(TbSearch.Text.ToLower()) 
                                                    || x.LastName.ToLower().Contains(TbSearch.Text.ToLower())).ToList();
            LvReaders.ItemsSource = Readers;
            LvReaders.Items.Refresh();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            var reader = new Reader();
            NavigationService.Navigate(new ReaderPage(reader));
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            var reader = LvReaders.SelectedItem as Reader;
            if (reader != null)
                NavigationService.Navigate(new ReaderPage(reader));
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var reader = (sender as Button).DataContext as Reader;

            if (MessageBox.Show("Вы точно хотите удалить читателя?", "Предупреждение", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                DataAccess.DeleteReader(reader);
        }
    }
}
