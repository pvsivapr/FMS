using System;
using System.Collections.Generic;

namespace FMS
{
	public class UserRegistration
	{
		public string version { get; set; }
		public List<string> messages { get; set; }
		public string status { get; set; }
		public List<string> statusCode { get; set; }
		public string statusDescription { get; set; }
		public string transactionId { get; set; }
	}
}
