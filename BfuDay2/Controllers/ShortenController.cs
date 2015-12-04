using System.Web.Http;

namespace BfuDay2.Controllers
{
    [RoutePrefix("shorten")]
    public class ShortenController : ApiController
    {
        [HttpPost]
        [Route("")]
        public IHttpActionResult Add(string key, [FromBody] string realUrl)
        {
            ShortenHelper.Add(key, realUrl);
            return this.Ok();
        }

        [HttpGet]
        [Route("{key}")]
        public IHttpActionResult Get(string key)
        {
            string realUrl;
            if (ShortenHelper.TryGet(key, out realUrl))
            {
                return this.Redirect(realUrl);
            }

            return this.NotFound();
        }
    }
}