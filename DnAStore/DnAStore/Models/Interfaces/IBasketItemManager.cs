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

		Task UpdateBasketItem(int id, BasketItem basketItem);

		bool DeleteBasketItem(int id);

		Task<List<BasketItem>> FindAllByBasketId(int basketId);
	}
}
