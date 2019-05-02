using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DnAStore.Models.Interfaces;

namespace DnAStore.Models.Services
{
	public class BasketService : IBasketManager
	{
		private readonly BasketDBContext _context;

		public BasketService(BasketDBContext context)
		{
			_context = context;
		}

		public Task AddProductToBasket(int id)
		{
			throw new NotImplementedException();
		}
	}
}
