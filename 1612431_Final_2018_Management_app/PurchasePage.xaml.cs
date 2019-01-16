using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
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
            
            var Products = db.Products.Where(s=>s.isDelete == false && s.Quantity > 0).ToList();

            List<Product> products = new List<Product>();

            foreach(var item in Products)
            {
                if (db.Categories.Find(item.CategoryID).isDelete == false)
                {
                    products.Add(item);
                }
            }

            ListviewItem.ItemsSource = products;

            CategoryListStackPanel.Height = db.Categories.Where(s => s.isDelete == false).ToList().Count * 45;
            
            CategoryListView.ItemsSource = db.Categories.Where(s => s.isDelete == false).ToList();
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
                        return;
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

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (NameTextBox.Text != "")
            {
                var Products = db.Products.Where(s => s.isDelete == false && s.Name.Contains(NameTextBox.Text.ToLower())).ToList();

                List<Product> products = new List<Product>();

                foreach (var item in Products)
                {
                    if (db.Categories.Find(item.CategoryID).isDelete == false)
                    {
                        products.Add(item);
                    }
                }
                ListviewItem.ItemsSource = products;

            }
            else
            {
                var Products = db.Products.Where(s => s.isDelete == false).ToList();

                List<Product> products = new List<Product>();

                foreach (var item in Products)
                {
                    if (db.Categories.Find(item.CategoryID).isDelete == false)
                    {
                        products.Add(item);
                    }
                }
                ListviewItem.ItemsSource = products;

            }
        }

        private void CategoryListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CategoryListView.SelectedIndex != -1)
            {
                var category = CategoryListView.SelectedItem as Category;

                ListviewItem.ItemsSource = db.Products.Where(s => (s.isDelete == false && s.CategoryID == category.ID)).ToList();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Page_Loaded(null, null);
        }

        int startPrice = 0;
        int endPrice = 0;

        private void StartPriceSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            startPrice = (int)(StartPriceSlider.Value * 100000) - ((int)(StartPriceSlider.Value * 100000) % 10000);

            // Chuyển định dạng số tiền
            CultureInfo cul = CultureInfo.CurrentCulture;
            string decimalSep = cul.NumberFormat.CurrencyDecimalSeparator;
            string groupSep = cul.NumberFormat.CurrencyGroupSeparator;
            string sFormat = string.Format("#{0}###", groupSep);

            StartPriceTextBox.Text = startPrice.ToString(sFormat);
        }

        private void EndPriceSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            endPrice = (int)(EndPriceSlider.Value * 100000) - (int)(EndPriceSlider.Value * 100000) % 10000;

            // Chuyển định dạng số tiền
            CultureInfo cul = CultureInfo.CurrentCulture;
            string decimalSep = cul.NumberFormat.CurrencyDecimalSeparator;
            string groupSep = cul.NumberFormat.CurrencyGroupSeparator;
            string sFormat = string.Format("#{0}###", groupSep);

            EndPriceTextBox.Text = endPrice.ToString(sFormat);
        }

        private void ApplyPriceButton_Click(object sender, RoutedEventArgs e)
        {
            if (CategoryListView.SelectedIndex != -1)
            {
                var category = CategoryListView.SelectedItem as Category;

                ListviewItem.ItemsSource = db.Products.Where(s => (s.isDelete == false && s.CategoryID == category.ID && s.DisplayPrice >= startPrice && s.DisplayPrice <= endPrice)).ToList();
            }
            else
            {
                var Products = db.Products.Where(s => s.isDelete == false && s.Quantity > 0 && s.DisplayPrice >= startPrice && s.DisplayPrice <= endPrice).ToList();

                List<Product> products = new List<Product>();

                foreach (var item in Products)
                {
                    if (db.Categories.Find(item.CategoryID).isDelete == false)
                    {
                        products.Add(item);
                    }
                }
                ListviewItem.ItemsSource = products;

            }
        }
    }
}
