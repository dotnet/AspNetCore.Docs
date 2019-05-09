using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Primitives;
using System.Collections.Generic;

namespace ModelBindingSample
{
    // This value provider is registered in Startup.ConfigureServices
    // and is used in Pages/Instructors/Index.cshtml.cs
    public class MyValueProvider : BindingSourceValueProvider, IEnumerableValueProvider
    {
        public MyValueProvider(BindingSource bindingSource) : base(bindingSource)
        {
        }

        public IDictionary<string, string> GetKeysFromPrefix(string prefix)
        {
            return new Dictionary<string, string>
            {
                { "cvpkey1", "custom-value-provider-value1" },
                { "cvpkey2", "custom-value-provider-value2" },
            };
        }

        public override bool ContainsPrefix(string prefix)
        {
            return true;
        }

        public override ValueProviderResult GetValue(string key)
        {
            string value;
            GetKeysFromPrefix("").TryGetValue(key, out value);
            if (value != null)
            {
                return new ValueProviderResult(new StringValues(value));
            }

            return ValueProviderResult.None;
        }
    }
}
