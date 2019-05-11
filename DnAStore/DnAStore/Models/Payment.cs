using AuthorizeNet.Api.Contracts.V1;
using AuthorizeNet.Api.Controllers.Bases;
using Microsoft.AspNetCore.Identity;
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
		private UserManager<User> _userManager;

		public Payment(IConfiguration configuration, UserManager<User> userManager)
		{
			Configuration = configuration;
			_userManager = userManager;
		}

		public string Run()
		{
			ApiOperationBase<ANetApiRequest, ANetApiResponse>.RunEnvironment = AuthorizeNet.Environment.SANDBOX;

			// Define merchant info
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

			customerAddressType billingAddress = GetAddress();
		}

		customerAddressType GetAddress()
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
	}
}
