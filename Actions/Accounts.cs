using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using tada.SDK.Objects;

namespace tada.SDK.Actions
{
    public class Accounts
    {
        public static AccountsList List()
        {
            var client = new Connection().Client;

            var result = client.GetAsync(SDK.Endpoints.Accounts.List).Result;

            string responseString = result.Content.ReadAsStringAsync().Result;
            JObject accountsJson = JObject.Parse(responseString);

            List<Account> currentAccounts = new List<Account>();

            foreach (var currentAccount in (JArray)accountsJson["data"]["accounts"])
            {
                currentAccounts.Add(new Account
                {
                    Id = (int)currentAccount["id"],
                    AccessRights = (string)currentAccount["access_rights"],
                    Description = (string)currentAccount["description"],
                    IBAN = (string)currentAccount["iban"]
                });
            }

            var accountList = new AccountsList
            {
                Accounts = currentAccounts
            };

            return accountList;
        }

        public static Account.Connect Add()
        {
            var client = new Connection().Client;

            var result = client.GetAsync(SDK.Endpoints.Accounts.Add).Result;

            string responseString = result.Content.ReadAsStringAsync().Result;
            JObject draftJson = JObject.Parse(responseString);
           
            var connectDetails = new Account.Connect
            {
                QRCode = draftJson["data"]["qrcode"].ToString(),
                Id = draftJson["data"]["draftid"].ToString()
            };

            return connectDetails;
        }
    }
}
