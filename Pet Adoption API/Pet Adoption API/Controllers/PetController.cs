using BLL.DTOs;
using BLL.Services;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Pet_Adoption_API.Controllers
{
    public class PetController : ApiController
    {
        [HttpPost]
        [Route("api/pet/create")]
        public HttpResponseMessage Create(PetDTO pet)
        {
            try
            {
                if (pet != null)
                {
                    var data = PetService.Create(pet);
                    if (data != null)
                        return Request.CreateResponse(HttpStatusCode.Created, data);
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, "Failed to create pet");
                }
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid pet data");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = "An unexpected error occurred", Error = ex.Message });
            }
        }

        [HttpGet]
        [Route("api/pet/all")]
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, PetService.Get());
        }

        [HttpGet]
        [Route("api/pet/{id:int}")]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var pet = PetService.Get(id);
                if (pet != null)
                    return Request.CreateResponse(HttpStatusCode.OK, pet);
                return Request.CreateResponse(HttpStatusCode.NotFound, "Pet not found");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = "An unexpected error occurred", Error = ex.Message });
            }
        }

        [HttpPut]
        [Route("api/pet/update")]
        public HttpResponseMessage Update(PetDTO pet)
        {
            try
            {
                if (pet != null)
                {
                    var updated = PetService.Update(pet);
                    if (updated != null)
                        return Request.CreateResponse(HttpStatusCode.OK, updated);
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Pet not found or update failed");
                }
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid pet data");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = "An unexpected error occurred", Error = ex.Message });
            }
        }

        [HttpDelete]
        [Route("api/pet/delete/{id:int}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var deleted = PetService.Delete(id);
                if (deleted)
                    return Request.CreateResponse(HttpStatusCode.OK, "Pet deleted successfully");
                return Request.CreateResponse(HttpStatusCode.NotFound, "Pet not found or delete failed");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = "An unexpected error occurred", Error = ex.Message });
            }
        }


        [HttpPost]
        [Route("api/pet/search")]
        public HttpResponseMessage Search(PetDTO filter)
        {
            try
            {
                var pets = PetService.Search(filter);
                return Request.CreateResponse(HttpStatusCode.OK, pets);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = "An unexpected error occurred", Error = ex.Message });
            }
        }


    }
}
