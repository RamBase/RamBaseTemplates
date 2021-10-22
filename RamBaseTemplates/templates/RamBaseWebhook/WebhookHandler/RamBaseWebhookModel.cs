using System;

namespace $safeprojectname$.WebhookHandler
{
	public class RamBaseWebhookModel
	{
		public string SystemID { get; set; }
		public int RamBaseEventId { get; set; }
		public string EventType { get; set; }
		public string Database { get; set; }
		public DateTime RegisterTime { get; set; }
		public int RegisterPid { get; set; }

	}

	public class WebhookParameter
	{
		public string ParameterName { get; set; }
		public string ParameterValue { get; set; }
	}
}
