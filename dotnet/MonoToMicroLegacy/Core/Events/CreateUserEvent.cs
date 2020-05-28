using MonoToMicroLegacy.Models;

namespace MonoToMicroLegacy.Core.Events
{
    public class CreateUserEvent : CreateEvent
    {
        public User User { get; private set; }

        public CreateUserEvent(User user)
        {
            this.User = user;
        }
    }
}