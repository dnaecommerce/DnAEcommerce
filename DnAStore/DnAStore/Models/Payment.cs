using AuthorizeNet.Api.Contracts.V1;
using AuthorizeNet.Api.Controllers;
using AuthorizeNet.Api.Controllers.Bases;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DnAStore.Models
{
	public class Payment
	{

		public IConfiguration Configuration { get; }

		public Payment(IConfiguration configuration)
		{
			Configuration = configuration;
		}


		//TODO Invoke this method in Receipt action in CheckoutController
		public string Run(Order order)
		{
			ApiOperationBase<ANetApiRequest, ANetApiResponse>.RunEnvironment = AuthorizeNet.Environment.SANDBOX;

			// Define merchant info (authentication / transaction ID
			ApiOperationBase<ANetApiRequest, ANetApiResponse>.MerchantAuthentication = new merchantAuthenticationType()
			{
				name = Configuration["AuthorizeNet_ApiLoginId"],
				ItemElementName = ItemChoiceType.transactionKey,
				Item = Configuration["AuthorizeNet_TransactionKey"]
			};

			creditCardType creditCard = new creditCardType
			{
				cardNumber = Configuration["CreditCardNumber_AmEx"],
				expirationDate = Configuration["ExpirationDate_AmEx"]
			};

			// Get billing address via GetAddress method defined below
			customerAddressType billingAddress = GetAddress(order);

			paymentType paymentType = new paymentType { Item = creditCard };

			// Get line items via GetLineItems method defined below
			lineItemType[] lineItems = GetLineItems(order);

			transactionRequestType transRequestType = new transactionRequestType
			{
				transactionType = transactionTypeEnum.authCaptureTransaction.ToString(),
				amount = order.Subtotal, //TODO Verify this should be Subtotal rather than FinalTotal
				billTo = billingAddress,
				payment = paymentType,
				lineItems = lineItems
			};

			createTransactionRequest request = new createTransactionRequest
			{
				transactionRequest = transRequestType
			};

			// Instantiate controller to call the service
			var controller = new createTransactionController(request);
			controller.Execute();

			// Get response from the service (including errors if any)
			var response = controller.GetApiResponse();

			// Validate response
			if (response != null)
			{
				if (response.messages.resultCode == messageTypeEnum.Ok)
				{
					//TODO Decide what to return if successful
						// Redirect to Receipt page?

					return "OK";
				}
			}

			//TODO Decide what to return if *not* successful
				// Redirect to Page Model?

			return "NOT OK";
		}

		private customerAddressType GetAddress(Order order)
		{
			customerAddressType address = new customerAddressType()
			{
				firstName = order.FirstName,
				lastName = order.LastName,
				address = order.Address,
				city = order.City,
				state = order.State,
				zip = order.PostalCode
			};

			return address;
		}

		/// <summary>
		/// Gets array of line items for order
		/// </summary>
		/// <param name="order">order</param>
		/// <returns>Array of lineItemType</returns>
		private lineItemType[] GetLineItems(Order order)
		{
			lineItemType[] items = new lineItemType[order.OrderItems.Count];

			int count = 0;
			foreach (OrderItem item in order.OrderItems)
			{
				items[count] = new lineItemType
				{
					itemId = item.ID.ToString(),
					name = item.Product.Name,
					quantity = item.Quantity,
					unitPrice = item.Product.Price
				};
				count++;
			}

			return items;
		}
	}
}
