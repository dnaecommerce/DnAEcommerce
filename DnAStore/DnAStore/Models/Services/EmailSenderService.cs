using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace DnAStore.Models.Services
{
	public class EmailSenderService : IEmailSender
	{
		public IConfiguration Configuration { get; }

		public EmailSenderService(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		/// <summary>
		/// Implements IEmailSender's method to send email
		/// </summary>
		/// <param name="email">email address to send message to</param>
		/// <param name="subject">email subject</param>
		/// <param name="htmlMessage">email message content</param>
		/// <returns>An async task</returns>
		public async Task SendEmailAsync(string email, string subject, string htmlMessage)
		{
			SendGridClient client = new SendGridClient(Configuration["SendGridKey"]);
			SendGridMessage msg = new SendGridMessage();

			msg.SetFrom("noreply-admin@dnastore.com", "NoReply");
			msg.AddTo(email);
			msg.SetSubject(subject);
			msg.AddContent(MimeType.Html, htmlMessage);

			await client.SendEmailAsync(msg);
		}
	}
}
