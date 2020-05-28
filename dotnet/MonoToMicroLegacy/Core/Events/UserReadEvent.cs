using MonoToMicroLegacy.Models;

namespace MonoToMicroLegacy.Core.Events
{
    public class UserReadEvent : ReadEvent
    {
        public User User { get; }

        public UserReadEvent(User user, State state)
        {
            User = user;
            State = state;
        } 
        
        public UserReadEvent(State state)
        {
            State = state;
        }
    }
}