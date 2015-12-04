using System.Web.Http;

namespace BfuDay2.Controllers
{
    [RoutePrefix("ping")]
    public class PingController : ApiController
    {
        [Route("")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            return this.Ok("I'm alive!");
        }
    }
}
