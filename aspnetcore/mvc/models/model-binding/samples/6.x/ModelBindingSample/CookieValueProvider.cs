using System.Globalization;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ModelBindingSample;

public class CookieValueProvider : BindingSourceValueProvider, IEnumerableValueProvider
{
    private readonly IRequestCookieCollection _values;
    private PrefixContainer? _prefixContainer;

    public CookieValueProvider(BindingSource bindingSource, IRequestCookieCollection values, CultureInfo culture) : base(bindingSource)
    {
        _ = bindingSource ?? throw new ArgumentNullException(nameof(bindingSource));
        _ = values ?? throw new ArgumentNullException(nameof(values));

        (_values, Culture) = (values, culture);
    }

    public CultureInfo Culture { get; }

    protected PrefixContainer PrefixContainer =>
        _prefixContainer ??= new PrefixContainer(_values.Keys);

    public override bool ContainsPrefix(string prefix) =>
        PrefixContainer.ContainsPrefix(prefix);

    public virtual IDictionary<string, string> GetKeysFromPrefix(string prefix)
    {
        _ = prefix ?? throw new ArgumentNullException(nameof(prefix));

        return PrefixContainer.GetKeysFromPrefix(prefix);
    }


    public override ValueProviderResult GetValue(string key)
    {
        _ = key ?? throw new ArgumentNullException(nameof(key));

        if (key.Length == 0)
        {
            return ValueProviderResult.None;
        }

        var value = _values[key];
        if (string.IsNullOrEmpty(value))
        {
            return ValueProviderResult.None;
        }

        return new ValueProviderResult(value, Culture);
    }
}
