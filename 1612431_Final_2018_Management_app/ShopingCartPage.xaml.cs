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
        double SalePercent = 0;
        int PromotionCode = 0;
        int SumPromotion = 0;

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
            if (Products.Count > 0)
            {
                CartProduct.Visibility = Visibility.Visible;
                CartError.Visibility = Visibility.Collapsed;

                Price = TotalAmout = Promotion = SumPromotion = PromotionCode = 0;
                SalePercent = 0;

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

                // Kiểm tra khuyễn mãi dạng phiếu mua hàng có còn không

                var CouponPromo = db.CouponPromotions.Where(s => s.isDelete == false).ToList();
                if (CouponPromo.Count > 0)
                {
                    // Khuyến mãi từng sản phẩm
                    Promotion = CouponPromo[0].PromotionPrice;


                    foreach (var item in Products)
                    {
                        SumPromotion += (Promotion * item.Quantity);
                    }
                }
                else
                {
                    // Kiểm tra khuyến mãi dang sale phần trăm có tồn tại hay không
                    var SalePromo = db.SalePercentPromotions.Where(s => s.isDelete == false).ToList();
                    if (db.SalePercentPromotions.Where(s => s.isDelete == false).ToList().Count > 0)
                    {
                        // Phần trăm khuyễn mãi từng sản phẩm
                        SalePercent = SalePromo[0].SalePercent;

                        foreach (var item in Products)
                        {
                            SumPromotion += (int)(SalePercent * item.DisplayPrice) * item.Quantity;
                        }
                    }
                }

                // Chuyển định dạng số tiền
                CultureInfo cul = CultureInfo.CurrentCulture;
                string decimalSep = cul.NumberFormat.CurrencyDecimalSeparator;
                string groupSep = cul.NumberFormat.CurrencyGroupSeparator;
                string sFormat = string.Format("#{0}###", groupSep);
                PriceTextBlock.Text = Price.ToString(sFormat);

                PromotionTextBlock.Text = SumPromotion.ToString(sFormat);

                TotalAmountTextBlock.Text = (Price - SumPromotion).ToString(sFormat);

                ApplyCodeButton_Click(null, null);
            }
            else
            {
                CartProduct.Visibility = Visibility.Collapsed;
                CartError.Visibility = Visibility.Visible;
            }
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
                    if (item.Quantity < db.Products.Find(item.ID).Quantity)
                    {
                        item.Quantity = item.Quantity + 1;
                    }
                    else
                    {
                        MessageBox.Show("Sản phẩm chỉ còn lại " + item.Quantity + " sản phẩm", "Hết hàng", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
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
                PromotionCode = CodePromotion.PromotionPrice;
                SumPromotion += CodePromotion.PromotionPrice;

                // Chuyển định dạng số tiền
                CultureInfo cul = CultureInfo.CurrentCulture;
                string decimalSep = cul.NumberFormat.CurrencyDecimalSeparator;
                string groupSep = cul.NumberFormat.CurrencyGroupSeparator;
                string sFormat = string.Format("#{0}###", groupSep);

                PromotionTextBlock.Text = SumPromotion.ToString(sFormat);

                TotalAmountTextBlock.Text = (Price - SumPromotion).ToString(sFormat);

                ApplyCodeButton.IsEnabled = false;
            }

        }

        bool isATM = false;

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
                bill.CustomerID = customer.ID;
                bill.Date = DateTime.Now;
                bill.TotalAmount = TotalAmout;
                bill.PromotionCode = PromotionCode;
                bill.PayMethod = (isATM == true) ? "ATM" : "Money";

                db.Bills.Add(bill);
                db.SaveChanges();

                // Thêm DetailBill vào database
                foreach (var item in Products)
                {
                    DetailBill detailBill = new DetailBill();
                    detailBill.ID = bill.ID;
                    detailBill.ProductID = item.ID;
                    detailBill.Quantity = item.Quantity;
                    detailBill.UnitPrice = item.DisplayPrice;

                    if (Promotion != 0) detailBill.Promotion = Promotion;
                    else if (SalePercent != 0) detailBill.Promotion = (int)(detailBill.UnitPrice * SalePercent);
                    else detailBill.Promotion = 0;

                    detailBill.Amount = (detailBill.UnitPrice - detailBill.Promotion) * detailBill.Quantity;

                    db.DetailBills.Add(detailBill);
                    db.SaveChanges();

                    var product = db.Products.Find(detailBill.ProductID);
                    product.Quantity -= detailBill.Quantity;
                    db.SaveChanges();
                }


                MessageBox.Show("Tạo hoá dơn thành công");
                Products = new ObservableCollection<Product>();
                ProductListDataGrid.Height = 0;
                CustomerNameTextBox.Text = CustomerAdressTextBox.Text = CustomerPhoneTextBox.Text = "";


                Page_Loaded(null, null);
                Hyperlink_Click(null, null);
            }
        }

        private void ATMPayButton_Click(object sender, RoutedEventArgs e)
        {
            isATM = true;
            Purchase();
        }

        private void MoneyPayButton_Click(object sender, RoutedEventArgs e)
        {
            isATM = false;
            Purchase();
        }

        private void BackProductButton_Click(object sender, RoutedEventArgs e)
        {
            Hyperlink_Click(null, null);
        }
    }
}
