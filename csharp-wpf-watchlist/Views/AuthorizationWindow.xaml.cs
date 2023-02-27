using csharp_wpf_watchlist.ViewModels;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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
                        String? currentEmail = user.Email;
                        String? currentName = user.Name;
                        String? currentSurname = user.Surname;

                        MainWindow mainWindow = new MainWindow(currentEmail, currentName, currentSurname);
                        this.Close();
                        mainWindow.Show();
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