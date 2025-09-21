using BLL.DTOs;
using BLL.Services;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Pet_Adoption_API.Controllers
{
    public class NotificationController : ApiController
    {
        [HttpPost]
        [Route("api/notification/create")]
        public HttpResponseMessage Create(NotificationDTO notif)
        {
            var data = NotificationService.Create(notif);
            if (data != null)
                return Request.CreateResponse(HttpStatusCode.Created, data);
            return Request.CreateResponse(HttpStatusCode.InternalServerError, "Failed to create notification");
        }

        [HttpGet]
        [Route("api/notification/all")]
        public HttpResponseMessage GetAll()
        {
            return Request.CreateResponse(HttpStatusCode.OK, NotificationService.GetAll());
        }

        [HttpGet]
        [Route("api/notification/read/{id:int}")]
        public HttpResponseMessage MarkAsRead(int id)
        {
            var res = NotificationService.MarkAsRead(id);
            if (res) return Request.CreateResponse(HttpStatusCode.OK, "Notification marked as read");
            return Request.CreateResponse(HttpStatusCode.NotFound, "Notification not found");
        }
    }
}
