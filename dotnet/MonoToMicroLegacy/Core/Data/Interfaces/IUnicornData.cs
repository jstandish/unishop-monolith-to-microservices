using System;
using System.Collections.Generic;
using MonoToMicroLegacy.Core.Data.Models;

namespace MonoToMicroLegacy.Core.Data.Interfaces
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
	    bool AddUnicornToBasket(string userUuid, string unicornUuid);
	
	    /**
	 * 
	 * @param userUuid
	 * @param unicornUuid
	 * @return
	 */
	    bool RemoveUnicornFromBasket(string userUuid, string unicornUuid);
		
	    /**
	 * 
	 * @param userUuid
	 * @return
	 */
	    List<Unicorn> GetUnicornBasket(string userUuid);
	
	    /**
	 * 
	 * @return
	 */
	    List<UnicornBasket> GetAllBaskets();
    }
}