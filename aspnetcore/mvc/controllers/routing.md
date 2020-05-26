---
title: Routing to controller actions in ASP.NET Core
author: rick-anderson
description: Learn how ASP.NET Core MVC uses Routing Middleware to match URLs of incoming requests and map them to actions.
ms.author: riande
ms.date: 3/25/2020
no-loc: [Blazor, "Identity", "Let's Encrypt", Razor, SignalR]
uid: mvc/controllers/routing
---
# Routing to controller actions in ASP.NET Core

By [Ryan Nowak](https://github.com/rynowak), [Kirk Larkin](https://twitter.com/serpent5), and [Rick Anderson](https://twitter.com/RickAndMSFT)

::: moniker range=">= aspnetcore-3.0"

ASP.NET Core controllers use the Routing [middleware](xref:fundamentals/middleware/index) to match the URLs of incoming requests and map them to [actions](#action).  Routes templates:

* Are defined in startup code or attributes.
* Describe how URL paths are matched to [actions](#action).
* Are used to generate URLs for links. The generated links are typically returned in responses.

Actions are either [conventionally-routed](#cr) or [attribute-routed](#ar). Placing a route on the controller or [action](#action) makes it attribute-routed. See [Mixed routing](#routing-mixed-ref-label) for more information.

This document:

* Explains the interactions between MVC and routing:
  * How typical MVC apps make use of routing features.
  * Covers both:
    * [Conventionally routing](#cr) typically used with controllers and views.
    * *Attribute routing* used with REST APIs. If you're primarily interested in routing for REST APIs, jump to the [Attribute routing for REST APIs](#ar) section.
  * See [Routing](xref:fundamentals/routing) for advanced routing details.
* Refers to the default routing system added in ASP.NET Core 3.0, called endpoint routing. It's possible to use controllers with the previous version of routing for compatibility purposes. See the [2.2-3.0 migration guide](xref:migration/22-to-30) for instructions. Refer to the [2.2 version of this document](xref:mvc/controllers/routing?view=aspnetcore-2.2) for reference material on the legacy routing system.

<a name="cr"></a>

## Set up conventional route

`Startup.Configure` typically has code similar to the following when using [conventional routing](#crd):

[!code-csharp[](routing/samples/3.x/main/StartupDefaultMVC.cs?name=snippet)]

Inside the call to <xref:Microsoft.AspNetCore.Builder.EndpointRoutingApplicationBuilderExtensions.UseEndpoints*>, <xref:Microsoft.AspNetCore.Builder.ControllerEndpointRouteBuilderExtensions.MapControllerRoute*> is used to create a single route. The single route is named `default` route. Most apps with controllers and views use a route template similar to the `default` route. REST APIs should use [attribute routing](#ar).

The route template `"{controller=Home}/{action=Index}/{id?}"`:

* Matches a URL path like `/Products/Details/5`
* Extracts the route values `{ controller = Products, action = Details, id = 5 }` by tokenizing the path. The extraction of route values results in a match if the app has a controller named `ProductsController` and a `Details` action:

  [!code-csharp[](routing/samples/3.x/main/Controllers/ProductsController.cs?name=snippetA)]

  [!INCLUDE[](~/includes/MyDisplayRouteInfo.md)]

* `/Products/Details/5` model binds the value of `id = 5` to set the `id` parameter to `5`. See [Model Binding](xref:mvc/models/model-binding) for more details.
* `{controller=Home}` defines `Home` as the default `controller`.
* `{action=Index}` defines `Index` as the default `action`.
*  The `?` character in `{id?}` defines `id` as optional.
  * Default and optional route parameters don't need to be present in the URL path for a match. See [Route Template Reference](xref:fundamentals/routing#route-template-reference) for a detailed description of route template syntax.
* Matches the URL path `/`.
* Produces the route values `{ controller = Home, action = Index }`.

The values for `controller` and `action` make use of the default values. `id` doesn't produce a value since there's no corresponding segment in the URL path. `/` only matches if there exists a `HomeController` and `Index` action:

```csharp
public class HomeController : Controller
{
  public IActionResult Index() { ... }
}
```

Using the preceding controller definition and route template, the `HomeController.Index` action is run for the following URL paths:

* `/Home/Index/17`
* `/Home/Index`
* `/Home`
* `/`

The URL path `/` uses the route template default `Home` controllers and `Index` action. The URL path `/Home` uses the route template default `Index` action.

The convenience method <xref:Microsoft.AspNetCore.Builder.ControllerEndpointRouteBuilderExtensions.MapDefaultControllerRoute*>:

```csharp
endpoints.MapDefaultControllerRoute();
```

Replaces:

```csharp
endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
```

> [!IMPORTANT]
> Routing is configured using the <xref:Microsoft.AspNetCore.Builder.EndpointRoutingApplicationBuilderExtensions.UseRouting*> and <xref:Microsoft.AspNetCore.Builder.EndpointRoutingApplicationBuilderExtensions.UseEndpoints*> middleware. To use controllers:
>
> * Call <xref:Microsoft.AspNetCore.Builder.ControllerEndpointRouteBuilderExtensions.MapControllers*> inside `UseEndpoints` to map [attribute routed](#ar) controllers.
> * Call <xref:Microsoft.AspNetCore.Builder.ControllerEndpointRouteBuilderExtensions.MapControllerRoute*> or <xref:Microsoft.AspNetCore.Builder.ControllerEndpointRouteBuilderExtensions.MapAreaControllerRoute*>, to map both [conventionally routed](#cr) controllers and [attribute routed](#ar) controllers.

<a name="routing-conventional-ref-label"></a>
<a name="crd"></a>

## Conventional routing

Conventional routing is used with controllers and views. The `default` route:

[!code-csharp[](routing/samples/3.x/main/StartupDefaultMVC.cs?name=snippet2)]

is an example of a *conventional routing*. It's called *conventional routing* because it establishes a *convention* for URL paths:

* The first path segment, `{controller=Home}`, maps to the controller name.
* The second segment, `{action=Index}`, maps to the [action](#action) name.
* The third segment, `{id?}` is used for an optional `id`. The `?` in `{id?}` makes it optional. `id` is used to map to a model entity.

Using this `default` route, the URL path:

* `/Products/List` maps to the `ProductsController.List` action.
* `/Blog/Article/17` maps to `BlogController.Article` and typically model binds the `id` parameter to 17.

This mapping:

* Is based on the controller and [action](#action) names **only**.
* Isn't based on namespaces, source file locations, or method parameters.

Using conventional routing with the default route allows creating the app without having to come up with a new URL pattern for each action. For an app with [CRUD](https://wikipedia.org/wiki/Create,_read,_update_and_delete) style actions, having consistency for the URLs across controllers:

* Helps simplify the code.
* Makes the UI more predictable.

> [!WARNING]
> The `id` in the preceding code is defined as optional by the route template. Actions can execute without the optional ID provided as part of the URL. Generally, when`id` is omitted from the URL:
>
> * `id` is set to `0` by model binding.
> * No entity is found in the database matching `id == 0`.
>
> [Attribute routing](#ar) provides fine-grained control to make the ID required for some actions and not for others. By convention, the documentation includes optional parameters like `id` when they're likely to appear in correct usage.

Most apps should choose a basic and descriptive routing scheme so that URLs are readable and meaningful. The default conventional route `{controller=Home}/{action=Index}/{id?}`:

* Supports a basic and descriptive routing scheme.
* Is a useful starting point for UI-based apps.
* Is the only route template needed for many web UI apps. For larger web UI apps, another route using [Areas](#areas) if frequently all that's needed.

<xref:Microsoft.AspNetCore.Builder.ControllerEndpointRouteBuilderExtensions.MapControllerRoute*> and <xref:Microsoft.AspNetCore.Builder.MvcAreaRouteBuilderExtensions.MapAreaRoute*> :

* Automatically assign an **order** value to their endpoints based on the order they are invoked.

Endpoint routing in ASP.NET Core 3.0 and later:

* Doesn't have a concept of routes.
* Doesn't provide ordering guarantees for the execution of extensibility,  all endpoints are processed at once.

Enable [Logging](xref:fundamentals/logging/index) to see how the built-in routing implementations, such as <xref:Microsoft.AspNetCore.Routing.Route>, match requests.

[Attribute routing](#ar) is explained later in this document.

<a name="mr"></a>

### Multiple conventional routes

Multiple [conventional routes](#cr) can be added inside `UseEndpoints` by adding more calls to <xref:Microsoft.AspNetCore.Builder.ControllerEndpointRouteBuilderExtensions.MapControllerRoute*> and <xref:Microsoft.AspNetCore.Builder.ControllerEndpointRouteBuilderExtensions.MapAreaControllerRoute*>. Doing so allows defining multiple conventions, or to adding conventional routes that are dedicated to a specific [action](#action), such as:

[!code-csharp[](routing/samples/3.x/main/Startup.cs?name=snippet_1)]

<a name="dcr"></a>

The `blog` route in the preceding code is a **dedicated conventional route**. It's called a dedicated conventional route because:

* It uses [conventional routing](#cr).
* It's dedicated to a specific [action](#action).

Because `controller` and `action` don't appear in the route template `"blog/{*article}"` as parameters:

* They can only have the default values `{ controller = "Blog", action = "Article" }`.
* This route always maps to the action `BlogController.Article`.

`/Blog`, `/Blog/Article`, and `/Blog/{any-string}` are the only URL paths that match the blog route.

The preceding example:

* `blog` route has a higher priority for matches than the `default` route because it is added first.
* Is and example of [Slug](https://developer.mozilla.org/docs/Glossary/Slug) style routing where it's typical to have an article name as part of the URL.

> [!WARNING]
> In ASP.NET Core 3.0 and later, routing doesn't:
> * Define a concept called a *route*. `UseRouting` adds route matching to the middleware pipeline. The `UseRouting` middleware looks at the set of endpoints defined in the app, and selects the best endpoint match based on the request.
> * Provide guarantees about the execution order of extensibility like <xref:Microsoft.AspNetCore.Routing.IRouteConstraint> or <xref:Microsoft.AspNetCore.Mvc.ActionConstraints.IActionConstraint>.
>
>See [Routing](xref:fundamentals/routing) for reference material on routing.

<a name="cro"></a>

### Conventional routing order

Conventional routing only matches a combination of action and controller that are defined by the app. This is intended to simplify cases where conventional routes overlap.
Adding routes using <xref:Microsoft.AspNetCore.Builder.ControllerEndpointRouteBuilderExtensions.MapControllerRoute*>, <xref:Microsoft.AspNetCore.Builder.ControllerEndpointRouteBuilderExtensions.MapDefaultControllerRoute*>, and <xref:Microsoft.AspNetCore.Builder.ControllerEndpointRouteBuilderExtensions.MapAreaControllerRoute*> automatically assign an order value to their endpoints based on the order they are invoked. Matches from a route that appears earlier have a higher priority. Conventional routing is order-dependent. In general, routes with areas should be placed earlier as they're more specific than routes without an area. [Dedicated conventional routes](#dcr) with catch-all route parameters like `{*article}` can make a route too [greedy](xref:fundamentals/routing#greedy), meaning that it matches URLs that you intended to be matched by other routes. Put the greedy routes later in the route table to prevent greedy matches.

[!INCLUDE[](~/includes/catchall.md)]

<a name="best"></a>

### Resolving ambiguous actions

When two endpoints match through routing, routing must do one of the following:

* Choose the best candidate.
* Throw an exception.

For example:

[!code-csharp[](routing/samples/3.x/main/Controllers/ProductsController.cs?name=snippet9)]

The preceding controller defines two actions that match:

* The URL path `/Products33/Edit/17`
* Route data `{ controller = Products33, action = Edit, id = 17 }`.

This is a typical pattern for MVC controllers:

* `Edit(int)` displays a form to edit a product.
* `Edit(int, Product)` processes  the posted form.

To resolve the correct route:

* `Edit(int, Product)` is selected when the request is an HTTP `POST`.
* `Edit(int)` is selected when the [HTTP verb](#verb) is anything else. `Edit(int)` is generally called via `GET`.

The <xref:Microsoft.AspNetCore.Mvc.HttpPostAttribute>, `[HttpPost]`, is provided to routing so that it can choose based on the HTTP method of the request. The `HttpPostAttribute` makes `Edit(int, Product)` a better match than `Edit(int)`.

It's important to understand the role of attributes like `HttpPostAttribute`. Similar attributes are defined for other [HTTP verbs](#verb). In [conventional routing](#cr), it's common for actions to use the same action name when they're part of a show form, submit form workflow. For example, see [Examine the two Edit action methods](xref:tutorials/first-mvc-app/controller-methods-views#get-post).

If routing can't choose a best candidate, an <xref:System.Reflection.AmbiguousMatchException> is thrown, listing the multiple matched endpoints.

<a name="routing-route-name-ref-label"></a>

### Conventional route names

The strings  `"blog"` and `"default"` in the following examples are conventional route names:

[!code-csharp[](routing/samples/3.x/main/Startup.cs?name=snippet_1)]

The route names give the route a logical name. The named route can be used for URL generation. Using a named route simplifies URL creation when the ordering of routes could make URL generation complicated. Route names must be unique application wide.

Route names:

* Have no impact on URL matching or handling of requests.
* Are used only for URL generation.

The route name concept is represented in routing as [IEndpointNameMetadata](xref:Microsoft.AspNetCore.Routing.IEndpointNameMetadata). The terms **route name** and **endpoint name**:

* Are interchangeable.
* Which one is used in documentation and code depends on the API being described.

<a name="attribute-routing-ref-label"></a>
<a name="ar"></a>

## Attribute routing for REST APIs

REST APIs should use attribute routing to model the app's functionality as a set of resources where operations are represented by [HTTP verbs](#verb).

Attribute routing uses a set of attributes to map actions directly to route templates. The following `StartUp.Configure` code is typical for a REST API and is used in the next sample:

[!code-csharp[](routing/samples/3.x/main/StartupAPI.cs?name=snippet)]

In the preceding code, <xref:Microsoft.AspNetCore.Builder.ControllerEndpointRouteBuilderExtensions.MapControllers*> is called inside `UseEndpoints` to map attribute routed controllers.

In the following example:

* The preceding `Configure` method is used.
* `HomeController` matches a set of URLs similar to what the default conventional route `{controller=Home}/{action=Index}/{id?}` matches.

[!code-csharp[](routing/samples/3.x/main/Controllers/HomeController.cs?name=snippet2)]

The `HomeController.Index` action is run for any of the URL paths `/`, `/Home`, `/Home/Index`, or `/Home/Index/3`.

This example highlights a key programming difference between attribute routing and [conventional routing](#cr). Attribute routing requires more input to specify a route. The conventional default route handles routes more succinctly. However, attribute routing allows and requires precise control of which route templates apply to each [action](#action).

With attribute routing, the controller and action names play no part in which action is matched, unless [token replacement](#routing-token-replacement-templates-ref-label) is used. The following example matches the same URLs as the previous example:

[!code-csharp[](routing/samples/3.x/main/Controllers/MyDemoController.cs?name=snippet)]

The following code uses token replacement for `action` and `controller`:

[!code-csharp[](routing/samples/3.x/main/Controllers/HomeController.cs?name=snippet22)]

The following code applies `[Route("[controller]/[action]")]` to the controller:

[!code-csharp[](routing/samples/3.x/main/Controllers/HomeController.cs?name=snippet24)]

In the preceding code, the `Index` method templates must prepend `/` or `~/` to the route templates. Route templates applied to an action that begin with `/` or `~/` don't get combined with route templates applied to the controller.

See [Route template precedence](xref:fundamentals/routing#rtp) for information on route template selection.

## Reserved routing names

The following keywords are reserved route parameter names when using Controllers or Razor Pages:

* `action`
* `area`
* `controller`
* `handler`
* `page`

Using `page` as a route parameter with attribute routing is a common error. Doing that results in inconsistent and confusing behavior with URL generation.

[!code-csharp[](routing/samples/3.x/main/Controllers/MyDemo2Controller.cs?name=snippet)]

The special parameter names are used by the URL generation to determine if a URL generation operation refers to a Razor Page or to a Controller.

<a name="verb"></a>

## HTTP verb templates

ASP.NET Core has the following HTTP verb templates:

* [[HttpGet]](xref:Microsoft.AspNetCore.Mvc.HttpGetAttribute)
* [[HttpPost]](xref:Microsoft.AspNetCore.Mvc.HttpPostAttribute)
* [[HttpPut]](xref:Microsoft.AspNetCore.Mvc.HttpPutAttribute)
* [[HttpDelete]](xref:Microsoft.AspNetCore.Mvc.HttpDeleteAttribute)
* [[HttpHead]](xref:Microsoft.AspNetCore.Mvc.HttpHeadAttribute)
* [[HttpPatch]](xref:Microsoft.AspNetCore.Mvc.HttpPatchAttribute)

<a name="rt"></a>

### Route templates

ASP.NET Core has the following route templates:

* All the [HTTP verb templates](#verb) are route templates.
* [[Route]](xref:Microsoft.AspNetCore.Mvc.RouteAttribute)

<a name="arx"></a>

### Attribute routing with Http verb attributes

Consider the following controller:

[!code-csharp[](routing/samples/3.x/main/Controllers/Test2Controller.cs?name=snippet)]

In the preceding code:

* Each action contains the `[HttpGet]` attribute, which constrains matching to HTTP GET requests only.
* The `GetProduct` action includes the `"{id}"` template, therefore `id` is appended to the `"api/[controller]"` template on the controller. The methods template is `"api/[controller]/"{id}""`. Therefore this action only matches GET requests of for the form `/api/test2/xyz`,`/api/test2/123`,`/api/test2/{any string}`, etc.
  [!code-csharp[](routing/samples/3.x/main/Controllers/Test2Controller.cs?name=snippet2)]
* The `GetIntProduct` action contains the `"int/{id:int}")` template. The `:int` portion of the template constrains the `id` route values to strings that can be converted to an integer. A GET request to `/api/test2/int/abc`:
  * Doesn't match this action.
  * Returns a [404 Not Found](https://developer.mozilla.org/docs/Web/HTTP/Status/404) error.
    [!code-csharp[](routing/samples/3.x/main/Controllers/Test2Controller.cs?name=snippet3)]
* The `GetInt2Product` action contains `{id}` in the template, but doesn't constrain `id` to values that can be converted to an integer. A GET request to `/api/test2/int2/abc`:
  * Matches this route.
  * Model binding fails to convert `abc` to an integer. The `id` parameter of the method is integer.
  * Returns a [400 Bad Request](https://developer.mozilla.org/docs/Web/HTTP/Status/400) because model binding failed to convert`abc` to an integer.
      [!code-csharp[](routing/samples/3.x/main/Controllers/Test2Controller.cs?name=snippet4)]

Attribute routing can use <xref:Microsoft.AspNetCore.Mvc.Routing.HttpMethodAttribute> attributes such as <xref:Microsoft.AspNetCore.Mvc.HttpPostAttribute>, <xref:Microsoft.AspNetCore.Mvc.HttpPutAttribute>, and <xref:Microsoft.AspNetCore.Mvc.HttpDeleteAttribute>. All of the [HTTP verb](#verb) attributes accept a route template. The following example shows two actions that match the same route template:

[!code-csharp[](routing/samples/3.x/main/Controllers/MyProductsController.cs?name=snippet1)]

Using the URL path `/products3`:

* The `MyProductsController.ListProducts` action runs when the [HTTP verb](#verb) is `GET`.
* The `MyProductsController.CreateProduct` action runs when the [HTTP verb](#verb) is `POST`.

When building a REST API, it's rare that you'll need to use `[Route(...)]` on an action method because the action accepts all HTTP methods. It's better to use the more specific [HTTP verb attribute](#verb) to be precise about what your API supports. Clients of REST APIs are expected to know what paths and HTTP verbs map to specific logical operations.

REST APIs should use attribute routing to model the app's functionality as a set of resources where operations are represented by HTTP verbs. This means that many operations, for example, GET and POST on the same logical resource use the same URL. Attribute routing provides a level of control that's needed to carefully design an API's public endpoint layout.

Since an attribute route applies to a specific action, it's easy to make parameters required as part of the route template definition. In the following example, `id` is required as part of the URL path:

[!code-csharp[](routing/samples/3.x/main/Controllers/ProductsApiController.cs?name=snippet2)]

The `Products2ApiController.GetProduct(int)` action:

* Is run with URL path like `/products2/3`
* Isn't run with the URL path `/products2`.

The [[Consumes]](<xref:Microsoft.AspNetCore.Mvc.ConsumesAttribute>) attribute allows an action to limit the supported request content types. For more information, see [Define supported request content types with the Consumes attribute](xref:web-api/index#consumes).

 See [Routing](xref:fundamentals/routing) for a full description of route templates and related options.

For more information on `[ApiController]`, see [ApiController attribute](xref:web-api/index##apicontroller-attribute).

## Route name

The following code  defines a route name of `Products_List`:

[!code-csharp[](routing/samples/3.x/main/Controllers/ProductsApiController.cs?name=snippet2)]

Route names can be used to generate a URL based on a specific route. Route names:

* Have no impact on the URL matching behavior of routing.
* Are only used for URL generation.

Route names must be unique application-wide.

Contrast the preceding code with the conventional default route, which defines the `id` parameter as optional (`{id?}`). The ability to precisely specify APIs has advantages, such as  allowing `/products` and `/products/5` to be dispatched to different actions.

<a name="routing-combining-ref-label"></a>

## Combining attribute routes

To make attribute routing less repetitive, route attributes on the controller are combined with route attributes on the individual actions. Any route templates defined on the controller are prepended to route templates on the actions. Placing a route attribute on the controller makes **all** actions in the controller use attribute routing.

[!code-csharp[](routing/samples/3.x/main/Controllers/ProductsApiController.cs?name=snippet)]

In the preceding example:

* The URL path `/products` can match `ProductsApi.ListProducts`
* The URL path `/products/5` can match `ProductsApi.GetProduct(int)`.

Both of these actions only match HTTP `GET` because they're marked with the `[HttpGet]` attribute.

Route templates applied to an action that begin with `/` or `~/` don't get combined with route templates applied to the controller. The following example matches a set of URL paths similar to the default route.

[!code-csharp[](routing/samples/3.x/main/Controllers/HomeController.cs?name=snippet)]

The following table explains the `[Route]` attributes in the preceding code:

| Attribute               | Combines with `[Route("Home")]` | Defines route template |
| ----------------- | ------------ | --------- |
| `[Route("")]` | Yes | `"Home"` |
| `[Route("Index")]` | Yes | `"Home/Index"` |
| `[Route("/")]` | **No** | `""` |
| `[Route("About")]` | Yes | `"Home/About"` |

<a name="routing-ordering-ref-label"></a>
<a name="oar"></a>

### Attribute route order

Routing builds a tree and matches all endpoints simultaneously:

* The route entries behave as if placed in an ideal ordering.
* The most specific routes have a chance to execute before the more general routes.

For example, an attribute route like `blog/search/{topic}` is more specific than an attribute route like `blog/{*article}`. The `blog/search/{topic}` route has higher priority, by default, because it's more specific. Using [conventional routing](#cr), the developer is responsible for placing routes in the desired order.

Attribute routes can configure an order using the <xref:Microsoft.AspNetCore.Mvc.RouteAttribute.Order> property. All of the framework provided [route attributes](xref:Microsoft.AspNetCore.Mvc.RouteAttribute) include `Order` . Routes are processed according to an ascending sort of the `Order` property. The default order is `0`. Setting a route using `Order = -1` runs before routes that don't set an order. Setting a route using `Order = 1` runs after default route ordering.

**Avoid** depending on `Order`. If an app's URL-space requires explicit order values to route correctly, then it's likely confusing to clients as well. In general, attribute routing selects the correct route with URL matching. If the default order used for URL generation isn't working, using a route name as an override is usually simpler than applying the `Order` property.

Consider the following two controllers which both define the route matching `/home`:

[!code-csharp[](routing/samples/3.x/main/Controllers/HomeController.cs?name=snippet2)]

[!code-csharp[](routing/samples/3.x/main/Controllers/MyDemoController.cs?name=snippet)]

Requesting `/home` with the preceding code throws an exception similar to the following:

```text
AmbiguousMatchException: The request matched multiple endpoints. Matches:

 WebMvcRouting.Controllers.HomeController.Index
 WebMvcRouting.Controllers.MyDemoController.MyIndex
```

Adding `Order` to one of the route attributes resolves the ambiguity:

[!code-csharp[](routing/samples/3.x/main/Controllers/MyDemo3Controller.cs?name=snippet3& highlight=2)]

With the preceding code, `/home` runs the `HomeController.Index` endpoint. To get to the `MyDemoController.MyIndex`, request `/home/MyIndex`. **Note**:

* The preceding code is an example or poor routing design. It was used to illustrate the `Order` property.
* The `Order` property only resolves the ambiguity, that template cannot be matched. It would be better to remove the `[Route("Home")]` template.

See [Razor Pages route and app conventions: Route order](xref:razor-pages/razor-pages-conventions#route-order) for information on route order with Razor Pages.

In some cases, an HTTP 500 error is returned with ambiguous routes. Use [logging](xref:fundamentals/logging/index) to see which endpoints caused the `AmbiguousMatchException`.

<a name="routing-token-replacement-templates-ref-label"></a>

## Token replacement in route templates [controller], [action], [area]

For convenience, attribute routes support token replacement for reserved route parameters by enclosing a token in one of the following:

* Square brackets: `[]`
* Curly braces: `{}`

The tokens `[action]`, `[area]`, and `[controller]` are replaced with the values of the action name, area name, and controller name from the action where the route is defined:

[!code-csharp[](routing/samples/3.x/main/Controllers/ProductsController.cs?name=snippet)]

In the preceding code:

  [!code-csharp[](routing/samples/3.x/main/Controllers/ProductsController.cs?name=snippet10)]

  * Matches `/Products0/List`

  [!code-csharp[](routing/samples/3.x/main/Controllers/ProductsController.cs?name=snippet11)]

  * Matches `/Products0/Edit/{id}`

Token replacement occurs as the last step of building the attribute routes. The preceding example behaves the same as the following code:

[!code-csharp[](routing/samples/3.x/main/Controllers/ProductsController.cs?name=snippet20)]

[!INCLUDE[](~/includes/MTcomments.md)]

Attribute routes can also be combined with inheritance. This is powerful combined with token replacement. Token replacement also applies to route names defined by attribute routes.
`[Route("[controller]/[action]", Name="[controller]_[action]")]`generates a unique route name for each action:

[!code-csharp[](routing/samples/3.x/main/Controllers/ProductsController.cs?name=snippet5)]

Token replacement also applies to route names defined by attribute routes.
`[Route("[controller]/[action]", Name="[controller]_[action]")]`
generates a unique route name for each action.

To match the literal token replacement delimiter `[` or  `]`, escape it by repeating the character (`[[` or `]]`).

<a name="routing-token-replacement-transformers-ref-label"></a>

### Use a parameter transformer to customize token replacement

Token replacement can be customized using a parameter transformer. A parameter transformer implements <xref:Microsoft.AspNetCore.Routing.IOutboundParameterTransformer> and transforms the value of parameters. For example, a custom `SlugifyParameterTransformer` parameter transformer changes the `SubscriptionManagement` route value to `subscription-management`:

[!code-csharp[](routing/samples/3.x/main/StartupSlugifyParamTransformer.cs?name=snippet2)]

The <xref:Microsoft.AspNetCore.Mvc.ApplicationModels.RouteTokenTransformerConvention> is an application model convention that:

* Applies a parameter transformer to all attribute routes in an application.
* Customizes the attribute route token values as they are replaced.

[!code-csharp[](routing/samples/3.x/main/Controllers/SubscriptionManagementController.cs?name=snippet)]

The preceding `ListAll` method matches `/subscription-management/list-all`.

The `RouteTokenTransformerConvention` is registered as an option in `ConfigureServices`.

[!code-csharp[](routing/samples/3.x/main/StartupSlugifyParamTransformer.cs?name=snippet)]

See [MDN web docs on Slug](https://developer.mozilla.org/docs/Glossary/Slug) for the definition of Slug.

[!INCLUDE[](~/includes/regex.md)]
<a name="routing-multiple-routes-ref-label"></a>

### Multiple attribute routes

Attribute routing supports defining multiple routes that reach the same action. The most common usage of this is to mimic the behavior of the default conventional route as shown in the following example:

[!code-csharp[](routing/samples/3.x/main/Controllers/ProductsController.cs?name=snippet6x)]

Putting multiple route attributes on the controller means that each one combines with each of the route attributes on the action methods:

[!code-csharp[](routing/samples/3.x/main/Controllers/ProductsController.cs?name=snippet6)]

All the [HTTP verb](#verb) route constraints implement `IActionConstraint`.

When multiple route attributes that implement <xref:Microsoft.AspNetCore.Mvc.ActionConstraints.IActionConstraint> are placed on an action:

* Each action constraint combines with the route template applied to the controller.

[!code-csharp[](routing/samples/3.x/main/Controllers/ProductsController.cs?name=snippet7)]

Using multiple routes on actions might seem useful and powerful, it's better to keep your app's URL space basic and well defined. Use multiple routes on actions **only** where needed, for example, to support existing clients.

<a name="routing-attr-options"></a>

### Specifying attribute route optional parameters, default values, and constraints

Attribute routes support the same inline syntax as conventional routes to specify optional parameters, default values, and constraints.

[!code-csharp[](routing/samples/3.x/main/Controllers/ProductsController.cs?name=snippet8&highlight=3)]

In the preceding code, `[HttpPost("product/{id:int}")]` applies a route constraint. The `ProductsController.ShowProduct` action is matched only by URL paths like `/product/3`. The route template portion `{id:int}` constrains that segment to only integers.

See [Route Template Reference](xref:fundamentals/routing#route-template-reference) for a detailed description of route template syntax.

<a name="routing-cust-rt-attr-irt-ref-label"></a>

### Custom route attributes using IRouteTemplateProvider

All of the [route attributes](#rt) implement <xref:Microsoft.AspNetCore.Mvc.Routing.IRouteTemplateProvider>. The ASP.NET Core runtime:

* Looks for attributes on controller classes and action methods when the app starts.
* Uses the attributes that implement `IRouteTemplateProvider` to build the initial set of routes.

Implement `IRouteTemplateProvider` to define custom route attributes. Each `IRouteTemplateProvider` allows you to define a single route with a custom route template, order, and name:

[!code-csharp[](routing/samples/3.x/main/Controllers/MyTestApiController.cs?name=snippet&highlight=1-10)]

The preceding `Get` method returns `Order = 2, Template = api/MyTestApi`.

<a name="routing-app-model-ref-label"></a>

### Use application model to customize attribute routes

The application model:

* Is an object model created at startup.
* Contains all of the metadata used by ASP.NET Core to route and execute the actions in an app.

The application model includes all of the data gathered from route attributes. The data from route attributes is provided by the `IRouteTemplateProvider` implementation. Conventions:

* Can be written to modify the application model to customize how routing behaves.
* Are read at app startup.

This section shows a basic example of customizing routing using application model. The following code makes routes roughly line up with the folder structure of the project.

[!code-csharp[](routing/samples/3.x/nsrc/NamespaceRoutingConvention.cs?name=snippet)]

The following code prevents the `namespace` convention from being applied to controllers that are attribute routed:

[!code-csharp[](routing/samples/3.x/nsrc/NamespaceRoutingConvention.cs?name=snippet2)]

For example, the following controller doesn't use `NamespaceRoutingConvention`:

[!code-csharp[](routing/samples/3.x/nsrc/Controllers/ManagersController.cs?name=snippet&highlight=1)]

The `NamespaceRoutingConvention.Apply` method:

* Does nothing if the controller is attribute routed.
* Sets the controllers template based on the `namespace`, with the base `namespace` removed.

The `NamespaceRoutingConvention` can be applied in `Startup.ConfigureServices`:

[!code-csharp[](routing/samples/3.x/nsrc/Startup.cs?name=snippet&highlight=1,14-18)]

For example, consider the following controller:

[!code-csharp[](routing/samples/3.x/nsrc/Controllers/UsersController.cs)]

In the preceding code:

* The base `namespace` is `My.Application`.
* The full name of the preceding controller is `My.Application.Admin.Controllers.UsersController`.
* The `NamespaceRoutingConvention` sets the controllers template to `Admin/Controllers/Users/[action]/{id?`.

The `NamespaceRoutingConvention` can also be applied as an attribute on a controller:

[!code-csharp[](routing/samples/3.x/nsrc/Controllers/TestController.cs?name=snippet&highlight=1)]

<a name="routing-mixed-ref-label"></a>

## Mixed routing: Attribute routing vs conventional routing

ASP.NET Core apps can mix the use of conventional routing and attribute routing. It's typical to use conventional routes for controllers serving HTML pages for browsers, and attribute routing for controllers serving REST APIs.

Actions are either conventionally routed or attribute routed. Placing a route on the controller or the action makes it attribute routed. Actions that define attribute routes cannot be reached through the conventional routes and vice-versa. **Any** route attribute on the controller makes **all** actions in the controller attribute routed.

Attribute routing and conventional routing use the same routing engine.

<a name="routing-url-gen-ref-label"></a>
<a name="ambient"></a>

## URL Generation and ambient values

Apps can use routing URL generation features to generate URL links to actions. Generating URLs eliminates hardcoding URLs, making code more robust and maintainable. This section focuses on the URL generation features provided by MVC and only cover basics of how URL generation works. See [Routing](xref:fundamentals/routing) for a detailed description of URL generation.

The <xref:Microsoft.AspNetCore.Mvc.IUrlHelper> interface is the underlying element of infrastructure between MVC and routing for URL generation. An instance of `IUrlHelper` is available through the `Url` property in controllers, views, and view components.

In the following example, the `IUrlHelper` interface is used through the `Controller.Url` property to generate a URL to another action.

[!code-csharp[](routing/samples/3.x/main/Controllers/UrlGenerationController.cs?name=snippet_1)]

If the app is using the default conventional route, the value of the `url` variable is the URL path string `/UrlGeneration/Destination`. This URL path is created by routing by combining:

* The route values from the current request, which are called **ambient values**.
* The values passed to `Url.Action` and substituting those values into the route template:

``` text
ambient values: { controller = "UrlGeneration", action = "Source" }
values passed to Url.Action: { controller = "UrlGeneration", action = "Destination" }
route template: {controller}/{action}/{id?}

result: /UrlGeneration/Destination
```

Each route parameter in the route template has its value substituted by matching names with the values and ambient values. A route parameter that doesn't have a value can:

* Use a default value if it has one.
* Be skipped if it's optional. For example, the `id` from the  route template `{controller}/{action}/{id?}`.

URL generation fails if any required route parameter doesn't have a corresponding value. If URL generation fails for a route, the next route is tried until all routes have been tried or a match is found.

The preceding example of `Url.Action` assumes [conventional routing](#cr). URL generation works similarly with [attribute routing](#ar), though the concepts are different. With conventional routing:

* The route values are used to expand a template.
* The route values for `controller` and `action` usually appear in that template. This works because the URLs matched by routing adhere to a convention.

The following example uses attribute routing:

[!code-csharp[](routing/samples/3.x/main/Controllers/UrlGenerationAttrController.cs?name=snippet_1)]

The `Source` action in the preceding code generates `custom/url/to/destination`.

<xref:Microsoft.AspNetCore.Routing.LinkGenerator> was added in ASP.NET Core 3.0 as an alternative to `IUrlHelper`. `LinkGenerator` offers similar but more flexible functionality. Each method on `IUrlHelper` has a corresponding family of methods on `LinkGenerator` as well.

### Generating URLs by action name

[Url.Action](xref:Microsoft.AspNetCore.Mvc.IUrlHelper.Action*), [LinkGenerator.GetPathByAction](xref:Microsoft.AspNetCore.Routing.ControllerLinkGeneratorExtensions.GetPathByAction*), and all related overloads all are designed to generate the target endpoint by specifying a controller name and action name.

When using `Url.Action`, the current route values for `controller` and `action` are provided by the runtime:

* The value of `controller` and `action` are part of both [ambient values](#ambient) and values. The method `Url.Action` always uses the current values of `action` and `controller` and generates a URL path that routes to the current action.

Routing attempts to use the values in ambient values to fill in information that wasn't provided when generating a URL. Consider a route like `{a}/{b}/{c}/{d}` with ambient values `{ a = Alice, b = Bob, c = Carol, d = David }`:

* Routing has enough information to generate a URL without any additional values.
* Routing has enough information because all route parameters have a value.

If the value `{ d = Donovan }` is added:

* The value `{ d = David }` is ignored.
* The generated URL path is `Alice/Bob/Carol/Donovan`.

**Warning**: URL paths are hierarchical. In the preceding example, if the value `{ c = Cheryl }` is added:

* Both of the values `{ c = Carol, d = David }` are ignored.
* There is no longer a value for `d` and URL generation fails.
* The desired values of `c` and `d` must be specified to generate a URL.  

You might expect to hit this problem with the default route `{controller}/{action}/{id?}`. This problem is rare in practice because `Url.Action` always explicitly specifies a `controller` and `action` value.

Several overloads of [Url.Action](xref:Microsoft.AspNetCore.Mvc.IUrlHelper.Action*) take a route values object to provide values for route parameters other than `controller` and `action`. The route values object is frequently used with `id`. For example, `Url.Action("Buy", "Products", new { id = 17 })`. The route values object:

* By convention is usually an object of anonymous type.
* Can be an `IDictionary<>` or a [POCO](https://wikipedia.org/wiki/Plain_old_CLR_object)).

Any additional route values that don't match route parameters are put in the query string.

[!code-csharp[](routing/samples/3.x/main/Controllers/TestController.cs?name=snippet)]

The preceding code generates `/Products/Buy/17?color=red`.

The following code generates an absolute URL:

[!code-csharp[](routing/samples/3.x/main/Controllers/TestController.cs?name=snippet2)]

To create an absolute URL, use one of the following:

* An overload that accepts a `protocol`. For example, the preceding code.
* [LinkGenerator.GetUriByAction](xref:Microsoft.AspNetCore.Routing.ControllerLinkGeneratorExtensions.GetUriByAction*), which generates absolute URIs by default.

<a name="routing-gen-urls-route-ref-label"></a>

### Generate URLs by route

The preceding code demonstrated generating a URL by passing in the controller and action name. `IUrlHelper` also provides the [Url.RouteUrl](xref:Microsoft.AspNetCore.Mvc.IUrlHelper.RouteUrl*) family of methods. These methods are similar to [Url.Action](xref:Microsoft.AspNetCore.Mvc.IUrlHelper.Action*), but they don't copy the current values of `action` and `controller` to the route values. The most common usage of `Url.RouteUrl`:

* Specifies a route name to generate the URL.
* Generally doesn't specify a controller or action name.

[!code-csharp[](routing/samples/3.x/main/Controllers/UrlGeneration2Controller.cs?name=snippet_1)]

The following Razor file generates an HTML link to the `Destination_Route`:

[!code-cshtml[](routing/samples/3.x/main/Views/Shared/MyLink.cshtml)]

<a name="routing-gen-urls-html-ref-label"></a>

### Generate URLs in HTML and Razor

<xref:Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper> provides the <xref:Microsoft.AspNetCore.Mvc.ViewFeatures.HtmlHelper> methods [Html.BeginForm](xref:Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper.BeginForm*) and [Html.ActionLink](xref:Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper.ActionLink*) to generate `<form>` and `<a>` elements respectively. These methods use the [Url.Action](xref:Microsoft.AspNetCore.Mvc.IUrlHelper.Action*) method to generate a URL and they accept similar arguments. The `Url.RouteUrl` companions for `HtmlHelper` are `Html.BeginRouteForm` and `Html.RouteLink` which have similar functionality.

TagHelpers generate URLs through the `form` TagHelper and the `<a>` TagHelper. Both of these use `IUrlHelper` for their implementation. See [Tag Helpers in forms](xref:mvc/views/working-with-forms) for more information.

Inside views, the `IUrlHelper` is available through the `Url` property for any ad-hoc URL generation not covered by the above.

<a name="routing-gen-urls-action-ref-label"></a>

### URL generation in Action Results

The preceding examples showed using `IUrlHelper` in a controller. The most common usage in a controller is to generate a URL as part of an action result.

The <xref:Microsoft.AspNetCore.Mvc.ControllerBase> and <xref:Microsoft.AspNetCore.Mvc.Controller> base classes provide convenience methods for action results that reference another action. One typical usage is to redirect after accepting user input:

[!code-csharp[](routing/samples/3.x/main/Controllers/CustomerController.cs?name=snippet)]

The action results factory methods such as <xref:Microsoft.AspNetCore.Mvc.ControllerBase.RedirectToAction*> and <xref:Microsoft.AspNetCore.Mvc.ControllerBase.CreatedAtAction*> follow a similar pattern to the methods on `IUrlHelper`.

<a name="routing-dedicated-ref-label"></a>

### Special case for dedicated conventional routes

[Conventional routing](#cr) can use a special kind of route definition called a [dedicated conventional route](#dcr). In the following example, the route named `blog` is a dedicated conventional route:

[!code-csharp[](routing/samples/3.x/main/Startup.cs?name=snippet_1)]

Using the preceding route definitions, `Url.Action("Index", "Home")` generates the URL path `/` using the `default` route, but why? You might guess the route values `{ controller = Home, action = Index }` would be enough to generate a URL using `blog`, and the result would be `/blog?action=Index&controller=Home`.

[Dedicated conventional routes](#dcr) rely on a special behavior of default values that don't have a corresponding route parameter that prevents the route from being too [greedy](xref:fundamentals/routing#greedy) with URL generation. In this case the default values are `{ controller = Blog, action = Article }`, and neither `controller` nor `action` appears as a route parameter. When routing performs URL generation, the values provided must match the default values. URL generation using `blog` fails because the values `{ controller = Home, action = Index }` don't match `{ controller = Blog, action = Article }`. Routing then falls back to try `default`, which succeeds.

<a name="routing-areas-ref-label"></a>

## Areas

[Areas](xref:mvc/controllers/areas) are an MVC feature used to organize related functionality into a group as a separate:

* Routing namespace for controller actions.
* Folder structure for views.

Using areas allows an app to have multiple controllers with the same name, as long as they have different areas. Using areas creates a hierarchy for the purpose of routing by adding another route parameter, `area` to `controller` and `action`. This section discusses how routing interacts with areas. See [Areas](xref:mvc/controllers/areas) for details about how areas are used with views.

The following example configures MVC to use the default conventional route and an `area` route for an `area` named `Blog`:

[!code-csharp[](routing/samples/3.x/AreasRouting/Startup.cs?name=snippet1)]

In the preceding code, <xref:Microsoft.AspNetCore.Builder.ControllerEndpointRouteBuilderExtensions.MapAreaControllerRoute*> is called to create the `"blog_route"`. The second parameter, `"Blog"`, is the area name.

When matching a URL path like `/Manage/Users/AddUser`, the `"blog_route"` route generates the route values `{ area = Blog, controller = Users, action = AddUser }`. The `area` route value is produced by a default value for `area`. The route created by `MapAreaControllerRoute` is equivalent to the following:

[!code-csharp[](routing/samples/3.x/AreasRouting/Startup2.cs?name=snippet2)]

`MapAreaControllerRoute` creates a route using both a default value and constraint for `area` using the provided area name, in this case `Blog`. The default value ensures that the route always produces `{ area = Blog, ... }`, the constraint requires the value `{ area = Blog, ... }` for URL generation.

Conventional routing is order-dependent. In general, routes with areas should be placed earlier as they're more specific than routes without an area.

Using the preceding example, the route values `{ area = Blog, controller = Users, action = AddUser }` match the following action:

[!code-csharp[](routing/samples/3.x/AreasRouting/Areas/Blog/Controllers/UsersController.cs)]

The [[Area]](xref:Microsoft.AspNetCore.Mvc.AreaAttribute) attribute is what denotes a controller as part of an area. This controller is in the `Blog` area. Controllers without an `[Area]` attribute are not members of any area, and do **not** match when the `area` route value is provided by routing. In the following example, only the first controller listed can match the route values `{ area = Blog, controller = Users, action = AddUser }`.

[!code-csharp[](routing/samples/3.x/AreasRouting/Areas/Blog/Controllers/UsersController.cs)]

[!code-csharp[](routing/samples/3.x/AreasRouting/Areas/Zebra/Controllers/UsersController.cs)]

[!code-csharp[](routing/samples/3.x/AreasRouting/Controllers/UsersController.cs)]

The namespace of each controller is shown here for completeness. If the preceding controllers uses the same namespace, a compiler error would be generated. Class namespaces have no effect on MVC's routing.

The first two controllers are members of areas, and only match when their respective area name is provided by the `area` route value. The third controller isn't a member of any area, and can only match when no value for `area` is provided by routing.

<a name="aa"></a>

In terms of matching *no value*, the absence of the `area` value is the same as if the value for `area` were null or the empty string.

When executing an action inside an area, the route value for `area` is available as an [ambient value](#ambient) for routing to use for URL generation. This means that by default areas act *sticky* for URL generation as demonstrated by the following sample.

[!code-csharp[](routing/samples/3.x/AreasRouting/Startup3.cs?name=snippet3)]

[!code-csharp[](routing/samples/3.x/AreasRouting/Areas/Duck/Controllers/UsersController.cs)]

The following code generates a URL to `/Zebra/Users/AddUser`:

[!code-csharp[](routing/samples/3.x/AreasRouting/Controllers/HomeController.cs?name=snippet)]

<a name="action"></a>

## Action definition

Public methods on a controller, except those with the [NonAction](xref:Microsoft.AspNetCore.Mvc.NonActionAttribute) attribute, are actions.

## Sample code

 * The [MyDisplayRouteInfo](https://github.com/dotnet/AspNetCore.Docs/tree/master/aspnetcore/mvc/controllers/routing/samples/3.x/main/Extensions/ControllerContextExtensions.cs) method is included in the [sample download](https://github.com/dotnet/AspNetCore.Docs/tree/master/aspnetcore/mvc/controllers/routing/samples/3.x) and is used to display routing information.
* [View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/master/aspnetcore/mvc/controllers/routing/samples/3.x) ([how to download](xref:index#how-to-download-a-sample))

[!INCLUDE[](~/includes/dbg-route.md)]

::: moniker-end

::: moniker range="< aspnetcore-3.0"

ASP.NET Core MVC uses the Routing [middleware](xref:fundamentals/middleware/index) to match the URLs of incoming requests and map them to actions. Routes are defined in startup code or attributes. Routes describe how URL paths should be matched to actions. Routes are also used to generate URLs (for links) sent out in responses.

Actions are either conventionally routed or attribute routed. Placing a route on the controller or the action makes it attribute routed. See [Mixed routing](#routing-mixed-ref-label) for more information.

This document will explain the interactions between MVC and routing, and how typical MVC apps make use of routing features. See [Routing](xref:fundamentals/routing) for details on advanced routing.

## Setting up Routing Middleware

In your *Configure* method you may see code similar to:

```csharp
app.UseMvc(routes =>
{
   routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
});
```

Inside the call to `UseMvc`, `MapRoute` is used to create a single route, which we'll refer to as the `default` route. Most MVC apps will use a route with a template similar to the `default` route.

The route template `"{controller=Home}/{action=Index}/{id?}"` can match a URL path like `/Products/Details/5` and will extract the route values `{ controller = Products, action = Details, id = 5 }` by tokenizing the path. MVC will attempt to locate a controller named `ProductsController` and run the action `Details`:

```csharp
public class ProductsController : Controller
{
   public IActionResult Details(int id) { ... }
}
```

Note that in this example, model binding would use the value of `id = 5` to set the `id` parameter to `5` when invoking this action. See the [Model Binding](../models/model-binding.md) for more details.

Using the `default` route:

```csharp
routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
```

The route template:

* `{controller=Home}` defines `Home` as the default `controller`

* `{action=Index}` defines `Index` as the default `action`

* `{id?}` defines `id` as optional

Default and optional route parameters don't need to be present in the URL path for a match. See [Route Template Reference](xref:fundamentals/routing#route-template-reference) for a detailed description of route template syntax.

`"{controller=Home}/{action=Index}/{id?}"` can match the URL path `/` and will produce the route values `{ controller = Home, action = Index }`. The values for `controller` and `action` make use of the default values, `id` doesn't produce a value since there's no corresponding segment in the URL path. MVC would use these route values to select the `HomeController` and `Index` action:

```csharp
public class HomeController : Controller
{
  public IActionResult Index() { ... }
}
```

Using this controller definition and route template, the `HomeController.Index` action would be executed for any of the following URL paths:

* `/Home/Index/17`

* `/Home/Index`

* `/Home`

* `/`

The convenience method `UseMvcWithDefaultRoute`:

```csharp
app.UseMvcWithDefaultRoute();
```

Can be used to replace:

```csharp
app.UseMvc(routes =>
{
   routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
});
```

`UseMvc` and `UseMvcWithDefaultRoute` add an instance of `RouterMiddleware` to the middleware pipeline. MVC doesn't interact directly with middleware, and uses routing to handle requests. MVC is connected to the routes through an instance of `MvcRouteHandler`. The code inside of `UseMvc` is similar to the following:

```csharp
var routes = new RouteBuilder(app);

// Add connection to MVC, will be hooked up by calls to MapRoute.
routes.DefaultHandler = new MvcRouteHandler(...);

// Execute callback to register routes.
// routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");

// Create route collection and add the middleware.
app.UseRouter(routes.Build());
```

`UseMvc` doesn't directly define any routes, it adds a placeholder to the route collection for the `attribute` route. The overload `UseMvc(Action<IRouteBuilder>)` lets you add your own routes and also supports attribute routing.  `UseMvc` and all of its variations add a placeholder for the attribute route - attribute routing is always available regardless of how you configure `UseMvc`. `UseMvcWithDefaultRoute` defines a default route and supports attribute routing. The [Attribute Routing](#attribute-routing-ref-label) section includes more details on attribute routing.

<a name="routing-conventional-ref-label"></a>

## Conventional routing

The `default` route:

```csharp
routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
```

The preceding code is an example of a conventional routing. This style is called conventional routing because it establishes a *convention* for URL paths:

* The first path segment maps to the controller name.
* The second maps to the action name.
* The third segment is used for an optional `id`. `id` maps to a model entity.

Using this `default` route, the URL path `/Products/List` maps to the `ProductsController.List` action, and `/Blog/Article/17` maps to `BlogController.Article`. This mapping is based on the controller and action names **only** and isn't based on namespaces, source file locations, or method parameters.

> [!TIP]
> Using conventional routing with the default route allows you to build the application quickly without having to come up with a new URL pattern for each action you define. For an application with CRUD style actions, having consistency for the URLs across your controllers can help simplify your code and make your UI more predictable.

> [!WARNING]
> The `id` is defined as optional by the route template, meaning that your actions can execute without the ID provided as part of the URL. Usually what will happen if `id` is omitted from the URL is that it will be set to `0` by model binding, and as a result no entity will be found in the database matching `id == 0`. Attribute routing can give you fine-grained control to make the ID required for some actions and not for others. By convention the documentation will include optional parameters like `id` when they're likely to appear in correct usage.

## Multiple routes

You can add multiple routes inside `UseMvc` by adding more calls to `MapRoute`. Doing so allows you to define multiple conventions, or to add conventional routes that are dedicated to a specific action, such as:

```csharp
app.UseMvc(routes =>
{
   routes.MapRoute("blog", "blog/{*article}",
            defaults: new { controller = "Blog", action = "Article" });
   routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
});
```

The `blog` route here is a *dedicated conventional route*, meaning that it uses the conventional routing system, but is dedicated to a specific action. Since `controller` and `action` don't appear in the route template as parameters, they can only have the default values, and thus this route will always map to the action `BlogController.Article`.

Routes in the route collection are ordered, and will be processed in the order they're added. So in this example, the `blog` route will be tried before the `default` route.

> [!NOTE]
> *Dedicated conventional routes* often use **catch-all** route parameters like `{*article}` to capture the remaining portion of the URL path. This can make a route 'too greedy' meaning that it matches URLs that you intended to be matched by other routes. Put the 'greedy' routes later in the route table to solve this.

### Fallback

As part of request processing, MVC will verify that the route values can be used to find a controller and action in your application. If the route values don't match an action then the route isn't considered a match, and the next route will be tried. This is called *fallback*, and it's intended to simplify cases where conventional routes overlap.

### Disambiguating actions

When two actions match through routing, MVC must disambiguate to choose the 'best' candidate or else throw an exception. For example:

```csharp
public class ProductsController : Controller
{
   public IActionResult Edit(int id) { ... }

   [HttpPost]
   public IActionResult Edit(int id, Product product) { ... }
}
```

This controller defines two actions that would match the URL path `/Products/Edit/17` and route data `{ controller = Products, action = Edit, id = 17 }`. This is a typical pattern for MVC controllers where `Edit(int)` shows a form to edit a product, and `Edit(int, Product)` processes  the posted form. To make this possible MVC would need to choose `Edit(int, Product)` when the request is an HTTP `POST` and `Edit(int)` when the HTTP verb is anything else.

The `HttpPostAttribute` ( `[HttpPost]` ) is an implementation of `IActionConstraint` that will only allow the action to be selected when the HTTP verb is `POST`. The presence of an `IActionConstraint` makes the `Edit(int, Product)` a 'better' match than `Edit(int)`, so `Edit(int, Product)` will be tried first.

You will only need to write custom `IActionConstraint` implementations in specialized scenarios, but it's important to understand the role of attributes like `HttpPostAttribute`  - similar attributes are defined for other HTTP verbs. In conventional routing it's common for actions to use the same action name when they're part of a `show form -> submit form` workflow. The convenience of this pattern will become more apparent after reviewing the [Understanding IActionConstraint](#understanding-iactionconstraint) section.

If multiple routes match, and MVC can't find a 'best' route, it will throw an `AmbiguousActionException`.

<a name="routing-route-name-ref-label"></a>

### Route names

The strings  `"blog"` and `"default"` in the following examples are route names:

```csharp
app.UseMvc(routes =>
{
   routes.MapRoute("blog", "blog/{*article}",
               defaults: new { controller = "Blog", action = "Article" });
   routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
});
```

The route names give the route a logical name so that the named route can be used for URL generation. This greatly simplifies URL creation when the ordering of routes could make URL generation complicated. Route names must be unique application-wide.

Route names have no impact on URL matching or handling of requests; they're used only for URL generation. [Routing](xref:fundamentals/routing) has more detailed information on URL generation including URL generation in MVC-specific helpers.

<a name="attribute-routing-ref-label"></a>

## Attribute routing

Attribute routing uses a set of attributes to map actions directly to route templates. In the following example, `app.UseMvc();` is used in the `Configure` method and no route is passed. The `HomeController` will match a set of URLs similar to what the default route `{controller=Home}/{action=Index}/{id?}` would match:

```csharp
public class HomeController : Controller
{
   [Route("")]
   [Route("Home")]
   [Route("Home/Index")]
   public IActionResult Index()
   {
      return View();
   }
   [Route("Home/About")]
   public IActionResult About()
   {
      return View();
   }
   [Route("Home/Contact")]
   public IActionResult Contact()
   {
      return View();
   }
}
```

The `HomeController.Index()` action will be executed for any of the URL paths `/`, `/Home`, or `/Home/Index`.

> [!NOTE]
> This example highlights a key programming difference between attribute routing and conventional routing. Attribute routing requires more input to specify a route; the conventional default route handles routes more succinctly. However, attribute routing allows (and requires) precise control of which route templates apply to each action.

With attribute routing the controller name and action names play **no** role in which action is selected. This example will match the same URLs as the previous example.

```csharp
public class MyDemoController : Controller
{
   [Route("")]
   [Route("Home")]
   [Route("Home/Index")]
   public IActionResult MyIndex()
   {
      return View("Index");
   }
   [Route("Home/About")]
   public IActionResult MyAbout()
   {
      return View("About");
   }
   [Route("Home/Contact")]
   public IActionResult MyContact()
   {
      return View("Contact");
   }
}
```

> [!NOTE]
> The route templates above don't define route parameters for `action`, `area`, and `controller`. In fact, these route parameters are not allowed in attribute routes. Since the route template is already associated with an action, it wouldn't make sense to parse the action name from the URL.

## Attribute routing with Http[Verb] attributes

Attribute routing can also make use of the `Http[Verb]` attributes such as `HttpPostAttribute`. All of these attributes can accept a route template. This example shows two actions that match the same route template:

```csharp
[HttpGet("/products")]
public IActionResult ListProducts()
{
   // ...
}

[HttpPost("/products")]
public IActionResult CreateProduct(...)
{
   // ...
}
```

For a URL path like `/products` the `ProductsApi.ListProducts` action will be executed when the HTTP verb is `GET` and `ProductsApi.CreateProduct` will be executed when the HTTP verb is `POST`. Attribute routing first matches the URL against the set of route templates defined by route attributes. Once a route template matches, `IActionConstraint` constraints are applied to determine which actions can be executed.

> [!TIP]
> When building a REST API, it's rare that you will want to use `[Route(...)]` on an action method as the action will accept all HTTP methods. It's better to use the more specific `Http*Verb*Attributes` to be precise about what your API supports. Clients of REST APIs are expected to know what paths and HTTP verbs map to specific logical operations.

Since an attribute route applies to a specific action, it's easy to make parameters required as part of the route template definition. In this example, `id` is required as part of the URL path.

```csharp
public class ProductsApiController : Controller
{
   [HttpGet("/products/{id}", Name = "Products_List")]
   public IActionResult GetProduct(int id) { ... }
}
```

The `ProductsApi.GetProduct(int)` action will be executed for a URL path like `/products/3` but not for a URL path like `/products`. See [Routing](xref:fundamentals/routing) for a full description of route templates and related options.

## Route Name

The following code  defines a *route name* of `Products_List`:

```csharp
public class ProductsApiController : Controller
{
   [HttpGet("/products/{id}", Name = "Products_List")]
   public IActionResult GetProduct(int id) { ... }
}
```

Route names can be used to generate a URL based on a specific route. Route names have no impact on the URL matching behavior of routing and are only used for URL generation. Route names must be unique application-wide.

> [!NOTE]
> Contrast this with the conventional *default route*, which defines the `id` parameter as optional (`{id?}`). This ability to precisely specify APIs has advantages, such as  allowing `/products` and `/products/5` to be dispatched to different actions.

<a name="routing-combining-ref-label"></a>

### Combining routes

To make attribute routing less repetitive, route attributes on the controller are combined with route attributes on the individual actions. Any route templates defined on the controller are prepended to route templates on the actions. Placing a route attribute on the controller makes **all** actions in the controller use attribute routing.

```csharp
[Route("products")]
public class ProductsApiController : Controller
{
   [HttpGet]
   public IActionResult ListProducts() { ... }

   [HttpGet("{id}")]
   public ActionResult GetProduct(int id) { ... }
}
```

In this example the URL path `/products` can match `ProductsApi.ListProducts`, and the URL path `/products/5` can match `ProductsApi.GetProduct(int)`. Both of these actions only match HTTP `GET` because they're marked with the `HttpGetAttribute`.

Route templates applied to an action that begin with `/` or `~/` don't get combined with route templates applied to the controller. This example matches a set of URL paths similar to the *default route*.

```csharp
[Route("Home")]
public class HomeController : Controller
{
    [Route("")]      // Combines to define the route template "Home"
    [Route("Index")] // Combines to define the route template "Home/Index"
    [Route("/")]     // Doesn't combine, defines the route template ""
    public IActionResult Index()
    {
        ViewData["Message"] = "Home index";
        var url = Url.Action("Index", "Home");
        ViewData["Message"] = "Home index" + "var url = Url.Action; =  " + url;
        return View();
    }

    [Route("About")] // Combines to define the route template "Home/About"
    public IActionResult About()
    {
        return View();
    }   
}
```

<a name="routing-ordering-ref-label"></a>

### Ordering attribute routes

In contrast to conventional routes, which execute in a defined order, attribute routing builds a tree and matches all routes simultaneously. This behaves as-if the route entries were placed in an ideal ordering; the most specific routes have a chance to execute before the more general routes.

For example, a route like `blog/search/{topic}` is more specific than a route like `blog/{*article}`. Logically speaking the `blog/search/{topic}` route 'runs' first, by default, because that's the only sensible ordering. Using conventional routing, the developer is  responsible for placing routes in the desired order.

Attribute routes can configure an order, using the `Order` property of all of the framework provided route attributes. Routes are processed according to an ascending sort of the `Order` property. The default order is `0`. Setting a route using `Order = -1` will run before routes that don't set an order. Setting a route using `Order = 1` will run after default route ordering.

> [!TIP]
> Avoid depending on `Order`. If your URL-space requires explicit order values to route correctly, then it's likely confusing to clients as well. In general attribute routing will select the correct route with URL matching. If the default order used for URL generation isn't working, using route name as an override is usually simpler than applying the `Order` property.

Razor Pages routing and MVC controller routing share an implementation. Information on route order in the Razor Pages topics is available at [Razor Pages route and app conventions: Route order](xref:razor-pages/razor-pages-conventions#route-order).

<a name="routing-token-replacement-templates-ref-label"></a>

## Token replacement in route templates ([controller], [action], [area])

For convenience, attribute routes support *token replacement* by enclosing a token in square-brackets (`[`, `]`). The tokens `[action]`, `[area]`, and `[controller]` are replaced with the values of the action name, area name, and controller name from the action where the route is defined. In the following example, the actions match URL paths as described in the comments:

[!code-csharp[](routing/samples/2.x/main/Controllers/ProductsController.cs?range=7-11,13-17,20-22)]

Token replacement occurs as the last step of building the attribute routes. The above example will behave the same as the following code:

[!code-csharp[](routing/samples/2.x/main/Controllers/ProductsController2.cs?range=7-11,13-17,20-22)]

Attribute routes can also be combined with inheritance. This is particularly powerful combined with token replacement.

```csharp
[Route("api/[controller]")]
public abstract class MyBaseController : Controller { ... }

public class ProductsController : MyBaseController
{
   [HttpGet] // Matches '/api/Products'
   public IActionResult List() { ... }

   [HttpPut("{id}")] // Matches '/api/Products/{id}'
   public IActionResult Edit(int id) { ... }
}
```

Token replacement also applies to route names defined by attribute routes. `[Route("[controller]/[action]", Name="[controller]_[action]")]` generates a unique route name for each action.

To match the literal token replacement delimiter `[` or  `]`, escape it by repeating the character (`[[` or `]]`).

::: moniker-end

::: moniker range="= aspnetcore-2.2"

<a name="routing-token-replacement-transformers-ref-label"></a>

### Use a parameter transformer to customize token replacement

Token replacement can be customized using a parameter transformer. A parameter transformer implements `IOutboundParameterTransformer` and transforms the value of parameters. For example, a custom `SlugifyParameterTransformer` parameter transformer changes the `SubscriptionManagement` route value to `subscription-management`.

The `RouteTokenTransformerConvention` is an application model convention that:

* Applies a parameter transformer to all attribute routes in an application.
* Customizes the attribute route token values as they are replaced.

```csharp
public class SubscriptionManagementController : Controller
{
    [HttpGet("[controller]/[action]")] // Matches '/subscription-management/list-all'
    public IActionResult ListAll() { ... }
}
```

The `RouteTokenTransformerConvention` is registered as an option in `ConfigureServices`.

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddMvc(options =>
    {
        options.Conventions.Add(new RouteTokenTransformerConvention(
                                     new SlugifyParameterTransformer()));
    });
}

public class SlugifyParameterTransformer : IOutboundParameterTransformer
{
    public string TransformOutbound(object value)
    {
        if (value == null) { return null; }

        // Slugify value
        return Regex.Replace(value.ToString(), "([a-z])([A-Z])", "$1-$2").ToLower();
    }
}
```

::: moniker-end


::: moniker range="< aspnetcore-3.0"
<a name="routing-multiple-routes-ref-label"></a>

### Multiple Routes

Attribute routing supports defining multiple routes that reach the same action. The most common usage of this is to mimic the behavior of the *default conventional route* as shown in the following example:

```csharp
[Route("[controller]")]
public class ProductsController : Controller
{
   [Route("")]     // Matches 'Products'
   [Route("Index")] // Matches 'Products/Index'
   public IActionResult Index()
}
```

Putting multiple route attributes on the controller means that each one will combine with each of the route attributes on the action methods.

```csharp
[Route("Store")]
[Route("[controller]")]
public class ProductsController : Controller
{
   [HttpPost("Buy")]     // Matches 'Products/Buy' and 'Store/Buy'
   [HttpPost("Checkout")] // Matches 'Products/Checkout' and 'Store/Checkout'
   public IActionResult Buy()
}
```

When multiple route attributes (that implement `IActionConstraint`) are placed on an action, then each action constraint combines with the route template from the attribute that defined it.

```csharp
[Route("api/[controller]")]
public class ProductsController : Controller
{
   [HttpPut("Buy")]      // Matches PUT 'api/Products/Buy'
   [HttpPost("Checkout")] // Matches POST 'api/Products/Checkout'
   public IActionResult Buy()
}
```

> [!TIP]
> While using multiple routes on actions can seem powerful, it's better to keep your application's URL space simple and well-defined. Use multiple routes on actions only where needed, for example to support existing clients.

<a name="routing-attr-options"></a>

### Specifying attribute route optional parameters, default values, and constraints

Attribute routes support the same inline syntax as conventional routes to specify optional parameters, default values, and constraints.

```csharp
[HttpPost("product/{id:int}")]
public IActionResult ShowProduct(int id)
{
   // ...
}
```

See [Route Template Reference](xref:fundamentals/routing#route-template-reference) for a detailed description of route template syntax.

<a name="routing-cust-rt-attr-irt-ref-label"></a>

### Custom route attributes using `IRouteTemplateProvider`

All of the route attributes provided in the framework ( `[Route(...)]`, `[HttpGet(...)]` , etc.) implement the `IRouteTemplateProvider` interface. MVC looks for attributes on controller classes and action methods when the app starts and uses the ones that implement `IRouteTemplateProvider` to build the initial set of routes.

You can implement `IRouteTemplateProvider` to define your own route attributes. Each `IRouteTemplateProvider` allows you to define a single route with a custom route template, order, and name:

```csharp
public class MyApiControllerAttribute : Attribute, IRouteTemplateProvider
{
   public string Template => "api/[controller]";

   public int? Order { get; set; }

   public string Name { get; set; }
}
```

The attribute from the above example automatically sets the `Template` to `"api/[controller]"` when `[MyApiController]` is applied.

<a name="routing-app-model-ref-label"></a>

### Using Application Model to customize attribute routes

The *application model* is an object model created at startup with all of the metadata used by MVC to route and execute your actions. The *application model* includes all of the data gathered from route attributes (through `IRouteTemplateProvider`). You can write *conventions* to modify the application model at startup time to customize how routing behaves. This section shows a simple example of customizing routing using application model.

[!code-csharp[](routing/samples/2.x/main/NamespaceRoutingConvention.cs)]

<a name="routing-mixed-ref-label"></a>

## Mixed routing: Attribute routing vs conventional routing

MVC applications can mix the use of conventional routing and attribute routing. It's typical to use conventional routes for controllers serving HTML pages for browsers, and attribute routing for controllers serving REST APIs.

Actions are either conventionally routed or attribute routed. Placing a route on the controller or the action makes it attribute routed. Actions that define attribute routes cannot be reached through the conventional routes and vice-versa. **Any** route attribute on the controller makes all actions in the controller attribute routed.

> [!NOTE]
> What distinguishes the two types of routing systems is the process applied after a URL matches a route template. In conventional routing, the route values from the match are used to choose the action and controller from a lookup table of all conventional routed actions. In attribute routing, each template is already associated with an action, and no further lookup is needed.

## Complex segments

Complex segments (for example, `[Route("/dog{token}cat")]`), are processed by matching up literals from right to left in a non-greedy way. See [the source code](https://github.com/aspnet/Routing/blob/9cea167cfac36cf034dbb780e3f783114ef94780/src/Microsoft.AspNetCore.Routing/Patterns/RoutePatternMatcher.cs#L296) for a description. For more information, see [this issue](https://github.com/dotnet/AspNetCore.Docs/issues/8197).

<a name="routing-url-gen-ref-label"></a>

## URL Generation

MVC applications can use routing's URL generation features to generate URL links to actions. Generating URLs eliminates hardcoding URLs, making your code more robust and maintainable. This section focuses on the URL generation features provided by MVC and will only cover basics of how URL generation works. See [Routing](xref:fundamentals/routing) for a detailed description of URL generation.

The `IUrlHelper` interface is the underlying piece of infrastructure between MVC and routing for URL generation. You'll find an instance of `IUrlHelper` available through the `Url` property in controllers, views, and view components.

In this example, the `IUrlHelper` interface is used through the `Controller.Url` property to generate a URL to another action.

[!code-csharp[](routing/samples/2.x/main/Controllers/UrlGenerationController.cs?name=snippet_1)]

If the application is using the default conventional route, the value of the `url` variable will be the URL path string `/UrlGeneration/Destination`. This URL path is created by routing by combining the route values from the current request (ambient values), with the values passed to `Url.Action` and substituting those values into the route template:

```
ambient values: { controller = "UrlGeneration", action = "Source" }
values passed to Url.Action: { controller = "UrlGeneration", action = "Destination" }
route template: {controller}/{action}/{id?}

result: /UrlGeneration/Destination
```

Each route parameter in the route template has its value substituted by matching names with the values and ambient values. A route parameter that doesn't have a value can use a default value if it has one, or be skipped if it's optional (as in the case of `id` in this example). URL generation will fail if any required route parameter doesn't have a corresponding value. If URL generation fails for a route, the next route is tried until all routes have been tried or a match is found.

The example of `Url.Action` above assumes conventional routing, but URL generation works similarly with attribute routing, though the concepts are different. With conventional routing, the route values are used to expand a template, and the route values for `controller` and `action` usually appear in that template - this works because the URLs matched by routing adhere to a *convention*. In attribute routing, the route values for `controller` and `action` are not allowed to appear in the template - they're instead used to look up which template to use.

This example uses attribute routing:

[!code-csharp[](routing/samples/2.x/main/StartupUseMvc.cs?name=snippet_1)]

[!code-csharp[](routing/samples/2.x/main/Controllers/UrlGenerationControllerAttr.cs?name=snippet_1)]

MVC builds a lookup table of all attribute routed actions and will match the `controller` and `action` values to select the route template to use for URL generation. In the sample above,   `custom/url/to/destination` is generated.

### Generating URLs by action name

`Url.Action` (`IUrlHelper` . `Action`) and all related overloads all are based on that idea that you want to specify what you're linking to by specifying a controller name and action name.

> [!NOTE]
> When using `Url.Action`, the current route values for `controller` and `action` are specified for you - the value of `controller` and `action` are part of both *ambient values* **and** *values*. The method `Url.Action`, always uses the current values of `action` and `controller` and will generate a URL path that routes to the current action.

Routing attempts to use the values in ambient values to fill in information that you didn't provide when generating a URL. Using a route like `{a}/{b}/{c}/{d}` and ambient values `{ a = Alice, b = Bob, c = Carol, d = David }`, routing has enough information to generate a URL without any additional values - since all route parameters have a value. If you added the value `{ d = Donovan }`, the value `{ d = David }` would be ignored, and the generated URL path would be `Alice/Bob/Carol/Donovan`.

> [!WARNING]
> URL paths are hierarchical. In the example above, if you added the value `{ c = Cheryl }`, both of the values `{ c = Carol, d = David }` would be ignored. In this case we no longer have a value for `d` and URL generation will fail. You would need to specify the desired value of `c` and `d`.  You might expect to hit this problem with the default route (`{controller}/{action}/{id?}`) - but you will rarely encounter this behavior in practice as `Url.Action` will always explicitly specify a `controller` and `action` value.

Longer overloads of `Url.Action` also take an additional *route values* object to provide values for route parameters other than `controller` and `action`. You will most commonly see this used with `id` like `Url.Action("Buy", "Products", new { id = 17 })`. By convention the *route values* object is usually an object of anonymous type, but it can also be an `IDictionary<>` or a *plain old .NET object*. Any additional route values that don't match route parameters are put in the query string.

[!code-csharp[](routing/samples/2.x/main/Controllers/TestController.cs)]

> [!TIP]
> To create an absolute URL, use an overload that accepts a `protocol`: `Url.Action("Buy", "Products", new { id = 17 }, protocol: Request.Scheme)`

<a name="routing-gen-urls-route-ref-label"></a>

### Generating URLs by route

The code above demonstrated generating a URL by passing in the controller and action name. `IUrlHelper` also provides the `Url.RouteUrl` family of methods. These methods are similar to `Url.Action`, but they don't copy the current values of `action` and `controller` to the route values. The most common usage is to specify a route name to use a specific route to generate the URL, generally *without* specifying a controller or action name.

[!code-csharp[](routing/samples/2.x/main/Controllers/UrlGenerationControllerRouting.cs?name=snippet_1)]

<a name="routing-gen-urls-html-ref-label"></a>

### Generating URLs in HTML

`IHtmlHelper` provides the `HtmlHelper` methods `Html.BeginForm` and `Html.ActionLink` to generate `<form>` and `<a>` elements respectively. These methods use the `Url.Action` method to generate a URL and they accept similar arguments. The `Url.RouteUrl` companions for `HtmlHelper` are `Html.BeginRouteForm` and `Html.RouteLink` which have similar functionality.

TagHelpers generate URLs through the `form` TagHelper and the `<a>` TagHelper. Both of these use `IUrlHelper` for their implementation. See [Working with Forms](../views/working-with-forms.md) for more information.

Inside views, the `IUrlHelper` is available through the `Url` property for any ad-hoc URL generation not covered by the above.

<a name="routing-gen-urls-action-ref-label"></a>

### Generating URLS in Action Results

The examples above have shown using `IUrlHelper` in a controller, while the most common usage in a controller is to generate a URL as part of an action result.

The `ControllerBase` and `Controller` base classes provide convenience methods for action results that reference another action. One typical usage is to redirect after accepting user input.

```csharp
public IActionResult Edit(int id, Customer customer)
{
    if (ModelState.IsValid)
    {
        // Update DB with new details.
        return RedirectToAction("Index");
    }
    return View(customer);
}
```

The action results factory methods follow a similar pattern to the methods on `IUrlHelper`.

<a name="routing-dedicated-ref-label"></a>

### Special case for dedicated conventional routes

Conventional routing can use a special kind of route definition called a *dedicated conventional route*. In the example below, the route named `blog` is a dedicated conventional route.

```csharp
app.UseMvc(routes =>
{
    routes.MapRoute("blog", "blog/{*article}",
        defaults: new { controller = "Blog", action = "Article" });
    routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
});
```

Using these route definitions, `Url.Action("Index", "Home")` will generate the URL path `/` with the `default` route, but why? You might guess the route values `{ controller = Home, action = Index }` would be enough to generate a URL using `blog`, and the result would be `/blog?action=Index&controller=Home`.

Dedicated conventional routes rely on a special behavior of default values that don't have a corresponding route parameter that prevents the route from being "too greedy" with URL generation. In this case the default values are `{ controller = Blog, action = Article }`, and neither `controller` nor `action` appears as a route parameter. When routing performs URL generation, the values provided must match the default values. URL generation using `blog` will fail because the values `{ controller = Home, action = Index }` don't match `{ controller = Blog, action = Article }`. Routing then falls back to try `default`, which succeeds.

<a name="routing-areas-ref-label"></a>

## Areas

[Areas](areas.md) are an MVC feature used to organize related functionality into a group as a separate routing-namespace (for controller actions) and folder structure (for views). Using areas allows an application to have multiple controllers with the same name - as long as they have different *areas*. Using areas creates a hierarchy for the purpose of routing by adding another route parameter, `area` to `controller` and `action`. This section will discuss how routing interacts with areas - see [Areas](areas.md) for details about how areas are used with views.

The following example configures MVC to use the default conventional route and an *area route* for an area named `Blog`:

[!code-csharp[](routing/samples/3.x/AreasRouting/Startup.cs?name=snippet1)]

When matching a URL path like `/Manage/Users/AddUser`, the first route will produce the route values `{ area = Blog, controller = Users, action = AddUser }`. The `area` route value is produced by a default value for `area`, in fact the route created by `MapAreaRoute` is equivalent to the following:

[!code-csharp[](routing/samples/3.x/AreasRouting/Startup.cs?name=snippet2)]

`MapAreaRoute` creates a route using both a default value and constraint for `area` using the provided area name, in this case `Blog`. The default value ensures that the route always produces `{ area = Blog, ... }`, the constraint requires the value `{ area = Blog, ... }` for URL generation.

> [!TIP]
> Conventional routing is order-dependent. In general, routes with areas should be placed earlier in the route table as they're more specific than routes without an area.

Using the above example, the route values would match the following action:

[!code-csharp[](routing/samples/3.x/AreasRouting/Areas/Blog/Controllers/UsersController.cs)]

The `AreaAttribute` is what denotes a controller as part of an area, we say that this controller is in the `Blog` area. Controllers without an `[Area]` attribute are not members of any area, and will **not** match when the `area` route value is provided by routing. In the following example, only the first controller listed can match the route values `{ area = Blog, controller = Users, action = AddUser }`.

[!code-csharp[](routing/samples/3.x/AreasRouting/Areas/Blog/Controllers/UsersController.cs)]

[!code-csharp[](routing/samples/3.x/AreasRouting/Areas/Zebra/Controllers/UsersController.cs)]

[!code-csharp[](routing/samples/3.x/AreasRouting/Controllers/UsersController.cs)]

> [!NOTE]
> The namespace of each controller is shown here for completeness - otherwise the controllers would have a naming conflict and generate a compiler error. Class namespaces have no effect on MVC's routing.

The first two controllers are members of areas, and only match when their respective area name is provided by the `area` route value. The third controller isn't a member of any area, and can only match when no value for `area` is provided by routing.

> [!NOTE]
> In terms of matching *no value*, the absence of the `area` value is the same as if the value for `area` were null or the empty string.

When executing an action inside an area, the route value for `area` will be available as an *ambient value* for routing to use for URL generation. This means that by default areas act *sticky* for URL generation as demonstrated by the following sample.
[!code-csharp[](routing/samples/3.x/AreasRouting/Startup.cs?name=snippet3)]

[!code-csharp[](routing/samples/3.x/AreasRouting/Areas/Duck/Controllers/UsersController.cs)]

<a name="iactionconstraint-ref-label"></a>

## Understanding IActionConstraint

> [!NOTE]
> This section is a deep-dive on framework internals and how MVC chooses an action to execute. A typical application won't need a custom `IActionConstraint`

You have likely already used `IActionConstraint` even if you're not familiar with the interface. The `[HttpGet]` Attribute and similar `[Http-VERB]` attributes implement `IActionConstraint` in order to limit the execution of an action method.

```csharp
public class ProductsController : Controller
{
    [HttpGet]
    public IActionResult Edit() { }

    public IActionResult Edit(...) { }
}
```

Assuming the default conventional route, the URL path `/Products/Edit` would produce the values `{ controller = Products, action = Edit }`, which would match **both** of the actions shown here. In `IActionConstraint` terminology we would say that both of these actions are considered candidates - as they both match the route data.

When the `HttpGetAttribute` executes, it will say that *Edit()* is a match for *GET* and isn't a match for any other HTTP verb. The `Edit(...)` action doesn't have any constraints defined, and so will match any HTTP verb. So assuming a `POST` - only `Edit(...)` matches. But, for a `GET` both actions can still match - however, an action with an `IActionConstraint` is always considered *better* than an action without. So because `Edit()` has `[HttpGet]` it's considered more specific, and will be selected if both actions can match.

Conceptually, `IActionConstraint` is a form of *overloading*, but instead of overloading methods with the same name, it's overloading between actions that match the same URL. Attribute routing also uses `IActionConstraint` and can result in actions from different controllers both being considered candidates.

<a name="iactionconstraint-impl-ref-label"></a>

### Implementing IActionConstraint

The simplest way to implement an `IActionConstraint` is to create a class derived from `System.Attribute` and place it on your actions and controllers. MVC will automatically discover any `IActionConstraint` that are applied as attributes. You can use the application model to apply constraints, and this is probably the most flexible approach as it allows you to metaprogram how they're applied.

In the following example, a constraint chooses an action based on a *country code* from the route data. The [full sample on GitHub](https://github.com/aspnet/Entropy/blob/master/samples/Mvc.ActionConstraintSample.Web/CountrySpecificAttribute.cs).

```csharp
public class CountrySpecificAttribute : Attribute, IActionConstraint
{
    private readonly string _countryCode;

    public CountrySpecificAttribute(string countryCode)
    {
        _countryCode = countryCode;
    }

    public int Order
    {
        get
        {
            return 0;
        }
    }

    public bool Accept(ActionConstraintContext context)
    {
        return string.Equals(
            context.RouteContext.RouteData.Values["country"].ToString(),
            _countryCode,
            StringComparison.OrdinalIgnoreCase);
    }
}
```

You are responsible for implementing the `Accept` method and choosing an 'Order' for the constraint to execute. In this case, the `Accept` method returns `true` to denote the action is a match when the `country` route value matches. This is different from a `RouteValueAttribute` in that it allows fallback to a non-attributed action. The sample shows that if you define an `en-US` action then a country code like `fr-FR` will fall back to a more generic controller that doesn't have `[CountrySpecific(...)]` applied.

The `Order` property decides which *stage* the constraint is part of. Action constraints run in groups based on the `Order`. For example, all of the framework provided HTTP method attributes use the same `Order` value so that they run in the same stage. You can have as many stages as you need to implement your desired policies.

> [!TIP]
> To decide on a value for `Order` think about whether or not your constraint should be applied before HTTP methods. Lower numbers run first.

::: moniker-end
