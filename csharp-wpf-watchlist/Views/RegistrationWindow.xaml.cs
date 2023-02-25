using csharp_wpf_watchlist.Models;
using csharp_wpf_watchlist.ViewModels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace csharp_wpf_watchlist.Views
{
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void RegistrationButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var userContext = new UserContext())
                {
                    var user = new User
                    {
                        Name = NameTextBox.Text,
                        Surname = SurnameTextBox.Text,
                        Email = EmailTextBox.Text,
                        Password = PasswordBox.Password
                    };
                    userContext.Users.Add(user);
                    userContext.SaveChanges();
                }
                MessageBox.Show("Registration complete!");
                AuthorizationWindow authorizationWindow = new AuthorizationWindow();
                this.Close();
                authorizationWindow.Show();
            }
            catch
            {
                MessageBox.Show("Database connection error. Try again later.");
            }
        }

        private void LogIn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                AuthorizationWindow authorizationWindow = new AuthorizationWindow();
                this.Close();
                authorizationWindow.Show();
            }
        }
    }
}