using csharp_wpf_watchlist.ViewModels;
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
    public partial class MainWindow : Window
    {
        public String CurrentUserEmail { get; set; }

        public MainWindow(String currentEmail, String currentName, String currentSurname)
        {
            InitializeComponent();

            CurrentUserEmail = currentEmail;

            DataContext = new
            {
                FullName = $"{currentName} {currentSurname}",
                CurrentEmail = currentEmail
            };
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void RefreshTableButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var noteContext = new NoteContext())
                {
                    var note = noteContext.Notes.Where(n => n.Email == CurrentUserEmail).ToList();
                    WatchedListView.ItemsSource = note;
                }
            }
            catch
            {
                MessageBox.Show("Fail to refresh or display table!");
            }
        }

        private void AddNoteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {

            }
            catch
            {

            }
        }
    }
}