using MonoToMicroLegacy.Core.Events;

namespace MonoToMicroLegacy.Core.Services.Interfaces
{
    public interface IUnicornService
    {
	    
	    /**
	 * 
	 * @param readItemSetEvent
	 * @return
	 */
	    UnicornsReadEvent GetUnicorns(ReadUnicornsEvent readUnicornsEvent);

	    /**
	 * 
	 * @param writeUnicornsBasketEvent
	 * @return
	 */
	    UnicornsWriteBasketEvent AddUnicornToBasket(WriteUnicornsBasketEvent writeUnicornsBasketEvent);
		
	    /**
	 * 
	 * @param writeUnicornsBasketEvent
	 * @return
	 */
	    UnicornsWriteBasketEvent RemoveUnicornFromBasket(WriteUnicornsBasketEvent writeUnicornsBasketEvent);
	
	    /**
	 * 
	 * @param readUnicornsBasketEvent
	 * @return
	 */
	    UnicornsReadBasketEvent GetUnicornBasket(ReadUnicornsBasketEvent readUnicornsBasketEvent);
	
	    /**
	 * 
	 * @param readUnicornsBasketEvent
	 * @return
	 */
	    UnicornsReadBasketEvent GetAllBaskets();	
    }
}