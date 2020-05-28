namespace MonoToMicroLambda.Core.Events
{
    public class CreatedEvent : EventContext
    {
        public bool IsCreated
        {
            get { return base.IsStateSuccess; }
        }
    }
}