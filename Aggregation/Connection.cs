using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;

namespace tada.SDK.Aggregation
{
    public class Connection
    {
        public HttpClient Client { get; }

        public Connection()
        {
            Client = CreateHttpClient();
        }

        private static JObject LoadConfig()
        {
            return JObject.Parse(File.ReadAllText(@"appsettings.json"));
        }

        private static HttpClient CreateHttpClient()
        {
            var config = LoadConfig();
            var accessToken = AccessToken(config);
            var result = new HttpClient()
            {
                BaseAddress = new Uri((string)config["tadaSDK"]["Services"]["Aggregation"]["BaseUrl"])
            };
            result.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            return result;
        }

        private static string AccessToken(JObject config)
        {
            var pairs = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("grant_type", "password"),
                new KeyValuePair<string, string>("resource", (string)config["tadaSDK"]["Services"]["Aggregation"]["AppId"]),
                new KeyValuePair<string, string>("client_id", (string)config["tadaSDK"]["Application"]["ClientId"]),
                new KeyValuePair<string, string>("client_secret", (string)config["tadaSDK"]["Application"]["ClientSecret"]),
                new KeyValuePair<string, string>("username", (string)config["tadaSDK"]["Credentials"]["UserName"]),
                new KeyValuePair<string, string>("password", (string)config["tadaSDK"]["Credentials"]["Password"])
            };

            var content = new FormUrlEncodedContent(pairs);

            var httpClient = new HttpClient();
            var result = httpClient.PostAsync((string)config["AzureAd"]["Instance"] + (string)config["AzureAd"]["Domain"] +"/oauth2/token", content).Result;
            var accessToken = JObject.Parse(result.Content.ReadAsStringAsync().Result)["access_token"];

            return (string)accessToken;
        }
    }
}
