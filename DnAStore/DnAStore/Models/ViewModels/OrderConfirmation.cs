using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DnAStore.Models.ViewModels
{
    public class OrderConfirmation
    {
        public ShippingDetails ShippingDetails { get; set; }
        public Basket Basket { get; set; }
		public bool TransactionFailure { get; set; }
    }
}
