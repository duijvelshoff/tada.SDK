﻿using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using tada.SDK.Aggregation.Objects;

namespace tada.SDK.Aggregation.Actions
{
    public class PaymentRequest
    {
        public static int Execute(Details content)
        {
            var client = new Connection().Client;

            JObject request = new JObject {
                {"data", new JObject {
                    {"request", new JObject{
                        {"origin", new JObject {
                            {"iban", content.Origin.IBAN }
                        }},
                        {"recipient", new JObject{
                            {"name", content.Recipient.Name},
                            {"mail", content.Recipient.Value}
                        }},
                        {"amount", new JObject{
                            {"value", content.Amount.Value}
                        }},
                        {"description", content.Description }
                    }}
                }}
            };

            var httpContent = new StringContent(request.ToString());
            httpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            var result = client.PostAsync("/api/request", httpContent).Result;
            return (int)result.StatusCode;
        }
    }
}
