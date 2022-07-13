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
    /// Interaction logic for TransferListPage.xaml
    /// </summary>
    public partial class TransferListPage : Page
    {
        public List<BookTransfer> Transfers { get; set; }
        public TransferListPage()
        {
            InitializeComponent();
            Transfers = DataAccess.GetBookTransfers();
            DataAccess.Refresh += RefreshList;
            DataContext = this;
        }
        private void RefreshList()
        {
            TbSearch.Text = "";
            Transfers = DataAccess.GetBookTransfers();
            LvTransfers.ItemsSource = Transfers;
            LvTransfers.Items.Refresh();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            var transfer = new BookTransfer();
            NavigationService.Navigate(new TransferPage(transfer));
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            var transfer = LvTransfers.SelectedItem as BookTransfer;

            if (transfer != null)
                NavigationService.Navigate(new TransferPage(transfer));
        }

        private void TbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Transfers = DataAccess.GetBookTransfers().Where(x => x.Book.Title.ToLower().Contains(TbSearch.Text.ToLower())).ToList();
            LvTransfers.ItemsSource = Transfers;
            LvTransfers.Items.Refresh();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var transfer = (sender as Button).DataContext as BookTransfer;

            if (MessageBox.Show("Вы точно хотите удалить эту запись?", "Предупреждение", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                DataAccess.DeleteTransfer(transfer);
        }
    }
}
