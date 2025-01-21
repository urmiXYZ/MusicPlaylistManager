using DAL.EF.Tables;
using DAL.Interfaces;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {
        public static IPlaylistFeatures PlaylistData()
        {
            return new PlaylistRepo(); 
        }


        public static IRepo<Song, int, string> SongData()
        {
            return new SongRepo();
        }

        public static IRecentlyPlayedFeatures RecentlyPlayedData()
        {
            return new RecentlyPlayedRepo();
        }
        public static ISharedPlaylistFeatures SharedPlaylistData()
        {
            return new SharedPlaylistRepo();
        }
    }
}