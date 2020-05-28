namespace MonoToMicroLambda.Core.Events
{
    public class WriteUnicornsBasketEvent : ReadEvent
    {
        public string UserUuid { get; private set; }
        public string UnicornUuid { get; private set; }
        
        public WriteUnicornsBasketEvent(string userUuid)
        {
            this.UserUuid = userUuid;
        } 
        
        public WriteUnicornsBasketEvent(string userUuid, string unicornUuid)
        {
            this.UserUuid = userUuid;
            UnicornUuid = unicornUuid;
        }
    }
}