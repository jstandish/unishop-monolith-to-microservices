namespace MonoToMicroLambda.Core.Events
{
    public class ReadUnicornsBasketEvent : ReadEvent
    {
        public string UserUuid { get; private set; }

        public ReadUnicornsBasketEvent(string userUuid)
        {
            this.UserUuid = userUuid;
        }
    }
}