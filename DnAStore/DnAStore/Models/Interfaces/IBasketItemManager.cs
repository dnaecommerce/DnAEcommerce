using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DnAStore.Models.Interfaces
{
	public interface IBasketItemManager
	{
		Task CreateBasketItem(BasketItem basketItem);

		Task<BasketItem> FindBasketItem(int basketId, int productId);

		Task<BasketItem> FindBasketItem(int basketItemId);

		Task UpdateBasketItem(BasketItem basketItem);

		bool DeleteBasketItem(int basketItemId);

		Task<List<BasketItem>> FindAllByBasketId(int basketId);
	}
}
