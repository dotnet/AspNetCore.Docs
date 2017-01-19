public static IEdmModel GetModel()         
{             
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();             
    builder.EntitySet<Account>("Accounts");             
    var paymentInstrumentType = builder.EntityType<PaymentInstrument>();             
    var functionConfiguration = 
        paymentInstrumentType.Collection.Function("GetCount");             
    functionConfiguration.Parameter<string>("NameContains");             
    functionConfiguration.Returns<int>();             
    builder.Namespace = typeof(Account).Namespace;             
    return builder.GetEdmModel();         
}