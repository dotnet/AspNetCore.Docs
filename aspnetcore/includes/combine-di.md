## Combining service collection

Consider the following `ConfigureServices` that contains four service collections:

[!code-csharp[](~/fundamentals/configuration/index/samples/3.x/ConfigSample/Startup2.cs?name=snippet)]

Related groups of registrations can be moved to call that creates an extension method to register services. For example, the configuration services are added to the class:

[!code-csharp[](~/fundamentals/configuration/index/samples/3.x/ConfigSample/Options/MyConfgServiceCollectionExtensions.cs)]

The remaining services are registered in a similar class. The following `ConfigureServices` uses the new extension methods to register the services:

[!code-csharp[](~/fundamentals/configuration/index/samples/3.x/ConfigSample/Startup4.cs?name=snippet)]