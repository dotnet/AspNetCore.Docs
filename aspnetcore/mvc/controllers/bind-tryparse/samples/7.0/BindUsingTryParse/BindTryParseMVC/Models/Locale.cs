using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace BindTryParseMVC.Models;

// <snippet>
public class Locale : CultureInfo, IParsable<Locale>
{
    public Locale(string culture) : base(culture)
    {
    }

    public static Locale Parse(string value, IFormatProvider? provider)
    {
        if (!TryParse(value, provider, out var result))
        {
           throw new ArgumentException("Could not parse supplied value.", nameof(value));
        }

        return result;
    }

    public static bool TryParse([NotNullWhen(true)] string? value,
                                IFormatProvider? provider, out Locale locale)
    {
        if (value is null)
        {
            locale = new Locale(CurrentCulture.Name);
            return false;
        }
        
        try
        {
            locale = new Locale(value);
            return true;
        }
        catch (CultureNotFoundException)
        {
            locale = new Locale(CurrentCulture.Name);
            return false;
        }
    }
}
// </snippet>
