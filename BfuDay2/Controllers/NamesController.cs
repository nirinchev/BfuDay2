using System.Web.Http;

namespace BfuDay2.Controllers
{
    [RoutePrefix("names")]
    public class NamesController : ApiController
    {
        [Route("")]
        [HttpGet]
        public IHttpActionResult GetNames()
        {
            return this.Ok(new[]
            {
                "Niki",
                "Konstantin",
                "Kamen"
            });
        }
    }
}
