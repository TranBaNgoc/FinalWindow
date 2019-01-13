using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for PurchasePage.xaml
    /// </summary>
    public partial class PurchasePage : Page
    {
        StoreManagementEntities db;

        public PurchasePage()
        {
            InitializeComponent();
            
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            db = new StoreManagementEntities();
            
            ListviewItem.ItemsSource = db.Products.Where(s=>s.isDelete == false).ToList();
        }

        private void ListviewItem_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListviewItem.SelectedIndex != -1)
            {
                var product = ListviewItem.SelectedItem as Product;

                foreach (var item in ShopingCartPage.Products)
                {
                    if (item.ID == product.ID)
                    {
                        item.Quantity++;
                    }
                }

                product.Quantity = 1;
                ShopingCartPage.Products.Add(product);
            }
        }

        private void ShopingCartButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ShopingCartPage(ShopingCartPage.Products.Count * 150));
        }
    }
}
