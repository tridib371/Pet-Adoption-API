using BLL.DTOs;
using BLL.Services;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Pet_Adoption_API.Controllers
{
    public class ShelterController : ApiController
    {
        [HttpPost]
        [Route("api/shelter/create")]
        public HttpResponseMessage Create(ShelterDTO shelter)
        {
            try
            {
                if (shelter != null)
                {
                    var data = ShelterService.Create(shelter);
                    if (data != null)
                        return Request.CreateResponse(HttpStatusCode.Created, data);
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, "Failed to create shelter");
                }
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid shelter data");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = "An unexpected error occurred", Error = ex.Message });
            }
        }

        [HttpGet]
        [Route("api/shelter/all")]
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, ShelterService.Get());
        }

        [HttpGet]
        [Route("api/shelter/{id:int}")]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var shelter = ShelterService.Get(id);
                if (shelter != null)
                    return Request.CreateResponse(HttpStatusCode.OK, shelter);
                return Request.CreateResponse(HttpStatusCode.NotFound, "Shelter not found");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = "An unexpected error occurred", Error = ex.Message });
            }
        }

        [HttpPut]
        [Route("api/shelter/update")]
        public HttpResponseMessage Update(ShelterDTO shelter)
        {
            try
            {
                if (shelter != null)
                {
                    var updated = ShelterService.Update(shelter);
                    if (updated != null)
                        return Request.CreateResponse(HttpStatusCode.OK, updated);
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Shelter not found or update failed");
                }
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid shelter data");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = "An unexpected error occurred", Error = ex.Message });
            }
        }

        [HttpDelete]
        [Route("api/shelter/delete/{id:int}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var deleted = ShelterService.Delete(id);
                if (deleted)
                    return Request.CreateResponse(HttpStatusCode.OK, "Shelter deleted successfully");
                return Request.CreateResponse(HttpStatusCode.NotFound, "Shelter not found or delete failed");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = "An unexpected error occurred", Error = ex.Message });
            }
        }
    }
}
