:::moniker range=">= aspnetcore-8.0"

Parameter binding is the process of converting request data into strongly typed parameters that are expressed by route handlers. A binding source determines where parameters are bound from. Binding sources can be explicit or inferred based on HTTP method and parameter type.

Supported binding sources:

* Route values
* Query string
* Header
* Body (as JSON)
* Form values
* Services provided by dependency injection
* Custom

The following `GET` route handler uses some of these parameter binding sources:

:::code language="csharp" source="~/fundamentals/minimal-apis/7.0-samples/WebMinAPIs/Program.cs" id="snippet_pbg" highlight="8-11":::

The following table shows the relationship between the parameters used in the preceding example and the associated binding sources.

| Parameter | Binding Source |
|--|--|
| `id` | route value |
| `page` | query string |
| `customHeader` | header |
| `service` | Provided by dependency injection |

The HTTP methods `GET`, `HEAD`, `OPTIONS`, and `DELETE` don't implicitly bind from body. To bind from body (as JSON) for these HTTP methods, bind explicitly with [`[FromBody]`](xref:Microsoft.AspNetCore.Mvc.FromBodyAttribute) or read from the <xref:Microsoft.AspNetCore.Http.HttpRequest>.

The following example POST route handler uses a binding source of body (as JSON) for the `person` parameter:

:::code language="csharp" source="~/fundamentals/minimal-apis/7.0-samples/WebMinAPIs/Program.cs" id="snippet_pbp" highlight="5":::

For more information on parameter binding including explicit binding, binding from forms, dependency injection, special types, custom binding, and binding precedence, see <xref:fundamentals/minimal-apis/parameter-binding>.

:::moniker-end
