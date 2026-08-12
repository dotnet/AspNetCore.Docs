### Consistent authorization metadata across the stack

Authorization metadata can be expressed as <xref:Microsoft.AspNetCore.Authorization.IAuthorizeData>, an <xref:Microsoft.AspNetCore.Authorization.AuthorizationPolicy>, or an <xref:Microsoft.AspNetCore.Authorization.IAuthorizationRequirementData> attribute. MVC filters, SignalR hub methods, and Blazor's `AuthorizeView` and `AuthorizeRouteView` apply all three forms consistently.

<!-- TODO: Update `AuthorizationPolicy.CombineAsync` to <xref:> once the new overload's API docs are published. -->

A new `AuthorizationPolicy.CombineAsync` overload is the shared implementation:

```csharp
public class AuthorizationPolicy
{
    public static Task<AuthorizationPolicy?> CombineAsync(
        IAuthorizationPolicyProvider policyProvider,
        IEnumerable<object> metadata);
}
```

MVC, SignalR, and Blazor use this overload internally. A custom attribute that implements both <xref:Microsoft.AspNetCore.Authorization.IAuthorizeData> and <xref:Microsoft.AspNetCore.Authorization.IAuthorizationRequirementData> contributes to the decision once. The legacy MVC path with `EnableEndpointRouting = false` is unchanged.
