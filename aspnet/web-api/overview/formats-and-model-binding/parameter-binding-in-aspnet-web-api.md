---
uid: web-api/overview/formats-and-model-binding/parameter-binding-in-aspnet-web-api
title: "Parameter Binding in ASP.NET Web API | Microsoft Docs"
author: MikeWasson
description: ""
ms.author: aspnetcontent
manager: wpickett
ms.date: 07/11/2013
ms.topic: article
ms.assetid: e42c8388-04ed-4341-9fdb-41b1b4c06320
ms.technology: dotnet-webapi
ms.prod: .net-framework
msc.legacyurl: /web-api/overview/formats-and-model-binding/parameter-binding-in-aspnet-web-api
msc.type: authoredcontent
---
Parameter Binding in ASP.NET Web API
====================
by [Mike Wasson](https://github.com/MikeWasson)

When Web API calls a method on a controller, it must set values for the parameters, a process called *binding*. This article describes how Web API binds parameters, and how you can customize the binding process.

By default, Web API uses the following rules to bind parameters:

- If the parameter is a "simple" type, Web API tries to get the value from the URI. Simple types include the .NET [primitive types](https://msdn.microsoft.com/en-us/library/system.type.isprimitive.aspx) (**int**, **bool**, **double**, and so forth), plus **TimeSpan**, **DateTime**, **Guid**, **decimal**, and **string**, *plus* any type with a type converter that can convert from a string. (More about type converters later.)
- For complex types, Web API tries to read the value from the message body, using a [media-type formatter](media-formatters.md).

For example, here is a typical Web API controller method:

[!code-csharp[Main](parameter-binding-in-aspnet-web-api/samples/sample1.cs)]

The *id* parameter is a &quot;simple&quot; type, so Web API tries to get the value from the request URI. The *item* parameter is a complex type, so Web API uses a media-type formatter to read the value from the request body.

To get a value from the URI, Web API looks in the route data and the URI query string. The route data is populated when the routing system parses the URI and matches it to a route. For more information, see [Routing and Action Selection](../web-api-routing-and-actions/routing-and-action-selection.md).

In the rest of this article, I'll show how you can customize the model binding process. For complex types, however, consider using media-type formatters whenever possible. A key principle of HTTP is that resources are sent in the message body, using content negotiation to specify the representation of the resource. Media-type formatters were designed for exactly this purpose.

## Using [FromUri]

To force Web API to read a complex type from the URI, add the **[FromUri]** attribute to the parameter. The following example defines a `GeoPoint` type, along with a controller method that gets the `GeoPoint` from the URI.

[!code-csharp[Main](parameter-binding-in-aspnet-web-api/samples/sample2.cs)]

The client can put the Latitude and Longitude values in the query string and Web API will use them to construct a `GeoPoint`. For example:

`http://localhost/api/values/?Latitude=47.678558&Longitude=-122.130989`

## Using [FromBody]

To force Web API to read a simple type from the request body, add the **[FromBody]** attribute to the parameter:

[!code-csharp[Main](parameter-binding-in-aspnet-web-api/samples/sample3.cs)]

In this example, Web API will use a media-type formatter to read the value of *name* from the request body. Here is an example client request.

[!code-console[Main](parameter-binding-in-aspnet-web-api/samples/sample4.cmd)]

When a parameter has [FromBody], Web API uses the Content-Type header to select a formatter. In this example, the content type is &quot;application/json&quot; and the request body is a raw JSON string (not a JSON object).

At most one parameter is allowed to read from the message body. So this will not work:

[!code-csharp[Main](parameter-binding-in-aspnet-web-api/samples/sample5.cs)]

The reason for this rule is that the request body might be stored in a non-buffered stream that can only be read once.

## Type Converters

You can make Web API treat a class as a simple type (so that Web API will try to bind it from the URI) by creating a **TypeConverter** and providing a string conversion.

The following code shows a `GeoPoint` class that represents a geographical point, plus a **TypeConverter** that converts from strings to `GeoPoint` instances. The `GeoPoint` class is decorated with a **[TypeConverter]** attribute to specify the type converter. (This example was inspired by Mike Stall's blog post [How to bind to custom objects in action signatures in MVC/WebAPI](https://blogs.msdn.com/b/jmstall/archive/2012/04/20/how-to-bind-to-custom-objects-in-action-signatures-in-mvc-webapi.aspx).)

[!code-csharp[Main](parameter-binding-in-aspnet-web-api/samples/sample6.cs)]

Now Web API will treat `GeoPoint` as a simple type, meaning it will try to bind `GeoPoint` parameters from the URI. You don't need to include **[FromUri]** on the parameter.

[!code-csharp[Main](parameter-binding-in-aspnet-web-api/samples/sample7.cs)]

The client can invoke the method with a URI like this:

`http://localhost/api/values/?location=47.678558,-122.130989`

## Model Binders

A more flexible option than a type converter is to create a custom model binder. With a model binder, you have access to things like the HTTP request, the action description, and the raw values from the route data.

To create a model binder, implement the **IModelBinder** interface. This interface defines a single method, **BindModel**:

[!code-csharp[Main](parameter-binding-in-aspnet-web-api/samples/sample8.cs)]

Here is a model binder for `GeoPoint` objects.

[!code-csharp[Main](parameter-binding-in-aspnet-web-api/samples/sample9.cs)]

A model binder gets raw input values from a *value provider*. This design separates two distinct functions:

- The value provider takes the HTTP request and populates a dictionary of key-value pairs.
- The model binder uses this dictionary to populate the model.

The default value provider in Web API gets values from the route data and the query string. For example, if the URI is `http://localhost/api/values/1?location=48,-122`, the value provider creates the following key-value pairs:

- id = &quot;1&quot;
- location = &quot;48,122&quot;

(I'm assuming the default route template, which is &quot;api/{controller}/{id}&quot;.)

The name of the parameter to bind is stored in the **ModelBindingContext.ModelName** property. The model binder looks for a key with this value in the dictionary. If the value exists and can be converted into a `GeoPoint`, the model binder assigns the bound value to the **ModelBindingContext.Model** property.

Notice that the model binder is not limited to a simple type conversion. In this example, the model binder first looks in a table of known locations, and if that fails, it uses type conversion.

**Setting the Model Binder**

There are several ways to set a model binder. First, you can add a **[ModelBinder]** attribute to the parameter.

[!code-csharp[Main](parameter-binding-in-aspnet-web-api/samples/sample10.cs)]

You can also add a **[ModelBinder]** attribute to the type. Web API will use the specified model binder for all parameters of that type.

[!code-csharp[Main](parameter-binding-in-aspnet-web-api/samples/sample11.cs)]

Finally, you can add a model-binder provider to the **HttpConfiguration**. A model-binder provider is simply a factory class that creates a model binder. You can create a provider by deriving from the [ModelBinderProvider](https://msdn.microsoft.com/en-us/library/system.web.http.modelbinding.modelbinderprovider.aspx) class. However, if your model binder handles a single type, it's easier to use the built-in **SimpleModelBinderProvider**, which is designed for this purpose. The following code shows how to do this.

[!code-csharp[Main](parameter-binding-in-aspnet-web-api/samples/sample12.cs)]

With a model-binding provider, you still need to add the **[ModelBinder]** attribute to the parameter, to tell Web API that it should use a model binder and not a media-type formatter. But now you don't need to specify the type of model binder in the attribute:

[!code-csharp[Main](parameter-binding-in-aspnet-web-api/samples/sample13.cs)]

## Value Providers

I mentioned that a model binder gets values from a value provider. To write a custom value provider, implement the **IValueProvider** interface. Here is an example that pulls values from the cookies in the request:

[!code-csharp[Main](parameter-binding-in-aspnet-web-api/samples/sample14.cs)]

You also need to create a value provider factory by deriving from the **ValueProviderFactory** class.

[!code-csharp[Main](parameter-binding-in-aspnet-web-api/samples/sample15.cs)]

Add the value provider factory to the **HttpConfiguration** as follows.

[!code-csharp[Main](parameter-binding-in-aspnet-web-api/samples/sample16.cs)]

Web API composes all of the value providers, so when a model binder calls **ValueProvider.GetValue**, the model binder receives the value from the first value provider that is able to produce it.

Alternatively, you can set the value provider factory at the parameter level by using the **ValueProvider** attribute, as follows:

[!code-csharp[Main](parameter-binding-in-aspnet-web-api/samples/sample17.cs)]

This tells Web API to use model binding with the specified value provider factory, and not to use any of the other registered value providers.

## HttpParameterBinding

Model binders are a specific instance of a more general mechanism. If you look at the **[ModelBinder]** attribute, you will see that it derives from the abstract **ParameterBindingAttribute** class. This class defines a single method, **GetBinding**, which returns an **HttpParameterBinding** object:

[!code-csharp[Main](parameter-binding-in-aspnet-web-api/samples/sample18.cs)]

An **HttpParameterBinding** is responsible for binding a parameter to a value. In the case of **[ModelBinder]**, the attribute returns an **HttpParameterBinding** implementation that uses an **IModelBinder** to perform the actual binding. You can also implement your own **HttpParameterBinding**.

For example, suppose you want to get ETags from `if-match` and `if-none-match` headers in the request. We'll start by defining a class to represent ETags.

[!code-csharp[Main](parameter-binding-in-aspnet-web-api/samples/sample19.cs)]

We'll also define an enumeration to indicate whether to get the ETag from the `if-match` header or the `if-none-match` header.

[!code-csharp[Main](parameter-binding-in-aspnet-web-api/samples/sample20.cs)]

Here is an **HttpParameterBinding** that gets the ETag from the desired header and binds it to a parameter of type ETag:

[!code-csharp[Main](parameter-binding-in-aspnet-web-api/samples/sample21.cs)]

The **ExecuteBindingAsync** method does the binding. Within this method, add the bound parameter value to the **ActionArgument** dictionary in the **HttpActionContext**.

> [!NOTE]
> If your **ExecuteBindingAsync** method reads the body of the request message, override the **WillReadBody** property to return true. The request body might be an unbuffered stream that can only be read once, so Web API enforces a rule that at most one binding can read the message body.


To apply a custom **HttpParameterBinding**, you can define an attribute that derives from **ParameterBindingAttribute**. For `ETagParameterBinding`, we'll define two attributes, one for `if-match` headers and one for `if-none-match` headers. Both derive from an abstract base class.

[!code-csharp[Main](parameter-binding-in-aspnet-web-api/samples/sample22.cs)]

Here is a controller method that uses the `[IfNoneMatch]` attribute.

[!code-csharp[Main](parameter-binding-in-aspnet-web-api/samples/sample23.cs)]

Besides **ParameterBindingAttribute**, there is another hook for adding a custom **HttpParameterBinding**. On the **HttpConfiguration** object, the **ParameterBindingRules** property is a collection of anomymous functions of type (**HttpParameterDescriptor** -&gt; **HttpParameterBinding**). For example, you could add a rule that any ETag parameter on a GET method uses `ETagParameterBinding` with `if-none-match`:

[!code-csharp[Main](parameter-binding-in-aspnet-web-api/samples/sample24.cs)]

The function should return `null` for parameters where the binding is not applicable.

## IActionValueBinder

The entire parameter-binding process is controlled by a pluggable service, **IActionValueBinder**. The default implementation of **IActionValueBinder** does the following:

1. Look for a **ParameterBindingAttribute** on the parameter. This includes **[FromBody]**, **[FromUri]**, and **[ModelBinder]**, or custom attributes.
2. Otherwise, look in **HttpConfiguration.ParameterBindingRules** for a function that returns a non-null **HttpParameterBinding**.
3. Otherwise, use the default rules that I described previously. 

    - If the parameter type is "simple"or has a type converter, bind from the URI. This is equivalent to putting the **[FromUri]** attribute on the parameter.
    - Otherwise, try to read the parameter from the message body. This is equivalent to putting **[FromBody]** on the parameter.

If you wanted, you could replace the entire **IActionValueBinder** service with a custom implementation.

## Additional Resources

[Custom Parameter Binding Sample](http://aspnet.codeplex.com/sourcecontrol/latest#Samples/WebApi/CustomParameterBinding/ReadMe.txt)

Mike Stall wrote a good series of blog posts about Web API parameter binding:

- [How Web API does Parameter Binding](https://blogs.msdn.com/b/jmstall/archive/2012/04/16/how-webapi-does-parameter-binding.aspx)
- [MVC Style parameter binding for Web API](https://blogs.msdn.com/b/jmstall/archive/2012/04/18/mvc-style-parameter-binding-for-webapi.aspx)
- [How to bind to custom objects in action signatures in MVC/Web API](https://blogs.msdn.com/b/jmstall/archive/2012/04/20/how-to-bind-to-custom-objects-in-action-signatures-in-mvc-webapi.aspx)
- [How to create a custom value provider in Web API](https://blogs.msdn.com/b/jmstall/archive/2012/04/23/how-to-create-a-custom-value-provider-in-webapi.aspx)
- [Web API Parameter binding under the hood](https://blogs.msdn.com/b/jmstall/archive/2012/05/11/webapi-parameter-binding-under-the-hood.aspx)