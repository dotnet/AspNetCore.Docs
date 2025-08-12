### Json+PipeReader deserialization support in MVC and Minimal

- [ ] Edit for the What's New   - Assigned to: tdykstra
- [ ] Update in the docs, tracking:    - Assigned to: tdykstra

PR: https://github.com/dotnet/aspnetcore/pull/62895

See https://github.com/dotnet/core/blob/dotnet10-p7-libraries/release-notes/10.0/preview/preview7/libraries.md#pipereader-support-for-json-serializer

MVC, Minimal APIs, and the `HttpRequestJsonExtensions.ReadFromJsonAsync` methods have all been updated to use the new Json+PipeReader support without requiring any code changes from applications.

For the majority of applications this should have no impact on behavior. However, if the application is using a custom `JsonConverter`, there is a chance that the converter doesn't handle [Utf8JsonReader.HasValueSequence](https://learn.microsoft.com/dotnet/api/system.text.json.utf8jsonreader.hasvaluesequence) correctly. This can result in missing data and errors like `ArgumentOutOfRangeException` when deserializing.

The quick workaround (especially if you don't own the custom `JsonConverter` being used) is to set the `"Microsoft.AspNetCore.UseStreamBasedJsonParsing"` [AppContext](https://learn.microsoft.com/dotnet/api/system.appcontext?view=net-9.0) switch to `"true"`. This should be a temporary workaround and the `JsonConverter`(s) should be updated to support `HasValueSequence`.

To fix `JsonConverter` implementations, there is the quick fix which allocates an array from the `ReadOnlySequence` and would look something like:
```csharp
public override T? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
{
    var span = reader.HasValueSequence ? reader.ValueSequence.ToArray() : reader.ValueSpan;
    // previous code
}
```

Or the more complicated (but performant) fix which would involve having a separate code path for the `ReadOnlySequence` handling:
```csharp
public override T? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
{
    if (reader.HasValueSequence)
    {
        reader.ValueSequence;
        // ReadOnlySequence optimized path
    }
    else
    {
        reader.ValueSpan;
        // ReadOnlySpan optimized path
    }
}
```