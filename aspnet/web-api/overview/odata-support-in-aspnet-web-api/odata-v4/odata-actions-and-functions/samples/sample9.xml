ODataModelBuilder builder = new ODataConventionModelBuilder();
builder.EntitySet<Product>("Products");
builder.EntitySet<Supplier>("Suppliers");

// New code:
builder.Namespace = "ProductService";
builder.EntityType<Product>().Collection
    .Function("MostExpensive")
    .Returns<double>();