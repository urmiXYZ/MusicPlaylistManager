using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF
{
    public class Context : DbContext
    {
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<RecentlyPlayed> RecentlyPlayeds { get; set; }
        public DbSet<SharedPlaylist> SharedPlaylists { get; set; }
        //public DbSet<Token> Tokens { get; set; }
    }
}