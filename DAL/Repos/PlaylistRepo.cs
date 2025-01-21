using DAL.EF;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;
using DAL.EF.Tables;
using System;
using System.Collections.Concurrent;

namespace DAL.Repos
{
    internal class PlaylistRepo : Repo, IPlaylistFeatures
    {
        public string Create(Playlist playlist)
        {
            db.Playlists.Add(playlist);
            db.SaveChanges();
            return "Playlist created successfully.";
        }

        public string Update(Playlist playlist)
        {
            var existingPlaylist = Get(playlist.Id);
            if (existingPlaylist != null)
            {
                db.Entry(existingPlaylist).CurrentValues.SetValues(playlist);
                db.SaveChanges();
                return "Playlist updated successfully.";
            }
            return "Playlist not found.";
        }

        public bool Delete(int id)
        {
            var existingPlaylist = Get(id);
            if (existingPlaylist != null)
            {
                db.Playlists.Remove(existingPlaylist);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public Playlist Get(int id)
        {
            return db.Playlists.Find(id);
        }

        public List<Playlist> Get()
        {
            return db.Playlists.ToList();
        }

        public Playlist GetWithSongs(int id)
        {
            return db.Playlists
                .Include("Songs")
                .FirstOrDefault(p => p.Id == id);
        }

        public List<Song> ShuffleSongs(int playlistId)
        {
            var playlist = GetWithSongs(playlistId);
            if (playlist == null || playlist.Songs == null || !playlist.Songs.Any())
            {
                return new List<Song>(); 
            }

            
            var random = new Random();
            var shuffledSongs = playlist.Songs.OrderBy(x => random.Next()).ToList();

            return shuffledSongs;
        }

        // In-memory store for repeat modes
        private static Dictionary<int, string> playlistRepeatMode = new Dictionary<int, string>();

        // Set the repeat mode for a playlist
        public void SetRepeatMode(int playlistId, string repeatMode)
        {
            if (repeatMode == "Repeat One" || repeatMode == "Repeat All")
            {
                playlistRepeatMode[playlistId] = repeatMode;
            }
            else
            {
                throw new ArgumentException("Invalid repeat mode");
            }
        }

        // Get the repeat mode for a playlist
        public string GetRepeatMode(int playlistId)
        {
            // Check if the playlistId exists in the dictionary
            if (playlistRepeatMode.ContainsKey(playlistId))
            {
                return playlistRepeatMode[playlistId]; // Return the repeat mode if it exists
            }
            else
            {
                return "None"; // Return "None" if the repeat mode does not exist
            }
        }



    }

}

