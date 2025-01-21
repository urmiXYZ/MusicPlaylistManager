using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.Tables;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class SongService
    {

        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Song, SongDTO>(); 
                cfg.CreateMap<SongDTO, Song>(); 
              
            });
            return new Mapper(config);
        }

        // View all songs
        public static List<SongDTO> Get()
        {
            var repo = DataAccessFactory.SongData();  
            return GetMapper().Map<List<SongDTO>>(repo.Get());  
        }

        // View a specific song by ID
        public static SongDTO Get(int id)
        {
            var repo = DataAccessFactory.SongData();  
            var song = repo.Get(id);  
            return GetMapper().Map<SongDTO>(song);  
        }

        // Create a new song
        public static string Create(SongDTO songDto)
        {
            var mapper = GetMapper();  
            var song = mapper.Map<Song>(songDto);  
            var repo = DataAccessFactory.SongData();  
            var result = repo.Create(song);  
            return result;
        }

        // Update an existing song
        public static string Update(SongDTO songDto)
        {
            var mapper = GetMapper();  
            var song = mapper.Map<Song>(songDto);  
            var repo = DataAccessFactory.SongData();  
            var result = repo.Update(song);  
            return result;
        }

        // Delete a song by ID
        public static bool Delete(int id)
        {
            var repo = DataAccessFactory.SongData();  
            var result = repo.Delete(id);  
            return result;
        }

        //song details
        public static string GetSongDetails(int id)
        {
            var repo = DataAccessFactory.SongData();  
            var song = repo.Get(id);  
            if (song != null)
            {
                return $"Title: {song.Title}\nArtist: {song.Artist}\nAlbum: {song.Album}";  
            }
            return "Song not found.";
        }

        // Get Song Lyrics
        public static string GetSongLyrics(int id)
        {
            var repo = DataAccessFactory.SongData();  
            var song = repo.Get(id); 
            if (song != null)
            {
                return song.Lyrics ?? "Lyrics not available.";  
            }
            return "Song not found.";
        }
    }

}