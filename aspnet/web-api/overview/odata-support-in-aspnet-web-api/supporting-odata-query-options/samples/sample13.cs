public IQueryable<Product> Get(ODataQueryOptions opts)
{
    var settings = new ODataValidationSettings()
    {
        // Initialize settings as needed.
        AllowedFunctions = AllowedFunctions.AllMathFunctions
    };

    opts.Validate(settings);

    IQueryable results = opts.ApplyTo(products.AsQueryable());
    return results as IQueryable<Product>;
}