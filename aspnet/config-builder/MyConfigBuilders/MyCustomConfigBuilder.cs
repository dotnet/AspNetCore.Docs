using Microsoft.Configuration.ConfigurationBuilders;
using System.Collections.Generic;

public class MyCustomConfigBuilder : KeyValueConfigBuilder
{
    public override string GetValue(string key)
    {
        // Key lookup should be case-insensitive, because most key/value collections in 
        // .NET Framework config sections are case-insensitive.
        return "Value for given key, or null.";
    }

    public override ICollection<KeyValuePair<string, string>> GetAllValues(string prefix)
    {
        // Populate the return collection.
        return new Dictionary<string, string>() { { "one", "1" }, { "two", "2" } };
    }
}