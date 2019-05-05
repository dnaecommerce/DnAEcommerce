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
        public decimal Subtotal { get; set; }
        public decimal FinalTotal { get; set; }

        // Nav property
        public List<OrderItem> OrderItems { get; set; }
    }
}
