### Middleware  supports Keyed DI

Middleware now supports [Keyed DI](/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-9.0&preserve-view=true#keyed-services) in both the constructor and the `Invoke`/`InvokeAsync` method:

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/samples/KeyedServices9/Program.cs"  id="snippet_2":::
