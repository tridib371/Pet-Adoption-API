using BLL.DTOs;
using BLL.Services;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Pet_Adoption_API.Controllers
{
    public class RecommendationController : ApiController
    {
        [HttpGet]
        [Route("api/recommendation/user/{userId:int}")]
        public HttpResponseMessage GetRecommendations(int userId)
        {
            try
            {
                var recommendations = RecommendationService.RecommendPets(userId);
                return Request.CreateResponse(HttpStatusCode.OK, recommendations);
            }
            catch (System.Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new
                {
                    Message = "Failed to get recommendations",
                    Error = ex.Message
                });
            }
        }
    }
}
