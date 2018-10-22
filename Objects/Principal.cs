namespace tada.SDK.Objects
{
    public class Principal
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public static void Save(string principalId)
        {
            if (Config.Settings.Principal != null)
            {
                Config.Settings.Principal.Id = principalId;
            }
            else
            {
                Config.Settings.Principal = new Principal
                {
                    Id = principalId
                };
            }
        }
    }
}
