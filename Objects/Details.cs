using System;
namespace tada.SDK.Objects
{
    public class Details
    {
        public Account Origin { get; set; }
        public Amount Amount { get; set; }
        public Pointer Recipient { get; set; }
        public string Description { get; set; }
    }
}
