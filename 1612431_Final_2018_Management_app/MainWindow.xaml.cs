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
using Fluent;

namespace _1612431_Final_2018_Management_app
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : RibbonWindow
    {
       
        public MainWindow()
        {
            InitializeComponent();
        }

        private void RibbonWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var screens = new ObservableCollection<TabItem>()
            {
                new TabItem()
                {
                    Header ="Sản phẩm",
                    Content = new Frame() {
                        NavigationUIVisibility = NavigationUIVisibility.Hidden,
                        Content = new PurchasePage()
                    },
                },

                new TabItem()
                {
                    Header = "Quản lý",
                    Content = new Frame()
                    {
                        NavigationUIVisibility = NavigationUIVisibility.Hidden,
                        Content = new ManagePage()
                    },
                }
             };

            tabs.ItemsSource = screens;
            tabs.SelectedIndex = 0;
        }

        private void tabs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (tabs.SelectedIndex == 0) ribbon.Height = 30;
            else ribbon.Height = 118;
        }

        private void ProductButton_Click(object sender, RoutedEventArgs e)
        {
            TabControl tabControl = ManagePage.tabControl;
            tabControl.SelectedIndex = 0;
        }

        private void PromotionButton_Click(object sender, RoutedEventArgs e)
        {
            TabControl tabControl = ManagePage.tabControl;
            tabControl.SelectedIndex = 1;
        }

        private void SalesStatisticButton_Click(object sender, RoutedEventArgs e)
        {
            TabControl tabControl = ManagePage.tabControl;
            tabControl.SelectedIndex = 3;
        }

        private void ProductsStatisticButton_Click(object sender, RoutedEventArgs e)
        {
            TabControl tabControl = ManagePage.tabControl;
            tabControl.SelectedIndex = 2;
        }

        private void BillButton_Click(object sender, RoutedEventArgs e)
        {
            TabControl tabControl = ManagePage.tabControl;
            tabControl.SelectedIndex = 4;
        }

        private void RibbonWindow_Closed(object sender, EventArgs e)
        {
            App.Current.Shutdown();
        }
    }
}
