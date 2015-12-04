using System.Linq;
using System.Web.Http;
using BfuDay2.Models;

namespace BfuDay2.Controllers
{
    [RoutePrefix("users")]
    public class UsersController : ApiController
    {
        [HttpPost]
        [Route("")]
        public IHttpActionResult Add([FromBody] User user)
        {
            using (var context = new BfuContext())
            {
                context.Users.Add(user);
                context.SaveChanges();
            }

            return this.Ok();
        }

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            using (var context = new BfuContext())
            {
                var user = context.Users.Find(id);
                if (user != null)
                {
                    return this.Ok(user);
                }

                return this.NotFound();
            }
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult Get()
        {
            using (var context = new BfuContext())
            {
                return this.Ok(context.Users.ToArray());
            }
        }
    }
}
