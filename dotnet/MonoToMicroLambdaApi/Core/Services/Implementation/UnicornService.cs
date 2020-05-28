using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MonoToMicroLambda.Core.Events;
using MonoToMicroLambda.Core.Repository.Interfaces;
using MonoToMicroLambda.Models;

namespace MonoToMicroLambda.Core.Services.Implementation
{
    public class UnicornService : Interfaces.IUnicornService
    {
        private readonly IUnicornRepository _repository;

        public UnicornService(IUnicornRepository repository)
        {
            _repository = repository;
        }

        public async Task<UnicornsWriteBasketEvent> AddUnicornToBasket(WriteUnicornsBasketEvent writeUnicornsBasketEvent)
        {
           
            string userUuid = writeUnicornsBasketEvent.UserUuid;
            string unicornUuid = writeUnicornsBasketEvent.UnicornUuid;
            bool result = await _repository.AddUnicornToBasket(userUuid, unicornUuid);
		
            if (result) {			
                return new UnicornsWriteBasketEvent(State.Success);
            }
            return new UnicornsWriteBasketEvent(State.Failed);
        }

        public async Task<UnicornsWriteBasketEvent> RemoveUnicornFromBasket(WriteUnicornsBasketEvent writeUnicornsBasketEvent)
        {
            
            string userUuid = writeUnicornsBasketEvent.UserUuid;
            string unicornUuid = writeUnicornsBasketEvent.UnicornUuid;
            bool result = await _repository.RemoveUnicornFromBasket(userUuid, unicornUuid);
		
            if (result) {			
                return new UnicornsWriteBasketEvent(State.Success);
            }
            return new UnicornsWriteBasketEvent(State.Failed);
        }

        public async Task<UnicornsReadBasketEvent> GetUnicornBasket(ReadUnicornsBasketEvent readUnicornsBasketEvent)
        {
            string userUUID = readUnicornsBasketEvent.UserUuid;
		
            var unicorns = await _repository.GetUnicornBasket(userUUID);
		
            if (unicorns != null) {			
                return new UnicornsReadBasketEvent(unicorns, State.Success);
            }
            return new UnicornsReadBasketEvent(State.Failed);		
        }

        public UnicornsReadBasketEvent GetAllBaskets()
        {
            List<UnicornBasket> baskets = _repository.GetAllBaskets();

            if (baskets != null)
            {
                UnicornsReadBasketEvent e = new UnicornsReadBasketEvent(State.Success);
                e.Baskets = baskets;
                return e;
            }

            return new UnicornsReadBasketEvent(State.Failed);
        }
    }
}