using BLL.DTOs;
using BLL.Services;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Pet_Adoption_API.Controllers
{
    public class ReportController : ApiController
    {
        [HttpGet]
        [Route("api/report/all")]
        public HttpResponseMessage GetReport()
        {
            try
            {
                var report = ReportService.GenerateReport();
                return Request.CreateResponse(HttpStatusCode.OK, report);
            }
            catch (System.Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError,
                    new { Message = "Failed to generate report", Error = ex.Message });
            }
        }
    }
}
