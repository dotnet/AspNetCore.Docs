namespace TodoApi.EndpointFilters;

public static class Utilities
{
    public static string IsValid(Todo td)
    {
        if (td.Id < 0)
        {
            return "ID is less than 0";
        }
        else if (td.Name!.Length < 3)
        {
            return "Name length < 3";
        }
        else
        {
            return string.Empty;
        }
    }
}
