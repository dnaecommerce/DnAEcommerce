using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DnAStore.Models.Interfaces
{
	public interface IBasketManager
	{
		//TODO Add method that gets product by ID from Products DB and adds that product to a Baskets DB? OR better, just add product ID as foreign key to Baskets DB


		Task AddProductToBasket(int id); // Consider what other param(s) need to be included in addition to ID
	}
}
