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
		public string Run(Basket basket)
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
			customerAddressType billingAddress = GetAddress();

			paymentType paymentType = new paymentType { Item = creditCard };

			// Get line items via GetLineItems method defined below
			lineItemType[] lineItems = GetLineItems(basket);

			transactionRequestType transRequestType = new transactionRequestType
			{
				transactionType = transactionTypeEnum.authCaptureTransaction.ToString(),
				amount = basket.Subtotal, //TODO Verify this should be Subtotal rather than FinalTotal
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

		private customerAddressType GetAddress()
		{
			customerAddressType address = new customerAddressType()
			{
				firstName = "", //TODO populate dynamically 
				lastName = "", //TODO populate dynamically
				address = "", //TODO populate dynamically
				city = "", //TODO populate dynamically
				state = "", //TODO populate dynamically
				zip = "" //TODO populate dynamically
			};

			return address;
		}

		/// <summary>
		/// Gets array of line items for order
		/// </summary>
		/// <param name="basket">Basket</param>
		/// <returns>Array of lineItemType</returns>
		private lineItemType[] GetLineItems(Basket basket)
		{
			lineItemType[] items = new lineItemType[basket.BasketItems.Count];

			int count = 0;
			foreach (BasketItem bi in basket.BasketItems)
			{
				items[count] = new lineItemType
				{
					itemId = bi.ID.ToString(),
					name = bi.Product.Name,
					quantity = bi.Quantity,
					unitPrice = bi.Product.Price
				};
				count++;
			}

			return items;
		}
	}
}
