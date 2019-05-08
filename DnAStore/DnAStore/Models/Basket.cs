using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DnAStore.Models
{
	public class Basket
	{
		public int ID { get; set; }
		public string UserName { get; set; } // This will be user's email
		public decimal Subtotal { get; set; }

		// Nav property
		public List<BasketItem> BasketItems { get; set; }

        public void CalcSubtotal()
        {
            Subtotal = 0;
            foreach (var item in BasketItems)
            {
                Subtotal += (item.Product.Price * item.Quantity);
            }
        }
	}
}
