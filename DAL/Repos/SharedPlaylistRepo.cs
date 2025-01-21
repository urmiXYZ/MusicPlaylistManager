using DAL.EF.Tables;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repos
{
    internal class SharedPlaylistRepo : Repo, ISharedPlaylistFeatures
    {
        public SharedPlaylist SharePlaylist(int playlistId, int sharedWithUserId, string accessLevel, int sharedByUserId)
        {
            try
            {
                var sharedPlaylist = new SharedPlaylist
                {
                    PlaylistId = playlistId,
                    SharedWithUserId = sharedWithUserId,
                    SharedByUserId = sharedByUserId, // Store who shared the playlist
                    AccessLevel = accessLevel,
                    SharedDate = DateTime.Now
                };

                db.SharedPlaylists.Add(sharedPlaylist);
                db.SaveChanges(); // Use SaveChanges (not async)
                return sharedPlaylist;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sharing playlist: {ex.Message}");
                return null;
            }
        }


        // Retrieves all shared playlists for a specific user
        public IEnumerable<SharedPlaylist> GetSharedPlaylists(int userId)
        {
            try
            {
                return db.SharedPlaylists
                         .Where(sp => sp.SharedByUserId == userId)
                         .ToList(); 
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving shared playlists: {ex.Message}");
                return new List<SharedPlaylist>();
            }
        }

       

        // Removes a shared playlist (unshare it)
        public bool RemoveSharedPlaylist(int id)
        {
            try
            {
                var sharedPlaylist = db.SharedPlaylists
                                        .FirstOrDefault(sp => sp.Id == id);

                if (sharedPlaylist != null)
                {
                    db.SharedPlaylists.Remove(sharedPlaylist);
                    db.SaveChanges();
                    return true;
                }

                return false; 
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error removing shared playlist: {ex.Message}");
                return false;
            }
        }
    }
}
