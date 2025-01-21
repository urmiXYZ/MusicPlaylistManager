using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.Tables;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Services
{
    public class SharedPlaylistService
    {
        
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<SharedPlaylist, SharedPlaylistDTO>();

            });
            return new Mapper(config);
        }

        public static SharedPlaylistDTO SharePlaylist(int playlistId, int sharedWithUserId, string accessLevel, int sharedByUserId)
        {
            var repo = DataAccessFactory.SharedPlaylistData();
            var sharedPlaylist = repo.SharePlaylist(playlistId, sharedWithUserId, accessLevel, sharedByUserId);

            var mapper = GetMapper();
            return mapper.Map<SharedPlaylistDTO>(sharedPlaylist);
        }


        // Get all shared playlists for a user
        public static List<SharedPlaylistDTO> GetSharedPlaylists(int userId)
        {
            var repo = DataAccessFactory.SharedPlaylistData();
            var sharedPlaylists = repo.GetSharedPlaylists(userId); 

            
            var filteredPlaylists = sharedPlaylists
                .Where(sp => sp.SharedByUserId == userId)
                .ToList();

            var mapper = GetMapper();
            return mapper.Map<List<SharedPlaylistDTO>>(filteredPlaylists);
        }


        


        // Remove a shared playlist
        public static bool RemoveSharedPlaylist(int id)
        {
            var repo = DataAccessFactory.SharedPlaylistData();
            return repo.RemoveSharedPlaylist(id);
        }
    }
}
