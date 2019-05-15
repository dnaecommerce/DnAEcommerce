using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DnAStore.Models
{
    public class Order
    {
        public int ID { get; set; }
        public string UserName { get; set; } // This will be user's email
		public string FirstName { get; set; }
		public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string PhoneNumber { get; set; }
        public decimal Subtotal { get; set; }
        public decimal FinalTotal { get; set; }
        public string TransactionNumber { get; set; }
		//TODO Add in property for order date/time (capture this upon order placement)

        // Nav property
        public List<OrderItem> OrderItems { get; set; }
    }
}
