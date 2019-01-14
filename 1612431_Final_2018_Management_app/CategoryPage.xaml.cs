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
    /// Interaction logic for CategoryPage.xaml
    /// </summary>
    public partial class CategoryPage : Page
    {
        StoreManagementEntities db;

        public CategoryPage()
        {
            InitializeComponent();
            db = new StoreManagementEntities();
            CategoryListView.ItemsSource = db.Categories.Where(s => s.isDelete == false).ToList();
        }

        // Dialog thêm loại sản phẩm - sự kiện đóng
        private void Add_Category_DialogHost_OnDialogClosing(object sender, MaterialDesignThemes.Wpf.DialogClosingEventArgs eventArgs)
        {
            if ((bool)eventArgs.Parameter == false)
            {
           
                return;
            }
            Category category = new Category() { Name = AddCategoryTextBox.Text, isDelete = false };

            db.Categories.Add(category);

            db.SaveChanges();

            CategoryListView.ItemsSource = db.Categories.Where(s => s.isDelete == false).ToList();

            CategoryListView.SelectedIndex = -1;
        }

        // Dialog xoá loại sản phẩm - sự kiện đóng
        private void Delete_Category_DialogHost_OnDialogClosing(object sender, MaterialDesignThemes.Wpf.DialogClosingEventArgs eventArgs)
        {
            if ((bool)eventArgs.Parameter == false)
                return;

            if (CategoryListView.SelectedIndex != -1)
            {
                var selectedItem = CategoryListView.SelectedValue as Category;

                var category = db.Categories.Find(selectedItem.ID);

                category.isDelete = true;

                db.SaveChanges();

                CategoryListView.ItemsSource = db.Categories.Where(s => s.isDelete == false).ToList();

                CategoryListView.SelectedIndex = -1;

            }
        }

        // Dialog sửa tên loại sản phẩm - sự kiện đóng
        private void Update_Category_DialogHost_OnDialogClosing(object sender, MaterialDesignThemes.Wpf.DialogClosingEventArgs eventArgs)
        {
            if ((bool)eventArgs.Parameter == false)
                return;

            var selectedItem = CategoryListView.SelectedItem as Category;

            var category = db.Categories.Find(selectedItem.ID);

            category.Name = NewCategoryNameTextBox.Text;

            db.SaveChanges();

            CategoryListView.ItemsSource = db.Categories.Where(s => s.isDelete == false).ToList();

            CategoryListView.SelectedIndex = -1;
        }

        // Bắt sự kiện thay đổi trong list loại sản phẩm
        private void CategoryListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CategoryListView.SelectedIndex != -1)
            {
                DeleteCategoryButton.Visibility = Visibility.Visible;
                UpdateCategoryButton.Visibility = Visibility.Visible;
                AddProductButton.Visibility = Visibility.Visible;

                var category = CategoryListView.SelectedItem as Category;
                OldCategoryNameTextBox.Text = category.Name;
                NewCategoryNameTextBox.Text = "";

                ProductListDataGrid.ItemsSource = db.Products.Where(s => (s.isDelete == false && s.CategoryID == category.ID)).ToList();
            }
            else
            {
                DeleteCategoryButton.Visibility = Visibility.Hidden;
                UpdateCategoryButton.Visibility = Visibility.Hidden;
                AddProductButton.Visibility = Visibility.Hidden;
            }
        }

        // Dialog thêm sản phẩm - sự kiện đóng
        private void Add_Product_DialogHost_OnDialogClosing(object sender, MaterialDesignThemes.Wpf.DialogClosingEventArgs eventArgs)
        {
            if ((bool)eventArgs.Parameter == false)
                return;

            if (ProDuctNameTextBox.Text == "" || ProDuctOriginalPriceTextBox.Text == "" || ProDuctDisplayPriceTextBox.Text == "" || ProDuctQuantityTextBox.Text == "" || ProductSourceTextBlock.Text == "  Ảnh sản phẩm")
            {
                MessageBox.Show("Thêm sản phẩm không thành công");
                return;
            }  

            var selectedItem = CategoryListView.SelectedItem as Category;
        
            var product = new Product();
            product.CategoryID = selectedItem.ID;
            product.Name = ProDuctNameTextBox.Text;
            product.OriginalPrice = int.Parse(ProDuctOriginalPriceTextBox.Text);
            product.DisplayPrice = int.Parse(ProDuctDisplayPriceTextBox.Text);
            product.Quantity = int.Parse(ProDuctQuantityTextBox.Text);
            product.ProductSource = ProductSourceTextBlock.Text;

            db.Products.Add(product);

            db.SaveChanges();

            ProDuctNameTextBox.Text = ProDuctOriginalPriceTextBox.Text = ProDuctDisplayPriceTextBox.Text = ProDuctQuantityTextBox.Text = "";
            ProductSourceTextBlock.Text = "  Ảnh sản phẩm";

            var category = CategoryListView.SelectedItem as Category;
            ProductListDataGrid.ItemsSource = db.Products.Where(s => (s.isDelete == false && s.CategoryID == category.ID)).ToList();
        }

        // Dialog xoá sản phẩm - sự kiện đóng
        private void Delete_Product_DialogHost_OnDialogClosing(object sender, MaterialDesignThemes.Wpf.DialogClosingEventArgs eventArgs)
        {
            if ((bool)eventArgs.Parameter == false)
                return;

            if (ProductListDataGrid.SelectedIndex != -1)
            {
                var selectedItem = ProductListDataGrid.SelectedValue as Product;

                var product = db.Products.Find(selectedItem.ID);

                product.isDelete = true;

                db.SaveChanges();

                var category = CategoryListView.SelectedItem as Category;
                ProductListDataGrid.ItemsSource = db.Products.Where(s => s.isDelete == false && category.ID == s.CategoryID).ToList();

                ProductListDataGrid.SelectedIndex = -1;
            }
        }

        // Dialog sửa loại sản phẩm - sự kiện đóng
        private void Update_Product_DialogHost_OnDialogClosing(object sender, MaterialDesignThemes.Wpf.DialogClosingEventArgs eventArgs)
        {
            if ((bool)eventArgs.Parameter == false)
                return;

            var selectedItem = ProductListDataGrid.SelectedItem as Product;

            var product = db.Products.Find(selectedItem.ID);
            product.OriginalPrice = int.Parse(NewProductOriginalPriceTextBox.Text);
            product.DisplayPrice = int.Parse(NewProductDisplayPriceTextBox.Text);
            product.Quantity += int.Parse(AdditionProductQuantityTextBox.Text);
            product.ProductSource = NewProductSourceTextBlock.Text;

            db.SaveChanges();

            var category = CategoryListView.SelectedItem as Category;
            ProductListDataGrid.ItemsSource = db.Products.Where(s => s.isDelete == false && category.ID == s.CategoryID).ToList();

            ProductListDataGrid.SelectedIndex = -1;
        }

        // Chọn ảnh của sản phẩm
        private void ProductSourceButton_Click(object sender, RoutedEventArgs e)
        {
            // Create OpenFileDialog 
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            // Set filter for file extension and default file extension 

            dlg.Filter = "Image Files (*.png;*.jpg)|*.png;*.jpg";


            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();


            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                // Open document 
                ProductSourceTextBlock.Text = dlg.FileName;
                NewProductSourceTextBlock.Text = dlg.FileName;
            }
        }

        // Thay đổi lựa chọn trong datagrid
        private void ProductListDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ProductListDataGrid.SelectedIndex != -1)
            {
                DeleteProductButton.Visibility = Visibility.Visible;
                UpdateProductButton.Visibility = Visibility.Visible;

                var product = ProductListDataGrid.SelectedItem as Product;

                ThisProductNameTextBox.Text = product.Name;
                NewProductOriginalPriceTextBox.Text = product.OriginalPrice.ToString();
                NewProductDisplayPriceTextBox.Text = product.DisplayPrice.ToString();
                AdditionProductQuantityTextBox.Text = "0";
                NewProductSourceTextBlock.Text = product.ProductSource;

            }
            else
            {
                DeleteProductButton.Visibility = Visibility.Hidden;
                UpdateProductButton.Visibility = Visibility.Hidden;
            }
        }
    }
}
