using BLL.DTOs;
using BLL.Services;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Pet_Adoption_API.Controllers
{
    public class UserController : ApiController
    {
        [HttpPost]
        [Route("api/user/create")]
        public HttpResponseMessage Create(UserDTO user)
        {
            try
            {
                if (user != null)
                {
                    var data = UserService.Create(user);
                    if (data != null)
                    {
                        return Request.CreateResponse(HttpStatusCode.Created, data);
                    }
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, "Failed to create user");
                }
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid user data");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new
                {
                    Message = "An unexpected error occurred",
                    Error = ex.Message
                });
            }
        }

        [HttpGet]
        [Route("api/user/all")]
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, UserService.Get());
        }

        [HttpGet]
        [Route("api/user/{id:int}")]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var user = UserService.Get(id);
                if (user != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, user);
                }
                return Request.CreateResponse(HttpStatusCode.NotFound, "User not found");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new
                {
                    Message = "An unexpected error occurred",
                    Error = ex.Message
                });
            }
        }

        [HttpPut]
        [Route("api/user/update")]
        public HttpResponseMessage Update(UserDTO user)
        {
            try
            {
                if (user != null)
                {
                    var updatedUser = UserService.Update(user);
                    if (updatedUser != null)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, updatedUser);
                    }
                    return Request.CreateResponse(HttpStatusCode.NotFound, "User not found or update failed");
                }
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid user data");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new
                {
                    Message = "An unexpected error occurred",
                    Error = ex.Message
                });
            }
        }

        [HttpDelete]
        [Route("api/user/delete/{id:int}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var deleted = UserService.Delete(id);
                if (deleted)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "User deleted successfully");
                }
                return Request.CreateResponse(HttpStatusCode.NotFound, "User not found or delete failed");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new
                {
                    Message = "An unexpected error occurred",
                    Error = ex.Message
                });
            }
        }
        [HttpPatch]
        [Route("api/user/patch/{id:int}")]
        public HttpResponseMessage Patch(int id, UserDTO user)
        {
            try
            {
                if (user != null)
                {
                    var patchedUser = UserService.Patch(id, user);
                    if (patchedUser != null)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, patchedUser);
                    }
                    return Request.CreateResponse(HttpStatusCode.NotFound, "User not found or patch failed");
                }
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid user data");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new
                {
                    Message = "An unexpected error occurred",
                    Error = ex.Message
                });
            }
        }



    }
}
