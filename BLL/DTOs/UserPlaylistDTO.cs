using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class UserPlaylistDTO : UserDTO
    {
        public List<PlaylistDTO> Playlists { get; set; }
        public UserPlaylistDTO()
        {
            Playlists = new List<PlaylistDTO>();
        }
    
    }
}
