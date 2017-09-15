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
            UserRegistrationFailureResponse uRegFailResp;
            UserRegistrationSuccessResponse uRegSuccessResp;
            //ServerError seMessage;
            string serviceMethodName = Constants.apiurlExtended + Constants.apiurlExtendedUserId + "/customer";
            try
            {
                var responseStr = await HttpClientSource<UserRegistrationRequest>.CreateOrUpdateItemWithPostAsync(serviceMethodName, request);

                if (responseStr != null)
                {
                    string strSuccess = "\"statusCode\":[\"201\"]";
                    if (responseStr.Contains(strSuccess))
                    {
                        uRegSuccessResp = JsonConvert.DeserializeObject<UserRegistrationSuccessResponse>(responseStr);
                        userRegistrationResp.status = uRegSuccessResp.status;
                        userRegistrationResp.statusCode = uRegSuccessResp.statusCode;
                        userRegistrationResp.statusDescription = uRegSuccessResp.statusDescription;
                        userRegistrationResp.transactionId = uRegSuccessResp.transactionId;
                        userRegistrationResp.messages = null;
                        userRegistrationResp.version = uRegSuccessResp.version;
                    }
                    else
                    {
                        uRegFailResp = JsonConvert.DeserializeObject<UserRegistrationFailureResponse>(responseStr);
                        userRegistrationResp.status = uRegFailResp.status;
                        //userRegistrationResp.statusCode = URFR.statusCode;
                        userRegistrationResp.statusDescription = uRegFailResp.statusDescription;
                        userRegistrationResp.transactionId = "";
                        userRegistrationResp.messages = uRegFailResp.messages;
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
