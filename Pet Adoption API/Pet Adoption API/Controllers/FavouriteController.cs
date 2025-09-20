using BLL.DTOs;
using BLL.Services;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Pet_Adoption_API.Controllers
{
    public class FavoriteController : ApiController
    {
        [HttpPost]
        [Route("api/favorite/create")]
        public HttpResponseMessage Create(FavoriteDTO favorite)
        {
            try
            {
                if (favorite != null)
                {
                    var data = FavoriteService.Create(favorite);
                    if (data != null)
                        return Request.CreateResponse(HttpStatusCode.Created, data);
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, "Failed to create favorite");
                }
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid favorite data");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = "An unexpected error occurred", Error = ex.Message });
            }
        }

        [HttpGet]
        [Route("api/favorite/all")]
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, FavoriteService.Get());
        }

        [HttpGet]
        [Route("api/favorite/{id:int}")]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var favorite = FavoriteService.Get(id);
                if (favorite != null)
                    return Request.CreateResponse(HttpStatusCode.OK, favorite);
                return Request.CreateResponse(HttpStatusCode.NotFound, "Favorite not found");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = "An unexpected error occurred", Error = ex.Message });
            }
        }

        [HttpDelete]
        [Route("api/favorite/delete/{id:int}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var deleted = FavoriteService.Delete(id);
                if (deleted)
                    return Request.CreateResponse(HttpStatusCode.OK, "Favorite deleted successfully");
                return Request.CreateResponse(HttpStatusCode.NotFound, "Favorite not found or delete failed");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = "An unexpected error occurred", Error = ex.Message });
            }
        }
    }
}
