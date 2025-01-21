using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class PlaylistRepeatDTO
    {
        public int PlaylistId { get; set; }
        public string PlaylistName { get; set; }
        public SongDTO CurrentSong { get; set; }
        public string RepeatMode { get; set; }
        public SongDTO NextSong { get; set; }
        public List<SongDTO> Songs { get; set; }
        public string Status { get; set; }

        public PlaylistRepeatDTO()
        {
            Songs = new List<SongDTO>();
        }
    }

}
