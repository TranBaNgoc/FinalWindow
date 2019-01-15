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
    /// Interaction logic for ProductsStatisticPage.xaml
    /// </summary>
    public partial class SalesStatisticPage : Page
    {
        List<KeyValuePair<string, int>> Sales = new List<KeyValuePair<string, int>>();
        List<KeyValuePair<string, int>> Profit = new List<KeyValuePair<string, int>>();
        List<List<KeyValuePair<string, int>>> dataSourceList = new List<List<KeyValuePair<string, int>>>();

        StoreManagementEntities db = new StoreManagementEntities();
        public SalesStatisticPage()
        {
            InitializeComponent();

            var Month = new List<string>() { "Tháng 1", "Tháng 2", "Tháng 3", "Tháng 4", "Tháng 5", "Tháng 6", "Tháng 7", "Tháng 8", "Tháng 9", "Tháng 10", "Tháng 11", "Tháng 12" };
            MonthStartDP.ItemsSource = Month;
            MonthEndDP.ItemsSource = Month;

            var YearAvailable = new List<string>();
            for (int i = DateTime.Now.Year; i >= 2009; i--)
            {
                YearAvailable.Add(i.ToString());
            }
            YearStartDP.ItemsSource = YearAvailable;
            YearEndDP.ItemsSource = YearAvailable;

            
            Sales.Add(new KeyValuePair<string, int>("0", 12));

            lineChart.DataContext = null;
            lineChart.DataContext = Sales;

           

        }

        private void ResetDate_Click(object sender, RoutedEventArgs e)
        {
            MonthStartDP.SelectedIndex = -1;
            MonthEndDP.SelectedIndex = -1;
            YearStartDP.SelectedIndex = -1;
            YearEndDP.SelectedIndex = -1;
        }

        private void YearEndDP_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (YearEndDP.SelectedIndex != -1)
            {
                Sales = new List<KeyValuePair<string, int>>();

                // Chọn tháng năm bắt đầu
                // Lấy từng tháng từ tháng bắt đầu tới tháng kết thúc, mỗi tháng từ ngày 01 -> 31

                ////////////// Doanh thu //////////////
                // Lấy Bill từng tháng
                // Lấy DetailBill tương ứng
                // Lấy ((UnitPice - Promotion) * Quantity) - Bill.Promotion
                // Cộng tất cả

                ///////////// Lợi nhuận ///////////////
                //....
                //....
                // Lấy ((UnitPice - Promotion) * Quantity) - Bill.Promotion - Product.OriginalPrice
                //....


                for (int year = int.Parse(YearStartDP.SelectedItem.ToString()); year <= int.Parse(YearEndDP.SelectedItem.ToString()); year++)
                {
                    int startMonth = 1;
                    int endMonth = 12;
                    if (year == int.Parse(YearStartDP.SelectedItem.ToString()))
                    {
                        startMonth = int.Parse((MonthStartDP.SelectedIndex + 1).ToString());
                    }

                    if (year == int.Parse(YearEndDP.SelectedItem.ToString()))
                    {
                        endMonth = int.Parse((MonthEndDP.SelectedIndex + 1).ToString());
                    }

                    for (int month = startMonth; month <= endMonth; month++)
                    {
                        var list = db.Bills.Where(s => s.Date.Month == month && s.Date.Year == year).ToList();
                        var sale = 0;
                        foreach (var item in list)
                        {
                            sale += item.TotalAmount;
                        }

                        Sales.Add(new KeyValuePair<string, int>(month.ToString() + "/" + year.ToString(), sale));
                    }
                }

                lineChart.DataContext = null;

                lineChart.DataContext = Sales;

                ChartStackPanel.Visibility = Visibility.Visible;
            }
            else
            {
                ChartStackPanel.Visibility = Visibility.Hidden;
            }
        }

    }
}
