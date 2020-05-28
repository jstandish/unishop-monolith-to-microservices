using MonoToMicroLegacy.Core.Data;
using MonoToMicroLegacy.Core.Data.Models;

namespace MonoToMicroLegacy.Core.Data.Interfaces
{
    public interface IUserData
    {
      
	    /**
	 * 
	 * @param user
	 * @return
	 */
	    long Create(UnicornUser user);
	
	    /**
	 * 
	 * @param user
	 * @return
	 */
	    UnicornUser GetByEmail(string email);	
    }
}