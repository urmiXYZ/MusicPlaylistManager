using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.EF.Tables
{
    public class RecentlyPlayed
    {
        public int Id { get; set; }
        public DateTime PlayedAt { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }  

        [ForeignKey("Song")]
        public int SongId { get; set; }
        public Song Song { get; set; }  

        
    }
}
