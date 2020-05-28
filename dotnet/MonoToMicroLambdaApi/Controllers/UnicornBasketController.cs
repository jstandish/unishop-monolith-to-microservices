using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MonoToMicroLambda.Core.Events;
using MonoToMicroLambda.Core.Services.Interfaces;
using MonoToMicroLambda.Models;
using UnicornBasket = MonoToMicroLambda.Core.Data.Models.UnicornBasket;


namespace MonoToMicroLambdaApi.Controllers
{
    [Route("")]
    public class UnicornBasketService : ControllerBase
    {
        private readonly IUnicornService _service;


        public UnicornBasketService(IUnicornService service)
        {
            _service = service;
        }
        
        [HttpPost("")]
        public async Task<HttpResponseMessage>  AddUnicornToBasket(UnicornBasket request)
        {
            if(request != null) {
			
                var userUuid = request.Uuid;		
                //Assuming only one Unicorn is added each time
                var unicornUuid = request.Uuid;		
			
                var writeUnicornsBasketEvent = new WriteUnicornsBasketEvent(userUuid, unicornUuid);
                var unicornsWriteBasketEvent = await _service.AddUnicornToBasket(writeUnicornsBasketEvent);

                if (unicornsWriteBasketEvent.IsStateSuccess)
                {
                    return await Task.FromResult(
                        new HttpResponseMessage()
                        {
                            StatusCode = HttpStatusCode.OK
                        }
                    );    
                }
            }
            
            return await Task.FromResult(
                new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.BadRequest
                }
            );
        }
              
        [HttpDelete("")]
        public async Task<HttpResponseMessage> RemoveFromBasket(UnicornBasket request)
        {
            if(request != null) {
			
                var userUuid = request.Uuid;		
                //Assuming only one Unicorn is added each time
                var unicornUuid = request.Uuid;
		
                var writeUnicornsBasketEvent = new WriteUnicornsBasketEvent(userUuid, unicornUuid);
                var unicornsWriteBasketEvent = await _service.RemoveUnicornFromBasket(writeUnicornsBasketEvent);

                if (unicornsWriteBasketEvent.IsStateSuccess) {		
                    return await Task.FromResult(
                        new HttpResponseMessage()
                        {
                            StatusCode = HttpStatusCode.OK
                        }
                    );   
                }
            }
            
            return await Task.FromResult(
                new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.BadRequest
                }
            );    
        }
        
        [HttpGet("{userUuid}")]
        public async Task<UnicornBasketGet> GetUnicornBasket(string userUuid) //GetUnicornBasket(string userUuid)
        {
            //var userUuid = "2";
            var readUnicornsBasketEvent = new ReadUnicornsBasketEvent(userUuid);
            var unicornsReadBasketEvent = await _service.GetUnicornBasket(readUnicornsBasketEvent);

            if (unicornsReadBasketEvent.IsReadOk) {
                var unicorns = unicornsReadBasketEvent.Unicorns;
                var unicornBasket = new UnicornBasketGet();
                unicornBasket.Uuid = userUuid;
                
                unicornBasket.Unicorns = unicornsReadBasketEvent.Baskets.SelectMany(
                    p => p.Unicorns.Select( u => new Unicorn
                        {
                            Uuid = u
                        }
                    )
                ).ToList();
                
                return await Task.FromResult(unicornBasket);
            }
            
            return await Task.FromResult<UnicornBasketGet>(null);
        }
    }

  
}