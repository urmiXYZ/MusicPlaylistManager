using DAL.EF.Tables;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repos
{
    internal class RecentlyPlayedRepo : Repo, IRecentlyPlayedFeatures
    {
        // Adds a song to the RecentlyPlayed table
        public bool AddToRecentlyPlayed(int userId, int songId)
        {
            try
            {
                var recentlyPlayed = new RecentlyPlayed
                {
                    UserId = userId,
                    SongId = songId,
                    PlayedAt = DateTime.Now
                };

                db.RecentlyPlayeds.Add(recentlyPlayed);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                
                Console.WriteLine($"Error adding to RecentlyPlayed: {ex.Message}");
                return false;
            }
        }

        // Retrieves the 3 most recently played songs for a specific user
        public List<RecentlyPlayed> GetRecentSongs(int userId)
        {
            try
            {
                
                return db.RecentlyPlayeds
                         .Where(rp => rp.UserId == userId)
                         .OrderByDescending(rp => rp.PlayedAt)
                         .Take(3)
                         .ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving recent songs: {ex.Message}");
                return new List<RecentlyPlayed>();
            }
        }

    }
}
