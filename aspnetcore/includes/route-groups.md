The <xref:Microsoft.AspNetCore.Builder.EndpointRouteBuilderExtensions.MapGroup%2A> extension method helps organize groups of endpoints with a common prefix. It reduces repetitive code and allows for customizing entire groups of endpoints with a single call to methods like <xref:Microsoft.AspNetCore.Builder.AuthorizationEndpointConventionBuilderExtensions.RequireAuthorization%2A> and <xref:Microsoft.AspNetCore.Builder.RoutingEndpointConventionBuilderExtensions.WithMetadata%2A> which add [endpoint metadata](xref:fundamentals/routing#endpoint-metadata).

For example, the following code creates two similar groups of endpoints:

:::code language="csharp" source="~/fundamentals/minimal-apis/7.0-samples/todo-group/Program.cs" id="snippet_MapGroup":::

:::code language="csharp" source="~/fundamentals/minimal-apis/7.0-samples/todo-group/TodoEndpoints.cs" id="snippet_TodoEndpoints":::

In this scenario, you can use a relative address for the `Location` header in the `201 Created` result:

:::code language="csharp" source="~/fundamentals/minimal-apis/7.0-samples/todo-group/TodoEndpoints.cs" id="snippet_create":::

The first group of endpoints will only match requests prefixed with `/public/todos` and are accessible without any authentication. The second group of endpoints will only match requests prefixed with `/private/todos` and require authentication.

The `QueryPrivateTodos` [endpoint filter factory](xref:fundamentals/minimal-apis/min-api-filters) is a local function that modifies the route handler's `TodoDb` parameters to allow to access and store private todo data.

Route groups also support nested groups and complex prefix patterns with route parameters and constraints. In the following example, and route handler mapped to the `user` group can capture the `{org}` and `{group}` route parameters defined in the outer group prefixes.

The prefix can also be empty. This can be useful for adding endpoint metadata or filters to a group of endpoints without changing the route pattern.

:::code language="csharp" source="~/fundamentals/minimal-apis/7.0-samples/todo-group/Program.cs" id="snippet_NestedMapGroup1":::

Adding filters or metadata to a group behaves the same way as adding them individually to each endpoint before adding any extra filters or metadata that may have been added to an inner group or specific endpoint.

:::code language="csharp" source="~/fundamentals/minimal-apis/7.0-samples/todo-group/Program.cs" id="snippet_NestedMapGroup2":::

In the above example, the outer filter will log the incoming request before the inner filter even though it was added second. Because the filters were applied to different groups, the order they were added relative to each other does not matter. The order filters are added does matter if applied to the same group or specific endpoint.

A request to `/outer/inner/` will log the following:

```dotnetcli
/outer group filter
/inner group filter
MapGet filter
```
