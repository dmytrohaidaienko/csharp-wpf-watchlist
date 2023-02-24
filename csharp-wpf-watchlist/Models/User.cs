using System;
using System.ComponentModel.DataAnnotations;

namespace csharp_wpf_watchlist.Models
{
    class User
    {
        public User()
        {

        }

        [Key]
        public String? Email { get; set; }
        public String? Name { get; set; }
        public String? Surname { get; set; }
        public String? Password { get; set; }
    }
}