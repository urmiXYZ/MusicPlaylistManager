using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL.DTOs;
using BLL.Services;

namespace MusicPlaylistManager.Controllers
{
    public class PlaylistController : ApiController
    {
        [HttpGet]
        [Route("api/playlist/all")]
        public HttpResponseMessage Get()
        {
            try
            {
                var data = PlaylistService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("api/playlist/{id}")]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var data = PlaylistService.Get(id);
                if (data == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Playlist not found");
                }
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("api/playlist/{id}/songs")]
        public HttpResponseMessage GetwithSongs(int id)
        {
            try
            {
                var data = PlaylistService.GetwithSongs(id);
                if (data == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Playlist with songs not found");
                }
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("api/playlist/create")]
        public HttpResponseMessage Create(PlaylistDTO playlistDto)
        {
            try
            {
                var result = PlaylistService.Create(playlistDto);
                return Request.CreateResponse(HttpStatusCode.Created, result);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        [Route("api/playlist/update")]
        public HttpResponseMessage Update(PlaylistDTO playlistDto)
        {
            try
            {
                var result = PlaylistService.Update(playlistDto);
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpDelete]
        [Route("api/playlist/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var result = PlaylistService.Delete(id);
                if (result)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Playlist deleted successfully");
                }
                return Request.CreateResponse(HttpStatusCode.NotFound, "Playlist not found");
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("api/playlist/{id}/shuffle")]
        public HttpResponseMessage ShuffleSongs(int id)
        {
            try
            {
                var shuffledSongs = PlaylistService.ShuffleSongs(id);
                if (shuffledSongs == null || !shuffledSongs.Any())
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "No songs found in the playlist.");
                }
                return Request.CreateResponse(HttpStatusCode.OK, shuffledSongs);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        // Set the repeat mode (Repeat One or Repeat All) for a playlist
        [HttpPost]
        [Route("api/playlist/{id}/repeatMode")]
        public HttpResponseMessage SetRepeatMode(int id, [FromBody] RepeatModeRequest repeatModeRequest)
        {
            try
            {
                if (repeatModeRequest == null || string.IsNullOrEmpty(repeatModeRequest.RepeatMode))
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "RepeatMode is required.");
                }

                // Set the repeat mode
                PlaylistService.SetRepeatMode(id, repeatModeRequest.RepeatMode, repeatModeRequest.SongId);

                return Request.CreateResponse(HttpStatusCode.OK, $"Repeat mode for playlist {id} set to {repeatModeRequest.RepeatMode}");
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        // Get the playlist with repeat mode enabled
        [HttpGet]
        [Route("api/playlist/{id}/repeatMode")]
        public HttpResponseMessage GetRepeatMode(int id)
        {
            try
            {
                var playlistRepeat = PlaylistService.GetRepeatMode(id);

              
                var response = new
                {
                    playlistId = playlistRepeat.PlaylistId,
                    playlistName = playlistRepeat.PlaylistName,
                    currentSong = new
                    {
                        songId = playlistRepeat.CurrentSong?.Id,
                        title = playlistRepeat.CurrentSong?.Title,
                        artist = playlistRepeat.CurrentSong?.Artist
                    },
                    repeatMode = playlistRepeat.RepeatMode,
                    nextSong = playlistRepeat.NextSong != null ? new
                    {
                        songId = playlistRepeat.NextSong.Id,
                        title = playlistRepeat.NextSong.Title,
                        artist = playlistRepeat.NextSong.Artist
                    } : null,
                    songs = playlistRepeat.Songs.Select(song => new
                    {
                        songId = song.Id,
                        title = song.Title,
                        artist = song.Artist
                    }),
                    status = playlistRepeat.Status
                };

                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }


    }
}
