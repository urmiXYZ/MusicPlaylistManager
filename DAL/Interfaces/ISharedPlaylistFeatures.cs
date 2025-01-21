using DAL.EF.Tables;
using System;
using System.Collections.Generic;

namespace DAL.Interfaces
{
    public interface ISharedPlaylistFeatures
    {
        SharedPlaylist SharePlaylist(int playlistId, int sharedWithUserId, string accessLevel, int sharedByUserId);
        IEnumerable<SharedPlaylist> GetSharedPlaylists(int userId);
       // SharedPlaylist GetSharedPlaylistById(int id);
        bool RemoveSharedPlaylist(int id);
    }
}
