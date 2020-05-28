using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.UI.HtmlControls;
using Amazon.EC2;
using MonoToMicroLegacy.Core.Repository.Interfaces;
using MonoToMicroLegacy.Core.Services.Interfaces;

namespace MonoToMicroLegacy.Controllers
{
    [RoutePrefix("health")]
    public class HealthController : ApiController
    {
        private readonly IHealthService _service;

        public HealthController(IHealthService service)
        {
            _service = service;
        }
        
        [HttpGet]
        [Route("ishealthy")]
        public async Task<string> IsHealthy()
        {
            return await Task.FromResult("Developer life matter");
        }

        [HttpGet]
        [Route("ping")]
        public async Task<string> Ping()
        {
            if (string.IsNullOrEmpty(Amazon.EC2.Util.EC2Metadata.InstanceId))
            {
                return await Task.FromResult("No instance found");
            }
            else
            {
                var ret = $"instanceID: {Amazon.EC2.Util.EC2Metadata.InstanceId} \r\n" +
                          $"instanceType: {Amazon.EC2.Util.EC2Metadata.InstanceType}";

                return await Task.FromResult(ret);
            }
        }

        [HttpGet]
        [Route("dbping")]
        public async Task<HttpResponseMessage> DatabasePing()
        {
            if (this._service.IsReachable())
            {
                return await Task.FromResult(this.Request.CreateResponse(HttpStatusCode.OK));    
            }
            else
            {
                return await Task.FromResult(this.Request.CreateResponse(HttpStatusCode.BadRequest));
            }
            
        }
    }
}