using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DnAStore.Models
{
	public class BasketItem
	{
		public int ID { get; set; }
		public int BasketID { get; set; }
		public int ProductID { get; set; }
		public int Quantity { get; set; }

		// Navigation properties
		public Basket Basket { get; set; }
		public Product Product { get; set; }
	}
}
