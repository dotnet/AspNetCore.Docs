The <xref:Microsoft.AspNetCore.Builder.EndpointRouteBuilderExtensions.MapGroup%2A> extension method helps organize groups of endpoints with a common prefix and reduces repetitive code. Use this method to customize entire groups of endpoints with a single call to methods like <xref:Microsoft.AspNetCore.Builder.AuthorizationEndpointConventionBuilderExtensions.RequireAuthorization%2A> and <xref:Microsoft.AspNetCore.Builder.RoutingEndpointConventionBuilderExtensions.WithMetadata%2A> that add [endpoint metadata](xref:fundamentals/routing#endpoint-metadata).

For example, the following code creates two similar groups of endpoints:

:::code language="csharp" source="~/fundamentals/minimal-apis/7.0-samples/todo-group/Program.cs" id="snippet_MapGroup":::

:::code language="csharp" source="~/fundamentals/minimal-apis/7.0-samples/todo-group/TodoEndpoints.cs" id="snippet_TodoEndpoints":::

In this scenario, you can use a relative address for the `Location` header in the `201 Created` result:

:::code language="csharp" source="~/fundamentals/minimal-apis/7.0-samples/todo-group/TodoEndpoints.cs" id="snippet_create":::

The first group of endpoints matches only requests prefixed with `/public/todos` and are accessible without any authentication. The second group of endpoints matches only requests prefixed with `/private/todos` and require authentication.

`QueryPrivateTodos` is a local function that modifies the `TodoDb` parameters of the route handler, to enable them to access and store private todo data. `QueryPrivateTodos` serves as an [endpoint filter factory](xref:fundamentals/minimal-apis/min-api-filters).

Route groups also support nested groups and complex prefix patterns with route parameters and constraints. In the following example, the route handler mapped to the `user` group can capture the `{org}` and `{group}` route parameters defined in the outer group prefixes.

The prefix can also be empty. This approach can be useful for adding endpoint metadata or filters to a group of endpoints without changing the route pattern.

:::code language="csharp" source="~/fundamentals/minimal-apis/7.0-samples/todo-group/Program.cs" id="snippet_NestedMapGroup1":::

Adding filters or metadata to a group results in the same behavior as adding them individually to each endpoint (before adding extra filters or metadata that might exist in an inner group or specific endpoint).

:::code language="csharp" source="~/fundamentals/minimal-apis/7.0-samples/todo-group/Program.cs" id="snippet_NestedMapGroup2":::

In the preceding example, the outer filter logs the incoming request before the inner filter even though the outer filter is added second. Because the filters are applied to different groups, the order that they're added relative to each other doesn't matter. The order in which filters are added matters when applied to the same group or specific endpoint.

A request to `/outer/inner/` logs the following data:

```dotnetcli
/outer group filter
/inner group filter
MapGet filter
```
