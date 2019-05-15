using AuthorizeNet.Api.Contracts.V1;
using AuthorizeNet.Api.Controllers;
using AuthorizeNet.Api.Controllers.Bases;
using DnAStore.Models.ViewModels;
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
		public transactionResponse Run(Basket basket, ShippingDetails sdvm)
		{
			ApiOperationBase<ANetApiRequest, ANetApiResponse>.RunEnvironment = AuthorizeNet.Environment.SANDBOX;

			string[] cardTypes = { "AmEx", "Discover", "Visa", "Mastercard" };

			// Define merchant info (authentication / transaction ID
			ApiOperationBase<ANetApiRequest, ANetApiResponse>.MerchantAuthentication = new merchantAuthenticationType()
			{
				name = Configuration["AuthorizeNet_ApiLoginId"],
				ItemElementName = ItemChoiceType.transactionKey,
				Item = Configuration["AuthorizeNet_TransactionKey"]
			};

			creditCardType creditCard = new creditCardType
			{
				cardNumber = Configuration[$"CreditCardNumber_{cardTypes[sdvm.Card]}"],
				expirationDate = Configuration[$"ExpirationDate_{cardTypes[sdvm.Card]}"]
			};

			// Get billing address via GetAddress method defined below
			customerAddressType billingAddress = GetAddress(sdvm);

			paymentType paymentType = new paymentType { Item = creditCard };

			// Get line items via GetLineItems method defined below
			lineItemType[] lineItems = GetLineItems(basket);

			transactionRequestType transRequestType = new transactionRequestType
			{
				transactionType = transactionTypeEnum.authCaptureTransaction.ToString(),
				amount = basket.Subtotal,
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
					return response.transactionResponse;
				}
			}

			// If response *not* successful
			return null;
		}

		/// <summary>
		/// Captures address details from Order model
		/// </summary>
		/// <param name="order">order</param>
		/// <returns>customer address</returns>
		private customerAddressType GetAddress(ShippingDetails sdvm)
		{
			customerAddressType address = new customerAddressType()
			{
				firstName = sdvm.FirstName,
				lastName = sdvm.LastName,
				address = sdvm.Address,
				city = sdvm.City,
				state = sdvm.State,
				zip = sdvm.PostalCode
			};

			return address;
		}

		/// <summary>
		/// Gets array of line items for order
		/// </summary>
		/// <param name="order">order</param>
		/// <returns>Array of lineItemType</returns>
		private lineItemType[] GetLineItems(Basket basket)
		{
			lineItemType[] items = new lineItemType[basket.BasketItems.Count];

			int count = 0;
			foreach (BasketItem item in basket.BasketItems)
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
