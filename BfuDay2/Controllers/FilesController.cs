using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using BfuDay2.Helpers;

namespace BfuDay2.Controllers
{
    [RoutePrefix("files")]
    public class FilesController : ApiController
    {
        [HttpPost]
        [Route("")]
        public async Task<IHttpActionResult> AddFile([FromBody] string url)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                var bytes = await response.Content.ReadAsByteArrayAsync();

                var name = url.Split('/').Last();
                var blobUrl = await StorageHelper.SaveFile(bytes, name);
                return this.Ok(blobUrl);
            }
        }
    }
}
