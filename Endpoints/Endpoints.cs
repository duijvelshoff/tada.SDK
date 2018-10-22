using System;
namespace tada.SDK.Endpoints
{
    public class Accounts
    {
        public static string List = "/api/accounts/list";
        public static string Add = "/api/accounts/add";
    }

    public class Azure
    {
        public static string Token = Config.Settings.Azure.Authority + "/oauth2/token";
        public static string Authorization = Config.Settings.Azure.Authority + "/oauth/authorize";
    }

    public class Payment
    {
        public static string Execute = "/api/payment";
    }
}
