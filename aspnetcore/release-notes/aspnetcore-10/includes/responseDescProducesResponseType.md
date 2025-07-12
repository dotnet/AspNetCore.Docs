### Response description on `ProducesResponseType` for API controllers

The <xref:Microsoft.AspNetCore.Mvc.ProducesAttribute>, <xref:Microsoft.AspNetCore.Mvc.ProducesResponseTypeAttribute>, and <xref:Microsoft.AspNetCore.Mvc.ProducesDefaultResponseTypeAttribute> now accept an optional string parameter, `Description`, that sets the description of the response:

```csharp
[HttpGet(Name = "GetWeatherForecast")]
[ProducesResponseType<IEnumerable<WeatherForecast>>(StatusCodes.Status200OK,
    Description = "The weather forecast for the next 5 days.")]
public IEnumerable<WeatherForecast> Get()
{
```

Generated OpenAPI data:

```json
"responses": {
  "200": {
    "description": "The weather forecast for the next 5 days.",
    "content": {
```

Currently, Minimal APIs don't support <xref:Microsoft.AspNetCore.Mvc.ProducesResponseTypeAttribute>. Support is planned for a future ASP.NET Core release. For more information, see [Improving current methods for setting OpenAPI response descriptions with Minimal APIs (`dotnet/aspnetcore` #58724)](https://github.com/dotnet/aspnetcore/issues/58724).

[Community contribution (`dotnet/aspnetcore` #58193)](https://github.com/dotnet/aspnetcore/pull/58193) by [Sander ten Brinke](https://github.com/sander1095).
