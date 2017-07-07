using System.Web.Http;
using SignalRChat.Hubs;

namespace SignalRChat.Api
{
    [RoutePrefix("chat")]
    public class ChatApiController : ApiController
    {
        [HttpGet]
        [Route("clients/count")]
        public IHttpActionResult GetUsersCount()
        {
            return Ok(Chat._clientsCount);
        }
    }
}
