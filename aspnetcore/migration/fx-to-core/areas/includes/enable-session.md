**Enable session**

Session support requires explicit activation. Configure it per-route or globally using ASP.NET Core metadata:

* Annotate controllers

:::code language="csharp" source="~/migration/fx-to-core/areas/session/samples/remote/SomeController.cs" id="snippet_Controller" :::

* Enable globally for all endpoints

:::code language="csharp" source="~/migration/fx-to-core/areas/session/samples/remote/Program.cs" id="snippet_RequireSystemWebAdapterSession" :::
