namespace tada.SDK.Endpoints
{
    public class Azure
    {
        public static string Token = Config.Settings.Azure.Authority + "/oauth2/token";
        public static string Authorization = Config.Settings.Azure.Authority + "/oauth/authorize";
    }
}
