using System;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FMS
{
	public class UserRegistrationBAL : IUserRegistrationBAL
	{
		public UserRegistrationBAL()
		{
		}

		#region for accessing user registration method from database
		public async Task<UserRegistration> UserRegistration(UserRegistrationRequest request)
		{
			UserRegistration userRegistrationResp = new UserRegistration();
			UserRegistrationFailureResponse URFR;
			UserRegistrationSuccessResponse URSR;
			try
			{
				var responseStr = await HttpClientSource<UserRegistrationRequest>.CreateOrUpdateItemWithPostAsync("archive-reminders-list.php", request);
				if (responseStr.IndexOf('f') == 1)
				{
					responseStr.Remove(0, 1);
					URFR = JsonConvert.DeserializeObject<UserRegistrationFailureResponse>(responseStr);
					userRegistrationResp.status = URFR.status;
					userRegistrationResp.statusCode[0] = URFR.statusCode;
					userRegistrationResp.statusDescription = URFR.statusDescription;
					userRegistrationResp.transactionId = "";
					userRegistrationResp.messages = URFR.messages;
					userRegistrationResp.version = "";
				}
				else
				{
					URSR = JsonConvert.DeserializeObject<UserRegistrationSuccessResponse>(responseStr);
					userRegistrationResp.status = URSR.status;
					userRegistrationResp.statusCode = URSR.statusCode;
					userRegistrationResp.statusDescription = URSR.statusDescription;
					userRegistrationResp.transactionId = URSR.transactionId;
					userRegistrationResp.messages =null;
					userRegistrationResp.version = URSR.version;
				}
			}
			catch (Exception ex)
			{
				var msg = ex.Message;
				userRegistrationResp = null;
			}
			return userRegistrationResp;
		}
		#endregion

		#region IDisposable Support
		private bool disposedValue = false;
		protected virtual void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				if (disposing)
				{
				}
				disposedValue = true;
			}
		}
		public void Dispose()
		{
			Dispose(true);
		}
		#endregion
	}
}
