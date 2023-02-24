using csharp_wpf_watchlist.ViewModels;
using csharp_wpf_watchlist.Models;
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

namespace csharp_wpf_watchlist.Views
{
    public partial class AuthorizationWindow : Window
    {
        public AuthorizationWindow()
        {
            InitializeComponent();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void AuthorizationButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var userContext = new UserContext())
                {
                    var user = userContext.Users.FirstOrDefault(u => u.Email == EmailTextBox.Text && u.Password == PasswordBox.Password);
                    if (user != null)
                    {
                        MessageBox.Show("Correct!");
                    }
                    else
                    {
                        MessageBox.Show("Email or password entered incorrectly!");
                    }
                }
            }
            catch
            {
                MessageBox.Show("Database connection error.");
            }
        }

        private void CreateAccount_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                RegistrationWindow registrationWindow = new RegistrationWindow();
                this.Close();
                registrationWindow.Show();
            }
        }
    }
}