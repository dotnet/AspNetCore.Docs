---
title: Routing to controller actions in ASP.NET Core
author: rick-anderson
description: Learn how ASP.NET Core MVC uses Routing Middleware to match URLs of incoming requests and map them to actions.
ms.author: riande
ms.date: 04/08/2022
uid: mvc/controllers/routing
---
# Routing to controller actions in ASP.NET Core

By [Ryan Nowak](https://github.com/rynowak), [Kirk Larkin](https://twitter.com/serpent5), and [Rick Anderson](https://twitter.com/RickAndMSFT)

[!INCLUDE[](~/includes/not-latest-version.md)]

:::moniker range=">= aspnetcore-6.0"

ASP.NET Core controllers use the Routing [middleware](xref:fundamentals/middleware/index) to match the URLs of incoming requests and map them to [actions](#action).  Route templates:

* Are defined at startup in `Program.cs` or in attributes.
* Describe how URL paths are matched to [actions](#action).
* Are used to generate URLs for links. The generated links are typically returned in responses.

Actions are either [conventionally-routed](#cr6) or [attribute-routed](#ar6). Placing a route on the controller or [action](#action) makes it attribute-routed. See [Mixed routing](#routing-mixed-ref-label) for more information.

This document:

* Explains the interactions between MVC and routing:
  * How typical MVC apps make use of routing features.
  * Covers both:
    * [Conventional routing](#cr6) typically used with controllers and views.
    * *Attribute routing* used with REST APIs. If you're primarily interested in routing for REST APIs, jump to the [Attribute routing for REST APIs](#ar6) section.
  * See [Routing](xref:fundamentals/routing) for advanced routing details.
* Refers to the default routing system called endpoint routing. It's possible to use controllers with the previous version of routing for compatibility purposes. See the [2.2-3.0 migration guide](xref:migration/22-to-30) for instructions.

<a name="cr6"></a>

## Set up conventional route

The ASP.NET Core MVC template generates [conventional routing](#crd6) code similar to the following:

[!code-csharp[](routing/samples/6.x/main/Program.cs?name=snippet&highlight=20-22)]

<xref:Microsoft.AspNetCore.Builder.ControllerEndpointRouteBuilderExtensions.MapControllerRoute%2A> is used to create a single route. The single route is named `default` route. Most apps with controllers and views use a route template similar to the `default` route. REST APIs should use [attribute routing](#ar6).

[!code-csharp[](routing/samples/6.x/main/Program.cs?name=snippet2)]

The route template `"{controller=Home}/{action=Index}/{id?}"`:

* Matches a URL path like `/Products/Details/5`
* Extracts the route values `{ controller = Products, action = Details, id = 5 }` by tokenizing the path. The extraction of route values results in a match if the app has a controller named `ProductsController` and a `Details` action:

  [!code-csharp[](routing/samples/6.x/main/Controllers/ProductsController.cs?name=snippetA)]

  [!INCLUDE[](~/includes/MyDisplayRouteInfo.md)]

* `/Products/Details/5` model binds the value of `id = 5` to set the `id` parameter to `5`. See [Model Binding](xref:mvc/models/model-binding) for more details.
* `{controller=Home}` defines `Home` as the default `controller`.
* `{action=Index}` defines `Index` as the default `action`.
* The `?` character in `{id?}` defines `id` as optional.
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

The convenience method <xref:Microsoft.AspNetCore.Builder.ControllerEndpointRouteBuilderExtensions.MapDefaultControllerRoute%2A>:

[!code-csharp[](routing/samples/6.x/main/Program.cs?name=snippet4)]

Replaces:

[!code-csharp[](routing/samples/6.x/main/Program.cs?name=snippet2)]

> [!IMPORTANT]
> Routing is configured using the <xref:Microsoft.AspNetCore.Builder.EndpointRoutingApplicationBuilderExtensions.UseRouting%2A> and <xref:Microsoft.AspNetCore.Builder.EndpointRoutingApplicationBuilderExtensions.UseEndpoints%2A> middleware. To use controllers:
>
> * Call <xref:Microsoft.AspNetCore.Builder.ControllerEndpointRouteBuilderExtensions.MapControllers%2A> to map [attribute routed](#ar6) controllers.
> * Call <xref:Microsoft.AspNetCore.Builder.ControllerEndpointRouteBuilderExtensions.MapControllerRoute%2A> or <xref:Microsoft.AspNetCore.Builder.ControllerEndpointRouteBuilderExtensions.MapAreaControllerRoute%2A>, to map both [conventionally routed](#cr6) controllers and [attribute routed](#ar6) controllers.
>
> Apps typically don't need to call `UseRouting` or `UseEndpoints`. <xref:Microsoft.AspNetCore.Builder.WebApplicationBuilder> configures a middleware pipeline that wraps middleware added in `Program.cs` with `UseRouting` and `UseEndpoints`. For more information, see <xref:fundamentals/routing>.

<a name="routing-conventional-ref-label"></a>
<a name="crd6"></a>

## Conventional routing

Conventional routing is used with controllers and views. The `default` route:

[!code-csharp[](routing/samples/6.x/main/Program.cs?name=snippet2)]

The preceding is an example of a *conventional route*. It's called *conventional routing* because it establishes a *convention* for URL paths:

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
> The `id` in the preceding code is defined as optional by the route template. Actions can execute without the optional ID provided as part of the URL. Generally, when `id` is omitted from the URL:
>
> * `id` is set to `0` by model binding.
> * No entity is found in the database matching `id == 0`.
>
> [Attribute routing](#ar6) provides fine-grained control to make the ID required for some actions and not for others. By convention, the documentation includes optional parameters like `id` when they're likely to appear in correct usage.

Most apps should choose a basic and descriptive routing scheme so that URLs are readable and meaningful. The default conventional route `{controller=Home}/{action=Index}/{id?}`:

* Supports a basic and descriptive routing scheme.
* Is a useful starting point for UI-based apps.
* Is the only route template needed for many web UI apps. For larger web UI apps, another route using [Areas](#areas) is frequently all that's needed.

<xref:Microsoft.AspNetCore.Builder.ControllerEndpointRouteBuilderExtensions.MapControllerRoute%2A> and <xref:Microsoft.AspNetCore.Builder.MvcAreaRouteBuilderExtensions.MapAreaRoute%2A> :

* Automatically assign an **order** value to their endpoints based on the order they are invoked.

Endpoint routing in ASP.NET Core:

* Doesn't have a concept of routes.
* Doesn't provide ordering guarantees for the execution of extensibility,  all endpoints are processed at once.

Enable [Logging](xref:fundamentals/logging/index) to see how the built-in routing implementations, such as <xref:Microsoft.AspNetCore.Routing.Route>, match requests.

[Attribute routing](#ar6) is explained later in this document.

<a name="mr6"></a>

### Multiple conventional routes

Multiple [conventional routes](#cr6) can be configured by adding more calls to <xref:Microsoft.AspNetCore.Builder.ControllerEndpointRouteBuilderExtensions.MapControllerRoute%2A> and <xref:Microsoft.AspNetCore.Builder.ControllerEndpointRouteBuilderExtensions.MapAreaControllerRoute%2A>. Doing so allows defining multiple conventions, or to adding conventional routes that are dedicated to a specific [action](#action), such as:

[!code-csharp[](routing/samples/6.x/main/Program.cs?name=snippet_mcr)]

<a name="dcr"></a>

The `blog` route in the preceding code is a **dedicated conventional route**. It's called a dedicated conventional route because:

* It uses [conventional routing](#cr6).
* It's dedicated to a specific [action](#action).

Because `controller` and `action` don't appear in the route template `"blog/{*article}"` as parameters:

* They can only have the default values `{ controller = "Blog", action = "Article" }`.
* This route always maps to the action `BlogController.Article`.

`/Blog`, `/Blog/Article`, and `/Blog/{any-string}` are the only URL paths that match the blog route.

The preceding example:

* `blog` route has a higher priority for matches than the `default` route because it is added first.
* Is an example of [Slug](https://developer.mozilla.org/docs/Glossary/Slug) style routing where it's typical to have an article name as part of the URL.

> [!WARNING]
> In ASP.NET Core, routing doesn't:
> * Define a concept called a *route*. `UseRouting` adds route matching to the middleware pipeline. The `UseRouting` middleware looks at the set of endpoints defined in the app, and selects the best endpoint match based on the request.
> * Provide guarantees about the execution order of extensibility like <xref:Microsoft.AspNetCore.Routing.IRouteConstraint> or <xref:Microsoft.AspNetCore.Mvc.ActionConstraints.IActionConstraint>.
>
>See [Routing](xref:fundamentals/routing) for reference material on routing.

<a name="cro6"></a>

### Conventional routing order

Conventional routing only matches a combination of action and controller that are defined by the app. This is intended to simplify cases where conventional routes overlap.
Adding routes using <xref:Microsoft.AspNetCore.Builder.ControllerEndpointRouteBuilderExtensions.MapControllerRoute%2A>, <xref:Microsoft.AspNetCore.Builder.ControllerEndpointRouteBuilderExtensions.MapDefaultControllerRoute%2A>, and <xref:Microsoft.AspNetCore.Builder.ControllerEndpointRouteBuilderExtensions.MapAreaControllerRoute%2A> automatically assign an order value to their endpoints based on the order they are invoked. Matches from a route that appears earlier have a higher priority. Conventional routing is order-dependent. In general, routes with areas should be placed earlier as they're more specific than routes without an area. [Dedicated conventional routes](#dcr) with catch-all route parameters like `{*article}` can make a route too [greedy](xref:fundamentals/routing#greedy), meaning that it matches URLs that you intended to be matched by other routes. Put the greedy routes later in the route table to prevent greedy matches.

[!INCLUDE[](~/includes/catchall.md)]

<a name="best"></a>

### Resolving ambiguous actions

When two endpoints match through routing, routing must do one of the following:

* Choose the best candidate.
* Throw an exception.

For example:

[!code-csharp[](routing/samples/6.x/main/Controllers/ProductsController.cs?name=snippet9)]

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

It's important to understand the role of attributes like `HttpPostAttribute`. Similar attributes are defined for other [HTTP verbs](#verb). In [conventional routing](#cr6), it's common for actions to use the same action name when they're part of a show form, submit form workflow. For example, see [Examine the two Edit action methods](xref:tutorials/first-mvc-app/controller-methods-views#get-post).

If routing can't choose a best candidate, an <xref:System.Reflection.AmbiguousMatchException> is thrown, listing the multiple matched endpoints.

<a name="routing-route-name-ref-label"></a>

### Conventional route names

The strings  `"blog"` and `"default"` in the following examples are conventional route names:

[!code-csharp[](routing/samples/6.x/main/Program.cs?name=snippet_mcr)]

The route names give the route a logical name. The named route can be used for URL generation. Using a named route simplifies URL creation when the ordering of routes could make URL generation complicated. Route names must be unique application wide.

Route names:

* Have no impact on URL matching or handling of requests.
* Are used only for URL generation.

The route name concept is represented in routing as [IEndpointNameMetadata](xref:Microsoft.AspNetCore.Routing.IEndpointNameMetadata). The terms **route name** and **endpoint name**:

* Are interchangeable.
* Which one is used in documentation and code depends on the API being described.

<a name="attribute-routing-ref-label"></a>
<a name="ar6"></a>

## Attribute routing for REST APIs

REST APIs should use attribute routing to model the app's functionality as a set of resources where operations are represented by [HTTP verbs](#verb).

Attribute routing uses a set of attributes to map actions directly to route templates. The following code is typical for a REST API and is used in the next sample:

[!code-csharp[](routing/samples/6.x/main/Program.cs?name=snippet_webapi)]

In the preceding code, <xref:Microsoft.AspNetCore.Builder.ControllerEndpointRouteBuilderExtensions.MapControllers%2A> is called to map attribute routed controllers.

In the following example:

* `HomeController` matches a set of URLs similar to what the default conventional route `{controller=Home}/{action=Index}/{id?}` matches.

[!code-csharp[](routing/samples/6.x/main/Controllers/HomeController.cs?name=snippet2)]

The `HomeController.Index` action is run for any of the URL paths `/`, `/Home`, `/Home/Index`, or `/Home/Index/3`.

This example highlights a key programming difference between attribute routing and [conventional routing](#cr6). Attribute routing requires more input to specify a route. The conventional default route handles routes more succinctly. However, attribute routing allows and requires precise control of which route templates apply to each [action](#action).

With attribute routing, the controller and action names play no part in which action is matched, unless [token replacement](#routing-token-replacement-templates-ref-label) is used. The following example matches the same URLs as the previous example:

[!code-csharp[](routing/samples/6.x/main/Controllers/MyDemoController.cs?name=snippet)]

The following code uses token replacement for `action` and `controller`:

[!code-csharp[](routing/samples/6.x/main/Controllers/HomeController.cs?name=snippet22)]

The following code applies `[Route("[controller]/[action]")]` to the controller:

[!code-csharp[](routing/samples/6.x/main/Controllers/HomeController.cs?name=snippet24)]

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

[!code-csharp[](routing/samples/6.x/main/Controllers/MyDemo2Controller.cs?name=snippet)]

The special parameter names are used by the URL generation to determine if a URL generation operation refers to a Razor Page or to a Controller.

The following keywords are reserved in the context of a Razor view or a Razor Page:

* `page`
* `using`
* `namespace`
* `inject`
* `section`
* `inherits`
* `model`
* `addTagHelper`
* `removeTagHelper`

These keywords shouldn't be used for link generations, model bound parameters, or top level properties.

<a name="verb6"></a>

## HTTP verb templates

ASP.NET Core has the following HTTP verb templates:

* [[HttpGet]](xref:Microsoft.AspNetCore.Mvc.HttpGetAttribute)
* [[HttpPost]](xref:Microsoft.AspNetCore.Mvc.HttpPostAttribute)
* [[HttpPut]](xref:Microsoft.AspNetCore.Mvc.HttpPutAttribute)
* [[HttpDelete]](xref:Microsoft.AspNetCore.Mvc.HttpDeleteAttribute)
* [[HttpHead]](xref:Microsoft.AspNetCore.Mvc.HttpHeadAttribute)
* [[HttpPatch]](xref:Microsoft.AspNetCore.Mvc.HttpPatchAttribute)

<a name="rt6"></a>

### Route templates

ASP.NET Core has the following route templates:

* All the [HTTP verb templates](#verb6) are route templates.
* [[Route]](xref:Microsoft.AspNetCore.Mvc.RouteAttribute)

<a name="arx"></a>

### Attribute routing with Http verb attributes

Consider the following controller:

[!code-csharp[](routing/samples/6.x/main/Controllers/Test2Controller.cs?name=snippet)]

In the preceding code:

* Each action contains the `[HttpGet]` attribute, which constrains matching to HTTP GET requests only.
* The `GetProduct` action includes the `"{id}"` template, therefore `id` is appended to the `"api/[controller]"` template on the controller. The methods template is `"api/[controller]/{id}"`. Therefore this action only matches GET requests for the form `/api/test2/xyz`,`/api/test2/123`,`/api/test2/{any string}`, etc.
  [!code-csharp[](routing/samples/6.x/main/Controllers/Test2Controller.cs?name=snippet2)]
* The `GetIntProduct` action contains the `"int/{id:int}"` template. The `:int` portion of the template constrains the `id` route values to strings that can be converted to an integer. A GET request to `/api/test2/int/abc`:
  * Doesn't match this action.
  * Returns a [404 Not Found](https://developer.mozilla.org/docs/Web/HTTP/Status/404) error.
    [!code-csharp[](routing/samples/6.x/main/Controllers/Test2Controller.cs?name=snippet3)]
* The `GetInt2Product` action contains `{id}` in the template, but doesn't constrain `id` to values that can be converted to an integer. A GET request to `/api/test2/int2/abc`:
  * Matches this route.
  * Model binding fails to convert `abc` to an integer. The `id` parameter of the method is integer.
  * Returns a [400 Bad Request](https://developer.mozilla.org/docs/Web/HTTP/Status/400) because model binding failed to convert `abc` to an integer.
      [!code-csharp[](routing/samples/6.x/main/Controllers/Test2Controller.cs?name=snippet4)]

Attribute routing can use <xref:Microsoft.AspNetCore.Mvc.Routing.HttpMethodAttribute> attributes such as <xref:Microsoft.AspNetCore.Mvc.HttpPostAttribute>, <xref:Microsoft.AspNetCore.Mvc.HttpPutAttribute>, and <xref:Microsoft.AspNetCore.Mvc.HttpDeleteAttribute>. All of the [HTTP verb](#verb6) attributes accept a route template. The following example shows two actions that match the same route template:

[!code-csharp[](routing/samples/6.x/main/Controllers/MyProductsController.cs?name=snippet1)]

Using the URL path `/products3`:

* The `MyProductsController.ListProducts` action runs when the [HTTP verb](#verb6) is `GET`.
* The `MyProductsController.CreateProduct` action runs when the [HTTP verb](#verb6) is `POST`.

When building a REST API, it's rare that you'll need to use `[Route(...)]` on an action method because the action accepts all HTTP methods. It's better to use the more specific [HTTP verb attribute](#verb6) to be precise about what your API supports. Clients of REST APIs are expected to know what paths and HTTP verbs map to specific logical operations.

REST APIs should use attribute routing to model the app's functionality as a set of resources where operations are represented by HTTP verbs. This means that many operations, for example, GET and POST on the same logical resource use the same URL. Attribute routing provides a level of control that's needed to carefully design an API's public endpoint layout.

Since an attribute route applies to a specific action, it's easy to make parameters required as part of the route template definition. In the following example, `id` is required as part of the URL path:

[!code-csharp[](routing/samples/6.x/main/Controllers/ProductsApiController.cs?name=snippet2)]

The `Products2ApiController.GetProduct(int)` action:

* Is run with URL path like `/products2/3`
* Isn't run with the URL path `/products2`.

The [[Consumes]](xref:Microsoft.AspNetCore.Mvc.ConsumesAttribute) attribute allows an action to limit the supported request content types. For more information, see [Define supported request content types with the Consumes attribute](xref:web-api/index#consumes).

 See [Routing](xref:fundamentals/routing) for a full description of route templates and related options.

For more information on `[ApiController]`, see [ApiController attribute](xref:web-api/index##apicontroller-attribute).

## Route name

The following code  defines a route name of `Products_List`:

[!code-csharp[](routing/samples/6.x/main/Controllers/ProductsApiController.cs?name=snippet2)]

Route names can be used to generate a URL based on a specific route. Route names:

* Have no impact on the URL matching behavior of routing.
* Are only used for URL generation.

Route names must be unique application-wide.

Contrast the preceding code with the conventional default route, which defines the `id` parameter as optional (`{id?}`). The ability to precisely specify APIs has advantages, such as  allowing `/products` and `/products/5` to be dispatched to different actions.

<a name="routing-combining-ref-label"></a>

## Combining attribute routes

To make attribute routing less repetitive, route attributes on the controller are combined with route attributes on the individual actions. Any route templates defined on the controller are prepended to route templates on the actions. Placing a route attribute on the controller makes **all** actions in the controller use attribute routing.

[!code-csharp[](routing/samples/6.x/main/Controllers/ProductsApiController.cs?name=snippet)]

In the preceding example:

* The URL path `/products` can match `ProductsApi.ListProducts`
* The URL path `/products/5` can match `ProductsApi.GetProduct(int)`.

Both of these actions only match HTTP `GET` because they're marked with the `[HttpGet]` attribute.

Route templates applied to an action that begin with `/` or `~/` don't get combined with route templates applied to the controller. The following example matches a set of URL paths similar to the default route.

[!code-csharp[](routing/samples/6.x/main/Controllers/HomeController.cs?name=snippet)]

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

For example, an attribute route like `blog/search/{topic}` is more specific than an attribute route like `blog/{*article}`. The `blog/search/{topic}` route has higher priority, by default, because it's more specific. Using [conventional routing](#cr6), the developer is responsible for placing routes in the desired order.

Attribute routes can configure an order using the <xref:Microsoft.AspNetCore.Mvc.RouteAttribute.Order> property. All of the framework provided [route attributes](xref:Microsoft.AspNetCore.Mvc.RouteAttribute) include `Order` . Routes are processed according to an ascending sort of the `Order` property. The default order is `0`. Setting a route using `Order = -1` runs before routes that don't set an order. Setting a route using `Order = 1` runs after default route ordering.

**Avoid** depending on `Order`. If an app's URL-space requires explicit order values to route correctly, then it's likely confusing to clients as well. In general, attribute routing selects the correct route with URL matching. If the default order used for URL generation isn't working, using a route name as an override is usually simpler than applying the `Order` property.

Consider the following two controllers which both define the route matching `/home`:

[!code-csharp[](routing/samples/6.x/main/Controllers/HomeController.cs?name=snippet2)]

[!code-csharp[](routing/samples/6.x/main/Controllers/MyDemoController.cs?name=snippet)]

Requesting `/home` with the preceding code throws an exception similar to the following:

```text
AmbiguousMatchException: The request matched multiple endpoints. Matches:

 WebMvcRouting.Controllers.HomeController.Index
 WebMvcRouting.Controllers.MyDemoController.MyIndex
```

Adding `Order` to one of the route attributes resolves the ambiguity:

[!code-csharp[](routing/samples/6.x/main/Controllers/MyDemo3Controller.cs?name=snippet3& highlight=2)]

With the preceding code, `/home` runs the `HomeController.Index` endpoint. To get to the `MyDemoController.MyIndex`, request `/home/MyIndex`. **Note**:

* The preceding code is an example or poor routing design. It was used to illustrate the `Order` property.
* The `Order` property only resolves the ambiguity, that template cannot be matched. It would be better to remove the `[Route("Home")]` template.

See [Razor Pages route and app conventions: Route order](xref:razor-pages/razor-pages-conventions#route-order) for information on route order with Razor Pages.

In some cases, an HTTP 500 error is returned with ambiguous routes. Use [logging](xref:fundamentals/logging/index) to see which endpoints caused the `AmbiguousMatchException`.

<a name="routing-token-replacement-templates-ref-label"></a>

## Token replacement in route templates [controller], [action], [area]

For convenience, attribute routes support *token replacement* by enclosing a token in square-brackets (`[`, `]`). The tokens `[action]`, `[area]`, and `[controller]` are replaced with the values of the action name, area name, and controller name from the action where the route is defined:

[!code-csharp[](routing/samples/6.x/main/Controllers/ProductsController.cs?name=snippet)]

In the preceding code:

[!code-csharp[](routing/samples/6.x/main/Controllers/ProductsController.cs?name=snippet10)]

* Matches `/Products0/List`

[!code-csharp[](routing/samples/6.x/main/Controllers/ProductsController.cs?name=snippet11)]

* Matches `/Products0/Edit/{id}`

Token replacement occurs as the last step of building the attribute routes. The preceding example behaves the same as the following code:

[!code-csharp[](routing/samples/6.x/main/Controllers/ProductsController.cs?name=snippet20)]

[!INCLUDE[](~/includes/MTcomments.md)]

Attribute routes can also be combined with inheritance. This is powerful combined with token replacement. Token replacement also applies to route names defined by attribute routes.
`[Route("[controller]/[action]", Name="[controller]_[action]")]`generates a unique route name for each action:

[!code-csharp[](routing/samples/6.x/main/Controllers/ProductsController.cs?name=snippet5)]

To match the literal token replacement delimiter `[` or  `]`, escape it by repeating the character (`[[` or `]]`).

<a name="routing-token-replacement-transformers-ref-label"></a>

### Use a parameter transformer to customize token replacement

Token replacement can be customized using a parameter transformer. A parameter transformer implements <xref:Microsoft.AspNetCore.Routing.IOutboundParameterTransformer> and transforms the value of parameters. For example, a custom `SlugifyParameterTransformer` parameter transformer changes the `SubscriptionManagement` route value to `subscription-management`:

[!code-csharp[](routing/samples/6.x/main/SlugifyParameterTransformer.cs)]

The <xref:Microsoft.AspNetCore.Mvc.ApplicationModels.RouteTokenTransformerConvention> is an application model convention that:

* Applies a parameter transformer to all attribute routes in an application.
* Customizes the attribute route token values as they are replaced.

[!code-csharp[](routing/samples/6.x/main/Controllers/SubscriptionManagementController.cs?name=snippet)]

The preceding `ListAll` method matches `/subscription-management/list-all`.

The `RouteTokenTransformerConvention` is registered as an option:

[!code-csharp[](routing/samples/6.x/main/Program.cs?name=snippet_slug&range=5-9)]

See [MDN web docs on Slug](https://developer.mozilla.org/docs/Glossary/Slug) for the definition of Slug.

[!INCLUDE[](~/includes/regex.md)]
<a name="routing-multiple-routes-ref-label"></a>

### Multiple attribute routes

Attribute routing supports defining multiple routes that reach the same action. The most common usage of this is to mimic the behavior of the default conventional route as shown in the following example:

[!code-csharp[](routing/samples/6.x/main/Controllers/ProductsController.cs?name=snippet6x)]

Putting multiple route attributes on the controller means that each one combines with each of the route attributes on the action methods:

[!code-csharp[](routing/samples/6.x/main/Controllers/ProductsController.cs?name=snippet6)]

All the [HTTP verb](#verb6) route constraints implement `IActionConstraint`.

When multiple route attributes that implement <xref:Microsoft.AspNetCore.Mvc.ActionConstraints.IActionConstraint> are placed on an action:

* Each action constraint combines with the route template applied to the controller.

[!code-csharp[](routing/samples/6.x/main/Controllers/ProductsController.cs?name=snippet7)]

Using multiple routes on actions might seem useful and powerful, it's better to keep your app's URL space basic and well defined. Use multiple routes on actions **only** where needed, for example, to support existing clients.

<a name="routing-attr-options"></a>

### Specifying attribute route optional parameters, default values, and constraints

Attribute routes support the same inline syntax as conventional routes to specify optional parameters, default values, and constraints.

[!code-csharp[](routing/samples/6.x/main/Controllers/ProductsController.cs?name=snippet8&highlight=3)]

In the preceding code, `[HttpPost("product14/{id:int}")]` applies a route constraint. The `Products14Controller.ShowProduct` action is matched only by URL paths like `/product14/3`. The route template portion `{id:int}` constrains that segment to only integers.

See [Route Template Reference](xref:fundamentals/routing#route-template-reference) for a detailed description of route template syntax.

<a name="routing-cust-rt-attr-irt-ref-label"></a>

### Custom route attributes using IRouteTemplateProvider

All of the [route attributes](#rt6) implement <xref:Microsoft.AspNetCore.Mvc.Routing.IRouteTemplateProvider>. The ASP.NET Core runtime:

* Looks for attributes on controller classes and action methods when the app starts.
* Uses the attributes that implement `IRouteTemplateProvider` to build the initial set of routes.

Implement `IRouteTemplateProvider` to define custom route attributes. Each `IRouteTemplateProvider` allows you to define a single route with a custom route template, order, and name:

[!code-csharp[](routing/samples/6.x/main/Controllers/MyTestApiController.cs?name=snippet&highlight=1-10)]

The preceding `Get` method returns `Order = 2, Template = api/MyTestApi`.

<a name="routing-app-model-ref-label"></a>

### Use application model to customize attribute routes

The application model:

* Is an object model created at startup in `Program.cs`.
* Contains all of the metadata used by ASP.NET Core to route and execute the actions in an app.

The application model includes all of the data gathered from route attributes. The data from route attributes is provided by the `IRouteTemplateProvider` implementation. Conventions:

* Can be written to modify the application model to customize how routing behaves.
* Are read at app startup.

This section shows a basic example of customizing routing using application model. The following code makes routes roughly line up with the folder structure of the project.

[!code-csharp[](routing/samples/6.x/nsrc/NamespaceRoutingConvention.cs?name=snippet)]

The following code prevents the `namespace` convention from being applied to controllers that are attribute routed:

[!code-csharp[](routing/samples/6.x/nsrc/NamespaceRoutingConvention.cs?name=snippet2)]

For example, the following controller doesn't use `NamespaceRoutingConvention`:

[!code-csharp[](routing/samples/6.x/nsrc/Controllers/ManagersController.cs?name=snippet&highlight=1)]

The `NamespaceRoutingConvention.Apply` method:

* Does nothing if the controller is attribute routed.
* Sets the controllers template based on the `namespace`, with the base `namespace` removed.

The `NamespaceRoutingConvention` can be applied in `Program.cs`:

[!code-csharp[](routing/samples/6.x/nsrc/Program.cs?name=snippet_nrc)]

For example, consider the following controller:

[!code-csharp[](routing/samples/6.x/nsrc/Controllers/UsersController.cs)]

In the preceding code:

* The base `namespace` is `My.Application`.
* The full name of the preceding controller is `My.Application.Admin.Controllers.UsersController`.
* The `NamespaceRoutingConvention` sets the controllers template to `Admin/Controllers/Users/[action]/{id?`.

The `NamespaceRoutingConvention` can also be applied as an attribute on a controller:

[!code-csharp[](routing/samples/6.x/nsrc/Controllers/TestController.cs?name=snippet&highlight=1)]

<a name="routing-mixed-ref-label"></a>

## Mixed routing: Attribute routing vs conventional routing

ASP.NET Core apps can mix the use of conventional routing and attribute routing. It's typical to use conventional routes for controllers serving HTML pages for browsers, and attribute routing for controllers serving REST APIs.

Actions are either conventionally routed or attribute routed. Placing a route on the controller or the action makes it attribute routed. Actions that define attribute routes cannot be reached through the conventional routes and vice-versa. ***Any*** route attribute on the controller makes ***all*** actions in the controller attribute routed.

Attribute routing and conventional routing use the same routing engine.

[!INCLUDE[](~/includes/routeSlash.md)]

<a name="routing-url-gen-ref-label"></a>
<a name="ambient"></a>

## URL Generation and ambient values

Apps can use routing URL generation features to generate URL links to actions. Generating URLs eliminates [hard-coding](https://wikipedia.org/wiki/Hard_coding) URLs, making code more robust and maintainable. This section focuses on the URL generation features provided by MVC and only cover basics of how URL generation works. See [Routing](xref:fundamentals/routing) for a detailed description of URL generation.

The <xref:Microsoft.AspNetCore.Mvc.IUrlHelper> interface is the underlying element of infrastructure between MVC and routing for URL generation. An instance of `IUrlHelper` is available through the `Url` property in controllers, views, and view components.

In the following example, the `IUrlHelper` interface is used through the `Controller.Url` property to generate a URL to another action.

[!code-csharp[](routing/samples/6.x/main/Controllers/UrlGenerationController.cs?name=snippet_1)]

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

The preceding example of `Url.Action` assumes [conventional routing](#cr6). URL generation works similarly with [attribute routing](#ar6), though the concepts are different. With conventional routing:

* The route values are used to expand a template.
* The route values for `controller` and `action` usually appear in that template. This works because the URLs matched by routing adhere to a convention.

The following example uses attribute routing:

[!code-csharp[](routing/samples/6.x/main/Controllers/UrlGenerationAttrController.cs?name=snippet_1)]

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

[!code-csharp[](routing/samples/6.x/main/Controllers/TestController.cs?name=snippet)]

The preceding code generates `/Products/Buy/17?color=red`.

The following code generates an absolute URL:

[!code-csharp[](routing/samples/6.x/main/Controllers/TestController.cs?name=snippet2)]

To create an absolute URL, use one of the following:

* An overload that accepts a `protocol`. For example, the preceding code.
* [LinkGenerator.GetUriByAction](xref:Microsoft.AspNetCore.Routing.ControllerLinkGeneratorExtensions.GetUriByAction*), which generates absolute URIs by default.

<a name="routing-gen-urls-route-ref-label"></a>

### Generate URLs by route

The preceding code demonstrated generating a URL by passing in the controller and action name. `IUrlHelper` also provides the [Url.RouteUrl](xref:Microsoft.AspNetCore.Mvc.IUrlHelper.RouteUrl*) family of methods. These methods are similar to [Url.Action](xref:Microsoft.AspNetCore.Mvc.IUrlHelper.Action*), but they don't copy the current values of `action` and `controller` to the route values. The most common usage of `Url.RouteUrl`:

* Specifies a route name to generate the URL.
* Generally doesn't specify a controller or action name.

[!code-csharp[](routing/samples/6.x/main/Controllers/UrlGeneration2Controller.cs?name=snippet_1)]

The following Razor file generates an HTML link to the `Destination_Route`:

[!code-cshtml[](routing/samples/6.x/main/Views/Shared/MyLink.cshtml)]

<a name="routing-gen-urls-html-ref-label"></a>

### Generate URLs in HTML and Razor

<xref:Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper> provides the <xref:Microsoft.AspNetCore.Mvc.ViewFeatures.HtmlHelper> methods [Html.BeginForm](xref:Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper.BeginForm*) and [Html.ActionLink](xref:Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper.ActionLink*) to generate `<form>` and `<a>` elements respectively. These methods use the [Url.Action](xref:Microsoft.AspNetCore.Mvc.IUrlHelper.Action*) method to generate a URL and they accept similar arguments. The `Url.RouteUrl` companions for `HtmlHelper` are `Html.BeginRouteForm` and `Html.RouteLink` which have similar functionality.

TagHelpers generate URLs through the `form` TagHelper and the `<a>` TagHelper. Both of these use `IUrlHelper` for their implementation. See [Tag Helpers in forms](xref:mvc/views/working-with-forms) for more information.

Inside views, the `IUrlHelper` is available through the `Url` property for any ad-hoc URL generation not covered by the above.

<a name="routing-gen-urls-action-ref-label"></a>

### URL generation in Action Results

The preceding examples showed using `IUrlHelper` in a controller. The most common usage in a controller is to generate a URL as part of an action result.

The <xref:Microsoft.AspNetCore.Mvc.ControllerBase> and <xref:Microsoft.AspNetCore.Mvc.Controller> base classes provide convenience methods for action results that reference another action. One typical usage is to redirect after accepting user input:

[!code-csharp[](routing/samples/6.x/main/Controllers/CustomerController.cs?name=snippet)]

The action results factory methods such as <xref:Microsoft.AspNetCore.Mvc.ControllerBase.RedirectToAction%2A> and <xref:Microsoft.AspNetCore.Mvc.ControllerBase.CreatedAtAction%2A> follow a similar pattern to the methods on `IUrlHelper`.

<a name="routing-dedicated-ref-label"></a>

### Special case for dedicated conventional routes

[Conventional routing](#cr6) can use a special kind of route definition called a [dedicated conventional route](#dcr). In the following example, the route named `blog` is a dedicated conventional route:

[!code-csharp[](routing/samples/6.x/main/Program.cs?name=snippet_mcr)]

Using the preceding route definitions, `Url.Action("Index", "Home")` generates the URL path `/` using the `default` route, but why? You might guess the route values `{ controller = Home, action = Index }` would be enough to generate a URL using `blog`, and the result would be `/blog?action=Index&controller=Home`.

[Dedicated conventional routes](#dcr) rely on a special behavior of default values that don't have a corresponding route parameter that prevents the route from being too [greedy](xref:fundamentals/routing#greedy) with URL generation. In this case the default values are `{ controller = Blog, action = Article }`, and neither `controller` nor `action` appears as a route parameter. When routing performs URL generation, the values provided must match the default values. URL generation using `blog` fails because the values `{ controller = Home, action = Index }` don't match `{ controller = Blog, action = Article }`. Routing then falls back to try `default`, which succeeds.

<a name="routing-areas-ref-label"></a>

## Areas

[Areas](xref:mvc/controllers/areas) are an MVC feature used to organize related functionality into a group as a separate:

* Routing namespace for controller actions.
* Folder structure for views.

Using areas allows an app to have multiple controllers with the same name, as long as they have different areas. Using areas creates a hierarchy for the purpose of routing by adding another route parameter, `area` to `controller` and `action`. This section discusses how routing interacts with areas. See [Areas](xref:mvc/controllers/areas) for details about how areas are used with views.

The following example configures MVC to use the default conventional route and an `area` route for an `area` named `Blog`:

[!code-csharp[](routing/samples/6.x/AreasRouting/Program.cs?name=snippet_)]

In the preceding code, <xref:Microsoft.AspNetCore.Builder.ControllerEndpointRouteBuilderExtensions.MapAreaControllerRoute%2A> is called to create the `"blog_route"`. The second parameter, `"Blog"`, is the area name.

When matching a URL path like `/Manage/Users/AddUser`, the `"blog_route"` route generates the route values `{ area = Blog, controller = Users, action = AddUser }`. The `area` route value is produced by a default value for `area`. The route created by `MapAreaControllerRoute` is equivalent to the following:

[!code-csharp[](routing/samples/6.x/AreasRouting/Program.cs?name=snippet_2)]

`MapAreaControllerRoute` creates a route using both a default value and constraint for `area` using the provided area name, in this case `Blog`. The default value ensures that the route always produces `{ area = Blog, ... }`, the constraint requires the value `{ area = Blog, ... }` for URL generation.

Conventional routing is order-dependent. In general, routes with areas should be placed earlier as they're more specific than routes without an area.

Using the preceding example, the route values `{ area = Blog, controller = Users, action = AddUser }` match the following action:

[!code-csharp[](routing/samples/3.x/AreasRouting/Areas/Blog/Controllers/UsersController.cs)]

The [[Area]](xref:Microsoft.AspNetCore.Mvc.AreaAttribute) attribute is what denotes a controller as part of an area. This controller is in the `Blog` area. Controllers without an `[Area]` attribute are not members of any area, and do **not** match when the `area` route value is provided by routing. In the following example, only the first controller listed can match the route values `{ area = Blog, controller = Users, action = AddUser }`.

[!code-csharp[](routing/samples/3.x/AreasRouting/Areas/Blog/Controllers/UsersController.cs)]

[!code-csharp[](routing/samples/3.x/AreasRouting/Areas/Zebra/Controllers/UsersController.cs)]

[!code-csharp[](routing/samples/3.x/AreasRouting/Controllers/UsersController.cs)]

The namespace of each controller is shown here for completeness. If the preceding controllers used the same namespace, a compiler error would be generated. Class namespaces have no effect on MVC's routing.

The first two controllers are members of areas, and only match when their respective area name is provided by the `area` route value. The third controller isn't a member of any area, and can only match when no value for `area` is provided by routing.

<a name="aa"></a>

In terms of matching *no value*, the absence of the `area` value is the same as if the value for `area` were null or the empty string.

When executing an action inside an area, the route value for `area` is available as an [ambient value](#ambient) for routing to use for URL generation. This means that by default areas act *sticky* for URL generation as demonstrated by the following sample.

[!code-csharp[](routing/samples/6.x/AreasRouting/Program.cs?name=snippet_3)]

[!code-csharp[](routing/samples/3.x/AreasRouting/Areas/Duck/Controllers/UsersController.cs)]

The following code generates a URL to `/Zebra/Users/AddUser`:

[!code-csharp[](routing/samples/3.x/AreasRouting/Controllers/HomeController.cs?name=snippet)]

<a name="action"></a>

## Action definition

Public methods on a controller, except those with the [NonAction](xref:Microsoft.AspNetCore.Mvc.NonActionAttribute) attribute, are actions.

## Sample code

* [!INCLUDE[](~/includes/MyDisplayRouteInfo.md)]
* [View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/mvc/controllers/routing/samples/3.x) ([how to download](xref:index#how-to-download-a-sample))

[!INCLUDE[](~/includes/dbg-route.md)]

:::moniker-end

:::moniker range="< aspnetcore-6.0"

ASP.NET Core controllers use the Routing [middleware](xref:fundamentals/middleware/index) to match the URLs of incoming requests and map them to [actions](#action).  Route templates:

* Are defined in startup code or attributes.
* Describe how URL paths are matched to [actions](#action).
* Are used to generate URLs for links. The generated links are typically returned in responses.

Actions are either [conventionally-routed](#cr) or [attribute-routed](#ar). Placing a route on the controller or [action](#action) makes it attribute-routed. See [Mixed routing](#routing-mixed-ref-label) for more information.

This document:

* Explains the interactions between MVC and routing:
  * How typical MVC apps make use of routing features.
  * Covers both:
    * [Conventional routing](#cr) typically used with controllers and views.
    * *Attribute routing* used with REST APIs. If you're primarily interested in routing for REST APIs, jump to the [Attribute routing for REST APIs](#ar) section.
  * See [Routing](xref:fundamentals/routing) for advanced routing details.
* Refers to the default routing system added in ASP.NET Core 3.0, called endpoint routing. It's possible to use controllers with the previous version of routing for compatibility purposes. See the [2.2-3.0 migration guide](xref:migration/22-to-30) for instructions. Refer to the [2.2 version of this document](xref:mvc/controllers/routing?view=aspnetcore-2.2) for reference material on the legacy routing system.

<a name="cr"></a>

## Set up conventional route

`Startup.Configure` typically has code similar to the following when using [conventional routing](#crd):

[!code-csharp[](routing/samples/3.x/main/StartupDefaultMVC.cs?name=snippet)]

Inside the call to <xref:Microsoft.AspNetCore.Builder.EndpointRoutingApplicationBuilderExtensions.UseEndpoints%2A>, <xref:Microsoft.AspNetCore.Builder.ControllerEndpointRouteBuilderExtensions.MapControllerRoute%2A> is used to create a single route. The single route is named `default` route. Most apps with controllers and views use a route template similar to the `default` route. REST APIs should use [attribute routing](#ar).

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

The convenience method <xref:Microsoft.AspNetCore.Builder.ControllerEndpointRouteBuilderExtensions.MapDefaultControllerRoute%2A>:

```csharp
endpoints.MapDefaultControllerRoute();
```

Replaces:

```csharp
endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
```

> [!IMPORTANT]
> Routing is configured using the <xref:Microsoft.AspNetCore.Builder.EndpointRoutingApplicationBuilderExtensions.UseRouting%2A>, `MapControllerRoute`, and `MapAreaControllerRoute` middleware . To use controllers:
>
> * Call <xref:Microsoft.AspNetCore.Builder.ControllerEndpointRouteBuilderExtensions.MapControllers%2A> inside `UseEndpoints` to map [attribute routed](#ar) controllers.
> * Call <xref:Microsoft.AspNetCore.Builder.ControllerEndpointRouteBuilderExtensions.MapControllerRoute%2A> or <xref:Microsoft.AspNetCore.Builder.ControllerEndpointRouteBuilderExtensions.MapAreaControllerRoute%2A>, to map both [conventionally routed](#cr) controllers and [attribute routed](#ar) controllers.

<a name="routing-conventional-ref-label"></a>
<a name="crd"></a>

## Conventional routing

Conventional routing is used with controllers and views. The `default` route:

[!code-csharp[](routing/samples/3.x/main/StartupDefaultMVC.cs?name=snippet2)]

The preceding is an example of a *conventional route*. It's called *conventional routing* because it establishes a *convention* for URL paths:

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
> The `id` in the preceding code is defined as optional by the route template. Actions can execute without the optional ID provided as part of the URL. Generally, when `id` is omitted from the URL:
>
> * `id` is set to `0` by model binding.
> * No entity is found in the database matching `id == 0`.
>
> [Attribute routing](#ar) provides fine-grained control to make the ID required for some actions and not for others. By convention, the documentation includes optional parameters like `id` when they're likely to appear in correct usage.

Most apps should choose a basic and descriptive routing scheme so that URLs are readable and meaningful. The default conventional route `{controller=Home}/{action=Index}/{id?}`:

* Supports a basic and descriptive routing scheme.
* Is a useful starting point for UI-based apps.
* Is the only route template needed for many web UI apps. For larger web UI apps, another route using [Areas](#areas) is frequently all that's needed.

<xref:Microsoft.AspNetCore.Builder.ControllerEndpointRouteBuilderExtensions.MapControllerRoute%2A> and <xref:Microsoft.AspNetCore.Builder.MvcAreaRouteBuilderExtensions.MapAreaRoute%2A> :

* Automatically assign an **order** value to their endpoints based on the order they are invoked.

Endpoint routing in ASP.NET Core 3.0 and later:

* Doesn't have a concept of routes.
* Doesn't provide ordering guarantees for the execution of extensibility,  all endpoints are processed at once.

Enable [Logging](xref:fundamentals/logging/index) to see how the built-in routing implementations, such as <xref:Microsoft.AspNetCore.Routing.Route>, match requests.

[Attribute routing](#ar) is explained later in this document.

<a name="mr"></a>

### Multiple conventional routes

Multiple [conventional routes](#cr) can be added inside `UseEndpoints` by adding more calls to <xref:Microsoft.AspNetCore.Builder.ControllerEndpointRouteBuilderExtensions.MapControllerRoute%2A> and <xref:Microsoft.AspNetCore.Builder.ControllerEndpointRouteBuilderExtensions.MapAreaControllerRoute%2A>. Doing so allows defining multiple conventions, or to adding conventional routes that are dedicated to a specific [action](#action), such as:

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
* Is an example of [Slug](https://developer.mozilla.org/docs/Glossary/Slug) style routing where it's typical to have an article name as part of the URL.

> [!WARNING]
> In ASP.NET Core 3.0 and later, routing doesn't:
> * Define a concept called a *route*. `UseRouting` adds route matching to the middleware pipeline. The `UseRouting` middleware looks at the set of endpoints defined in the app, and selects the best endpoint match based on the request.
> * Provide guarantees about the execution order of extensibility like <xref:Microsoft.AspNetCore.Routing.IRouteConstraint> or <xref:Microsoft.AspNetCore.Mvc.ActionConstraints.IActionConstraint>.
>
>See [Routing](xref:fundamentals/routing) for reference material on routing.

<a name="cro"></a>

### Conventional routing order

Conventional routing only matches a combination of action and controller that are defined by the app. This is intended to simplify cases where conventional routes overlap.
Adding routes using <xref:Microsoft.AspNetCore.Builder.ControllerEndpointRouteBuilderExtensions.MapControllerRoute%2A>, <xref:Microsoft.AspNetCore.Builder.ControllerEndpointRouteBuilderExtensions.MapDefaultControllerRoute%2A>, and <xref:Microsoft.AspNetCore.Builder.ControllerEndpointRouteBuilderExtensions.MapAreaControllerRoute%2A> automatically assign an order value to their endpoints based on the order they are invoked. Matches from a route that appears earlier have a higher priority. Conventional routing is order-dependent. In general, routes with areas should be placed earlier as they're more specific than routes without an area. [Dedicated conventional routes](#dcr) with catch-all route parameters like `{*article}` can make a route too [greedy](xref:fundamentals/routing#greedy), meaning that it matches URLs that you intended to be matched by other routes. Put the greedy routes later in the route table to prevent greedy matches.

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

In the preceding code, <xref:Microsoft.AspNetCore.Builder.ControllerEndpointRouteBuilderExtensions.MapControllers%2A> is called inside `UseEndpoints` to map attribute routed controllers.

In the following example:

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

The following keywords are reserved in the context of a Razor view or a Razor Page:

* `page`
* `using`
* `namespace`
* `inject`
* `section`
* `inherits`
* `model`
* `addTagHelper`
* `removeTagHelper`

These keywords shouldn't be used for link generations, model bound parameters, or top level properties.

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
* The `GetProduct` action includes the `"{id}"` template, therefore `id` is appended to the `"api/[controller]"` template on the controller. The methods template is `"api/[controller]/{id}"`. Therefore this action only matches GET requests for the form `/api/test2/xyz`,`/api/test2/123`,`/api/test2/{any string}`, etc.
  [!code-csharp[](routing/samples/3.x/main/Controllers/Test2Controller.cs?name=snippet2)]
* The `GetIntProduct` action contains the `"int/{id:int}"` template. The `:int` portion of the template constrains the `id` route values to strings that can be converted to an integer. A GET request to `/api/test2/int/abc`:
  * Doesn't match this action.
  * Returns a [404 Not Found](https://developer.mozilla.org/docs/Web/HTTP/Status/404) error.
    [!code-csharp[](routing/samples/3.x/main/Controllers/Test2Controller.cs?name=snippet3)]
* The `GetInt2Product` action contains `{id}` in the template, but doesn't constrain `id` to values that can be converted to an integer. A GET request to `/api/test2/int2/abc`:
  * Matches this route.
  * Model binding fails to convert `abc` to an integer. The `id` parameter of the method is integer.
  * Returns a [400 Bad Request](https://developer.mozilla.org/docs/Web/HTTP/Status/400) because model binding failed to convert `abc` to an integer.
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

The [[Consumes]](xref:Microsoft.AspNetCore.Mvc.ConsumesAttribute) attribute allows an action to limit the supported request content types. For more information, see [Define supported request content types with the Consumes attribute](xref:web-api/index#consumes).

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

For convenience, attribute routes support *token replacement* by enclosing a token in square-brackets (`[`, `]`). The tokens `[action]`, `[area]`, and `[controller]` are replaced with the values of the action name, area name, and controller name from the action where the route is defined:

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

In the preceding code, `[HttpPost("product14/{id:int}")]` applies a route constraint. The `Products14Controller.ShowProduct` action is matched only by URL paths like `/product14/3`. The route template portion `{id:int}` constrains that segment to only integers.

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

The action results factory methods such as <xref:Microsoft.AspNetCore.Mvc.ControllerBase.RedirectToAction%2A> and <xref:Microsoft.AspNetCore.Mvc.ControllerBase.CreatedAtAction%2A> follow a similar pattern to the methods on `IUrlHelper`.

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

In the preceding code, <xref:Microsoft.AspNetCore.Builder.ControllerEndpointRouteBuilderExtensions.MapAreaControllerRoute%2A> is called to create the `"blog_route"`. The second parameter, `"Blog"`, is the area name.

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

The namespace of each controller is shown here for completeness. If the preceding controllers used the same namespace, a compiler error would be generated. Class namespaces have no effect on MVC's routing.

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

* [!INCLUDE[](~/includes/MyDisplayRouteInfo.md)]
* [View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/mvc/controllers/routing/samples/3.x) ([how to download](xref:index#how-to-download-a-sample))

[!INCLUDE[](~/includes/dbg-route.md)]

:::moniker-end
