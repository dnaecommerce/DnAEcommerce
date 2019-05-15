using DnAStore.Data;
using DnAStore.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DnAStore.Models.Services
{
    public class OrderService : IOrderManager
    {
        private ProductDBContext _context;

        public OrderService (ProductDBContext context)
        {
            _context = context;
        }

        public async Task CreateOrder(Order order)
        {
            _context.Add(order);
            await _context.SaveChangesAsync();
        }

        public async Task<Order> GetOrderByIDEager(int id)
        {
            return await _context.Orders.Where(order => order.ID == id)
											  .Include(order => order.OrderItems)
											  .ThenInclude(orderItem => orderItem.Product)
											  .FirstOrDefaultAsync();
        }

        public async Task<Order> GetOrderByIDLazy(int id)
        {
            return await _context.Orders.Where(order => order.ID == id)
											  .FirstOrDefaultAsync();
        }

		public List<Order> GetAllOrders()
		{
			return _context.Orders.ToList();
		}

        public async Task<List<Order>> GetAllUserOrdersEager(string username)
        {
            return await _context.Orders.Where(order => order.UserName == username)
											  .Include(order => order.OrderItems)
											  .ThenInclude(orderItem => orderItem.Product)
											  .ToListAsync();
        }

        public async Task UpdateOrder(Order order)
        {
            _context.Update(order);
            await _context.SaveChangesAsync();
        }
    }
}
