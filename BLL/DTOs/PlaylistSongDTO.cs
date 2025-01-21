using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class PlaylistSongDTO : PlaylistDTO
    {
        public List<SongDTO> Songs { get; set; }
        public PlaylistSongDTO()
        {
            Songs = new List<SongDTO>();
        }
    }
}