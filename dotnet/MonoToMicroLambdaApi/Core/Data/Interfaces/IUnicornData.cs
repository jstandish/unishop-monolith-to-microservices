using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MonoToMicroLambda.Core.Data.Models;

namespace MonoToMicroLambda.Core.Data.Interfaces
{
    public interface IUnicornData
    {
      
	    /**
	 * 
	 * @return
	 */
	    List<Unicorn> GetUnicorns();
	
	    /**
	 * 
	 * @param userUuid
	 * @param unicornUuid
	 * @return
	 */
	    Task<bool> AddUnicornToBasket(string userUuid, string unicornUuid);
	
	    /**
	 * 
	 * @param userUuid
	 * @param unicornUuid
	 * @return
	 */
	    Task<bool> RemoveUnicornFromBasket(string userUuid, string unicornUuid);

	    /**
	 * 
	 * @param userUuid
	 * @return
	 */
	    Task<List<UnicornBasket>> GetUnicornBasket(string userUuid);
	
	    /**
	 * 
	 * @return
	 */
	    List<UnicornBasket> GetAllBaskets();
    }
}