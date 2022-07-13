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
    /// Interaction logic for ReaderPage.xaml
    /// </summary>
    public partial class ReaderPage : Page
    {
        public Reader Reader { get; set; }
        public ReaderPage(Reader reader)
        {
            InitializeComponent();
            this.Reader = reader;
            DataContext = Reader;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (DataAccess.SaveReader(Reader))
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
