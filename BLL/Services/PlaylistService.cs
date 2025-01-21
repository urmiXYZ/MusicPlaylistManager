using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.Tables;
using DAL.Interfaces;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class PlaylistService
    {
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Playlist, PlaylistDTO>();
                cfg.CreateMap<PlaylistDTO, Playlist>();
                cfg.CreateMap<Playlist, PlaylistSongDTO>();
                cfg.CreateMap<Song, SongDTO>();
            });
            return new Mapper(config);
        }

        //View all playlists
        public static List<PlaylistDTO> Get()
        {
            var repo = DataAccessFactory.PlaylistData();
            return GetMapper().Map<List<PlaylistDTO>>(repo.Get());
        }

        //View certain playlist
        public static PlaylistDTO Get(int id)
        {
            var repo = DataAccessFactory.PlaylistData();
            var Playlist = repo.Get(id);
            var ret = GetMapper().Map<PlaylistDTO>(Playlist);
            return ret;

        }
       //View playlist with song
        public static PlaylistSongDTO GetwithSongs(int id)
        {
            var repo = DataAccessFactory.PlaylistData();
            var Playlist = repo.Get(id);
            var ret = GetMapper().Map<PlaylistSongDTO>(Playlist);
            return ret;

        }

        //Create playlist
        public static string Create(PlaylistDTO playlistDto)
        {
            var mapper = GetMapper(); 
            var playlist = mapper.Map<Playlist>(playlistDto); 
            var repo = DataAccessFactory.PlaylistData(); 
            var result = repo.Create(playlist); 
            return result;
        }

        //Update playlist
        public static string Update(PlaylistDTO playlistDto)
        {
            var mapper = GetMapper(); 
            var playlist = mapper.Map<Playlist>(playlistDto); 
            var repo = DataAccessFactory.PlaylistData(); 
            var result = repo.Update(playlist); 
            return result; 
        }

        //Delete playlist
        public static bool Delete(int id)
        {
            var repo = DataAccessFactory.PlaylistData();
            var result = repo.Delete(id);
            return result;
        }

        //Shuffle
        public static List<SongDTO> ShuffleSongs(int playlistId)
        {           
            var repo = DataAccessFactory.PlaylistData();
            var shuffledSongs = repo.ShuffleSongs(playlistId);

            var mapper = GetMapper();
            return mapper.Map<List<SongDTO>>(shuffledSongs);
        }

        //Repeat
        // Global variables
        private static string currentRepeatMode = "None";  // Default
        private static int? repeatSongId = null; 

       
        public static void SetRepeatMode(int playlistId, string repeatMode, int? songId = null)
        {
            
            currentRepeatMode = repeatMode;

            if (repeatMode == "Repeat One" && songId.HasValue)
            {
                repeatSongId = songId;
            }
            else
            {
               
                repeatSongId = null;
            }
        }

      
        public static PlaylistRepeatDTO GetRepeatMode(int playlistId)
        {
            var repo = DataAccessFactory.PlaylistData();

           
            var playlist = repo.GetWithSongs(playlistId);

            // in-memory currentRepeatMode
            string repeatMode = currentRepeatMode;

            
            Song currentSong = null;
            Song nextSong = null;

            if (repeatMode == "Repeat One" && repeatSongId.HasValue)
            {
                
                currentSong = playlist.Songs.FirstOrDefault(s => s.Id == repeatSongId.Value);
                nextSong = currentSong;
            }
            else
            {
                currentSong = playlist.Songs.FirstOrDefault(); 
                nextSong = playlist.Songs.Skip(1).FirstOrDefault(); 
            }

            var playlistRepeatDto = new PlaylistRepeatDTO
            {
                PlaylistId = playlist.Id,
                PlaylistName = playlist.Name,
                CurrentSong = currentSong != null ? new SongDTO
                {
                    Id = currentSong.Id,
                    Title = currentSong.Title,
                    Artist = currentSong.Artist
                } : null,
                RepeatMode = repeatMode,
                NextSong = nextSong != null ? new SongDTO
                {
                    Id = nextSong.Id,
                    Title = nextSong.Title,
                    Artist = nextSong.Artist
                } : null, 
                Songs = playlist.Songs.Select(song => new SongDTO
                {
                    Id = song.Id,
                    Title = song.Title,
                    Artist = song.Artist
                }).ToList(),
                Status = "Playing" 
            };

            return playlistRepeatDto;
        }





    }
}