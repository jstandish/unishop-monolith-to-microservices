using System.Collections.Generic;
using MonoToMicroLambda.Models;

namespace MonoToMicroLambda.Core.Events
{
    public class UnicornsReadEvent : ReadCompleteEvent
    {
        public List<Unicorn> Unicorns { get; set; }
        
        
        public UnicornsReadEvent(State state)
        {
            this.State = state;
        }
        
        public UnicornsReadEvent(List<Unicorn> unicorns)
        {
            Unicorns = unicorns;
        }
        
        public UnicornsReadEvent(List<Unicorn> unicorns, State state)
        {
            this.State = state;
            Unicorns = unicorns;
        }
    }
}