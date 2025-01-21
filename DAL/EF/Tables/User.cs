using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Tables
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public virtual List<Playlist> Playlists { get; set; }
        public virtual List<RecentlyPlayed> RecentlyPlayeds { get; set; }
        public virtual List<SharedPlaylist> SharedPlaylists { get; set; } 
        public User()
        {
            Playlists = new List<Playlist>();
            RecentlyPlayeds = new List<RecentlyPlayed>();
            SharedPlaylists = new List<SharedPlaylist>(); 
        }
    }

}
