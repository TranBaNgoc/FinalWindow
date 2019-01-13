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
    /// Interaction logic for ShopingCartPage.xaml
    /// </summary>
    public partial class ShopingCartPage : Page
    {
        public static ObservableCollection<Product> Products = new ObservableCollection<Product>();
        StoreManagementEntities db = new StoreManagementEntities();
        public static List<DetailBill> detailBills = new List<DetailBill>();

        int Price = 0;
        int Promotion = 0;
        int TotalAmout = 0;

        public ShopingCartPage()
        {
            InitializeComponent();
        }

        public ShopingCartPage(int Height)
        {
            InitializeComponent();
            ProductListDataGrid.Height = Height;
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }


        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Price = TotalAmout = Promotion = 0;

            // Số sản phẩm
            TotalProductQuantity.Text = Products.Count.ToString();

            // Danh sách sản phẩm đã mua
            ProductListDataGrid.ItemsSource = Products;

            // Tính tổng số tiền (tạm tính) và số sản phẩm
            int NumberProduct = 0;
            foreach (var item in Products)
            {
                Price += (item.Quantity * item.DisplayPrice);
                NumberProduct += item.Quantity;
            }

            var CouponPromo = db.CouponPromotions.Where(s => s.isDelete == false).ToList();
            if (CouponPromo.Count > 0)
            {
                Promotion = CouponPromo[0].PromotionPrice * NumberProduct;
            }
            else
            {
                var SalePromo = db.SalePercentPromotions.Where(s => s.isDelete == false).ToList();
                if (db.SalePercentPromotions.Where(s=>s.isDelete==false).ToList().Count > 0)
                {
                    Promotion = (int)(Price * SalePromo[0].SalePercent);
                }
                else
                {
                    Promotion = 0;
                }
            }

            // Chuyển định dạng số tiền
            CultureInfo cul = CultureInfo.CurrentCulture;
            string decimalSep = cul.NumberFormat.CurrencyDecimalSeparator;
            string groupSep = cul.NumberFormat.CurrencyGroupSeparator;
            string sFormat = string.Format("#{0}###", groupSep);
            PriceTextBlock.Text = Price.ToString(sFormat);

            PromotionTextBlock.Text = Promotion.ToString(sFormat);

            TotalAmountTextBlock.Text = (Price - Promotion).ToString(sFormat);

            ApplyCodeButton_Click(null, null);
        }

        Product product = new Product();

        private void DataGridCell_PreviewMouseLeftButtonDownProduct(object sender, MouseButtonEventArgs e)
        {
            DataGridCell myCell = sender as DataGridCell;
            DataGridRow row = DataGridRow.GetRowContainingElement(myCell);
            Product temp = row.DataContext as Product;
            product = temp;
        }

        private void AdditionQuantity_Click(object sender, RoutedEventArgs e)
        {
            foreach(var item in Products)
            {
                if (item.ID == product.ID)
                {
                    item.Quantity = item.Quantity + 1;
                }
            }

            ProductListDataGrid.ItemsSource = null;
            ProductListDataGrid.ItemsSource = Products;

            Page_Loaded(null, null);
        }

        private void DisturbQuantity_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in Products)
            {
                if (item.Quantity > 1 && item.ID == product.ID)
                {
                    item.Quantity = item.Quantity - 1;
                }
            }

            ProductListDataGrid.ItemsSource = null;
            ProductListDataGrid.ItemsSource = Products;

            Page_Loaded(null, null);
        }

        private void DeleteProductButton_Click(object sender, RoutedEventArgs e)
        {
            var temp_product = new Product();

            Products.Remove(product);

            ProductListDataGrid.ItemsSource = null;
            ProductListDataGrid.ItemsSource = Products;

            ProductListDataGrid.Height -= 150;

            Page_Loaded(null, null);
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            CodePanel.Visibility = Visibility.Visible;
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            CodePanel.Visibility = Visibility.Hidden;
        }

        private void ApplyCodeButton_Click(object sender, RoutedEventArgs e)
        {
            var CodePromotion = db.CodePromotions.Find(CodeTextBox.Text);
            if (CodePromotion != null && CodeTextBox.Text != "")
            {
                Promotion += CodePromotion.PromotionPrice;

                // Chuyển định dạng số tiền
                CultureInfo cul = CultureInfo.CurrentCulture;
                string decimalSep = cul.NumberFormat.CurrencyDecimalSeparator;
                string groupSep = cul.NumberFormat.CurrencyGroupSeparator;
                string sFormat = string.Format("#{0}###", groupSep);

                PromotionTextBlock.Text = Promotion.ToString(sFormat);

                TotalAmountTextBlock.Text = (Price - Promotion).ToString(sFormat);

                ApplyCodeButton.IsEnabled = false;
            }
        }

        bool isATM = false;
        bool isMoney = false;

        void Purchase()
        {
            if (CustomerNameTextBox.Text != "" && CustomerAdressTextBox.Text !="" && CustomerPhoneTextBox.Text != "")
            {
                // Thêm khách hàng vào database

                Customer customer = new Customer();
                customer.Name = CustomerNameTextBox.Text;
                customer.Adress = CustomerAdressTextBox.Text;
                customer.Phone = CustomerPhoneTextBox.Text;

                db.Customers.Add(customer);
                db.SaveChanges();

                // Thêm Bill vào database
                Bill bill = new Bill();


            }
        }

        private void ATMPayButton_Click(object sender, RoutedEventArgs e)
        {
            isATM = true;
            isMoney = false;
            Purchase();
        }

        private void MoneyPayButton_Click(object sender, RoutedEventArgs e)
        {
            isATM = false;
            isMoney = true;
            Purchase();
        }
    }
}
