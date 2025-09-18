<!--
This include file is used in 
minimal-apis.md
parameter-binding10.md
model-binding.md
-->

Srtarting in .NET 10, the following functional areas of ASP.NET Core use overloads of `JsonSerializer.<xref:System.Text.Json.JsonSerializer.DeserializeAsync%2A?displayProperty=nameWithType>DeserializeAsync` based on PipeReader instead of Stream:

* Minimal APIs (parameter binding, read request body)
* MVC (input formatters, model)
* The <xref:Microsoft.AspNetCore.Http.HttpRequestJsonExtensions?displayProperty=nameWithType> methods

For most applications, a transition from Stream to PipeReader provides better performance without requiring changes in application code. But if your application has a custom converter, the converter might not handle <xref:System.Text.Json.Utf8JsonReader.HasValueSequence%2A?displayProperty=nameWithType> correctly. If it doesn't, the result could be errors such as <xref:System.ArgumentOutOfRangeException>with no warning, or missing data when deserializing. You have the following options for getting your converter to work without PipeReader-related errors:

## Option 1: Temporary workaround

The quick workaround is to go back to using Stream without PipeReader support. To implement this option, set the "Microsoft.AspNetCore.UseStreamBasedJsonParsing" AppContext switch to "true". We recommend that you do this only as a temporary workaround, and update your converter to support`HasValueSequence` as soon as possible. The switch might be removed in .NET 11. Its only purpose was to give developers time to get their converters updated.

## Option 2: A quick fix for `JsonConverter` implementations

For this fix, you allocate an array from the `ReadOnlySequence`. This example shows what the code would look like::

```csharp
public override T? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
{
    var span = reader.HasValueSequence ? reader.ValueSequence.ToArray() : reader.ValueSpan;
    // previous code
}
```

## Option 3: A more complicated but better performing fix

This fix involves setting up a separate code path for the `ReadOnlySequence` handling:

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

For more information, see
* <xref:System.Text.Json.Serialization.JsonConverter?displayProperty=nameWithType>
* [github.com/dotnet/aspnetcore/pull/62895](https://github.com/dotnet/aspnetcore/pull/62895)