---
title: Choose an ASP.NET Core UI
author: wadepickett
description: Learn when to use which ASP.NET Core web UI technologies. Understand the server, client and hybrid options.
ms.author: wpickett
ms.date: 10/04/2023
uid: tutorials/choose-web-ui
---
# Choose an ASP.NET Core web UI

ASP.NET Core is a complete UI framework. Choose which functionalities to combine that fit the app's web UI needs.

## ASP.NET Core Blazor

Blazor is a full-stack web UI framework and is recommended for most web UI scenarios.

Benefits of using Blazor:

* Reusable component model.
* Efficient diff-based component rendering.
* Flexibly render components from the server or client via WebAssembly.
* Build rich interactive web UI components in C#.
* Render components statically from the server.
* Progressively enhance server rendered components for smoother navigation and form handling and to enable streaming rendering.
* Share code for common logic on the client and server.
* Interop with JavaScript.
* Integrate components with existing MVC, Razor Pages, or JavaScript based apps.

For a complete overview of Blazor, its architecture and benefits, see <xref:blazor/index> and <xref:blazor/hosting-models>. To get started with your first Blazor app, see [Build your first Blazor app](https://dotnet.microsoft.com/learn/aspnet/blazor-tutorial/intro).

## ASP.NET Core Razor Pages

Razor Pages is a page-based model for building server rendered web UI. Razor pages UI are dynamically rendered on the server to generate the page's HTML and CSS in response to a browser request. The page arrives at the client ready to display. Support for Razor Pages is built on ASP.NET Core MVC.

Razor Pages benefits:

* Quickly build and update UI. Code for the page is kept with the page, while keeping UI and business logic concerns separate.
* Testable and scales to large apps.
* Keep your ASP.NET Core pages organized in a simpler way than ASP.NET MVC:
  * View specific logic and view models can be kept together in their own namespace and directory.
  * Groups of related pages can be kept in their own namespace and directory.

To get started with your first ASP.NET Core Razor Pages app, see <xref:tutorials/razor-pages/razor-pages-start>. For a complete overview of ASP.NET Core Razor Pages, its architecture and benefits, see: <xref:razor-pages/index>.

## ASP.NET Core MVC

ASP.NET Core MVC renders UI on the server and uses a Model-View-Controller (MVC) architectural pattern. The MVC pattern separates an app into three main groups of components: models, views, and controllers. User requests are routed to a controller. The controller is responsible for working with the model to perform user actions or retrieve results of queries. The controller chooses the view to display to the user and provides it with any model data it requires.

ASP.NET Core MVC benefits:

* Based on a scalable and mature model for building large web apps.
* Clear [separation of concerns](/dotnet/standard/modern-web-apps-azure-architecture/architectural-principles#separation-of-concerns) for maximum flexibility.
* The Model-View-Controller separation of responsibilities ensures that the business model can evolve without being tightly coupled to low-level implementation details.

To get started with  ASP.NET Core MVC, see <xref:tutorials/first-mvc-app/start-mvc>. For an overview of ASP.NET Core MVC's architecture and benefits, see <xref:mvc/overview>.

## ASP.NET Core Single Page Applications (SPA) with frontend JavaScript frameworks

Build client-side logic for ASP.NET Core apps using popular JavaScript frameworks, like [Angular](https://angular.io/), [React](https://facebook.github.io/react/), and [Vue](https://vuejs.org/). ASP.NET Core provides project templates for Angular, React, and Vue, and it can be used with other JavaScript frameworks as well.

Benefits of ASP.NET Core SPA with JavaScript Frameworks, in addition to the client rendering benefits previously listed:

* The JavaScript runtime environment is already provided with the browser.
* Large community and mature ecosystem.
* Build client-side logic for ASP.NET Core apps using popular JS frameworks, like Angular, React, and Vue.

Downsides:

* More coding languages, frameworks, and tools required.
* Difficult to share code so some logic may be duplicated.

To get started, see:

* [Create an ASP.NET Core app with Angular](/visualstudio/javascript/tutorial-asp-net-core-with-angular)
* [Create an ASP.NET Core app with React](/visualstudio/javascript/tutorial-asp-net-core-with-react)
* [Create an ASP.NET Core app with Vue](/visualstudio/javascript/tutorial-asp-net-core-with-vue)
* [JavaScript and TypeScript in Visual Studio](/visualstudio/javascript/javascript-in-visual-studio)

## Choose a hybrid solution: ASP.NET Core MVC or Razor Pages plus Blazor

MVC, Razor Pages, and Blazor are part of the ASP.NET Core framework and are designed to be used together. Razor components can be integrated into Razor Pages and MVC apps. When a view or page is rendered, components can be prerendered at the same time.

Benefits for MVC or Razor Pages plus Blazor, in addition to MVC or Razor Pages benefits:

* Prerendering executes Razor components on the server and renders them into a view or page, which improves the perceived load time of the app.
* Add interactivity to existing views or pages with the [Component Tag Helper](xref:mvc/views/tag-helpers/builtin-th/component-tag-helper).

:::moniker range=">= aspnetcore-8.0"

To get started with ASP.NET Core MVC or Razor Pages plus Blazor, see <xref:blazor/components/integration>.

:::moniker-end

:::moniker range="< aspnetcore-8.0"

To get started with ASP.NET Core MVC or Razor Pages plus Blazor, see <xref:blazor/components/prerendering-and-integration>.

:::moniker-end

## Next steps

For more information, see:

:::moniker range=">= aspnetcore-8.0"

* <xref:blazor/index>
* <xref:blazor/hosting-models>
* <xref:blazor/components/integration>
* <xref:grpc/comparison>

:::moniker-end

:::moniker range="< aspnetcore-8.0"

* <xref:blazor/index>
* <xref:blazor/hosting-models>
* <xref:blazor/components/prerendering-and-integration>
* <xref:grpc/comparison>

:::moniker-end
