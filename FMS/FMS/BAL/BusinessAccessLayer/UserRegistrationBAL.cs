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
            //ServerError seMessage;
            string serviceMethodName = Constants.Apiurl_Extended + Constants.Apiurl_Extended_userId + "/customer";
            try
            {
                var responseStr = await HttpClientSource<UserRegistrationRequest>.CreateOrUpdateItemWithPostAsync(serviceMethodName, request);

                if (responseStr == null)
                {
                    if (true)
                    {
                        URSR = JsonConvert.DeserializeObject<UserRegistrationSuccessResponse>(responseStr);
                        userRegistrationResp.status = URSR.status;
                        userRegistrationResp.statusCode = URSR.statusCode;
                        userRegistrationResp.statusDescription = URSR.statusDescription;
                        userRegistrationResp.transactionId = URSR.transactionId;
                        userRegistrationResp.messages = null;
                        userRegistrationResp.version = URSR.version;
                    }
                    else
                    {
                        URFR = JsonConvert.DeserializeObject<UserRegistrationFailureResponse>(responseStr);
                        userRegistrationResp.status = URFR.status;
                        userRegistrationResp.statusCode[0] = URFR.statusCode;
                        userRegistrationResp.statusDescription = URFR.statusDescription;
                        userRegistrationResp.transactionId = "";
                        userRegistrationResp.messages = URFR.messages;
                        userRegistrationResp.version = "";
                    }
                }
                else
                {
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
