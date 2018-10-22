using System;
using System.IO;
using Newtonsoft.Json.Linq;
using tada.SDK.Objects;

namespace tada.SDK
{
    public class Config
    {
        public Resource Resource { get; set; }
        public Client Client { get; set; }
        public Principal Principal { get; set; }
        public Azure Azure { get; set;  }

        public static Config Settings = Initialize();

        private static Config Initialize() {

            var config = JObject.Parse(File.ReadAllText(@"appsettings.json"));

            var result = new Config
            {
                Resource = new Resource
                {
                    Id = (string)config["tadaSDK"]["Services"]["Aggregation"]["AppId"],
                    Url = (string)config["tadaSDK"]["Services"]["Aggregation"]["BaseUrl"]
                },
                Azure = new Azure
                {
                    Domain = (string)config["AzureAd"]["Domain"],
                    TenantId = (string)config["AzureAd"]["TenantId"]
                }
            };

            try
            {
                result.Client = new Client
                {
                    Id = (string)config["tadaSDK"]["Application"]["ClientId"],
                    Secret = (string)config["tadaSDK"]["Application"]["ClientSecret"]
                };
            }
            catch
            {
                Console.WriteLine("warn: Client is not filled");
            }

            try
            {
                result.Principal = new Principal
                {
                    UserName = (string)config["tadaSDK"]["Credentials"]["UserName"],
                    Password = (string)config["tadaSDK"]["Credentials"]["Password"]
                };
            }
            catch
            {
                Console.WriteLine("warn: Principal is not filled");
            }

            return result;
        }
    }
}