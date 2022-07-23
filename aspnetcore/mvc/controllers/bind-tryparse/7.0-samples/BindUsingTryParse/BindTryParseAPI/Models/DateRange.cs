namespace BindTryParseAPI.Models
{
    // <snippet>
    public class DateRange
    {
        public DateOnly? From { get; }
        public DateOnly? To { get; }

        public DateRange(DateOnly fromDate, DateOnly toDate)
        {
            From = fromDate;
            To = toDate;
        }

        public static bool TryParse(string? value, IFormatProvider? provider, out DateRange? dateRange)
        {
            if (string.IsNullOrEmpty(value) || value.Split('-').Length != 2)
            {
                dateRange = default;
                return false;
            }

            var range = value.Split('-');

            if (!DateOnly.TryParse(range[0], provider, out var fromDate) 
             || !DateOnly.TryParse(range[1], provider, out var toDate))
            {
                dateRange = default;
                return false;
            }

            dateRange = new DateRange(fromDate, toDate);
            return true;
        }
    }
    // </snippet>
}
