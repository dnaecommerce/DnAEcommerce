using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DnAStore.Models
{
    public class OrderItem
    {
        public int ID { get; set; }
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }

        // Navigation properties
        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}
