using DAL.EF.Tables;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class SongRepo : Repo, ISongFeatures
    {
        // Create a new song
        public string Create(Song song)
        {
            try
            {
                // Validate PlaylistId
                if (!db.Playlists.Any(p => p.Id == song.PlaylistId))
                {
                    return "Invalid PlaylistId. Playlist does not exist.";
                }

                // Validate required fields
                if (string.IsNullOrEmpty(song.Title) || string.IsNullOrEmpty(song.Artist))
                {
                    return "Title and Artist are required.";
                }

                // Add song
                db.Songs.Add(song);
                db.SaveChanges();
                return "Song created successfully.";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException?.Message); // Log error
                return "Error while creating the song: " + ex.Message;
            }
        }


        // Update an existing song
        public string Update(Song song)
        {
            var existingSong = Get(song.Id);  
            if (existingSong != null)
            {
                db.Entry(existingSong).CurrentValues.SetValues(song);  
                db.SaveChanges(); 
                return "Song updated successfully.";
            }
            return "Song not found.";
        }

        // Delete a song by ID
        public bool Delete(int id)
        {
            var existingSong = Get(id);  
            if (existingSong != null)
            {
                db.Songs.Remove(existingSong); 
                db.SaveChanges();  
                return true;
            }
            return false;  
        }

        
        public Song Get(int id)
        {
            return db.Songs.Find(id);  
        }

        // Get all songs
        public List<Song> Get()
        {
            return db.Songs.ToList(); 
        }

        // Display song details (title, artist, album)
        public string DisplaySongDetails(int id)
        {
            var song = Get(id);
            if (song != null)
            {
                
                return $"Title: {song.Title}\nArtist: {song.Artist}\nAlbum: {song.Album}";
            }
            return "Song not found.";
        }

        // Display song lyrics
        public string GetSongLyrics(int id)
        {
            var song = Get(id);
            if (song != null)
            {
              
                return song.Lyrics ?? "Lyrics not available.";
            }
            return "Song not found.";
        }
    }
}
