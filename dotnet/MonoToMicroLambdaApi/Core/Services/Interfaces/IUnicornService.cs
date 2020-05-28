using System.Threading.Tasks;
using MonoToMicroLambda.Core.Events;

namespace MonoToMicroLambda.Core.Services.Interfaces
{
    public interface IUnicornService
    {
	    

	    /**
	 * 
	 * @param writeUnicornsBasketEvent
	 * @return
	 */
	    Task<UnicornsWriteBasketEvent> AddUnicornToBasket(WriteUnicornsBasketEvent writeUnicornsBasketEvent);
		
	    /**
	 * 
	 * @param writeUnicornsBasketEvent
	 * @return
	 */
	    Task<UnicornsWriteBasketEvent> RemoveUnicornFromBasket(WriteUnicornsBasketEvent writeUnicornsBasketEvent);
	
	    /**
	 * 
	 * @param readUnicornsBasketEvent
	 * @return
	 */
	    Task<UnicornsReadBasketEvent>  GetUnicornBasket(ReadUnicornsBasketEvent readUnicornsBasketEvent);
	
	    /**
	 * 
	 * @param readUnicornsBasketEvent
	 * @return
	 */
	    UnicornsReadBasketEvent GetAllBaskets();	
    }
}