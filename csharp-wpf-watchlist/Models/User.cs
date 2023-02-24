using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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