using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using static $safeprojectname$.WebhookHandler.HMACUtil;

namespace $safeprojectname$.WebhookHandler
{
	[ApiController, Route("webhook")]
	public class RamBaseWebhookHandler : ControllerBase
	{
		private readonly ILogger<RamBaseWebhookHandler> _logger;
		private readonly IConfiguration _configuration;

		public RamBaseWebhookHandler(ILogger<RamBaseWebhookHandler> logger, IConfiguration configuration)
		{
			_logger = logger;
			_configuration = configuration;
		}

		[HttpPost("")]
		public async Task<IActionResult> Handle()
		{
			RamBaseWebhookModel webhook;

			using (var reader = new StreamReader(Request.Body))
			{
				var body = await reader.ReadToEndAsync();

				if (!ValidateSignature(body))
				{
					_logger.LogWarning("Webhook received with invalid signature");
					return Ok(); //Return 200 OK even though signature did not match, if not RamBase will try to send it again
				}

				webhook = JsonSerializer.Deserialize<RamBaseWebhookModel>(body);
			}

			//Do something with the webhook
			_logger.LogInformation("Received webhook for {event} from system {system}", webhook.EventType, webhook.SystemID);

			return Ok();
		}

		private bool ValidateSignature(string body)
		{
			if (!Request.Headers.TryGetValue("x-rambase-signature", out var signature))
				return false; //No signature found

			var s = GenerateHMACToken(HmacAlgorithm.SHA512, _configuration["HMACToken"], body);

			return s == signature;
		}
	}
}
