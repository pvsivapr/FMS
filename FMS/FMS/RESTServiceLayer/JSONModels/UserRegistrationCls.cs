using System;
using System.Collections.Generic;

namespace FMS
{
	public class UserRegistrationCls
	{
		public UserRegistrationCls()
		{
		}
	}

	#region for user registration request class
	public class UserProfile
	{
		public string application { get; set; }
		public string givenName { get; set; }
		public string sn { get; set; }
		public string mail { get; set; }
		public string telephoneNumber { get; set; }
		public string mobile { get; set; }
		public string homePhoneNumber { get; set; }
		public string Company_entered_byUser { get; set; }
		public string Company_Zip { get; set; }
		public string Fuel_Preference { get; set; }
		public List<string> Communication_Preference { get; set; }
		public string Receive_Ryder_Communication { get; set; }
		public string employeeNumber { get; set; }
		public string password { get; set; }
		public string confirmPassword { get; set; }
		public string forcePasswordReset { get; set; }
	}

	public class Entitlements
	{
		public string MobFleetApp { get; set; }
		public List<string> lessee { get; set; }
		public List<string> FIS_Rental { get; set; }
		public List<string> Mobile_Fleet_Role { get; set; }
	}

	public class UserRegistrationRequest
	{
		public UserProfile UserProfile { get; set; }
		public Entitlements Entitlements { get; set; }
	}
	#endregion

	#region for user registration failure response class
	public class UserRegistrationFailureResponse
	{
		public string status { get; set; }
		public string statusCode { get; set; }
		public string statusDescription { get; set; }
		public List<string> messages { get; set; }
	}

	#endregion

	#region for user registration success response class
	public class UserRegistrationSuccessResponse
	{
		public string version { get; set; }
		public string status { get; set; }
		public List<string> statusCode { get; set; }
		public string statusDescription { get; set; }
		public string transactionId { get; set; }
	}
	#endregion
}
