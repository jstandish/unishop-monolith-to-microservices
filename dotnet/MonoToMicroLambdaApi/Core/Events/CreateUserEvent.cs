using MonoToMicroLambda.Models;

namespace MonoToMicroLambda.Core.Events
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