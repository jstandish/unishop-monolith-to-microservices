namespace MonoToMicroLegacy.Core.Events
{
    public class ReadCompleteEvent : EventContext
    {
        public bool EntityFound { get; set; }
        
        public bool IsReadOk
        {
            get { return base.IsStateSuccess; }
        }
    }
}