namespace tada.SDK.Objects
{
    public class Amount
    {
        public string Value { get; set; }
        public string Currency { get; set; }

        public Amount(string value, string currency)
        {
            Value = value;
            Currency = currency;
        }
    }
}
