using csharp_wpf_watchlist.Models;
using csharp_wpf_watchlist.ViewModels;
using System;
using System.Windows;
using System.Windows.Input;

namespace csharp_wpf_watchlist.Views
{
    public partial class AddNoteWindow : Window
    {
        public String NoteEmail { get; set; }

        public AddNoteWindow(String CurrentUserEmail)
        {
            NoteEmail = CurrentUserEmail;
            InitializeComponent();
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

        private void AddNoteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var noteContext = new NoteContext())
                {
                    var newNote = new Note
                    {
                        Email = NoteEmail,
                        NoteTitle = TitleTextBox.Text,
                        NoteType = TypeComboBox.Text,
                        NoteEpisodes = Int32.Parse(EpisodesTextBox.Text),
                        NoteRating = Int32.Parse(RatingComboBox.Text),
                    };
                    noteContext.Notes.Add(newNote);
                    noteContext.SaveChanges();
                    MessageBox.Show("New note added!");
                }
            }
            catch
            {
                MessageBox.Show("Error to add new note. Try again later.");
            }
        }
    }
}