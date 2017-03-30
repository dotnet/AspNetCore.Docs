---
uid: overview
title: "ASP.NET overview | Microsoft Docs"
author: rick-anderson
description: "Introduction to ASP.NET, a free framework for creating websites, web applications, and web APIs."
ms.author: aspnetcontent
manager: wpickett
ms.date: 03/12/2010
ms.topic: article
ms.assetid: 3a309468-f1ca-4e51-b9c3-536af79d7a8b
ms.technology: 
ms.prod: .net-framework
msc.legacyurl: 
msc.type: content
---

# ASP.NET overview

ASP.NET is a free web framework for building great websites and web applications using HTML, CSS, and JavaScript. You can also create Web APIs and use real-time technologies like Web Sockets.

[ASP.NET Core](https://docs.microsoft.com/aspnet/core/) is an alternative to ASP.NET.  See the [guidance on how to choose between ASP.NET and ASP.NET Core](https://docs.microsoft.com/aspnet/core/choose-aspnet-framework).

## Get started

[Download Visual Studio 2015](https://go.microsoft.com/fwlink/?LinkId=826064), a free IDE for ASP.NET on Windows.

## Websites and web applications

 ASP.NET offers three frameworks for creating web applications: Web Forms, ASP.NET MVC, and ASP.NET Web Pages. All three frameworks are stable and mature, and you can create great web applications with any of them. No matter what framework you choose, you will get all the benefits and features of ASP.NET everywhere.

Each framework targets a different development style. The one you choose depends on a combination of your programming assets (knowledge, skills, and development experience), the type of application you’re creating, and the development approach you’re comfortable with.

Below is an overview of each of the frameworks and some ideas for how to choose between them. If you prefer a video introduction, see [Making Websites with ASP.NET](https://channel9.msdn.com/Blogs/ASP-NET-Site-Videos/Making-Websites-with-ASPNET) and [What is Web Tools?](https://channel9.msdn.com/Blogs/ASP-NET-Site-Videos/what-is-web-tools)

|   | If you have experience in | Development style | Expertise | 
|-----------|----------------------|-----------------------------------------------------|----------------|
| Web Forms | Win Forms, WPF, .NET | Rapid development using a rich library of controls that encapsulate HTML markup | Mid-Level, Advanced RAD |
| MVC       | Ruby on Rails, .NET  | Full control over HTML markup, code and markup separated, and easy to write tests. The best choice for mobile and single-page applications (SPA). | Mid-Level, Advanced |
| Web Pages  | Classic ASP, PHP     | HTML markup and your code together in the same file | New, Mid-Level |

### Web Forms

With ASP.NET Web Forms, you can build dynamic websites using a familiar drag-and-drop, event-driven model. A design surface and hundreds of controls and components let you rapidly build sophisticated, powerful UI-driven sites with data access. 

[Learn more about Web Forms](web-forms/index.md)

### MVC

ASP.NET MVC gives you a powerful, patterns-based way to build dynamic websites that enables a clean separation of concerns and that gives you full control over markup for enjoyable, agile development. ASP.NET MVC includes many features that enable fast, TDD-friendly development for creating sophisticated applications that use the latest web standards. 

[Learn more about MVC](mvc/index.md)

### ASP.NET Web Pages

ASP.NET Web Pages and the Razor syntax provide a fast, approachable, and lightweight way to combine server code with HTML to create dynamic web content. Connect to databases, add video, link to social networking sites, and include many more features that help you create beautiful sites that conform to the latest web standards.

[Learn more about Web Pages](web-pages/index.md)

### Notes about Web Forms, MVC, and Web Pages

All three ASP.NET frameworks are based on the .NET Framework and share core functionality of .NET and of ASP.NET. For example, all three frameworks offer a login security model based around membership, and all three share the same facilities for managing requests, handling sessions, and so on that are part of the core ASP.NET functionality.

In addition, the three frameworks are not entirely independent, and choosing one does not preclude using another. Since the frameworks can coexist in the same web application, it's not uncommon to see individual components of applications written using different frameworks. For example, customer-facing portions of an app might be developed in MVC to optimize the markup, while the data access and administrative portions are developed in Web Forms to take advantage of data controls and simple data access.

## Web APIs

ASP.NET Web API is a framework that makes it easy to build HTTP services that reach a broad range of clients, including browsers and mobile devices. ASP.NET Web API is an ideal platform for building RESTful applications on the .NET Framework.

[Learn more about Web API](web-api/index.md)

<!-- Put first under Web API TOC:  Watch video (9 minutes) https://channel9.msdn.com/Blogs/ASP-NET-Site-Videos/services-and-aspnet -->

## Real-time technologies

ASP.NET SignalR is a new library for ASP.NET developers that makes developing real-time web functionality easier. SignalR allows bi-directional communication between server and client. Servers can push content to connected clients instantly as it becomes available. SignalR supports Web Sockets, and falls back to other compatible techniques for older browsers. SignalR includes APIs for connection management (for instance, connect and disconnect events), grouping connections, and authorization.

[Learn more about SignalR](signalr/index.md)

<!-- Put first under SignalR TOC:  Watch video (6 minutes) https://channel9.msdn.com/Blogs/ASP-NET-Site-Videos/signalr-and-the-real-time-web -->

## Mobile apps and sites 

ASP.NET can power native mobile apps with a Web API back end, as well as mobile web sites using responsive design frameworks like Twitter Bootstrap. If you are building a native mobile app, it's easy to create a JSON-based Web API to handle data access, authentication, and push notifications for your app. If you are building a responsive mobile site, you can use any CSS framework or open grid system you prefer, or select a powerful mobile system like jQuery Mobile or Sencha and great mobile applications with PhoneGap.

[Learn more about mobile app and site development](mobile/index.md)

<!-- Put first under mobile TOC:  Watch video (11 minutes) https://channel9.msdn.com/Blogs/ASP-NET-Site-Videos/aspnet-and-mobile -->

## Single-page applications 

ASP.NET Single Page Application (SPA) helps you build applications that include significant client-side interactions using HTML 5, CSS 3 and JavaScript. Visual Studio includes a template for building single page applications using knockout.js and ASP.NET Web API. In addition to the built-in SPA template, community-created SPA templates are also available for download.

[Learn more about single-page app development](single-page-application/index.md)

## WebHooks

WebHooks is a lightweight HTTP pattern providing a simple pub/sub model for wiring together Web APIs and SaaS services. When an event happens in a service, a notification is sent in the form of an HTTP POST request to registered subscribers. The POST request contains information about the event which makes it possible for the receiver to act accordingly.

WebHooks are exposed by a large number of services including Dropbox, GitHub, Instagram, MailChimp, PayPal, Slack, Trello, and many more. For example, a WebHook can indicate that a file has changed in Dropbox, or a code change has been committed in GitHub, or a payment has been initiated in PayPal, or a card has been created in Trello.

[Learn more about WebHooks](webhooks/index.md)





<!--
Create Deployment TOC based on https://www.asp.net/aspnet/overview/deployment
Copy deployment content map to MVC, WebForms, Web Pages, Web API sections.
Copy Web Deployment in Enterprise from WebForms to MVC
Move under ASP.NET Best practices
	What not to do in ASP​.NET, and what to do instead https://review.docs.microsoft.com/en-us/aspnet/aspnet/overview/web-development-best-practices/what-not-to-do-in-aspnet-and-what-to-do-instead
	Async and await https://channel9.msdn.com/Blogs/ASP-NET-Site-Videos/async-and-await
	Building Real World Cloud Apps with Azure https://review.docs.microsoft.com/en-us/aspnet/aspnet/overview/developing-apps-with-windows-azure/building-real-world-cloud-apps-with-windows-azure/introduction
	Hands on Lab: Maintainable Azure Websites: Managing Change and Scale https://review.docs.microsoft.com/en-us/aspnet/aspnet/overview/developing-apps-with-windows-azure/maintainable-azure-websites-managing-change-and-scale

-->
