ODataModelBuilder builder = new ODataConventionModelBuilder();
builder.EntitySet<Product>("Products");

// New code:
builder.Function("GetSalesTaxRate")
    .Returns<double>()
    .Parameter<int>("PostalCode");