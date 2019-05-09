using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DnAStore.Models.Interfaces
{
    public interface IOrderItemManager
    {
        Task CreateOrderItem(OrderItem orderItem);
    }
}
