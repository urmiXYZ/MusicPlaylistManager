using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class RecentlyPlayedDTO
    {
        public int Id { get; set; }
        public DateTime PlayedAt { get; set; }
        public int UserId { get; set; }  
        public int SongId { get; set; }
    }
}
