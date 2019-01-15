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
    /// Interaction logic for SalesStatisticPage.xaml
    /// </summary>
    public partial class ProductsStatisticPage : Page
    {
        List<KeyValuePair<string, int>> SPBanChayNgay = new List<KeyValuePair<string, int>>();
        StoreManagementEntities db = new StoreManagementEntities();

        public ProductsStatisticPage()
        {
            InitializeComponent();

            SPBanChayNgay = new List<KeyValuePair<string, int>>();
            SPBanChayNgay.Add(new KeyValuePair<string, int>("0", 12));

            columnChart.DataContext = null;
            columnChart.DataContext = SPBanChayNgay;

            columnChart.Width = column.Width + 100;

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            
            List<string> StatisticMethod = new List<string>() { "Thống kê theo ngày", "Thống kê theo tháng", "Thống kê theo năm", "Thống kê giữa hai thời điểm" };
            StatisticMethodCombobox.ItemsSource = StatisticMethod;

            MonthDP.ItemsSource = new List<string>() { "Tháng 1", "Tháng 2", "Tháng 3", "Tháng 4", "Tháng 5", "Tháng 6", "Tháng 7", "Tháng 8", "Tháng 9", "Tháng 10", "Tháng 11", "Tháng 12" };

            var YearAvailable = new List<string>();
            for (int i = DateTime.Now.Year; i >= 2009; i--)
            {
                YearAvailable.Add(i.ToString());
            }
            YearOfMonthDP.ItemsSource = YearAvailable;
            YearDP.ItemsSource = YearAvailable;
        }

        void DisableCotrol()
        {
            DayStatisticDP.Visibility = Visibility.Hidden;
            DayStatisticDP.SelectedDate = DateTime.Parse((DateTime.Now.Month).ToString() + "/" + (DateTime.Now.Day + 1).ToString() + "/" + (DateTime.Now.Year));

            MonthDP.Visibility = Visibility.Hidden;
            MonthDP.SelectedIndex = -1;

            YearOfMonthDP.Visibility = Visibility.Hidden;
            YearOfMonthDP.SelectedIndex = -1;

            YearDP.Visibility = Visibility.Hidden;
            YearDP.SelectedIndex = -1;

            SEDateStackPanel.Visibility = Visibility.Hidden;
        }

        private void StatisticMethod_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DisableCotrol();
            switch (StatisticMethodCombobox.SelectedIndex)
            {
                case 0:
                    DayStatisticDP.Visibility = Visibility.Visible;
                    break;
                case 1:
                    MonthDP.Visibility = Visibility.Visible;
                    break;
                case 2:
                    YearDP.Visibility = Visibility.Visible;
                    break;
                case 3:
                    SEDateStackPanel.Visibility = Visibility.Visible;
                    break;
                default:
                    break;
            }
        }

        void CreateChart(DateTime start, DateTime end)
        {
            var bills = new List<Bill>();
            var id = new List<int>();
            foreach (var item in db.Bills.ToList())
            {
                if (item.Date.Date >= start.Date && item.Date.Date <= end.Date)
                {
                    bills.Add(item);
                    id.Add(item.ID);
                }
            }

            if (bills.Count > 0)
            {
                ErrorStackPanel.Visibility = Visibility.Hidden;
                ChartStackPanel.Visibility = Visibility.Visible;

                var list = db.DetailBills.Where(s => id.Contains(s.ID)).ToList();

                Dictionary<int, int> chartValue = new Dictionary<int, int>();
                foreach (var item in list)
                {
                    if (chartValue.ContainsKey(item.ProductID))
                    {
                        chartValue[item.ProductID] += item.Quantity;
                    }
                    else
                    {
                        chartValue[item.ProductID] = item.Quantity;
                    }
                }

                var products = db.Products.Where(s => s.isDelete == false).ToList();

                foreach (var item in products)
                {
                    if (chartValue.ContainsKey(item.ID))
                    {
                        item.Quantity = chartValue[item.ID];
                    }
                    else
                    {
                        item.Quantity = 0;
                    }
                }


                SPBanChayNgay = new List<KeyValuePair<string, int>>();
                foreach (var item in products)
                {
                    if (item.Quantity != 0)
                    {
                        SPBanChayNgay.Add(new KeyValuePair<string, int>(item.Name, item.Quantity));
                    }
                }

                columnChart.DataContext = null;
                columnChart.DataContext = SPBanChayNgay;
            }
            else
            {

                ErrorStackPanel.Visibility = Visibility.Visible;
                ChartStackPanel.Visibility = Visibility.Hidden;
            }
        }

        private void DayStatisticDP_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            CreateChart((DateTime)DayStatisticDP.SelectedDate, (DateTime)DayStatisticDP.SelectedDate);
        }

        private void MonthDP_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (MonthDP.SelectedIndex != -1) YearOfMonthDP.Visibility = Visibility.Visible;
        }

        private void YearOfMonthDP_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (YearOfMonthDP.SelectedIndex != -1)
            {
                var startDate = (MonthDP.SelectedIndex + 1).ToString() + "/1/" + YearOfMonthDP.SelectedItem.ToString();
                var endDate = (MonthDP.SelectedIndex + 1).ToString() + "/31/" + YearOfMonthDP.SelectedItem.ToString();

                CreateChart(DateTime.Parse(startDate), DateTime.Parse(endDate));
            }
        }

        private void YearDP_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (YearDP.SelectedIndex != -1)
            {
                var startDate = "1/1/" + YearDP.SelectedItem.ToString();
                var endDate = "12/31/" + YearDP.SelectedItem.ToString();

                CreateChart(DateTime.Parse(startDate), DateTime.Parse(endDate));
            }
        }

        private void StartDateDP_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            // CreateChart((DateTime)StartDateDP.SelectedDate, (DateTime)EndDateDP.SelectedDate);
        }

        private void EndDateDP_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            CreateChart((DateTime)StartDateDP.SelectedDate, (DateTime)EndDateDP.SelectedDate);
        }
    }
}
