using System.Collections.Generic;
using MonoToMicroLambda.Models;

namespace MonoToMicroLambda.Core.Events
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
        
        public UnicornsReadBasketEvent(List<UnicornBasket> baskets, State state)
        {
            this.State = state;
            Baskets = baskets;
        }
    }
}