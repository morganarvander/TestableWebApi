using System.Threading.Tasks;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class DefaultController : ApiController
    {
        [HttpGet]
        [Route("api/test")]
        public IHttpActionResult Index()
        {
            return Ok(new WebApiResult()
            {
                Name = "John Doe"
            });
        }
    }


}