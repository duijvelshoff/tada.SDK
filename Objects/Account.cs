using System.Collections.Generic;

namespace tada.SDK.Objects
{
    public class Account
    {
        public int Id { get; set; }
        public string AccessRights { get; set; }
        public string IBAN { get; set; }
        public string Description { get; set; }
    }

    public class AccountsList
    {
        public List<Account> Accounts { get; set; }
    }
}
