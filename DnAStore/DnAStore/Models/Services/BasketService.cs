using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DnAStore.Data;
using DnAStore.Models.Interfaces;

namespace DnAStore.Models.Services
{
	public class BasketService : IBasketManager
	{
		private readonly ProductDBContext _context;

		public BasketService(ProductDBContext context)
		{
			_context = context;
		}

		public async Task CreateBasket(Basket basket)
		{
			_context.Add(basket);
			await _context.SaveChangesAsync();
		}
		
		//TODO Finish method for adding to basket
		public Task AddProductToBasket(int productID/*, int BasketID */)
		{
			throw new NotImplementedException();
		}

		//TODO UpdateBasket method
		public void UpdateBasket(int id, Basket basket)
		{
			if (id == Basket.ID)
			{
				_context.Update(basket);
				_context.SaveChanges();
			}
		}

		//TODO DeleteBasket method
		public bool DeleteBasket(int id)
		{
			var basket = _context.Baskets.FirstOfDefault(b => b.ID == id);
			if (basket != null)
			{
				_context.Remove(basket);
				_context.SaveChanges();
			}
			return true;
		}
	}
}
