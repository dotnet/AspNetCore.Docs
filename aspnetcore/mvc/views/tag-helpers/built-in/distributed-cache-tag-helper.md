---
title: Distributed Cache Tag Helper in ASP.NET Core
author: pkellner
description: Learn how to use the Distributed Cache Tag Helper.
ms.author: riande
ms.date: 02/14/2017
uid: mvc/views/tag-helpers/builtin-th/distributed-cache-tag-helper
---
# Distributed Cache Tag Helper in ASP.NET Core

By [Peter Kellner](http://peterkellner.net) 

The Distributed Cache Tag Helper provides the ability to dramatically improve the performance of your ASP.NET Core app by caching its content to a distributed cache source.

The Distributed Cache Tag Helper inherits from the same base class as the Cache Tag Helper. All attributes associated with the Cache Tag Helper will also work on the Distributed Tag Helper.

The Distributed Cache Tag Helper follows the **Explicit Dependencies Principle** known as **Constructor Injection**. Specifically, the `IDistributedCache` interface container is passed into the Distributed Cache Tag Helper's constructor. If no specific concrete implementation of `IDistributedCache` has been created in `ConfigureServices`, usually found in startup.cs, then the Distributed Cache Tag Helper will use the same in-memory provider for storing cached data as the basic Cache Tag Helper.

## Distributed Cache Tag Helper Attributes

- - -

### enabled expires-on expires-after expires-sliding vary-by-header vary-by-query vary-by-route vary-by-cookie vary-by-user vary-by priority

See Cache Tag Helper for definitions. Distributed Cache Tag Helper inherits from the same class as Cache Tag Helper so all these attributes are common from Cache Tag Helper.

- - -

### name (required)

| Attribute Type 	| Example Value   	|
|----------------	|----------------	|
| string    | "my-distributed-cache-unique-key-101" 	|

The required `name` attribute is used as a key to that cache stored for each instance of a Distributed Cache Tag Helper. Unlike the basic Cache Tag Helper that assigns a key to each Cache Tag Helper instance based on the Razor page name and location of the Tag Helper in the razor page, the Distributed Cache Tag Helper only bases its key on the attribute `name`

Usage Example:

```cshtml
<distributed-cache name="my-distributed-cache-unique-key-101">
    Time Inside Cache Tag Helper: @DateTime.Now
</distributed-cache>
```

## Distributed Cache Tag Helper IDistributedCache implementations

There are two implementations of `IDistributedCache` built in to ASP.NET Core. One is based on SQL Server and the other is based on Redis. Details of these implementations can be found at <xref:performance/caching/distributed>. Both implementations involve setting an instance of `IDistributedCache` in ASP.NET Core's *Startup.cs*.

There are no tag attributes specifically associated with using any specific implementation of `IDistributedCache`.

## Additional resources

* <xref:mvc/views/tag-helpers/builtin-th/cache-tag-helper>
* <xref:fundamentals/dependency-injection>
* <xref:performance/caching/distributed>
* <xref:performance/caching/memory>
* <xref:security/authentication/identity>
