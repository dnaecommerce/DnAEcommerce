using DnAStore.Data;
using DnAStore.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DnAStore.Models.Services
{
    public class OrderItemService : IOrderItemManager
    {

        private ProductDBContext _context;

        public OrderItemService (ProductDBContext context)
        {
            _context = context;
        }

        public async Task CreateOrderItem(OrderItem orderItem)
        {
            _context.Add(orderItem);
            await _context.SaveChangesAsync();
        }
    }
}
