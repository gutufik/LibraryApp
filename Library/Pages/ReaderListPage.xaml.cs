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
            DataContext = this;
        }

        private void LvReaders_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
