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
    /// Interaction logic for TransferPage.xaml
    /// </summary>
    public partial class TransferPage : Page
    {
        public List<TransferType> Types { get; set; }
        public List<Book> Books { get; set; }
        public List<Reader> Readers { get; set; }

        public BookTransfer Transfer { get; set; }

        public TransferPage(BookTransfer transfer)
        {
            InitializeComponent();
            Types = DataAccess.GetTransferTypes();
            Books = DataAccess.GetBooks();
            Readers = DataAccess.GetReaders();
            Transfer = transfer;
            DataContext = this;
        }

        private void BtnGoBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (DataAccess.SaveTransfer(Transfer))
                NavigationService.GoBack();
            else
                MessageBox.Show("Данные заполнены некорректно");
        }
    }
}
