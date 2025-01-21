using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class SongDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public string Album { get; set; }
        public string Lyrics { get; set; }
        public int PlaylistId { get; set; }
       // public int RecentlyPlayedId { get; set; }
    }
}