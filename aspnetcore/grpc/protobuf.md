---
title: Create Protobuf messages for .NET apps
author: jamesnk
description: Learn how to create Protobuf messages for .NET apps.
monikerRange: '>= aspnetcore-3.0'
ms.author: jamesnk
ms.date: 02/12/2021
uid: grpc/protobuf
---
# Create Protobuf messages for .NET apps

By [James Newton-King](https://twitter.com/jamesnk) and [Mark Rendle](https://twitter.com/markrendle)

gRPC uses [Protobuf](https://developers.google.com/protocol-buffers) as its Interface Definition Language (IDL). Protobuf IDL is a language neutral format for specifying the messages sent and received by gRPC services. Protobuf messages are defined in `.proto` files. This document explains how Protobuf concepts map to .NET.

## Protobuf messages

Messages are the main data transfer object in Protobuf. They are conceptually similar to .NET classes.

```protobuf
syntax = "proto3";

option csharp_namespace = "Contoso.Messages";

message Person {
    int32 id = 1;
    string first_name = 2;
    string last_name = 3;
}  
```

The preceding message definition specifies three fields as name-value pairs. Like properties on .NET types, each field has a name and a type. The field type can be a [Protobuf scalar value type](#scalar-value-types), e.g. `int32`, or another message.

The [Protobuf style guide](https://developers.google.com/protocol-buffers/docs/style) recommends using `underscore_separated_names` for field names. New Protobuf messages created for .NET apps should follow the Protobuf style guidelines. .NET tooling automatically generates .NET types that use .NET naming standards. For example, a `first_name` Protobuf field generates a `FirstName` .NET property.

In addition to a name, each field in the message definition has a unique number. Field numbers are used to identify fields when the message is serialized to Protobuf. Serializing a small number is faster than serializing the entire field name. Because field numbers identify a field it is important to take care when changing them. For more information about changing Protobuf messages see <xref:grpc/versioning>.

When an app is built the Protobuf tooling generates .NET types from `.proto` files. The `Person` message generates a .NET class:

```csharp
public class Person
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}
```

For more information about Protobuf messages see the [Protobuf language guide](https://developers.google.com/protocol-buffers/docs/proto3#simple).

## Scalar Value Types

Protobuf supports a range of native scalar value types. The following table lists them all with their equivalent C# type:

| Protobuf type | C# type      |
| ------------- | ------------ |
| `double`      | `double`     |
| `float`       | `float`      |
| `int32`       | `int`        |
| `int64`       | `long`       |
| `uint32`      | `uint`       |
| `uint64`      | `ulong`      |
| `sint32`      | `int`        |
| `sint64`      | `long`       |
| `fixed32`     | `uint`       |
| `fixed64`     | `ulong`      |
| `sfixed32`    | `int`        |
| `sfixed64`    | `long`       |
| `bool`        | `bool`       |
| `string`      | `string`     |
| `bytes`       | `ByteString` |

Scalar values always have a default value and can't be set to `null`. This constraint includes `string` and `ByteString` which are C# classes. `string` defaults to an empty string value and `ByteString` defaults to an empty bytes value. Attempting to set them to `null` throws an error.

[Nullable wrapper types](#nullable-types) can be used to support null values.

### Dates and times

The native scalar types don't provide for date and time values, equivalent to .NET's <xref:System.DateTimeOffset>, <xref:System.DateTime>, and <xref:System.TimeSpan>. These types can be specified by using some of Protobuf's *Well-Known Types* extensions. These extensions provide code generation and runtime support for complex field types across the supported platforms.

The following table shows the date and time types:

| .NET type        | Protobuf Well-Known Type    |
| ---------------- | --------------------------- |
| `DateTimeOffset` | `google.protobuf.Timestamp` |
| `DateTime`       | `google.protobuf.Timestamp` |
| `TimeSpan`       | `google.protobuf.Duration`  |

```protobuf  
syntax = "proto3";

import "google/protobuf/duration.proto";  
import "google/protobuf/timestamp.proto";

message Meeting {
    string subject = 1;
    google.protobuf.Timestamp start = 2;
    google.protobuf.Duration duration = 3;
}  
```

The generated properties in the C# class aren't the .NET date and time types. The properties use the `Timestamp` and `Duration` classes in the `Google.Protobuf.WellKnownTypes` namespace. These classes provide methods for converting to and from `DateTimeOffset`, `DateTime`, and `TimeSpan`.

```csharp
// Create Timestamp and Duration from .NET DateTimeOffset and TimeSpan.
var meeting = new Meeting
{
    Time = Timestamp.FromDateTimeOffset(meetingTime), // also FromDateTime()
    Duration = Duration.FromTimeSpan(meetingLength)
};

// Convert Timestamp and Duration to .NET DateTimeOffset and TimeSpan.
var time = meeting.Time.ToDateTimeOffset();
var duration = meeting.Duration?.ToTimeSpan();
```

> [!NOTE]
> The `Timestamp` type works with UTC times. `DateTimeOffset` values always have an offset of zero, and the `DateTime.Kind` property is always `DateTimeKind.Utc`.

### Nullable types

The Protobuf code generation for C# uses the native types, such as `int` for `int32`. So the values are always included and can't be `null`.

For values that require explicit `null`, such as using `int?` in C# code, Protobuf's Well-Known Types include wrappers that are compiled to nullable C# types. To use them, import `wrappers.proto` into your `.proto` file, like the following code:

```protobuf  
syntax = "proto3";

import "google/protobuf/wrappers.proto";

message Person {
    // ...
    google.protobuf.Int32Value age = 5;
}
```

`wrappers.proto` types aren't exposed in generated properties. Protobuf automatically maps them to appropriate .NET nullable types in C# messages. For example, a `google.protobuf.Int32Value` field generates an `int?` property. Reference type properties like `string` and `ByteString` are unchanged except `null` can be assigned to them without error.

The following table shows the complete list of wrapper types with their equivalent C# type:

| C# type      | Well-Known Type wrapper       |
| ------------ | ----------------------------- |
| `bool?`      | `google.protobuf.BoolValue`   |
| `double?`    | `google.protobuf.DoubleValue` |
| `float?`     | `google.protobuf.FloatValue`  |
| `int?`       | `google.protobuf.Int32Value`  |
| `long?`      | `google.protobuf.Int64Value`  |
| `uint?`      | `google.protobuf.UInt32Value` |
| `ulong?`     | `google.protobuf.UInt64Value` |
| `string`     | `google.protobuf.StringValue` |
| `ByteString` | `google.protobuf.BytesValue`  |

### Bytes

Binary payloads are supported in Protobuf with the `bytes` scalar value type. A generated property in C# uses `ByteString` as the property type.

Use `ByteString.CopyFrom(byte[] data)` to create a new instance from a byte array:

```csharp
var data = await File.ReadAllBytesAsync(path);

var payload = new PayloadResponse();
payload.Data = ByteString.CopyFrom(data);
```

`ByteString` data is accessed directly using `ByteString.Span` or `ByteString.Memory`. Or call `ByteString.ToByteArray()` to convert an instance back into a byte array:

```csharp
var payload = await client.GetPayload(new PayloadRequest());

await File.WriteAllBytesAsync(path, payload.Data.ToByteArray());
```

### Decimals

Protobuf doesn't natively support the .NET `decimal` type, just `double` and `float`. There's an ongoing discussion in the Protobuf project about the possibility of adding a standard decimal type to the Well-Known Types, with platform support for languages and frameworks that support it. Nothing has been implemented yet.

It's possible to create a message definition to represent the `decimal` type that works for safe serialization between .NET clients and servers. But developers on other platforms would have to understand the format being used and implement their own handling for it.

#### Creating a custom decimal type for Protobuf

```protobuf
package CustomTypes;

// Example: 12345.6789 -> { units = 12345, nanos = 678900000 }
message DecimalValue {

    // Whole units part of the amount
    int64 units = 1;

    // Nano units of the amount (10^-9)
    // Must be same sign as units
    sfixed32 nanos = 2;
}
```

The `nanos` field represents values from `0.999_999_999` to `-0.999_999_999`. For example, the `decimal` value `1.5m` would be represented as `{ units = 1, nanos = 500_000_000 }`. This is why the `nanos` field in this example uses the `sfixed32` type, which encodes more efficiently than `int32` for larger values. If the `units` field is negative, the `nanos` field should also be negative.

> [!NOTE]
> Additional algorithms are available for encoding `decimal` values as byte strings. The algorithm used by `DecimalValue`:
> 
> * Is easy to understand.
> * Isn't affected by big-endian or little-endian on different platforms.
> * Supports decimal numbers ranging from positive `9,223,372,036,854,775,807.999999999` to negative `9,223,372,036,854,775,808.999999999` with a maximum precision of nine decimal places, which isn't the full range of a `decimal`.

Conversion between this type and the BCL `decimal` type might be implemented in C# like this:

```csharp
namespace CustomTypes
{
    public partial class DecimalValue
    {
        private const decimal NanoFactor = 1_000_000_000;
        public DecimalValue(long units, int nanos)
        {
            Units = units;
            Nanos = nanos;
        }

        public static implicit operator decimal(CustomTypes.DecimalValue grpcDecimal)
        {
            return grpcDecimal.Units + grpcDecimal.Nanos / NanoFactor;
        }

        public static implicit operator CustomTypes.DecimalValue(decimal value)
        {
            var units = decimal.ToInt64(value);
            var nanos = decimal.ToInt32((value - units) * NanoFactor);
            return new CustomTypes.DecimalValue(units, nanos);
        }
    }
}
```

The preceding code:

* Adds a partial class for `DecimalValue`. The partial class is combined with `DecimalValue` generated from the `.proto` file. The generated class declares the `Units` and `Nanos` properties.
* Has implicit operators for converting between `DecimalValue` and the BCL `decimal` type.

## Collections

### Lists

Lists in Protobuf are specified by using the `repeated` prefix keyword on a field. The following example shows how to create a list:

```protobuf
message Person {
    // ...
    repeated string roles = 8;
}
```

In the generated code, `repeated` fields are represented by the `Google.Protobuf.Collections.RepeatedField<T>` generic type.

```csharp
public class Person
{
    // ...
    public RepeatedField<string> Roles { get; }
}
```

`RepeatedField<T>` implements <xref:System.Collections.Generic.IList%601>. So you can use LINQ queries or convert it to an array or a list. `RepeatedField<T>` properties don't have a public setter. Items should be added to the existing collection.

```csharp
var person = new Person();

// Add one item.
person.Roles.Add("user");

// Add all items from another collection.
var roles = new [] { "admin", "manager" };
person.Roles.Add(roles);
```

### Dictionaries

The .NET <xref:System.Collections.Generic.IDictionary%602> type is represented in Protobuf using `map<key_type, value_type>`.

```protobuf
message Person {
    // ...
    map<string, string> attributes = 9;
}
```

In generated .NET code, `map` fields are represented by the `Google.Protobuf.Collections.MapField<TKey, TValue>` generic type. `MapField<TKey, TValue>` implements <xref:System.Collections.Generic.IDictionary%602>. Like `repeated` properties, `map` properties don't have a public setter. Items should be added to the existing collection.

```csharp
var person = new Person();

// Add one item.
person.Attributes["created_by"] = "James";

// Add all items from another collection.
var attributes = new Dictionary<string, string>
{
    ["last_modified"] = DateTime.UtcNow.ToString()
};
person.Attributes.Add(attributes);
```

## Unstructured and conditional messages

Protobuf is a contract-first messaging format. An app's messages, including its fields and types, must be specified in `.proto` files when the app is built. Protobuf's contract-first design is great at enforcing message content but can limit scenarios where a strict contract isn't required:

* Messages with unknown payloads. For example, a message with a field that could contain any message.
* Conditional messages. For example, a message returned from a gRPC service might be a success result or an error result.
* Dynamic values. For example, a message with a field that contains an unstructured collection of values, similar to JSON.

Protobuf offers language features and types to support these scenarios.

### Any

The `Any` type lets you use messages as embedded types without having their `.proto` definition. To use the `Any` type, import `any.proto`.

```protobuf
import "google/protobuf/any.proto";

message Status {
    string message = 1;
    google.protobuf.Any detail = 2;
}
```

```csharp
// Create a status with a Person message set to detail.
var status = new ErrorStatus();
status.Detail = Any.Pack(new Person { FirstName = "James" });

// Read Person message from detail.
if (status.Detail.Is(Person.Descriptor))
{
    var person = status.Detail.Unpack<Person>();
    // ...
}
```

### Oneof

`oneof` fields are a language feature. The compiler handles the `oneof` keyword when it generates the message class. Using `oneof` to specify a response message that could either return a `Person` or `Error` might look like this:

```protobuf
message Person {
    // ...
}

message Error {
    // ...
}

message ResponseMessage {
  oneof result {
    Error error = 1;
    Person person = 2;
  }
}
```

Fields within the `oneof` set must have unique field numbers in the overall message declaration.

When using `oneof`, the generated C# code includes an enum that specifies which of the fields has been set. You can test the enum to find which field is set. Fields that aren't set return `null` or the default value, rather than throwing an exception.

```csharp
var response = await client.GetPersonAsync(new RequestMessage());

switch (response.ResultCase)
{
    case ResponseMessage.ResultOneofCase.Person:
        HandlePerson(response.Person);
        break;
    case ResponseMessage.ResultOneofCase.Error:
        HandleError(response.Error);
        break;
    default:
        throw new ArgumentException("Unexpected result.");
}
```

### Value

The `Value` type represents a dynamically typed value. It can be either `null`, a number, a string, a boolean, a dictionary of values (`Struct`), or a list of values (`ValueList`). `Value` is a Protobuf Well-Known Type that uses the previously discussed `oneof` feature. To use the `Value` type, import `struct.proto`.

```protobuf
import "google/protobuf/struct.proto";

message Status {
    // ...
    google.protobuf.Value data = 3;
}
```

```csharp
// Create dynamic values.
var status = new Status();
status.Data = Value.ForStruct(new Struct
{
    Fields =
    {
        ["enabled"] = Value.ForBool(true),
        ["metadata"] = Value.ForList(
            Value.ForString("value1"),
            Value.ForString("value2"))
    }
});

// Read dynamic values.
switch (status.Data.KindCase)
{
    case Value.KindOneofCase.StructValue:
        foreach (var field in status.Data.StructValue.Fields)
        {
            // Read struct fields...
        }
        break;
    // ...
}
```

Using `Value` directly can be verbose. An alternative way to use `Value` is with Protobuf's built-in support for mapping messages to JSON. Protobuf's `JsonFormatter` and `JsonWriter` types can be used with any Protobuf message. `Value` is particularly well suited to being converted to and from JSON.

This is the JSON equivalent of the previous code:

```csharp
// Create dynamic values from JSON.
var status = new Status();
status.Data = Value.Parser.ParseJson(@"{
    ""enabled"": true,
    ""metadata"": [ ""value1"", ""value2"" ]
}");

// Convert dynamic values to JSON.
// JSON can be read with a library like System.Text.Json or Newtonsoft.Json
var json = JsonFormatter.Default.Format(status.Data);
var document = JsonDocument.Parse(json);
```

## Additional resources

* [Protobuf language guide](https://developers.google.com/protocol-buffers/docs/proto3#simple)
* <xref:grpc/versioning>
