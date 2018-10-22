using System;
namespace tada.SDK.Objects
{
    public class Azure
    {
        public string Instance { get { return "https://login.microsoftonline.com/"; } }
        public string TenantId { get; set; }
        public string Domain { get; set; }
        public string Authority { get { return $"{Instance}{TenantId}"; } }
    }
}
