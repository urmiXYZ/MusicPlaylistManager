using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Tables
{
    public class Song
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public string Album { get; set; }
        public string Lyrics { get; set; }

        [ForeignKey("Play")]
        public int PlaylistId { get; set; }
        public Playlist Play { get; set; }
        public virtual List<RecentlyPlayed> RecentlyPlayeds { get; set; }
        public Song()
        {
            RecentlyPlayeds = new List<RecentlyPlayed>();
        }
    }
}