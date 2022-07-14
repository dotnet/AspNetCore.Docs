namespace BindTryParseMVC.Models
{
    // <snippet>
    public class Culture
    {
        public string? DisplayName { get; }

        public Culture(string displayName)
        {
            if (string.IsNullOrEmpty(displayName))
                throw new ArgumentNullException(nameof(displayName));

            DisplayName = displayName;
        }

        public static bool TryParse(string? value, out Culture? result)
        {
            if (value is null)
            {
                result = default;
                return false;
            }

            result = new Culture(value);
            return true;
        }
    }
    // </snippet>
}
