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
using System.Windows.Shapes;

namespace _1612431_Final_2018_Management_app
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        const string userAdmin = "admin";
        const string passwordAdmin = "123";

        public Login()
        {
            InitializeComponent();
        }

        private void SignInButton_Click(object sender, RoutedEventArgs e)
        {
            if (userAdmin == UsernameText.Text && passwordAdmin == PasswordText.Password)
            {
                Hide();
                MainWindow mainWindow = new MainWindow();
                mainWindow.ShowDialog();
                Close();
            }
            else
            {
                MessageBox.Show("Username/password was unavailble!", "Problem", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}
