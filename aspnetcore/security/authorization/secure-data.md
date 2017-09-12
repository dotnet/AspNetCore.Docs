---
title: Create an ASP.NET Core app with user data protected by authorization
author: rick-anderson
keywords: ASP.NET Core, MVC, authorization, roles, security, administrator
ms.author: riande
manager: wpickett
ms.date: 05/22/2017
ms.topic: article
ms.assetid: abeb2f8e-dfbf-4398-a04c-338a613a65bc
ms.technology: aspnet
ms.prod: aspnet-core
uid: security/authorization/secure-data
---

# Create an ASP.NET Core app with user data protected by authorization

By [Rick Anderson](https://twitter.com/RickAndMSFT) and [Joe Audette](https://twitter.com/joeaudette)

This tutorial shows how to create a web app with user data protected by authorization. It  displays a list of contacts that authenticated (registered) users have created. There are three security groups:

* Registered users can view all the approved contact data.
* Registered users can edit/delete their own data. 
* Managers can approve or reject contact data. Only approved contacts are visible to users.
* Administrators can approve/reject and edit/delete any data.

In the following image, user Rick (`rick@example.com`) is signed in. User Rick can only view approved contacts and edit/delete his contacts. Only the last record, created by Rick, displays edit and delete links

![image described above](secure-data/_static/rick.png)

In the following image, `manager@contoso.com` is signed in and in the managers role. 

![image described above](secure-data/_static/manager1.png)

The following image shows the  managers details view of a contact.

![image described above](secure-data/_static/manager.png)

Only managers and administrators have the approve and reject buttons.

In the following image, `admin@contoso.com` is signed in and in the administrator’s role. 

![image described above](secure-data/_static/admin.png)

The administrator has all privileges. She can read/edit/delete any contact and change the status of contacts.

The app was created by [scaffolding](xref:tutorials/first-mvc-app-xplat/adding-model#scaffold-the-moviecontroller)  the following `Contact` model:

[!code-csharp[Main](secure-data/samples/starter/Models/Contact.cs?name=snippet1)]

A `ContactIsOwnerAuthorizationHandler` authorization handler ensures that a user can only edit their data. A `ContactManagerAuthorizationHandler` authorization handler allows managers to approve or reject contacts.  A `ContactAdministratorsAuthorizationHandler` authorization handler allows administrators to approve or reject contacts and to edit/delete contacts. 

## Prerequisites

This is not a beginning tutorial. You should be familiar with:

* [ASP.NET Core MVC](xref:tutorials/first-mvc-app/start-mvc)
* [Entity Framework Core](xref:data/ef-mvc/intro)

## The starter and completed app

[Download](xref:tutorials/index#how-to-download-a-sample) the [completed](https://github.com/aspnet/Docs/tree/master/aspnetcore/security/authorization/secure-data/samples/final) app. [Test](#test-the-completed-app) the completed app so you become familiar with its security features. 

### The starter app

It's helpful to compare your code with the completed sample.

[Download](xref:tutorials/index#how-to-download-a-sample) the [starter](https://github.com/aspnet/Docs/tree/master/aspnetcore/security/authorization/secure-data/samples/starter) app. 

See [Create the starter app](#create-the-starter-app) if you'd like to create it from scratch.

Update the database:

```none
   dotnet ef database update
```

Run the app, tap the **ContactManager** link, and verify you can create, edit, and delete a contact.

This tutorial has all the major steps to create the secure user data app. You may find it helpful to refer to the completed project.

## Modify the app to secure user data

The following sections have all the major steps to create the secure user data app. You may find it helpful to refer to the completed project.

### Tie the contact data to the user

Use the ASP.NET [Identity](xref:security/authentication/identity) user ID to ensure users can edit their data, but not other users data. Add `OwnerID` to the `Contact` model:

[!code-csharp[Main](secure-data/samples/final/Models/Contact.cs?name=snippet1&highlight=5-6,16-)]

`OwnerID` is the user's ID from the `AspNetUser` table in the [Identity](xref:security/authentication/identity) database. The `Status` field determines if a contact is viewable by general users. 

Scaffold a new migration and update the database:

```console
dotnet ef migrations add userID_Status
dotnet ef database update
 ```

### Require SSL and authenticated users

In the `ConfigureServices` method of the *Startup.cs* file, add the [RequireHttpsAttribute](https://docs.microsoft.com/aspnet/core/api) authorization filter:

[!code-csharp[Main](secure-data/samples/final/Startup.cs?name=snippet_SSL&highlight=1)]

If you're using Visual Studio, see [Set up IIS Express for SSL/HTTPS](xref:security/enforcing-ssl#set-up-iis-express-for-sslhttps). To redirect HTTP requests to HTTPS, see [URL Rewriting Middleware](xref:fundamentals/url-rewriting). If you are using Visual Studio Code or testing on local platform that doesn't include a test certificate for SSL:

- Set `"LocalTest:skipSSL": true` in the *appsettings.json* file.

### Require authenticated users

Set the default authentication policy to require users to be authenticated. You can opt out of authentication at the controller or action method with the `[AllowAnonymous]` attribute. With this approach, any new controllers added will automatically require authentication, which is safer than relying on new controllers to include the `[Authorize]` attribute. Add the following to  the `ConfigureServices` method of the *Startup.cs* file:

[!code-csharp[Main](secure-data/samples/final/Startup.cs?name=snippet_defaultPolicy)]

Add `[AllowAnonymous]` to the home controller so anonymous users can get information about the site before they register.

[!code-csharp[Main](secure-data/samples/final/Controllers/HomeController.cs?name=snippet1&highlight=2,6)]

### Configure the test account

The `SeedData` class creates two accounts,  administrator and manager. Use the [Secret Manager tool](xref:security/app-secrets) to set a password for these accounts. Do this from the project directory (the directory containing *Program.cs*).

```console
dotnet user-secrets set SeedUserPW <PW>
```

Update `Configure` to use the test password:

[!code-csharp[Main](secure-data/samples/final/Startup.cs?name=Configure&highlight=19-21)]

Add the administrator user ID and `Status = ContactStatus.Approved` to the contacts. Only one contact is shown, add the user ID to all contacts:

[!code-csharp[Main](secure-data/samples/final/Data/SeedData.cs?name=snippet1&highlight=17,18)]

## Create owner, manager, and administrator authorization handlers

Create a `ContactIsOwnerAuthorizationHandler` class in the  *Authorization* folder. The `ContactIsOwnerAuthorizationHandler` will verify the user acting on the resource owns the resource.

[!code-csharp[Main](secure-data/samples/final/Authorization/ContactIsOwnerAuthorizationHandler.cs)]

The `ContactIsOwnerAuthorizationHandler` calls `context.Succeed` if the current authenticated user is the contact owner. Authorization handlers generally return `context.Succeed` when the requirements are met. They return `Task.FromResult(0)` when requirements are not met. `Task.FromResult(0)` is neither success or failure, it allows other authorization handler to run. If you need to explicitly fail, return `context.Fail()`.

We allow contact owners to edit/delete their own data, so we don't need to check the operation passed in the requirement parameter.

### Create a manager authorization handler

Create a `ContactManagerAuthorizationHandler` class in the  *Authorization* folder. The `ContactManagerAuthorizationHandler` will verify the user acting on the resource is a manager. Only managers can approve or reject content changes (new or changed).

[!code-csharp[Main](secure-data/samples/final/Authorization/ContactManagerAuthorizationHandler.cs)]

### Create an administrator authorization handler

Create a `ContactAdministratorsAuthorizationHandler` class in the  *Authorization* folder. The `ContactAdministratorsAuthorizationHandler` will verify the user acting on the resource is a administrator. Administrator can do all operations.

[!code-csharp[Main](secure-data/samples/final/Authorization/ContactAdministratorsAuthorizationHandler.cs)]

## Register the authorization handlers

Services using Entity Framework Core must be registered for [dependency injection](xref:fundamentals/dependency-injection) using [AddScoped](https://docs.microsoft.com/aspnet/core/api). The `ContactIsOwnerAuthorizationHandler` uses ASP.NET Core [Identity](xref:security/authentication/identity), which is built on Entity Framework Core. Register the handlers with the service collection so they will be available to the `ContactsController` through [dependency injection](xref:fundamentals/dependency-injection). Add the following code to the end of `ConfigureServices`:

[!code-csharp[Main](secure-data/samples/final/Startup.cs?name=AuthorizationHandlers)]

`ContactAdministratorsAuthorizationHandler` and `ContactManagerAuthorizationHandler` are added as singletons. They are singletons because they don't use EF and all the information needed is in the `Context` parameter of the `HandleRequirementAsync` method.

The complete `ConfigureServices`:

[!code-csharp[Main](secure-data/samples/final/Startup.cs?name=ConfigureServices)]

## Update the code to support authorization

In this section, you update the controller and views and add an operations requirements class.

### Update the Contacts controller

Update the `ContactsController` constructor:

* Add the `IAuthorizationService` service to  access to the authorization handlers. 
* Add the `Identity` `UserManager` service:

[!code-csharp[Main](secure-data/samples/final/Controllers/ContactsController.cs?name=snippet_ContactsControllerCtor)]

### Add a contact operations requirements class

Add the `ContactOperationsRequirements` class to the *Authorization* folder. This class  contain the requirements our app supports:

[!code-csharp[Main](secure-data/samples/final/Authorization/ContactOperations.cs)]

### Update Create

Update the `HTTP POST Create` method to:

* Add the user ID to the `Contact` model.
* Call the authorization handler to verify the user owns the contact.

[!code-csharp[Main](secure-data/samples/final/Controllers/ContactsController.cs?name=snippet_Create)]

### Update Edit

Update both `Edit` methods to use the authorization handler to verify the user owns the contact. Because we are performing resource authorization we cannot use the `[Authorize]` attribute. We don't have access to the resource when attributes are evaluated. Resource based authorization must be imperative. Checks must be performed once we have access to the resource, either by loading it in our controller, or by loading it within the handler itself. Frequently you will access the resource by passing in the resource key.

[!code-csharp[Main](secure-data/samples/final/Controllers/ContactsController.cs?name=snippet_Edit)]

### Update the Delete method

Update both `Delete` methods to use the authorization handler to verify the user owns the contact.

[!code-csharp[Main](secure-data/samples/final/Controllers/ContactsController.cs?name=snippet_Delete)]

## Inject the authorization service into the views

Currently the UI shows edit and delete links for data the user cannot modify. We'll fix that by applying the authorization handler to the views.

Inject the authorization service in the *Views/_ViewImports.cshtml* file so it will be available to all views:

[!code-html[Main](secure-data/samples/final/Views/_ViewImports.cshtml)]

Update the *Views/Contacts/Index.cshtml* Razor view to only display the edit and delete links for users who can edit/delete the contact.

Add `@using ContactManager.Authorization;`

Update the `Edit` and `Delete` links so they are only rendered for users with permission to edit and delete the contact.

[!code-html[Main](secure-data/samples/final/Views/Contacts/Index.cshtml?range=63-84)]

Warning: Hiding links from users that do not have permission to edit or delete data does not secure the app. Hiding links makes the app more user friendly by displaying only valid links. Users can hack the generated URLs to invoke edit and delete operations on data they don't own.  The controller must repeat the access checks to be secure.

### Update the Details view

Update the details view so managers can approve or reject contacts:

[!code-html[Main](secure-data/samples/final/Views/Contacts/Details.cshtml?range=53-)]

## Test the completed app

If you are using Visual Studio Code or testing on local platform that doesn't include a test certificate for SSL:

- Set `"LocalTest:skipSSL": true` in the *appsettings.json* file.

If you have run the app and have contacts, delete all the records in the `Contact` table and restart the app to seed the database. If you are using Visual Studio, you need to exit and restart IIS Express to seed the database.

Register a user to browse the contacts.

An easy way to test the completed app is to launch three different browsers (or incognito/InPrivate versions). In one browser, register a new user, for example, `test@example.com`. Sign in to each browser with a different user. Verify the following:

* Registered users can view all the approved contact data.
* Registered users can edit/delete their own data. 
* Managers can approve or reject contact data. The `Details` view shows **Approve** and **Reject** buttons. 
* Administrators can approve/reject and edit/delete any data.

| User| Options |
| ------------ | ---------|
| test@example.com | Can edit/delete own data |
| manager@contoso.com | Can approve/reject and edit/delete own data  |
| admin@contoso.com | Can edit/delete and approve/reject all data|

Create a contact in the administrators browser. Copy the URL for delete and edit from the administrator contact. Paste these links into the test user's browser to verify the test user cannot perform these operations.

## Create the starter app

Follow these instructions to create the starter app.

* Create an **ASP.NET Core Web Application** using [Visual Studio 2017](https://www.visualstudio.com/) named "ContactManager"

  * Create the app with **Individual User Accounts**.
  * Name it "ContactManager" so your namespace will match the namespace use in the sample.

* Add the following `Contact` model:

  [!code-csharp[Main](secure-data/samples/starter/Models/Contact.cs?name=snippet1)]

* Scaffold the `Contact` model using Entity Framework Core and the `ApplicationDbContext` data context. Accept all the scaffolding defaults. Using `ApplicationDbContext` for the data context class  puts the contact table in the [Identity](xref:security/authentication/identity) database. See [Adding a model](xref:tutorials/first-mvc-app/adding-model) for more information.

* Update the **ContactManager** anchor in the *Views/Shared/_Layout.cshtml* file from `asp-controller="Home"` to `asp-controller="Contacts"` so tapping the **ContactManager** link will invoke the Contacts controller. The original markup:

```html
   <a asp-area="" asp-controller="Home" asp-action="Index" class="navbar-brand">ContactManager</a>
   ```

The updated markup:

```html
   <a asp-area="" asp-controller="Contacts" asp-action="Index" class="navbar-brand">ContactManager</a>
   ```

* Scaffold the initial migration and update the database

```none
   dotnet ef migrations add initial
   dotnet ef database update
   ```

* Test the app by creating, editing and deleting a contact

### Seed the database

Add the `SeedData` class to the *Data* folder. If you've downloaded the sample, you can copy the *SeedData.cs* file to the *Data* folder of the starter project.

[!code-csharp[Main](secure-data/samples/starter/Data/SeedData.cs)]

Add the highlighted code to the end of the `Configure` method in the *Startup.cs* file:

[!code-csharp[Main](secure-data/samples/starter/Startup.cs?name=Configure&highlight=28-)]

Test that the app seeded the database. The seed method does not run if there are any rows in the contact DB.

### Create a class used in the tutorial

* Create a folder named *Authorization*.
* Copy the *Authorization\ContactOperations.cs* file from the completed project download, or copy the following code:

[!code-csharp[Main](secure-data/samples/final/Authorization/ContactOperations.cs)]

<a name=secure-data-add-resources-label></a>

### Additional resources

* [ASP.NET Core Authorization Lab](https://github.com/blowdart/AspNetAuthorizationWorkshop). This lab goes into more detail on the security features introduced in this tutorial.
* [Authorization in ASP.NET Core : Simple, role, claims-based and custom](index.md)
* [Custom Policy-Based Authorization](policies.md)
