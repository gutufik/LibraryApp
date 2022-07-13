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
    /// Interaction logic for BookPage.xaml
    /// </summary>
    public partial class BookPage : Page
    {
        public Book Book { get; set; }
        public BookPage(Book book)
        {
            InitializeComponent();
            Book = book;
            DataContext = Book;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (DataAccess.SaveBook(Book))
                NavigationService.GoBack();
            else
                MessageBox.Show("Данные заполнены некорректно");
        }

        private void BtnGoBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
