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
    public class RecentlyPlayedService
    {
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<RecentlyPlayed, RecentlyPlayedDTO>();
                
            });
            return new Mapper(config);
        }


        // Add to Recently Played
        public static bool AddToRecentlyPlayed(int userId, int songId)
        {
            var repo = DataAccessFactory.RecentlyPlayedData();
            return repo.AddToRecentlyPlayed(userId, songId);
        }

        // Get 3 most recent songs for a user
        public static List<RecentlyPlayedDTO> GetRecentSongs(int userId)
        {
            var repo = DataAccessFactory.RecentlyPlayedData();
            var recentSongs = repo.GetRecentSongs(userId);

            var mapper = GetMapper();
            return mapper.Map<List<RecentlyPlayedDTO>>(recentSongs);
        }

    }
}
