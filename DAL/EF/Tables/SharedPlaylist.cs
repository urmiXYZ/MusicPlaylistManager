using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.EF.Tables
{
    public class SharedPlaylist
    {
        public int Id { get; set; }

        
        [ForeignKey("Play")]
        public int PlaylistId { get; set; }
        public Playlist Play { get; set; }

        [ForeignKey("SharedWithUser")]
        public int SharedWithUserId { get; set; }
        public User SharedWithUser { get; set; }

        [ForeignKey("SharedByUser")]
        public int SharedByUserId { get; set; }
        public User SharedByUser { get; set; }


        public string AccessLevel { get; set; } 
        public DateTime SharedDate { get; set; } 

        public SharedPlaylist()
        {
            SharedDate = DateTime.Now; 
        }
    }
}
