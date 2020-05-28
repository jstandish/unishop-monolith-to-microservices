using MonoToMicroLegacy.Core.Events;

namespace MonoToMicroLegacy.Core.Services.Interfaces
{
    public interface IUserService
    {
        /**
	 * 
	 * @param createUserEvent
	 * @return
	 */
        UserCreatedEvent Create(CreateUserEvent createUserEvent);
	
        /**
	 * 
	 * @param readUserEvent
	 * @return
	 */
        UserReadEvent GetByEmail(ReadUserEvent readUserEvent);
    }
}