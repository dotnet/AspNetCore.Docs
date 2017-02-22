public Contact[] GetAllContacts()
{
    var ctx = HttpContext.Current;

    if (ctx != null)
    {
        return (Contact[])ctx.Cache[CacheKey];
    }

    return new Contact[]
        {
            new Contact
            {
                Id = 0,
                Name = "Placeholder"
            }
        };
}