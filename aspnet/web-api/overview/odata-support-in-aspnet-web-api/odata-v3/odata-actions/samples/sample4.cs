public static class WebApiConfig
{
    public static void Register(HttpConfiguration config)
    {
        ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
        builder.EntitySet<Product>("Products");
        builder.EntitySet<Supplier>("Suppliers");
        builder.EntitySet<ProductRating>("Ratings");

        // New code: Add an action to the EDM, and define the parameter and return type.
        ActionConfiguration rateProduct = builder.Entity<Product>().Action("RateProduct");
        rateProduct.Parameter<int>("Rating");
        rateProduct.Returns<double>();

        config.Routes.MapODataRoute("odata", "odata", builder.GetEdmModel());
    }
}
