namespace MonoToMicroLambda.Core.Events
{
    public class UnicornsWriteBasketEvent : UpdateEvent
    {
        public UnicornsWriteBasketEvent(State state)
        {
            this.State = state;
        }
    }
}