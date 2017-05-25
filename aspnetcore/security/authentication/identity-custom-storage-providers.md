---
title: Custom storage providers for ASP.NET Core Identity | Microsoft Docs
author: ardalis
description: How to configure custom storage providers for ASP.NET Core Identity.
keywords: ASP.NET Core, Identity, custom storage providers
ms.author: riande
manager: wpickett
ms.date: 05/24/2017
ms.topic: article
ms.assetid: b2ace545-ecf6-4664-b31e-b65bd4a6b025
ms.technology: aspnet
ms.prod: asp.net-core
uid: security/authentication/identity-custom-storage-providers
---
# Custom storage providers for ASP.NET Core Identity

By [Steve Smith](http://ardalis.com)

ASP.NET Core Identity is an extensible system which enables you to create your own storage provider and plug it into your application without re-working the application. This topic describes how to create a customized storage provider for ASP.NET Core Identity. It covers the important concepts for creating your own storage provider, but it is not step-by-step walkthrough of implementing a custom storage provider.

[View or download sample from GitHub](https://github.com/aspnet/Docs/tree/master/aspnetcore/security/authentication/identity/sample).

## Introduction

By default, the ASP.NET Core Identity system stores user information in a SQL Server database, and uses Entity Framework Core to create the database. For many applications, this approach works well. However, you may prefer to use a different type of persistence mechanism, such as Azure Table Storage, or you may already have database tables with a very different structure than the default implementation. In either case, you can write a customized provider for your storage mechanism and plug that provider into your application.

ASP.NET Core Identity is included in application templates in Visual Studio when the "Indvidual User Accoutns" option is chosen:

(show screenshot)

When using the dotnet CLI, you can include ASP.NET Core Identity by adding the -au or --auth option and specifying Individual:

```
dotnet new mvc -au Individual
dotnet new webapi -au Individual
```

## Understand the architecture

ASP.NET Core Identity consists of classes called managers and stores. Managers are high-level classes which an application developer uses to perform operations, such as creating a user, in the ASP.NET Core Identity system. Stores are lower-level classes that specify how entities, such as users and roles, are persisted. Stores follow the [repository pattern](http://deviq.com/repository-pattern/) and are closely coupled with the persistence mechanism, but managers are decoupled from stores which means you can replace the persistence mechanism without disrupting the entire application.

The following diagram shows how your web application interacts with the managers, and stores interact with the data access layer.

(update screenshot to say ASP.NET Core Apps)
![ASP.NET Core Apps work with Managers (for example, UserManager, RoleManager). Managers work with Stores (for example, UserStore) which communicate with a Data Source using a library like Entity Framework Core.](identity/_static/identity-architecture-diagram.png)

To create a custom storage provider for ASP.NET Core Identity, you have to create the data source, the data access layer, and the store classes that interact with this data access layer. You can continue using the same manager APIs to perform data operations on the user but now that data is saved to a different storage system.

You do not need to customize the manager classes because when creating a new instance of UserManager or RoleManager you provide the type of the user class and pass an instance of the store class as an argument. This approach enables you to plug your customized classes into the existing structure. You will see how to instantiate UserManager and RoleManager with your customized store classes in the section Reconfigure application to use new storage provider (TODO: link).

## Understand the data that is stored

To implement a custom storage provider, you should understand the types of data used with ASP.NET Core Identity. This will help you decide which features are relevant to your application. ASP.NET Core stores details about the four different data types shown below.

### Users

Registered users of your web site, including the user Id and user name. May include a hashed password if users log in with credentials that are specific to your site (rather than using credentials from an external site like Facebook), and security stamp to indicate whether anything has changed in the user credentials. May also include email address, phone number, whether two factor authentication is enabled, the current number of failed logins, and whether an account has been locked.

### User Claims

A set of statements (or claims) about the user that represent the user's identity. Can enable greater expression of the user's identity than can be achieved through roles.

### User Logins

Information about the external authentication provider (like Facebook) to use when logging in a user.

### Roles

Authorization groups for your site. Includes the role Id and role name (like "Admin" or "Employee").

## Create the data access layer

This topic assumes you are familiar with the persistence mechanism that you are going to use and how to create entities for that mechanism. This topic does not provide details about how to create the repositories or data access classes; instead, it provides some suggestions about the design decisions you need to make when working with ASP.NET Core Identity.

You have a lot of freedom when designing the data access layer for a customized store provider. You only need to create persistence mechanisms for features that you intend to use in your application. For example, if you are not using roles in your application, you do not need to create storage for roles or user roles. Your technology and existing infrastructure may require a structure that is very different from the default implementation of ASP.NET Core Identity. In your data access layer, you provide the logic to work with the structure of your storage implementation.

For a MySQL implemention of data repositories for ASP.NET Core Identity, see [MySQLIdentity.sql](https://aspnet.codeplex.com/SourceControl/latest#Samples/Identity/AspNet.Identity.MySQL/MySQLIdentity.sql). TODO: Does this work with ASP.NET Core Identity? Most likely not. Is there an updated example? Possibly use Azure Storage as our sample. Open source example here: https://github.com/dlmelendez/identityazuretable/tree/master/src/ElCamino.AspNetCore.Identity.AzureTable

In the data access layer, you provide the logic to save the data from ASP.NET Core Identity to your data source. The data access layer for your customized storage provider might include the following classes to store user and role information.

### Context class

Encapsulates the information to connect to your persistence mechanism and execute queries. This class is central to your data access layer. The other data classes will require an instance of this class to perform their operations. You will also initialize your store classes with an instance of this class.

### User Storage

Stores and retrieves user information (such as user name and password hash).

### Role Storage

Stores and retrieves role information (such as the role name).	

### UserClaims Storage

Stores and retrieves user claim information (such as the claim type and value).

### UserLogins Storage

Stores and retrieves user login information (such as an external authentication provider).	

### UserRole Storage

Stores and retrieves which roles are assigned to which users.

[!TIP] Only implement the classes you intend to use in your app.

In the data access classes, you provide code to perform data operations for your particular persistence mechanism. For example, within the Azure Table implementation, the UserTable class contains a method to insert a new record into the Users table in Azure Storage. The variable named _context is an instance of the `IdentityCloudContext` class.

(show code example for an Insert method)

After creating your data access classes, you must create store classes that call the specific methods in the data access layer.

## Customize the user class

When implementing your own storage provider, you must create a user class which is equivalent to the [`IdentityUser` class](https://docs.microsoft.com/aspnet/core/api/microsoft.aspnet.identity.corecompat.identityuser).

At a minimum your user class must include an `Id` and a `UserName` property.

The `IUser<TKey>` interface defines the properties that the `UserManager` attempts to call when performing requested operations. The interface contains two properties: `Id` and `UserName`. The `IUser<TKey>` interface enables you to specify the type of the key for the user through the generic `TKey` parameter. The type of the `Id` property matches the value of the `TKey` parameter.

The ASP.NET Core Identity framework also provides the `IUser` interface (without the generic parameter) when you want to use a string value for the key.

The `IdentityUser` class implements `IUser` and contains any additional properties or constructors for users on your web site. The following example shows an `IdentityUser` class that uses an integer for the key. The `Id` field is set to `int` to match the value of the generic parameter.

## References

- [Custom Storage Providers for ASP.NET Identity](https://docs.microsoft.com/en-us/aspnet/identity/overview/extensibility/overview-of-custom-storage-providers-for-aspnet-identity)