public static void Register(HttpConfiguration config)
{
    config.Filters.Add(new AuthorizeAttribute());
}