### Response description on ProducesResponseType

https://github.com/dotnet/aspnetcore/pull/58193

The ProducesAttribute, ProducesResponseTypeAttribute, and ProducesDefaultResponseType attributes now accept an optional string parameter, `Description`, that will set the description of the response. Here's an example:

```csharp
[HttpGet(Name = "GetWeatherForecast")]
[ProducesResponseType<IEnumerable<WeatherForecast>>(StatusCodes.Status200OK, Description = "The weather forecast for the next 5 days.")]
public IEnumerable<WeatherForecast> Get()
{
```

And the generated OpenAPI will be

```json
        "responses": {
          "200": {
            "description": "The weather forecast for the next 5 days.",
            "content": {
```

Community contribution! 🙏 