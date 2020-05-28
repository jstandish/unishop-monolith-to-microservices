using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using MonoToMicroLegacy.Core.Events;
using MonoToMicroLegacy.Core.Services.Interfaces;
using MonoToMicroLegacy.Models;

namespace MonoToMicroLegacy.Controllers
{
    [RoutePrefix("unicorns/basket")]
    public class BasketController : ApiController
    {
        private readonly IUnicornService _service;

        public BasketController(IUnicornService service)
        {
            _service = service;
        }
        
        [HttpPost]        
        [Route("")]
        public async Task<HttpResponseMessage>  AddUnicornToBasket(UnicornBasket request)
        {
            if(request?.Unicorns?.Count > 0) {
			
                var userUuid = request.Uuid;		
                //Assuming only one Unicorn is added each time
                var unicornUuid = request.Unicorns.First().Uuid;		
			
                var writeUnicornsBasketEvent = new WriteUnicornsBasketEvent(userUuid, unicornUuid);
                var unicornsWriteBasketEvent = _service.AddUnicornToBasket(writeUnicornsBasketEvent);

                if (unicornsWriteBasketEvent.IsStateSuccess) {
				
                    return await Task.FromResult(this.Request.CreateResponse(HttpStatusCode.OK));    
                }
            }
            return await Task.FromResult(this.Request.CreateResponse(HttpStatusCode.BadRequest));    
        }
        
        [HttpDelete]        
        [Route("")]
        public async Task<HttpResponseMessage> RemoveFromBasket(UnicornBasket request)
        {
            if(request?.Unicorns?.Count > 0) {
			
                var userUuid = request.Uuid;		
                //Assuming only one Unicorn is added each time
                var unicornUuid = request.Unicorns.First().Uuid;
		
                var writeUnicornsBasketEvent = new WriteUnicornsBasketEvent(userUuid, unicornUuid);
                var unicornsWriteBasketEvent = _service.RemoveUnicornFromBasket(writeUnicornsBasketEvent);

                if (unicornsWriteBasketEvent.IsStateSuccess) {		
                    return await Task.FromResult(this.Request.CreateResponse(HttpStatusCode.OK));    
                }
            }
            return await Task.FromResult(this.Request.CreateResponse(HttpStatusCode.BadRequest));    
        }
        
        [HttpGet]
        [Route("{userUuid}")]
        public async Task<UnicornBasketGet> GetUnicornBasket(string userUuid)
        {
            var readUnicornsBasketEvent = new ReadUnicornsBasketEvent(userUuid);
            var unicornsReadBasketEvent = _service.GetUnicornBasket(readUnicornsBasketEvent);

            if (unicornsReadBasketEvent.IsReadOk) {
                List<Unicorn> unicorns = unicornsReadBasketEvent.Unicorns;
                UnicornBasketGet unicornBasket = new UnicornBasketGet();
                unicornBasket.Uuid = userUuid;
                unicornBasket.Unicorns = unicorns;
                return await Task.FromResult(unicornBasket);
            }
            return await Task.FromResult<UnicornBasketGet>(null);
        }
    }
}