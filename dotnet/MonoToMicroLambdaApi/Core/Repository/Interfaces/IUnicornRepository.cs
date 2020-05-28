using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MonoToMicroLambda.Models;

namespace MonoToMicroLambda.Core.Repository.Interfaces
{
    public interface IUnicornRepository
    {
	    /**
	 * 
	 * @return
	 */
	    Task<bool> AddUnicornToBasket(string userUuid, string unicornUuid);

        /**
	 * 
	 * @return
	 */
        Task<bool> RemoveUnicornFromBasket(string userUuid, string unicornUuid);

        /**
	 * 
	 * @param userUUID
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