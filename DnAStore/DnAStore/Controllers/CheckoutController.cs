using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnAStore.Models;
using DnAStore.Models.Interfaces;
using DnAStore.Models.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;

namespace DnAStore.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly IOrderManager _orderManager;
        private readonly IOrderItemManager _orderItemManager;
        private readonly IBasketManager _basketManager;
        private readonly IBasketItemManager _basketItemManager;
		private readonly IEmailSender _emailSender;
		private readonly IHostingEnvironment _environment;

        public CheckoutController(IOrderManager orderManager, IOrderItemManager orderItemManager, IBasketManager basketManager, IBasketItemManager basketItemManager, IEmailSender emailSender, IHostingEnvironment environment)
        {
            _orderItemManager = orderItemManager;
            _orderManager = orderManager;
            _basketItemManager = basketItemManager;
            _basketManager = basketManager;
			_emailSender = emailSender;
			_environment = environment;
        }

        [HttpPost]
        public async Task<IActionResult> ShippingDetails(string username)
        {
            //Get user's basket by username
            Basket basket = await _basketManager.FindBasketByUserEager(username);

            // If basket for user doesn't exist yet, create empty one, but don't add it to DB
            if (basket == null)
            {
                RedirectToAction("ViewBasket", "Basket");
            }
            else
            {
                basket.CalcSubtotal();
                await _basketManager.UpdateBasket(basket);
            }
            OrderConfirmation orderConfirmation = new OrderConfirmation { ShippingDetails = new ShippingDetails(), Basket = basket };
            return View(orderConfirmation);
        }

        [HttpPost]
        public async Task<IActionResult> Receipt([Bind(Prefix = "ShippingDetails")]ShippingDetails sdvm)
        {
            //American Express 	370000000000002
            //Discover	6011000000000012
            //Visa	4007000000027
            //Mastercard	5424000000000015
            string[] cardTypes = { "American Express", "Discover", "Visa", "Mastercard" };
            string[] cardNumbers = { "370000000000002", "6011000000000012", "4007000000027", "5424000000000015" };

            var result = await _basketManager.FindBasketByUserEager(sdvm.Username);
            if (result != null)
            {
				// Capture date and time order was placed
				DateTime orderDateTime = DateTime.Now;

				//TODO Use orderDateTime to set date/time property of Order object
					// OR, could capture order date/time inside SendReceiptEmail method
						// NOTE: This latter option for setting date/time property of order would require us to query the DB again

				
				// Creates the order from the Basket information and saves it in the database.
                Order order = new Order
				{
					ID = 0,
					UserName = result.UserName,
					Subtotal = result.Subtotal,
					FinalTotal = result.Subtotal,
					OrderItems = new List<OrderItem>(),
                    Address = sdvm.Address,
                    State = sdvm.State,
                    PostalCode = sdvm.PostalCode,
                    PhoneNumber = sdvm.PhoneNumber
				};
                await _orderManager.CreateOrder(order);

                result.BasketItems.Reverse();
                // Loops through the basket items creating new order items and adding them to the order
                for (int i = result.BasketItems.Count - 1; i > -1; i--)
                {
                    BasketItem bi = result.BasketItems[i];
                    OrderItem orderItem = new OrderItem
					{
						OrderID = order.ID,
						Order = order,
						ID = 0,
						ProductID = bi.ProductID,
						Product = bi.Product,
						Quantity = bi.Quantity
					};

					order.OrderItems.Add(orderItem);
                    await _orderItemManager.CreateOrderItem(orderItem);
                    _basketItemManager.DeleteBasketItem(bi.ID);
                }
                _basketManager.DeleteBasket(result.ID);

                // Don't send receipt email if in dev environment (to avoid excessive emailing)
                if (!_environment.IsDevelopment())
				{
					// Send receipt email
					await SendReceiptEmail(order.UserName, order.ID);
				}

                return View(order);
            }

            return RedirectToAction("Basket", "ViewBasketPage");
        }

		public async Task SendReceiptEmail(string emailAddress, int orderId)
		{
			// Email subject
			string subject = "Your order receipt";

			// Email message body
			StringBuilder sb = new StringBuilder();

			sb.AppendLine("<h1>Thank you for your order!</h1>");
			sb.AppendLine("Here's what you ordered: <ul>");

			var order = await _orderManager.GetOrderByIDEager(orderId);
			foreach (var orderItem in order.OrderItems)
			{
				sb.AppendLine($"<li>{orderItem.Product.Name}: Qty {orderItem.Quantity}, Item Price ${orderItem.Product.Price}</li>");
			}

			sb.AppendLine("</ul>");
			sb.AppendLine($"<strong>Order Total: ${order.FinalTotal}</strong>");
			//sb.AppendLine($"Order date: {/*order.orderDateTime*/}");
			sb.ToString();

			//string htmlMsgContent = "<p> Here's your receipt! </p>";
			string htmlMsgContent = sb.ToString();

			// Send email
			await _emailSender.SendEmailAsync(emailAddress, subject, htmlMsgContent);
		}
	}
}