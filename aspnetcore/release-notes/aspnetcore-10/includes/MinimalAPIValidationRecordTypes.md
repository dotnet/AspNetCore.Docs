### Improvements to Minimal APIs Validation

<!-- https://github.com/dotnet/aspnetcore/pull/61193 -->
<!-- https://github.com/dotnet/aspnetcore/pull/61402 -->
Beginning in Preview 4, ASP.NET Core supports validation on record types. With this enhancement,
inputs to API endpoints defined using `record` types are now validated automatically, in the same way as
class types.