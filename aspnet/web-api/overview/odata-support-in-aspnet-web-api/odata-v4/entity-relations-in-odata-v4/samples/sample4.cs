public static void Register(HttpConfiguration config)
{
    ODataModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<Product>("Products");
    // New code:
    builder.EntitySet<Supplier>("Suppliers");
    config.MapODataServiceRoute("ODataRoute", null, builder.GetEdmModel());
}