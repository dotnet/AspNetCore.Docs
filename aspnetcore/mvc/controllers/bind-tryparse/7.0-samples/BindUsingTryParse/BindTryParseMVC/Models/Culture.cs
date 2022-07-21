namespace BindTryParseMVC.Models;

// <snippet>
public class Culture
{
    public string? DisplayName { get; }

    public Culture(string displayName)
    {
        DisplayName = displayName;
    }
    
    public static bool TryParse(string? value, out Culture? culture)
    {
        if (string.IsNullOrEmpty(value))
        {
            culture = default;
            return false;
        }

        culture = new Culture(value);
        return true;
    }
}
// </snippet>
