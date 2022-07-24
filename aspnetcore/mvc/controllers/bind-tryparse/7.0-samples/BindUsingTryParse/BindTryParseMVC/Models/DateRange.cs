using System.Drawing;
using System;

namespace BindTryParseMVC.Models
{
    // <snippet>
    public class DateRange : IParsable<DateRange>
    {
        public DateOnly? From { get; set;  }
        public DateOnly? To { get; set; }

        public static DateRange Parse(string value, IFormatProvider? provider)
        {
            if (!TryParse(value, provider, out var result))
            {
                throw new ArgumentException("Could not parse supplied value.", nameof(value));
            }

            return result;
        }

        public static bool TryParse(string? value, IFormatProvider? provider, out DateRange dateRange)
        {
            var segments = value?.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

            if (segments?.Length == 2
                && DateOnly.TryParse(segments[0], provider, out var fromDate)
                && DateOnly.TryParse(segments[1], provider, out var toDate))
            {
                dateRange = new DateRange { From = fromDate, To = toDate };
                return true;
            }

            dateRange = new DateRange();
            return false;
        }
    }
    // </snippet>
}
