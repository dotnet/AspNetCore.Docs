### Validation APIs moved to Microsoft.Extensions.Validation

The validation APIs have moved to the `Microsoft.Extensions.Validation` namespace and NuGet package. This change makes the APIs usable outside of ASP.NET Core HTTP scenarios. The public APIs and behavior remain unchanged&em&mdash;only the package and namespace are different. Existing projects don't require code changes, as old references redirect to the new implementation.

