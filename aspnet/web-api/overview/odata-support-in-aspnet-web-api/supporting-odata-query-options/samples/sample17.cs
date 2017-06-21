public IQueryable<Product> Get(ODataQueryOptions opts)
{
    if (opts.OrderBy != null)
    {
        opts.OrderBy.Validator = new MyOrderByValidator();
    }

    var settings = new ODataValidationSettings()
    {
        // Initialize settings as needed.
        AllowedFunctions = AllowedFunctions.AllMathFunctions
    };

    // Validate
    opts.Validate(settings);

    IQueryable results = opts.ApplyTo(products.AsQueryable());
    return results as IQueryable<Product>;
}