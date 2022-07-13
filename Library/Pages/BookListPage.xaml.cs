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
    /// Interaction logic for BookListPage.xaml
    /// </summary>
    public partial class BookListPage : Page
    {
        public List<Book> Books { get; set; }
        public BookListPage()
        {
            InitializeComponent();
            Books = DataAccess.GetBooks();
            DataContext = this;

            DataAccess.Refresh += RefreshList;

        }
        private void RefreshList()
        {
            TbSearch.Text = "";
            Books = DataAccess.GetBooks();
            LvBooks.ItemsSource = Books;
            LvBooks.Items.Refresh();
        }

        private void LvBooks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void TbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Books = DataAccess.GetBooks().Where(x => x.Title.ToLower().Contains(TbSearch.Text.ToLower())).ToList();
            LvBooks.ItemsSource = Books;
            LvBooks.Items.Refresh();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            var book = new Book();
            NavigationService.Navigate(new BookPage(book));
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            var book = LvBooks.SelectedItem as Book;

            if (book != null)
                NavigationService.Navigate(new BookPage(book));
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var book = (sender as Button).DataContext as Book;

            if (MessageBox.Show("Вы точно хотите удалить эту книгу?", "Предупреждение", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                DataAccess.DeleteBook(book);
        }
    }
}
