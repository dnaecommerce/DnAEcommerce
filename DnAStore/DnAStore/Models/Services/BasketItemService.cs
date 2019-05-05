using DnAStore.Data;
using DnAStore.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DnAStore.Models.Services
{
	public class BasketItemService : IBasketItemManager
	{
		private readonly ProductDBContext _context;
		
		public BasketItemService(ProductDBContext context)
		{
			_context = context;
		}


		public async Task CreateBasketItem(BasketItem basketItem)
		{
			_context.Add(basketItem);
			await _context.SaveChangesAsync();
		}

		public async Task<BasketItem> FindBasketItem(int basketId, int productId)
		{
			var result = await _context.BasketItems.FirstOrDefaultAsync(bi => (bi.BasketID == basketId && bi.ProductID == productId));
			return result;
		}

		public async Task<BasketItem> FindBasketItem(int basketItemId)
		{
			var result = await _context.BasketItems.FirstOrDefaultAsync(bi => bi.ID == basketItemId);
			return result;
		}

		public async Task<List<BasketItem>> FindAllByBasketId(int basketId)
		{
			var result = await _context.BasketItems.Where(bi => bi.BasketID == basketId).ToListAsync();
			return result;
		}

		public async Task UpdateBasketItem(BasketItem basketItem)
		{
			if (basketItem != null)
			{
				_context.Update(basketItem);
				await _context.SaveChangesAsync();
			}
		}

		public bool DeleteBasketItem(int basketItemId)
		{
			var basketItem = _context.BasketItems.FirstOrDefault(bi => bi.ID == basketItemId);
			if (basketItem != null)
			{
				_context.Remove(basketItem);
				_context.SaveChanges();
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}
