using System;
namespace tada.SDK.Aggregation.Objects
{
    public class Pointer
    {
        public string Type { get; set; }
        public string Value { get; set; }
        public string Name { get; set; }

        public Pointer(string type, string value, string name)
        {
            Type = type;
            Value = value;
            Name = name;
        }
    }
}
