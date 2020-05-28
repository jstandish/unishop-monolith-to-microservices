using MonoToMicroLegacy.Models;

namespace MonoToMicroLegacy.Core.Repository.Interfaces
{
    public interface IUserRepository
    {
      
	    /**
	 * 
	 * @param user
	 * @return
	 */
	    User Create(User user);
	
	    /**
	 * 
	 * @param user
	 * @return
	 */
	    User GetByEmail(string email);	
    }
}