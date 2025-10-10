using BLL.DTOs;
using BLL.Services;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Pet_Adoption_API.Controllers
{
    public class AdoptionController : ApiController
    {
        [HttpPost]
        [Route("api/adoption/create")]
        public HttpResponseMessage Create(AdoptionDTO adoption)
        {
            try
            {
                if (adoption != null)
                {
                    var data = AdoptionService.Create(adoption);
                    if (data != null)
                        return Request.CreateResponse(HttpStatusCode.Created, data);
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, "Failed to create adoption record");
                }
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid adoption data");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = "An unexpected error occurred", Error = ex.Message });
            }
        }

        [HttpGet]
        [Route("api/adoption/all")]
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, AdoptionService.Get());
        }

        [HttpGet]
        [Route("api/adoption/{id:int}")]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var adoption = AdoptionService.Get(id);
                if (adoption != null)
                    return Request.CreateResponse(HttpStatusCode.OK, adoption);
                return Request.CreateResponse(HttpStatusCode.NotFound, "Adoption record not found");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = "An unexpected error occurred", Error = ex.Message });
            }
        }


        [HttpDelete]
        [Route("api/adoption/delete/{id:int}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var deleted = AdoptionService.Delete(id);
                if (deleted)
                    return Request.CreateResponse(HttpStatusCode.OK, "Adoption record deleted successfully");
                return Request.CreateResponse(HttpStatusCode.NotFound, "Adoption record not found or delete failed");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = "An unexpected error occurred", Error = ex.Message });
            }
        }



        // Workflow Automation Endpoint

        [HttpPatch]
        [Route("api/adoption/status/{id:int}")]
        public HttpResponseMessage UpdateStatus(int id, [FromBody] string newStatus)
        {
            try
            {
                var updated = AdoptionService.UpdateStatus(id, newStatus);
                if (updated != null)
                    return Request.CreateResponse(HttpStatusCode.OK, updated);

                return Request.CreateResponse(HttpStatusCode.NotFound, "Adoption record not found or update failed");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = "An unexpected error occurred", Error = ex.Message });
            }
        }
    }
}
