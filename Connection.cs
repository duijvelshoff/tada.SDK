using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;

namespace tada.SDK
{
    public class Connection
    {
        public HttpClient Client { get; }
        public static ISession Session { get; set; }

        public Connection()
        {
            Client = CreateHttpClient();
        }

        private static HttpClient CreateHttpClient()
        {
            string accessToken = (Config.Settings.Principal.Id != null) ? Website.AccessToken() : Console.AccessToken();

            var result = new HttpClient()
            {
                BaseAddress = new Uri(Config.Settings.Resource.Url)
            };
            result.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            return result;
        }

        public static class Console {
            public static string AccessToken()
            {
                var pairs = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("grant_type", "password"),
                    new KeyValuePair<string, string>("resource", Config.Settings.Resource.Id),
                    new KeyValuePair<string, string>("client_id", Config.Settings.Client.Id),
                    new KeyValuePair<string, string>("client_secret", Config.Settings.Client.Secret),
                    new KeyValuePair<string, string>("username", Config.Settings.Principal.UserName),
                    new KeyValuePair<string, string>("password", Config.Settings.Principal.Password)
                };

                var content = new FormUrlEncodedContent(pairs);

                var httpClient = new HttpClient();
                var result = httpClient.PostAsync(Endpoints.Azure.Token, content).Result;
                var accessToken = JObject.Parse(result.Content.ReadAsStringAsync().Result)["access_token"];

                return (string)accessToken;
            }
        }

        public static class Website {
            public static String AccessToken()
            {
                AuthenticationResult result = null;

                AuthenticationContext authContext = new AuthenticationContext(Config.Settings.Azure.Authority, new NaiveSessionCache(Config.Settings.Principal.Id, Connection.Session));

                ClientCredential credential = new ClientCredential(Config.Settings.Client.Id, Config.Settings.Client.Secret);

                result = authContext.AcquireTokenSilentAsync(Config.Settings.Resource.Id, credential, new UserIdentifier(Config.Settings.Principal.Id, UserIdentifierType.UniqueId)).Result;

                return result.AccessToken;
            }
        }
    }
}
