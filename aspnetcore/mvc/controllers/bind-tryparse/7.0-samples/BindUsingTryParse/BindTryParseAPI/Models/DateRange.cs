namespace BindTryParseAPI.Models
{
    // <snippet>
    public class DateRange
    {
        public DateOnly? From { get; }
        public DateOnly? To { get; }

        public DateRange(string from, string to)
        {
            if (string.IsNullOrEmpty(from))
                throw new ArgumentNullException(nameof(from));
            if (string.IsNullOrEmpty(to))
                throw new ArgumentNullException(nameof(to));

            From = DateOnly.Parse(from);
            To = DateOnly.Parse(to);
        }

        public static bool TryParse(string? value, IFormatProvider? provider, out DateRange? result)
        {
            if (string.IsNullOrEmpty(value) || value.Split('-').Length != 2)
            {
                result = default;
                return false;
            }

            var range = value.Split('-');
            result = new DateRange(range[0], range[1]);
            return true;
        }
    }
    // </snippet>
}
