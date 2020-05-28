using System.Collections.Generic;
using MonoToMicroLegacy.Models;

namespace MonoToMicroLegacy.Core.Events
{
    public class UnicornsReadBasketEvent : ReadCompleteEvent
    {
        public List<Unicorn> Unicorns { get; set; }
        public List<UnicornBasket> Baskets { get; set; }
        
        
        public UnicornsReadBasketEvent(State state)
        {
            this.State = state;
        }
        
        public UnicornsReadBasketEvent(List<Unicorn> unicorns)
        {
            Unicorns = unicorns;
        }
        
        public UnicornsReadBasketEvent(List<Unicorn> unicorns, State state)
        {
            this.State = state;
            Unicorns = unicorns;
        }
    }
}