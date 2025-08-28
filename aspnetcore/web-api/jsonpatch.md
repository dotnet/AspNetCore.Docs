---
title: JsonPatch in ASP.NET Core web API
author: wadepickett
description: Learn how to handle JSON Patch requests in an ASP.NET Core web API.
monikerRange: '>= aspnetcore-3.1'
ms.author: wpickett
ms.custom: mvc
ms.date: 06/03/2025
uid: web-api/jsonpatch
---
# JSON Patch support in ASP.NET Core web API

:::moniker range=">= aspnetcore-10.0"

This article explains how to handle JSON Patch requests in an ASP.NET Core web API.

JSON Patch support in ASP.NET Core web API is based on <xref:System.Text.Json> serialization, and requires the [`Microsoft.AspNetCore.JsonPatch.SystemTextJson`](https://www.nuget.org/packages/Microsoft.AspNetCore.JsonPatch.SystemTextJson) NuGet package. 

## What is the JSON Patch standard?

The JSON Patch standard:

* Is a standard format for describing changes to apply to a JSON document.
* Is defined in [RFC 6902](https://datatracker.ietf.org/doc/html/rfc6902) and is widely used in RESTful APIs to perform partial updates to JSON resources.
* Describes a sequence of operations that modify a JSON document such as:
  
  * `add`
  * `remove`
  * `replace`
  * `move`
  * `copy`
  * `test`

In web apps, JSON Patch is commonly used in a PATCH operation to perform partial updates of a resource. Rather than sending the entire resource for an update, clients can send a JSON Patch document containing only the changes. Patching reduces payload size and improves efficiency.

For an overview of the JSON Patch standard, see [jsonpatch.com](https://jsonpatch.com/).

## JSON Patch support in ASP.NET Core web API

JSON Patch support in ASP.NET Core web API is based on <xref:System.Text.Json> serialization, starting with .NET 10, implementing <xref:Microsoft.AspNetCore.JsonPatch> based on <xref:System.Text.Json> serialization. This feature:

* Requires the [`Microsoft.AspNetCore.JsonPatch.SystemTextJson`](https://www.nuget.org/packages/Microsoft.AspNetCore.JsonPatch.SystemTextJson) NuGet package. 
* Aligns with modern .NET practices by leveraging the <xref:System.Text.Json> library, which is optimized for .NET.
* Provides improved performance and reduced memory usage compared to the legacy `Newtonsoft.Json`-based implementation. For more information on the legacy `Newtonsoft.Json`-based implementation, see the [.NET 9 version of this article](xref:web-api/jsonpatch?view=aspnetcore-9.0&preserve-view=true).

> [!NOTE]
> The implementation of <xref:Microsoft.AspNetCore.JsonPatch> based on <xref:System.Text.Json?displayProperty=fullName> serialization isn't a drop-in replacement for the legacy `Newtonsoft.Json`-based implementation. It doesn't support dynamic types, for example <xref:System.Dynamic.ExpandoObject>.

> [!IMPORTANT]
> The JSON Patch standard has ***inherent security risks***. Since these risks are inherent to the JSON Patch standard, the ASP.NET Core implementation ***doesn't attempt to mitigate inherent security risks***. It's the responsibility of the developer to ensure that the JSON Patch document is safe to apply to the target object. For more information, see the [Mitigating Security Risks](#mitigating-security-risks) section.

## Enable JSON Patch support with <xref:System.Text.Json>

To enable JSON Patch support with <xref:System.Text.Json>, install the [`Microsoft.AspNetCore.JsonPatch.SystemTextJson`](https://www.nuget.org/packages/Microsoft.AspNetCore.JsonPatch.SystemTextJson) NuGet package.

```dotnetcli
dotnet add package Microsoft.AspNetCore.JsonPatch.SystemTextJson --prerelease
```

This package provides a <xref:Microsoft.AspNetCore.JsonPatch.SystemTextJson.JsonPatchDocument%601> class to represent a JSON Patch document for objects of type `T` and custom logic for serializing and deserializing JSON Patch documents using <xref:System.Text.Json>. The key method of the <xref:Microsoft.AspNetCore.JsonPatch.SystemTextJson.JsonPatchDocument%601> class is <xref:Microsoft.AspNetCore.JsonPatch.SystemTextJson.JsonPatchDocument.ApplyTo(System.Object)>, which applies the patch operations to a target object of type `T`.

## Action method code applying JSON Patch

In an API controller, an action method for JSON Patch:

* Is annotated with the <xref:Microsoft.AspNetCore.Mvc.HttpPatchAttribute> attribute.
* Accepts a <xref:Microsoft.AspNetCore.JsonPatch.SystemTextJson.JsonPatchDocument%601>, typically with [<xref:Microsoft.AspNetCore.Mvc.FromBodyAttribute>](xref:Microsoft.AspNetCore.Mvc.FromBodyAttribute).
* Calls <xref:Microsoft.AspNetCore.JsonPatch.SystemTextJson.JsonPatchDocument.ApplyTo(System.Object)> on the patch document to apply the changes.

### Example Controller Action method:

:::code language="csharp" source="~/web-api/jsonpatch/samples/10.x/JsonPatchSample/Controllers/CustomerController.cs" id="snippet_PatchAction" highlight="1,2,14-19":::

This code from the sample app works with the following `Customer` and `Order` models:

:::code language="csharp" source="~/web-api/jsonpatch/samples/10.x/JsonPatchSample/Models/Customer.cs":::

:::code language="csharp" source="~/web-api/jsonpatch/samples/10.x/JsonPatchSample/Models/Order.cs":::

The sample action method's key steps:

* **Retrieve the Customer**:
  * The method retrieves a `Customer` object from the database `AppDb` using the provided id.
  * If no `Customer` object is found, it returns a `404 Not Found` response.
* **Apply JSON Patch**:
  * The <xref:Microsoft.AspNetCore.JsonPatch.SystemTextJson.JsonPatchDocument.ApplyTo(System.Object)> method applies the JSON Patch operations from the patchDoc to the retrieved `Customer` object.
  * If errors occur during the patch application, such as invalid operations or conflicts, they are captured by an error handling delegate. This delegate adds error messages to the `ModelState` using the type name of the affected object and the error message.
* **Validate ModelState**:
  * After applying the patch, the method checks the `ModelState` for errors.
  * If the `ModelState` is invalid, such as due to patch errors, it returns a `400 Bad Request` response with the validation errors.
* **Return the Updated Customer**:
  * If the patch is successfully applied and the `ModelState` is valid, the method returns the updated `Customer` object in the response.

### Example error response:

The following example shows the body of a `400 Bad Request` response for a JSON Patch operation when the specified path is invalid:

```json
{
  "Customer": [
    "The target location specified by path segment 'foobar' was not found."
  ]
}
```

## Apply a JSON Patch document to an object

The following examples demonstrate how to use the <xref:Microsoft.AspNetCore.JsonPatch.SystemTextJson.JsonPatchDocument.ApplyTo(System.Object)> method to apply a JSON Patch document to an object.

### Example: Apply a <xref:Microsoft.AspNetCore.JsonPatch.SystemTextJson.JsonPatchDocument%601> to an object

The following example demonstrates:

* The `add`, `replace`, and `remove` operations.
* Operations on nested properties.
* Adding a new item to an array.
* Using a JSON String Enum Converter in a JSON patch document.

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
    { "op": "add", "path": "/PhoneNumbers/-", "value": { "Number": "987-654-3210",
                                                                "Type": "Work" } }
]
""";

// Deserialize the JSON patch document
var patchDoc = JsonSerializer.Deserialize<JsonPatchDocument<Person>>(jsonPatch);

// Apply the JSON patch document
patchDoc!.ApplyTo(person);

// Output updated object
Console.WriteLine(JsonSerializer.Serialize(person, serializerOptions));
```

The previous example results in the following output of the updated object:

```output
{
    "firstName": "Jane",
    "lastName": "Doe",
    "address": {
        "street": "123 Main St",
        "city": "Anytown",
        "state": "TX",
        "zipCode": "90210"
    },
    "phoneNumbers": [
        {
            "number": "123-456-7890",
            "type": "Mobile"
        },
        {
            "number": "987-654-3210",
            "type": "Work"
        }
    ]
}
```

The <xref:Microsoft.AspNetCore.JsonPatch.SystemTextJson.JsonPatchDocument.ApplyTo(System.Object)> method generally follows the conventions and options of <xref:System.Text.Json> for processing the <xref:Microsoft.AspNetCore.JsonPatch.SystemTextJson.JsonPatchDocument%601>, including the behavior controlled by the following options:

* <xref:System.Text.Json.Serialization.JsonNumberHandling>: Whether numeric properties are read from strings.
* <xref:System.Text.Json.JsonSerializerOptions.PropertyNameCaseInsensitive>: Whether property names are case-sensitive.

Key differences between <xref:System.Text.Json> and the new <xref:Microsoft.AspNetCore.JsonPatch.SystemTextJson.JsonPatchDocument%601> implementation:

* The runtime type of the target object, not the declared type, determines which properties <xref:Microsoft.AspNetCore.JsonPatch.SystemTextJson.JsonPatchDocument.ApplyTo(System.Object)> patches.
* <xref:System.Text.Json> deserialization relies on the declared type to identify eligible properties.

### Example: Apply a JsonPatchDocument with error handling

There are various errors that can occur when applying a JSON Patch document. For example, the target object may not have the specified property, or the value specified might be incompatible with the property type.

JSON `Patch` supports the `test` operation, which checks if a specified value equals the target property. If it doesn't, it returns an error.

The following example demonstrates how to handle these errors gracefully.

> [!Important]
> The object passed to the <xref:Microsoft.AspNetCore.JsonPatch.SystemTextJson.JsonPatchDocument.ApplyTo(System.Object)> method is modified in place. The caller is responsible for discarding changes if any operation fails.

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
```

The previous example results in the following output:

```output
Error in Person: The current value 'John' at path 'FirstName' is not equal 
to the test value 'Jane'.
{
    "firstName": "John",
    "lastName": "Smith",              <<< Modified!
    "email": "janedoe@gmail.com",     <<< Modified!
    "phoneNumbers": []
}
```

## Mitigating security risks

When using the `Microsoft.AspNetCore.JsonPatch.SystemTextJson` package, it's critical to understand and mitigate potential security risks. The following sections outline the identified security risks associated with JSON Patch and provide recommended mitigations to ensure secure usage of the package.

> [!IMPORTANT]
> ***This is not an exhaustive list of threats.*** App developers must conduct their own threat model reviews to determine an app-specific comprehensive list and come up with appropriate mitigations as needed. For example, apps which expose collections to patch operations should consider the potential for algorithmic complexity attacks if those operations insert or remove elements at the beginning of the collection.

To minimize security risks when integrating JSON Patch functionality into their apps, developers should:

* Run comprehensive threat models for their own apps.
* Address identified threats.
* Follow the recommended mitigations in the following sections.

### Denial of Service (DoS) via memory amplification

* **Scenario**: A malicious client submits a `copy` operation that duplicates large object graphs multiple times, leading to excessive memory consumption.
* **Impact**: Potential Out-Of-Memory (OOM) conditions, causing service disruptions.
* **Mitigation**:
  * Validate incoming JSON Patch documents for size and structure before calling <xref:Microsoft.AspNetCore.JsonPatch.SystemTextJson.JsonPatchDocument.ApplyTo(System.Object)>.
  * The validation must be app specific, but an example validation can look similar to the following:

```csharp
public void Validate(JsonPatchDocument<T> patch)
{
    // This is just an example. It's up to the developer to make sure that
    // this case is handled properly, based on the app needs.
    if (patch.Operations.Where(op=>op.OperationType == OperationType.Copy).Count()
                              > MaxCopyOperationsCount)
    {
        throw new InvalidOperationException();
    }
}
```

### Business Logic Subversion

* **Scenario**: Patch operations can manipulate fields with implicit invariants (for example, internal flags, IDs, or computed fields), violating business constraints.
* **Impact**: Data integrity issues and unintended app behavior.
* **Mitigation**:
  * Use POCOs (Plain Old CLR Objects) with explicitly defined properties that are safe to modify.
    * Avoid exposing sensitive or security-critical properties in the target object.
    * If a POCO object isn't used, validate the patched object after applying operations to ensure business rules and invariants aren't violated.

### Authentication and authorization

* **Scenario**: Unauthenticated or unauthorized clients send malicious JSON Patch requests.
* **Impact**: Unauthorized access to modify sensitive data or disrupt app behavior.
* **Mitigation**:
  * Protect endpoints accepting JSON Patch requests with proper authentication and authorization mechanisms.
  * Restrict access to trusted clients or users with appropriate permissions.

## Get the code

[View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/web-api/jsonpatch/samples). ([How to download](xref:fundamentals/index#how-to-download-a-sample)).

To test the sample, run the app and send HTTP requests with the following settings:

* URL: `http://localhost:{port}/jsonpatch/jsonpatchwithmodelstate`
* HTTP method: `PATCH`
* Header: `Content-Type: application/json-patch+json`
* Body: Copy and paste one of the JSON patch document samples from the *JSON* project folder.

## Additional resources

* [IETF RFC 5789 PATCH method specification](https://tools.ietf.org/html/rfc5789)
* [IETF RFC 6902 JSON Patch specification](https://tools.ietf.org/html/rfc6902)
* [IETF RFC 6901 JSON Pointer](https://tools.ietf.org/html/rfc6901)
* [ASP.NET Core JSON Patch source code](https://github.com/dotnet/AspNetCore/tree/main/src/Features/JsonPatch/src)

:::moniker-end

[!INCLUDE[](~/web-api/jsonpatch/includes/jsonpatch9.md)]
