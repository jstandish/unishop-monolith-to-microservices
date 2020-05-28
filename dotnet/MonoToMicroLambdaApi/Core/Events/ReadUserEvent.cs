using MonoToMicroLambda.Models;

namespace MonoToMicroLambda.Core.Events
{
    public class ReadUserEvent : ReadEvent
    {
        public User User { get; private set; }

        public ReadUserEvent(User user)
        {
            this.User = user;
        }
    }
}