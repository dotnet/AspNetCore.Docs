### `IOutputCachePolicyProvider` interface

ASP.NET Core in .NET 11 provides the [IOutputCachePolicyProvider](https://source.dot.net/#Microsoft.AspNetCore.OutputCaching/[IOutputCachePolicyProvider.cs](https://source.dot.net/#Microsoft.AspNetCore.OutputCaching/IOutputCachePolicyProvider.cs)` interface for implementing custom output caching policy selection logic. By using this interface, apps can determine the default base caching policy, check for the existence of named policies, and support advanced scenarios where policies must be resolved dynamically. Examples include loading policies from external configuration sources, databases, or applying tenant-specific caching rules.

The following code shows the `IOutputCachePolicyProvider` interface:

```csharp
public interface IOutputCachePolicyProvider
{
    IReadOnlyList<IOutputCachePolicy> GetBasePolicies();
    ValueTask<IOutputCachePolicy?> GetPolicyAsync(string policyName);
}
```

<!-- 
UPDATE 11.0 - Add API cross-reference link when available:
<xref:Microsoft.AspNetCore.OutputCaching.IOutputCachePolicyProvider>
-->

Thank you [@lqlive](https://github.com/lqlive) for this contribution!