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

namespace _1612431_Final_2018_Management_app
{
    /// <summary>
    /// Interaction logic for BillManagePage.xaml
    /// </summary>
    public partial class BillManagePage : Page
    {
        StoreManagementEntities db = new StoreManagementEntities();
        public BillManagePage()
        {
            InitializeComponent();
            
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var list = new List<Bill>();
            list = null;
            list = db.Bills.ToList();
            BillListDataGrid.ItemsSource = null;
            BillListDataGrid.ItemsSource = list;
            
        }

        private void BillListDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (BillListDataGrid.SelectedIndex != -1)
            {
                var bill = BillListDataGrid.SelectedItem as Bill;
                BillListDataGrid.SelectedIndex = -1;
                NavigationService.Navigate(new DetailBillManage(bill.ID));
            }
        }
    }
}
