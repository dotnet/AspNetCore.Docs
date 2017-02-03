ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
builder.EntitySet<Product>("Products");
// New code:
builder.EntitySet<Supplier>("Suppliers");