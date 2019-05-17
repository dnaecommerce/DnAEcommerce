using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DnAStore.Models.Interfaces
{
	public interface IBasketManager
	{
		Task CreateBasket(Basket basket);

		Task UpdateBasket(Basket basket);

		bool DeleteBasket(int id);

		Task<Basket> FindBasketByUserLazy(string username);

		Task<Basket> FindBasketByUserEager(string username);
	}
}
