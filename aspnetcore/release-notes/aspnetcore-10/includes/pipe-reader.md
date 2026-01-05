### Json+PipeReader deserialization support in MVC and Minimal APIs

PR: https://github.com/dotnet/aspnetcore/pull/62895

See https://github.com/dotnet/core/blob/main/release-notes/10.0/preview/preview7/libraries.md#pipereader-support-for-json-serializer

MVC, Minimal APIs, and the `HttpRequestJsonExtensions.ReadFromJsonAsync` methods have all been updated to use the new Json+PipeReader support without requiring any code changes from applications.

For most applications, the addition of this support has no effect on their behavior. However, if the application is using a custom <xref:System.Text.Json.Serialization.JsonConverter>, there's a chance that the converter doesn't handle <xref:System.Text.Json.Utf8JsonReader.HasValueSequence%2A?displayProperty=nameWithType> correctly. This can result in missing data and errors, such as <xref:System.ArgumentOutOfRangeException>, when deserializing.

The quick workaround (especially if you don't own the custom `JsonConverter` being used) is to set the `"Microsoft.AspNetCore.UseStreamBasedJsonParsing"` <xref:System.AppContext> switch to `"true"`. This should be a temporary workaround, and the `JsonConverter` should be updated to support <xref:System.Text.Json.Utf8JsonReader.HasValueSequence%2A>.

To fix `JsonConverter` implementations, there's a quick fix that allocates an array from the `ReadOnlySequence` and would look like the following example:

```csharp
public override T? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
{
    var span = reader.HasValueSequence ? reader.ValueSequence.ToArray() : reader.ValueSpan;
    // previous code
}
```

There's also a more complicated (but performant) fix, which would involve having a separate code path for the `ReadOnlySequence` handling:

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