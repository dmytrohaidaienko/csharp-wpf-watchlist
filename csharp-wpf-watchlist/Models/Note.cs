using System;
using System.ComponentModel.DataAnnotations;

namespace csharp_wpf_watchlist.Models
{
    class Note
    {
        public Note()
        {

        }

        [Key]
        public String? NoteTitle { get; set; }
        public String? Email { get; set; }
        public String? NoteType { get; set; }
        public Int32 NoteEpisodes { get; set; }
        public Int32 NoteRating { get; set; }
    }
}