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
    public class SongController : ApiController
    {
        // Get all songs
        [HttpGet]
        [Route("api/song/all")]
        public HttpResponseMessage Get()
        {
            try
            {
                var data = SongService.Get();  // Using SongService to get all songs
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        // Get a specific song by ID
        [HttpGet]
        [Route("api/song/{id}")]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var data = SongService.Get(id);  // Using SongService to get a song by ID
                if (data == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Song not found");
                }
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        // Create a new song
        [HttpPost]
        [Route("api/song/add")]
        public HttpResponseMessage Create(SongDTO songDto)
        {
            try
            {
                var result = SongService.Create(songDto);  
                return Request.CreateResponse(HttpStatusCode.Created, result);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }


        // Update an existing song
        [HttpPut]
        [Route("api/song/update")]
        public HttpResponseMessage Update(SongDTO songDto)
        {
            try
            {
                var result = SongService.Update(songDto);  
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        // Delete a song by ID
        [HttpDelete]
        [Route("api/song/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var result = SongService.Delete(id);  
                if (result)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Song deleted successfully");
                }
                return Request.CreateResponse(HttpStatusCode.NotFound, "Song not found");
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        // Get song details (title, artist, album)
        [HttpGet]
        [Route("api/song/details/{id}")]
        public HttpResponseMessage GetSongDetails(int id)
        {
            try
            {
                var details = SongService.GetSongDetails(id); 
                if (string.IsNullOrEmpty(details))
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Song details not found");
                }
                return Request.CreateResponse(HttpStatusCode.OK, details);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        // Get song lyrics
        [HttpGet]
        [Route("api/song/lyrics/{id}")]
        public HttpResponseMessage GetSongLyrics(int id)
        {
            try
            {
                var lyrics = SongService.GetSongLyrics(id);  
                if (string.IsNullOrEmpty(lyrics))
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Song lyrics not found");
                }
                return Request.CreateResponse(HttpStatusCode.OK, lyrics);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }

}

