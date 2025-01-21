using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Tables
{
    public class Playlist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Song> Songs { get; set; }
        public virtual List<SharedPlaylist> SharedPlaylists { get; set; }
        public Playlist()
        {
            Songs = new List<Song>();
            SharedPlaylists = new List<SharedPlaylist>();
        }

        [ForeignKey("Us")]
        public int UserId { get; set; }
        public User Us { get; set; }
    }
}