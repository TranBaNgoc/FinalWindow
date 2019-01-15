using System;
using System.Collections.Generic;
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
    /// Interaction logic for DetailBillManage.xaml
    /// </summary>
    public partial class DetailBillManage : Page
    {
        StoreManagementEntities db = new StoreManagementEntities();
        int BillID = 0;

        public DetailBillManage()
        {
            InitializeComponent();
        }

        public DetailBillManage(int ID)
        {
            InitializeComponent();
            BillID = ID;
            Page_Loaded(null, null);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var listDetail = db.DetailBills.Where(s => s.ID == BillID).ToList();

            var listProduct = new List<Product>();

            foreach (var item in listDetail)
            {
                var product = db.Products.Find(item.ProductID);
                product.Quantity = item.Quantity;
                product.Promotion = item.Promotion;
                product.Amount = item.Amount;

                listProduct.Add(product);
            }

            ProductListDataGrid.ItemsSource = listProduct;

            var bill = db.Bills.Find(BillID);
            var customer = db.Customers.Find(bill.CustomerID);
            CustomerNameTextBox.Text = customer.Name;
            CustomerPhoneTextBox.Text = customer.Phone;
            CustomerAdressTextBox.Text = customer.Adress;

            int OriginalPrice = 0;
            int Promotion = 0;
            int TotalAmount = 0;

            foreach (var item in listProduct)
            {
                OriginalPrice += item.OriginalPrice * item.Quantity;
                Promotion += item.Promotion * item.Quantity;
               
            }

            TotalAmount = OriginalPrice - Promotion;

            // Chuyển định dạng số tiền
            CultureInfo cul = CultureInfo.CurrentCulture;
            string decimalSep = cul.NumberFormat.CurrencyDecimalSeparator;
            string groupSep = cul.NumberFormat.CurrencyGroupSeparator;
            string sFormat = string.Format("#{0}###", groupSep);

            OriginalPriceTextBox.Text = OriginalPrice.ToString(sFormat);
            PromotionTextBox.Text = Promotion.ToString(sFormat);
            TotalAmountTextBox.Text = TotalAmount.ToString(sFormat);
        }

        private void ResetDate_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
