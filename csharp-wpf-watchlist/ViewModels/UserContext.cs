using csharp_wpf_watchlist.Models;
using Microsoft.EntityFrameworkCore;

namespace csharp_wpf_watchlist.ViewModels
{
    class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=WatchListDatabase;Trusted_Connection=True;");
        }
    }
}