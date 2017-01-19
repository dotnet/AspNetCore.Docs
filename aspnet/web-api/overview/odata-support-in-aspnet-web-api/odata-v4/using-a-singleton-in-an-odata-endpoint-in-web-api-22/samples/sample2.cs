public static IEdmModel GetEdmModel() 
{ 
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<Employee>("Employees"); builder.Singleton<Company>("Umbrella");
    builder.Namespace = typeof(Company).Namespace;
    return builder.GetEdmModel(); 
}