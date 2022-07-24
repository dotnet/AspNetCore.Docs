using System.Globalization;

namespace BindTryParseMVC.Models
{
    // <snippet>
    public class Culture : IParsable<Culture>
    {
        public CultureInfo? CultureInfo { get; set; }

        public static Culture Parse(string value, IFormatProvider? provider)
        {
            throw new NotImplementedException();
        }

        public static bool TryParse(string? value, IFormatProvider? provider, out Culture culture)
        {
            if (value is null)
            {
                culture = new Culture();
                return false;
            }

            try
            {
                var ci = new CultureInfo(value);
                culture = new Culture { CultureInfo = ci };
                return true;
            }
            catch (CultureNotFoundException)
            {
                culture = new Culture();
                return false;
            }
        }
    }
    // </snippet>
}
