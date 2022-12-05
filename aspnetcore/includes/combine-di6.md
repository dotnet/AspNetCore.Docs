<a name="csc"></a>

Consider the following which registers services and configures options:

[!code-csharp[](~/fundamentals/configuration/index/samples/6.x/ConfigSample/program.cs?name=snippet2)]

Related groups of registrations can be moved to an extension method to register services. For example, the configuration services are added to the following class:

[!code-csharp[](~/fundamentals/configuration/index/samples/6.x/ConfigSample/Options/MyConfigServiceCollectionExtensions.cs)]

The remaining services are registered in a similar class. The following code uses the new extension methods to register the services:

[!code-csharp[](~/fundamentals/configuration/index/samples/6.x/ConfigSample/program.cs?name=snippet3)]

**_Note:_** Each `services.Add{GROUP_NAME}` extension method adds and potentially configures services. For example, <xref:Microsoft.Extensions.DependencyInjection.MvcServiceCollectionExtensions.AddControllersWithViews%2A> adds the services MVC controllers with views require, and <xref:Microsoft.Extensions.DependencyInjection.MvcServiceCollectionExtensions.AddRazorPages%2A> adds the services Razor Pages requires.
