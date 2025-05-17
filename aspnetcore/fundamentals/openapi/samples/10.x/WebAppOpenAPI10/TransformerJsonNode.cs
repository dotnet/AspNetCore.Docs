options.AddSchemaTransformer((schema, context, cancellationToken) =>
{
    if (context.JsonTypeInfo.Type == typeof(WeatherForecast))
    {
-       schema.Example = new OpenApiObject
+       schema.Example = new JsonObject
        {
-           ["date"] = new OpenApiString(DateTime.Now.AddDays(1).ToString("yyyy-MM-dd")),
+           ["date"] = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd"),
-           ["temperatureC"] = new OpenApiInteger(0),
+           ["temperatureC"] = 0,
-           ["temperatureF"] = new OpenApiInteger(32),
+           ["temperatureF"] = 32,
-           ["summary"] = new OpenApiString("Bracing"),
+           ["summary"] = "Bracing",
        };
    }
    return Task.CompletedTask;
});
