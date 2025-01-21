using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ISongFeatures : IRepo<Song, int, string>
    {
        string DisplaySongDetails(int id);
        string GetSongLyrics(int id);
        

    }
}
