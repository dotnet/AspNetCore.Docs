### Response description on ProducesResponseType for API controllers

The [ProducesAttribute](/dotnet/api/microsoft.aspnetcore.mvc.producesattribute-1), [ProducesResponseTypeAttribute](/dotnet/api/microsoft.aspnetcore.mvc.producesresponsetypeattribute-1), and [ProducesDefaultResponseType](/dotnet/api/microsoft.aspnetcore.mvc.producesdefaultresponsetypeattribute) attributes now accept an optional string parameter, `Description`, that will set the description of the response. Here's an example:

```csharp
[HttpGet(Name = "GetWeatherForecast")]
[ProducesResponseType<IEnumerable<WeatherForecast>>(StatusCodes.Status200OK,
                   Description = "The weather forecast for the next 5 days.")]
public IEnumerable<WeatherForecast> Get()
{
```

And the generated OpenAPI:

```json
        "responses": {
          "200": {
            "description": "The weather forecast for the next 5 days.",
            "content": {
```

[Community contribution](https://github.com/dotnet/aspnetcore/pull/58193) by [Sander ten Brinke](https://github.com/sander1095) 🙏
