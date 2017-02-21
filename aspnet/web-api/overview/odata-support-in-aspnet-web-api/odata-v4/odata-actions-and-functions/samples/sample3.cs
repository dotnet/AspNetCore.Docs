ODataModelBuilder builder = new ODataConventionModelBuilder();
builder.EntitySet<Product>("Products");

// New code:
builder.Namespace = "ProductService";
builder.EntityType<Product>()
    .Action("Rate")
    .Parameter<int>("Rating");