using System;
using System.Collections.Generic;
using MonoToMicroLegacy.Models;

namespace MonoToMicroLegacy.Core.Repository.Interfaces
{
    public interface IUnicornRepository
    {
        /**
	 * 
	 * @return
	 */
        List<Unicorn> GetUnicorns();

        /**
	 * 
	 * @return
	 */
        bool AddUnicornToBasket(string userUuid, string unicornUuid);

        /**
	 * 
	 * @return
	 */
        bool RemoveUnicornFromBasket(string userUuid, string unicornUuid);

        /**
	 * 
	 * @param userUUID
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