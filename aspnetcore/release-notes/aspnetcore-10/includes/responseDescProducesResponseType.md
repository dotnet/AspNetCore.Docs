### Response description on ProducesResponseType for API controllers and Minimal APIs

The [ProducesAttribute](/dotnet/api/microsoft.aspnetcore.mvc.producesattribute-1), [ProducesResponseTypeAttribute](/dotnet/api/microsoft.aspnetcore.mvc.producesresponsetypeattribute-1), and [ProducesDefaultResponseType](/dotnet/api/microsoft.aspnetcore.mvc.producesdefaultresponsetypeattribute) attributes now accept an optional string parameter, `Description`, that sets the description of the response. Here's an example:

```csharp
[HttpGet(Name = "GetWeatherForecast")]
[ProducesResponseType<IEnumerable<WeatherForecast>>(StatusCodes.Status200OK,
                   Description = "The weather forecast for the next 5 days.")]
public IEnumerable<WeatherForecast> Get()
{
The following OpenAPI response and description are generated:

```json
        "responses": {
          "200": {
            "description": "The weather forecast for the next 5 days.",
            "content": {
```

This functionality is supported in both [API controllers](~/web-api.md#apicontroller-attribute.md#apicontroller-attribute) and [Minimal APIs](~/fundamentals/minimal-apis.md). For Minimal APIs, the `Description` property is correctly set even when the attribute’s type and the inferred return type aren't an exact match.


[Community contribution](https://github.com/dotnet/aspnetcore/pull/58193) by [Sander ten Brinke](https://github.com/sander1095) 🙏
