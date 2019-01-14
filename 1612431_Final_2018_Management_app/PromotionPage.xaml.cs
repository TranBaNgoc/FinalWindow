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
    /// Interaction logic for PromotionPage.xaml
    /// </summary>
    public partial class PromotionPage : Page
    {
        StoreManagementEntities db = new StoreManagementEntities();
        public PromotionPage()
        {
            InitializeComponent();
        }

        private void AddCode_DialogHost_OnDialogClosing(object sender, MaterialDesignThemes.Wpf.DialogClosingEventArgs eventArgs)
        {
            if ((bool)eventArgs.Parameter == false)
                return;

            if (db.CodePromotions.Where(s=>s.Code == CodeTextBox.Text).ToList().Count == 0)
            {
                CodePromotion codePromotion = new CodePromotion();
                codePromotion.Code = CodeTextBox.Text;
                codePromotion.PromotionPrice = int.Parse(CodePriceTextBox.Text);

                db.CodePromotions.Add(codePromotion);
                db.SaveChanges();
                
                Page_Loaded(null, null);
            }
            else
            {
                MessageBox.Show("Mã khuyến mãi đã tồn tại");
            }
        }

        private void DeleteCode_DialogHost_OnDialogClosing(object sender, MaterialDesignThemes.Wpf.DialogClosingEventArgs eventArgs)
        {
            if ((bool)eventArgs.Parameter == false)
                return;

            var code = CodeListView.SelectedItem as CodePromotion;
            var codePromotion = db.CodePromotions.Find(code.Code);
            codePromotion.isDelete = true;

            db.SaveChanges();

            Page_Loaded(null, null);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            CodeListView.ItemsSource = db.CodePromotions.Where(s => s.isDelete == false).ToList();

            SalePercentNameTextBox.Text = SalePercentTextBox.Text = CouponPriceTextBox.Text  = "Hiện tại chưa có chương trình này";

            foreach (var item in db.SalePercentPromotions.Where(s => s.isDelete == false).ToList())
            {
                SalePercentNameTextBox.Text = "Khuyến mãi hiện tại: " + item.Name;
                SalePercentTextBox.Text = item.SalePercent.ToString();
            }

            foreach (var item in db.CouponPromotions.Where(s => s.isDelete == false).ToList())
            {
                CouponPriceTextBox.Text = "Giá trị PMH hiện tại: " + item.PromotionPrice.ToString();
            }

        }

        private void CodeListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CodeListView.SelectedIndex != -1)
            {
                DeleteCodeButton.Visibility = Visibility.Visible;
            }
            else
            {
                DeleteCodeButton.Visibility = Visibility.Hidden;
            }
        }

        void LoadPromotion()
        {
            foreach (var item in db.SalePercentPromotions.Where(s => s.isDelete == false).ToList())
            {
                item.isDelete = true;
                db.SaveChanges();
            }

            foreach (var item in db.CouponPromotions.Where(s => s.isDelete == false).ToList())
            {
                item.isDelete = true;
                db.SaveChanges();
            }

        }

        private void AddSaleButton_Click(object sender, RoutedEventArgs e)
        {
            LoadPromotion();
            SalePercentPromotion salePercentPromotion = new SalePercentPromotion();
            salePercentPromotion.Name = NewSalePercentNameTextBox.Text;

            if (NewSalePercentTextBox.Text.Contains('.'))
            {
                salePercentPromotion.SalePercent = double.Parse(NewSalePercentTextBox.Text);
            }
            else
            {
                if (NewSalePercentTextBox.Text.Contains('%'))
                {
                    salePercentPromotion.SalePercent = (double)int.Parse(NewSalePercentTextBox.Text.Substring(0, NewSalePercentTextBox.Text.IndexOf('%'))) / 100;
                }
                else
                {
                    try
                    {
                        salePercentPromotion.SalePercent = (double)int.Parse(NewSalePercentTextBox.Text) / 100;
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Giá trị khuyến mãi đã gặp vấn đề");
                        return;
                    }
                }
            }

            salePercentPromotion.isDelete = false;

            db.SalePercentPromotions.Add(salePercentPromotion);
            db.SaveChanges();

            Page_Loaded(null, null);
        }

        private void AddCouponButton_Click(object sender, RoutedEventArgs e)
        {
            LoadPromotion();
            CouponPromotion couponPromotion = new CouponPromotion();

            couponPromotion.PromotionPrice = int.Parse(NewCouponPriceTextBox.Text);
            couponPromotion.isDelete = false;

            db.CouponPromotions.Add(couponPromotion);
            db.SaveChanges();

            Page_Loaded(null, null);
        }

        private void DeleteSaleButton_Click(object sender, RoutedEventArgs e)
        {
            LoadPromotion();
            Page_Loaded(null, null);
        }

        private void DeleteCouponButton_Click(object sender, RoutedEventArgs e)
        {
            LoadPromotion();

            Page_Loaded(null, null);
        }
    }
}
