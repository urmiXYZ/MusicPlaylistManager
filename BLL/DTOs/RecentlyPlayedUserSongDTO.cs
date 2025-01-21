using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class RecentlyPlayedUserSongDTO : RecentlyPlayedDTO
    {
        public List<SongDTO> Songs { get; set; }
        //public List<UserDTO> Users { get; set; }
        public RecentlyPlayedUserSongDTO()
        {
            Songs = new List<SongDTO>();
            //Users = new List<UserDTO>();
        }
    }
}
