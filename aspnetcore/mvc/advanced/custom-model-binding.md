---
title: Custom Model Binding | Microsoft Docs
author: ardalis
description: Customizing model binding in ASP.NET Core MVC.
keywords: ASP.NET Core, model binding, custom model binder
ms.author: riande
manager: wpickett
ms.date: 4/10/2017
ms.topic: article
ms.assetid: ebd98159-a028-4a94-b06c-43981c79c6be
ms.technology: aspnet
ms.prod: asp.net-core
uid: mvc/advanced/custom-model-binding
---
# Custom Model Binding

By [Steve Smith](http://ardalis.com)

Model binding allows controller actions to work directly with model types, passed in as method arguments, rather than HTTP requests. Repetitive mapping between incoming request data and application models is consolidated into model binders. Developers can extend the built-in model binding functionality by implementing custom model binders.

[View or download sample from GitHub](https://github.com/aspnet/Docs/)

## The problem

The build-in model binding supports simple types such as strings, integers, floats, DateTimes, and more. In addition, model binding works with classes that have properties comprised of these primitive types. However, the default model binders expect to bind text-based input from the request directly to model types. You might need to transform the input prior to binding it, such as if the input is encoded in some manner. Two examples of such encoding are

- Input is encoded as a Base64 string and must be decoded prior to being mapped to a model
- Input represents a key that can be used to look up model data from a data store; binder must fetch data based on key and pass result as action argument(s)

## The solution

Both of these problems can be solved with custom model binders. A custom model binder for working with byte arrays already exists in ASP.NET Core MVC; a binder that fetches results from a data store does not. You will see how to create one in this article.

## Working with the ByteArrayModelBinder

## Implementing a custom model binder

## Recommendations and best practices


> [!NOTE]
> This is a note example.

Copy the `IFormFile` to a stream and save it to the byte array:

```csharp
// POST: /Account/Register
[HttpPost]
[AllowAnonymous]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Register(RegisterViewModel model)
{
    ViewData["ReturnUrl"] = returnUrl;
    if  (ModelState.IsValid)
    {
        var user = new ApplicationUser {
          UserName = model.Email,
          Email = model.Email
        };
        using (var memoryStream = new MemoryStream())
        {
            await model.AvatarImage.CopyToAsync(memoryStream);
            user.AvatarImage = memoryStream.ToArray();
        }
    // additional logic omitted
    
    // Don't rely on or trust the model.AvatarImage.FileName property 
    // without validation.
}
```
