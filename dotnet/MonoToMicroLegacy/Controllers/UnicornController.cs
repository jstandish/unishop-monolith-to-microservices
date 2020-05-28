using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using MonoToMicroLegacy.Core.Events;
using MonoToMicroLegacy.Core.Services.Interfaces;
using MonoToMicroLegacy.Models;

namespace MonoToMicroLegacy.Controllers
{
    [RoutePrefix("unicorns")]
    public class UnicornController : ApiController
    {
        private readonly IUnicornService _service;

        public UnicornController(IUnicornService service)
        {
            _service = service;
        }
        
        
        [HttpGet]
        [Route("")]
        public async Task<ICollection<Unicorn>> GetUnicornToBasket()
        {
            ReadUnicornsEvent readUnicornsEvent = new ReadUnicornsEvent();
            UnicornsReadEvent unicornsReadEvent = _service.GetUnicorns(readUnicornsEvent);

            if (unicornsReadEvent.IsReadOk) {
                var unicorns = unicornsReadEvent.Unicorns;
                return await Task.FromResult(unicorns);
            }

            return await Task.FromResult(new List<Unicorn>());
        }
    }
}