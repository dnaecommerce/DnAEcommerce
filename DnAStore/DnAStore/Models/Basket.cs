using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DnAStore.Models
{
	public class Basket
	{
		public int ID { get; set; }
		public int UserID { get; set; }
		public decimal Subtotal { get; set; }

		// Nav property
		public List<BasketItem> BasketItems { get; set; }
	}
}
