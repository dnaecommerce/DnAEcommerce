using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DnAStore.Models;
using DnAStore.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DnAStore.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly IOrderManager _orderManager;
        private readonly IOrderItemManager _orderItemManager;
        private readonly IBasketManager _basketManager;
        private readonly IBasketItemManager _basketItemManager;

        public CheckoutController(IOrderManager orderManager, IOrderItemManager orderItemManager, IBasketManager basketManager, IBasketItemManager basketItemManager)
        {
            _orderItemManager = orderItemManager;
            _orderManager = orderManager;
            _basketItemManager = basketItemManager;
            _basketManager = basketManager;
        }

        [HttpPost]
        public async Task<IActionResult> Receipt(string username)
        {
            var result = await _basketManager.FindBasketByUserEager(username);
            if (result != null)
            {

                // Creates the order from the Basket information and saves it in the database.
                Order order = new Order { ID = 0, UserName = result.UserName, Subtotal = result.Subtotal, FinalTotal = result.Subtotal, OrderItems = new List<OrderItem>() };
                await _orderManager.CreateOrder(order);

                // Loops through the basket items creating new order items and adding them to the order
                foreach (var bi in result.BasketItems)
                {
                    OrderItem orderItem = new OrderItem { OrderID = order.ID, Order = order, ID = 0, ProductID = bi.ProductID, Product = bi.Product, Quantity = bi.Quantity };
                    order.OrderItems.Add(orderItem);
                    await _orderItemManager.CreateOrderItem(orderItem);
                    _basketItemManager.DeleteBasketItem(bi.ID);
                }

                _basketManager.DeleteBasket(result.ID);

                return View(order);
            }

            return RedirectToAction("Basket", "ViewBasketPage");
        }

    }
}