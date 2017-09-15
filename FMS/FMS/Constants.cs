using System;

#region Created by Sivaprasad

namespace FMS
{//URI: SSO HOST /iam/im/pub/rws/users/{userId}/customer
    public static class Constants
    {
        // FMS DEVELOPMENT CREDENTIALS
        public const string applicationID = "";
        public const string apiKey = "";
        public const string apiurl = "https://st.idm.ryder.com/";
        public const string apiurlExtended = "iam/im/pub/rws/users/";
        public static string apiurlExtendedUserId = "";
        public const string masterKey = "";


        public const string serverSecretCode = "";
        public static string serverSecurityCode;
        public static bool isNotified;
        public static string remIds;

        //Used in Installation for push notification.
        public const string appIdentifier = "com.fleet.ryder";
        public const string appName = "RyderFleet";
        public const string appVersion = "1";
        public const string parseVersion = "1.6.2.0";
        public const string gcmSenderId = "558839287361";


        //SportzBee PrivacyPolicy URL.
        public const string privacyPolicyURL = "";

        //Error Message to show.
        public const string reportErrorMessage = "Sorry for error, please contact us incase this error repeats";

        //public static Constants()
        //{
        //  //dbmethods = new DatabaseMethods();
        //}
    }
}

#endregion