using System.Web.Http;
using MonoToMicroLegacy.Models;

namespace MonoToMicroLegacy.Controllers
{
    [RoutePrefix("data")]
    public class DataReplicationController : ApiController
    {
        [HttpGet]        
        [Route("")]
        public async void Replicate()
        {
            
        }
    }
}