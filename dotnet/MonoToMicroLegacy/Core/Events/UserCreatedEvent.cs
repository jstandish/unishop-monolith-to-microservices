using MonoToMicroLegacy.Models;

namespace MonoToMicroLegacy.Core.Events
{
    public class UserCreatedEvent : CreatedEvent
    {
        public User User { get; }

        public UserCreatedEvent(State state)
        {
            State = state;
        }
        
        public UserCreatedEvent(User user, State state)
        {
            User = user;
            State = state;
        }
    }
}