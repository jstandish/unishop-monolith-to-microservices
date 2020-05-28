using System;
using System.Collections.Generic;
using MonoToMicroLegacy.Core.Events;
using MonoToMicroLegacy.Core.Repository.Interfaces;
using MonoToMicroLegacy.Models;

namespace MonoToMicroLegacy.Core.Services.Implementation
{
    public class UnicornService : Interfaces.IUnicornService
    {
        private readonly IUnicornRepository _repository;

        public UnicornService(IUnicornRepository repository)
        {
            _repository = repository;
        }

        public UnicornsReadEvent GetUnicorns(ReadUnicornsEvent readUnicornsEvent)
        {
            List<Unicorn> unicorns = _repository.GetUnicorns();
			
            if (unicorns != null) {
                UnicornsReadEvent unicornsEvent = new UnicornsReadEvent(unicorns, State.Success);
                return unicornsEvent;
            }
            return new UnicornsReadEvent(State.Failed);	
        }

        public UnicornsWriteBasketEvent AddUnicornToBasket(WriteUnicornsBasketEvent writeUnicornsBasketEvent)
        {
           
            string userUuid = writeUnicornsBasketEvent.UserUuid;
            string unicornUuid = writeUnicornsBasketEvent.UnicornUuid;
            bool result = _repository.AddUnicornToBasket(userUuid, unicornUuid);
		
            if (result) {			
                return new UnicornsWriteBasketEvent(State.Success);
            }
            return new UnicornsWriteBasketEvent(State.Failed);
        }

        public UnicornsWriteBasketEvent RemoveUnicornFromBasket(WriteUnicornsBasketEvent writeUnicornsBasketEvent)
        {
            
            string userUuid = writeUnicornsBasketEvent.UserUuid;
            string unicornUuid = writeUnicornsBasketEvent.UnicornUuid;
            bool result = _repository.RemoveUnicornFromBasket(userUuid, unicornUuid);
		
            if (result) {			
                return new UnicornsWriteBasketEvent(State.Success);
            }
            return new UnicornsWriteBasketEvent(State.Failed);
        }

        public UnicornsReadBasketEvent GetUnicornBasket(ReadUnicornsBasketEvent readUnicornsBasketEvent)
        {
            string userUUID = readUnicornsBasketEvent.UserUuid;
		
            List<Unicorn> unicorns = _repository.GetUnicornBasket(userUUID);
		
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