using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace MusicPlaylistManager.Controllers
{
    public class RecentlyPlayedController : ApiController
    {
        // Add to Recently Played
        [HttpPost]
        [Route("api/recentlyplayed/add")]
        public HttpResponseMessage AddToRecentlyPlayed(RecentlyPlayedDTO recentlyPlayedDto)
        {
            try
            {
                
                var result = RecentlyPlayedService.AddToRecentlyPlayed(recentlyPlayedDto.UserId, recentlyPlayedDto.SongId);

                if (result)
                {
                    return Request.CreateResponse(HttpStatusCode.Created, "Song added to Recently Played.");
                }
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Failed to add song to Recently Played.");
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        // Get the 3 most recently played songs for a user
        [HttpGet]
        [Route("api/recentlyplayed/{userId}")]
        public HttpResponseMessage GetRecentSongs(int userId)
        {
            try
            {
                var recentSongs = RecentlyPlayedService.GetRecentSongs(userId);

                if (recentSongs == null || recentSongs.Count == 0)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "No recent songs found.");
                }

                return Request.CreateResponse(HttpStatusCode.OK, recentSongs);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

    }
}
