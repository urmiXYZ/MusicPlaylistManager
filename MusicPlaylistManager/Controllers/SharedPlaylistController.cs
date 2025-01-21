using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MusicPlaylistManager.Controllers
{
    public class SharedPlaylistController : ApiController
    {
        // Share a playlist with another user
        [HttpPost]
        [Route("api/sharedplaylist/share")]
        public HttpResponseMessage SharePlaylist(SharedPlaylistDTO sharedPlaylistDto)
        {
            try
            {
                // Assuming the sharedByUserId is the authenticated user making the request
                int sharedByUserId = sharedPlaylistDto.SharedByUserId; // This should be retrieved from the session or JWT token

                var result = SharedPlaylistService.SharePlaylist(sharedPlaylistDto.PlaylistId,
                                                                 sharedPlaylistDto.SharedWithUserId,
                                                                 sharedPlaylistDto.AccessLevel,
                                                                 sharedByUserId);

                if (result != null)
                {
                    return Request.CreateResponse(HttpStatusCode.Created, result);
                }

                return Request.CreateResponse(HttpStatusCode.BadRequest, "Failed to share the playlist.");
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }


        // Get all shared playlists for a user
        [HttpGet]
        [Route("api/sharedplaylist/{userId}")]
        public HttpResponseMessage GetSharedPlaylists(int userId)
        {
            try
            {
                // Get all shared playlists for this user
                var sharedPlaylists = SharedPlaylistService.GetSharedPlaylists(userId);

                if (sharedPlaylists == null || sharedPlaylists.Count == 0)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "No shared playlists found.");
                }

                return Request.CreateResponse(HttpStatusCode.OK, sharedPlaylists);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        


        // Remove a shared playlist
        [HttpDelete]
        [Route("api/sharedplaylist/remove/{id}")]
        public HttpResponseMessage RemoveSharedPlaylist(int id)
        {
            try
            {
                var result = SharedPlaylistService.RemoveSharedPlaylist(id);

                if (result)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Shared playlist removed successfully.");
                }

                return Request.CreateResponse(HttpStatusCode.BadRequest, "Failed to remove shared playlist.");
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
