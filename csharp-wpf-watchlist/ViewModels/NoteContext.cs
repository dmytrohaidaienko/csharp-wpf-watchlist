using csharp_wpf_watchlist.Models;
using Microsoft.EntityFrameworkCore;

namespace csharp_wpf_watchlist.ViewModels
{
    class NoteContext : DbContext
    {
        public DbSet<Note> Notes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=WatchListDatabase;Trusted_Connection=True;");
        }
    }
}