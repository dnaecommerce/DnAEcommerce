using System;
using System.Linq;
using System.Threading.Tasks;
using DnAStore.Data;
using DnAStore.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DnAStore.Models.Services
{
	public class BasketService : IBasketManager
	{
		private readonly ProductDBContext _context;

		public BasketService(ProductDBContext context)
		{
			_context = context;
		}

		public async Task<Basket> FindByUser(string username)
		{
			var result = await _context.Baskets.Where(b => b.UserName == username)
								.Include(b => b.BasketItems)
								.ThenInclude(bi => bi.Product)
								.FirstOrDefaultAsync();
			return result;
		}

		public async Task CreateBasket(Basket basket)
		{
			_context.Add(basket);
			await _context.SaveChangesAsync();
		}

		public async Task UpdateBasket(int basketId, Basket basket, string username)
		{
			if (basketId == basket.ID && basket.UserName == username)
			{
				_context.Update(basket);
				await _context.SaveChangesAsync();
			}
		}

		public bool DeleteBasket(int id)
		{
			var basket = _context.Baskets.FirstOrDefault(b => b.ID == id);
			if (basket != null)
			{
				_context.Remove(basket);
				_context.SaveChanges();
			}
			return true;
		}
	}
}
