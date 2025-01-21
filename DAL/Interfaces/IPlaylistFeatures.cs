using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IPlaylistFeatures : IRepo<Playlist, int, string>
    {
        Playlist GetWithSongs(int id);
        List<Song> ShuffleSongs(int playlistId);

        void SetRepeatMode(int playlistId, string repeatMode);  
        string GetRepeatMode(int playlistId);  
    }
}
