using System;

#region Created by Sivaprasad

namespace FMS
{//URI: SSO HOST /iam/im/pub/rws/users/{userId}/customer
    public static class Constants
    {
        // FMS DEVELOPMENT CREDENTIALS
        public const string ApplicationID = "";
        public const string ApiKey = "";
        public const string Apiurl = "https://st.idm.ryder.com/";
        public const string Apiurl_Extended = "iam/im/pub/rws/users/";
        public const string MasterKey = "";


        public const string ServerSecretCode = "";
        public static string ServerSecurityCode;
        public static bool IsNotified;
        public static string rem_Ids;
        //public static IDatabaseMethods dbmethods;

        //Used in Installation for push notification.
        public const string AppIdentifier = "com.fleet.ryder";
        public const string AppName = "RyderFleet";
        public const string AppVersion = "1";
        public const string ParseVersion = "1.6.2.0";
        public const string GCMSenderId = "558839287361";


        //SportzBee PrivacyPolicy URL.
        public const string PrivacyPolicyURL = "";

        //Error Message to show.
        public const string ReportErrorMessage = "Sorry for error, please contact us incase this error repeats";

        //public static Constants()
        //{
        //  //dbmethods = new DatabaseMethods();
        //}
    }
}

#endregion