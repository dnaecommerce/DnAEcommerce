﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DnAStore.Models.Interfaces
{
    public interface IOrderManager
    {
        Task CreateOrder(Order order);

        Task<Order> GetOrderByIDEager(int id);

        Task<Order> GetOrderByIDLazy(int id);

		List<Order> GetAllOrders();

		Task<List<Order>> GetAllUserOrdersEager(string username);

        Task<List<Order>> GetUserLastFiveEager(string username);

        Task UpdateOrder(Order order);
    }
}
