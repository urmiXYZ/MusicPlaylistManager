using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class SharedPlaylistDTO
    {
        public int Id { get; set; } 
        public int PlaylistId { get; set; } 
        //public string PlaylistName { get; set; } 
        public int SharedWithUserId { get; set; }
        public int SharedByUserId { get; set; }
        //public string UserName { get; set; } 
        public string AccessLevel { get; set; } 
        public DateTime? SharedDate { get; set; } 

        
    }

}
