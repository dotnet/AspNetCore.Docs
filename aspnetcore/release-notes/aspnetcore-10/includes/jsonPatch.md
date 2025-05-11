### New JsonPatch Implementation with System.Text.Json

**[JSON Patch](https://jsonpatch.com/)**:

* Is a standard format for describing changes to apply to a JSON document.
* Is defined in [RFC 6902] and is widely used in RESTful APIs to perform partial updates to JSON resources.
* Represents a sequence of operations (for example, Add, Remove, Replace, Move, Copy, Test) that can be applied to modify a JSON document.

In web apps, JSON Patch is commonly used in a PATCH operation to perform partial updates of a resource. Rather than sending the entire resource for an update, clients can send a JSON Patch document containing only the changes. Patching reduces payload size and improves efficiency.

[RFC 6902]: https://tools.ietf.org/html/rfc6902

This release introduces a new implementation of [`JsonPatch`](/dotnet/api/system.text.json based on `System.Text.Json` serialization. This feature:

* Aligns with modern .NET practices by leveraging the `System.Text.Json` library, which is optimized for .NET.
* Provides improved performance and reduced memory usage compared to the legacy `Newtonsoft.Json`-based implementation.

The following benchmarks compare the performance of the new `System.Text.Json` implementation with the legacy `Newtonsoft.Json` implementation:

| Scenario                   | Implementation         | Mean       | Allocated Memory |
|----------------------------|------------------------|------------|------------------|
| **Application Benchmarks** | Newtonsoft.JsonPatch   | 271.924 µs | 25 KB            |
|                            | System.Text.JsonPatch  | 1.584 µs   | 3 KB             |
| **Deserialization Benchmarks** | Newtonsoft.JsonPatch | 19.261 µs  | 43 KB            |
|                            | System.Text.JsonPatch  | 7.917 µs   | 7 KB             |

These benchmarks highlight significant performance gains and reduced memory usage with the new implementation.

Notes:
 * The new implementation isn't a drop-in replacement for the legacy implementation. In particular:
   * The new implementation doesn't support dynamic types, for example, [`ExpandoObject`](/dotnet/api/system.dynamic.expandoobject.
 * The JSON Patch standard has ***inherent security risks***. Since these risks are inherent to the JSON Patch standard, the new implementation ***doesn't attempt to mitigate inherent security risks***. It's the responsibility of the developer to ensure that the JSON Patch document is safe to apply to the target object. For more information, see the [Mitigating Security Risks](#mitigating-security-risks) section.

#### Usage

To enable JSON Patch support with `System.Text.Json`, install the [`Microsoft.AspNetCore.JsonPatch.SystemTextJson`](https://www.nuget.org/packages/Microsoft.AspNetCore.JsonPatch/) NuGet package.

```sh
dotnet add package Microsoft.AspNetCore.JsonPatch.SystemTextJson --prerelease
```

This package provides a `JsonPatchDocument<T>` class to represent a JSON Patch document for objects of type `T` and custom logic for serializing and deserializing JSON Patch documents using `System.Text.Json`. The key method of the `JsonPatchDocument<T>` class is `ApplyTo`, which applies the patch operations to a target object of type `T`.

The following examples demonstrate how to use the `ApplyTo` method to apply a JSON Patch document to an object.

#### Example: Applying a JsonPatchDocument

The following example demonstrates:

1. The `add`, `replace`, and `remove` operations.
2. Operations on nested properties.
3. Adding a new item to an array.
4. Using a JSON String Enum Converter in a JSON patch document.

```csharp
// Original object
var person = new Person {
    FirstName = "John",
    LastName = "Doe",
    Email = "johndoe@gmail.com",
    PhoneNumbers = [new() {Number = "123-456-7890", Type = PhoneNumberType.Mobile}],
    Address = new Address
    {
        Street = "123 Main St",
        City = "Anytown",
        State = "TX"
    }
};

// Raw JSON patch document
string jsonPatch = """
[
    { "op": "replace", "path": "/FirstName", "value": "Jane" },
    { "op": "remove", "path": "/Email"},
    { "op": "add", "path": "/Address/ZipCode", "value": "90210" },
    { "op": "add", "path": "/PhoneNumbers/-", "value": { "Number": "987-654-3210", "Type": "Work" } }
]
""";

// Deserialize the JSON patch document
var patchDoc = JsonSerializer.Deserialize<JsonPatchDocument<Person>>(jsonPatch);

// Apply the JSON patch document
patchDoc!.ApplyTo(person);

// Output updated object
Console.WriteLine(JsonSerializer.Serialize(person, serializerOptions));

// Output:
// {
//   "firstName": "Jane",
//   "lastName": "Doe",
//   "address": {
//     "street": "123 Main St",
//     "city": "Anytown",
//     "state": "TX",
//     "zipCode": "90210"
//   },
//   "phoneNumbers": [
//     {
//       "number": "123-456-7890",
//       "type": "Mobile"
//     },
//     {
//       "number": "987-654-3210",
//       "type": "Work"
//     }
//   ]
// }
```

The `ApplyTo` method generally follows the conventions and options of `System.Text.Json` for processing the `JsonPatchDocument`, including the behavior controlled by the following options:

* `NumberHandling`: Whether numeric properties can be read from strings.
* `PropertyNameCaseInsensitive`: Whether property names are case-sensitive.

Key differences between `System.Text.Json` and the new `JsonPatchDocument<T>` implementation:

* The runtime type of the target object, not the declared type, determines which   properties `ApplyTo` patches.
* `System.Text.Json` deserialization relies on the declared type to identify eligible properties.

#### Example: Applying a JsonPatchDocument with error handling

There are various errors that can occur when applying a JSON Patch document. For example, the target object may not have the specified property, or the value specified might be incompatible with the property type.

JSON `Patch` also supports the `test` operation. The `test` operation checks if a specified value is equal to the target property, and if not, returns an error.

The following example demonstrates how to handle these errors gracefully.

> Important: The object passed to the `ApplyTo` method is modified in place. It is the caller's responsiblity to discard these changes if any operation fails.

```csharp
// Original object
var person = new Person {
    FirstName = "John",
    LastName = "Doe",
    Email = "johndoe@gmail.com"
};

// Raw JSON patch document
string jsonPatch = """
[
    { "op": "replace", "path": "/Email", "value": "janedoe@gmail.com"},
    { "op": "test", "path": "/FirstName", "value": "Jane" },
    { "op": "replace", "path": "/LastName", "value": "Smith" }
]
""";

// Deserialize the JSON patch document
var patchDoc = JsonSerializer.Deserialize<JsonPatchDocument<Person>>(jsonPatch);

// Apply the JSON patch document, catching any errors
Dictionary<string, string[]>? errors = null;
patchDoc!.ApplyTo(person, jsonPatchError =>
    {
        errors ??= new ();
        var key = jsonPatchError.AffectedObject.GetType().Name;
        if (!errors.ContainsKey(key))
        {
            errors.Add(key, new string[] { });
        }
        errors[key] = errors[key].Append(jsonPatchError.ErrorMessage).ToArray();
    });
if (errors != null)
{
    // Print the errors
    foreach (var error in errors)
    {
        Console.WriteLine($"Error in {error.Key}: {string.Join(", ", error.Value)}");
    }
}

// Output updated object
Console.WriteLine(JsonSerializer.Serialize(person, serializerOptions));

// Output:
// Error in Person: The current value 'John' at path 'FirstName' is not equal to the test value 'Jane'.
// {
//   "firstName": "John",
//   "lastName": "Smith",              <<< Modified!
//   "email": "janedoe@gmail.com",     <<< Modified!
//   "phoneNumbers": []
// }
```

#### Mitigating security risks

When using the `Microsoft.AspNetCore.JsonPatch.SystemTextJson` package, it's critical to understand and mitigate potential security risks. The following sections outline the identified security risks associated with JSON Patch and provide recommended mitigations to ensure secure usage of the package.

> [!IMPORTANT]
> ***This is not an exhaustive list of threats.*** app developers must conduct their own threat model reviews to determine an app-specific comprehensive list and come up with appropriate mitigations as needed. For example, apps which expose collections to patch operations should consider the potential for algorithmic complexity attacks if those operations insert or remove elements at the beginning of the collection.

By running comprehensive threat models for their own apps and addressing identified threats while following the recommended mitigations below, consumers of these packages can <!-- review removing safely --> integrate JSON Patch functionality into their apps while minimizing security risks.

Consumers of these packages can integrate JSON Patch functionality into their apps while minimizing security risks, including:

* Run comprehensive threat models for their own apps.
* Address identified threats.
* Follow the recommended mitigations in the following sections.

##### Denial of Service (DoS) via memory amplification

* **Scenario**: A malicious client submits a `copy` operation that duplicates large object graphs multiple times, leading to excessive memory consumption.
* **Impact**: Potential Out-Of-Memory (OOM) conditions, causing service disruptions.
* **Mitigation**:
  * Validate incoming JSON Patch documents for size and structure <!-- review my removing: before applying the document --> before calling `ApplyTo`.
  * The validation needs to be app specific, but an example validation can look similar to the following:

```csharp
public void Validate(JsonPatchDocument<T> patch)
{
    // This is just an example. It's up to the developer to make sure that this case is handled properly, based on the app needs.
    if (patch.Operations.Where(op=>op.OperationType == OperationType.Copy).Count() > MaxCopyOperationsCount)
    {
        throw new InvalidOperationException();
    }
}
```

##### Business Logic Subversion

* **Scenario**: Patch operations can manipulate fields with implicit invariants, (e.g., internal flags, IDs, or computed fields), violating business constraints.
* **Impact**: Data integrity issues and unintended app behavior.
* **Mitigation**:
  * Use POCO objects with explicitly defined properties that are safe to modify.
  * Avoid exposing sensitive or security-critical properties in the target object.
  * If no POCO object is used, validate the patched object after applying operations to ensure business rules and invariants aren't violated.

##### Authentication and authorization

* **Scenario**: Unauthenticated or unauthorized clients send malicious JSON Patch requests.
* **Impact**: Unauthorized access to modify sensitive data or disrupt app behavior.
* **Mitigation**:
  * Protect endpoints accepting JSON Patch requests with proper authentication and authorization mechanisms.
  * Restrict access to trusted clients or users with appropriate permissions.
