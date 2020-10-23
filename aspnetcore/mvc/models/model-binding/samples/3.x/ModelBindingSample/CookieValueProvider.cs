using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace ModelBindingSample
{
    // This value provider is registered in Startup.ConfigureServices
    // and is used in Pages/Instructors/Index.cshtml.cs
    public class CookieValueProvider : BindingSourceValueProvider, IEnumerableValueProvider
    {
        private readonly IRequestCookieCollection _values;
        private PrefixContainer _prefixContainer;

        public CookieValueProvider(BindingSource bindingSource, IRequestCookieCollection values, CultureInfo culture) : base(bindingSource)
        {
            if (bindingSource == null)
            {
                throw new ArgumentNullException(nameof(bindingSource));
            }

            if (values == null)
            {
                throw new ArgumentNullException(nameof(values));
            }

            _values = values;
            Culture = culture;
        }

        public CultureInfo Culture { get; }


        protected PrefixContainer PrefixContainer
        {
            get
            {
                if (_prefixContainer == null)
                {
                    _prefixContainer = new PrefixContainer(_values.Keys);
                }

                return _prefixContainer;
            }
        }

        public override bool ContainsPrefix(string prefix)
        {
            return PrefixContainer.ContainsPrefix(prefix);
        }

        public virtual IDictionary<string, string> GetKeysFromPrefix(string prefix)
        {
            if (prefix == null)
            {
                throw new ArgumentNullException(nameof(prefix));
            }

            return PrefixContainer.GetKeysFromPrefix(prefix);
        }


        public override ValueProviderResult GetValue(string key)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            if (key.Length == 0)
            {
                return ValueProviderResult.None;
            }

            var value = _values[key];
            if (string.IsNullOrEmpty(value))
            {
                return ValueProviderResult.None;
            }
            else
            {
                return new ValueProviderResult(value, Culture);
            }
        }
    }
}
