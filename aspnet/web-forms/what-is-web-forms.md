---
uid: web-forms/what-is-web-forms
title: "What is Web Forms | Microsoft Docs"
author: rick-anderson
description: ""
ms.author: aspnetcontent
manager: wpickett
ms.date: 02/21/2014
ms.topic: article
ms.assetid: 5fa1daf9-1161-4cfa-bd4c-658f48b2c229
ms.technology: dotnet-webforms
ms.prod: .net-framework
msc.legacyurl: /web-forms/what-is-web-forms
msc.type: content
---
What is Web Forms
====================
ASP.NET Web Forms is a part of the ASP.NET web application framework and is included with [Visual Studio](https://www.asp.net/downloads). It is one of the four programming models you can use to create ASP.NET web applications, the others are ASP.NET MVC, ASP.NET Web Pages, and ASP.NET Single Page Applications.

Web Forms are pages that your users request using their browser. These pages can be written using a combination of HTML, client-script, server controls, and server code. When users request a page, it is compiled and executed on the server by the framework, and then the framework generates the HTML markup that the browser can render. An ASP.NET Web Forms page presents information to the user in any browser or client device.

Using Visual Studio, you can create ASP.NET Web Forms. The Visual Studio Integrated Development Environment (IDE) lets you drag and drop server controls to lay out your Web Forms page. You can then easily set properties, methods, and events for controls on the page or for the page iteself. These properties, methods, and events are used to define the web page's behavior, look and feel, and so on. To write server code to handle the logic for the page, you can use a .NET language like Visual Basic or C#.

> [!NOTE] 
> 
> ASP.NET and Visual Studio documentation spans several versions. Topics that highlight features from previous versions may be useful for your current tasks and scenarios using the latest versions.


**ASP.NET Web Forms are:** 

- Based on Microsoft ASP.NET technology, in which code that runs on the server dynamically generates Web page output to the browser or client device.
- Compatible with any browser or mobile device. An ASP.NET Web page automatically renders the correct browser-compliant HTML for features such as styles, layout, and so on.
- Compatible with any language supported by the .NET common language runtime, such as Microsoft Visual Basic and Microsoft Visual C#.
- Built on the Microsoft .NET Framework. This provides all the benefits of the framework, including a managed environment, type safety, and inheritance.
- Flexible because you can add user-created and third party controls to them.

**ASP.NET Web Forms offer:** 

- Separation of HTML and other UI code from application logic.
- A rich suite of server controls for common tasks, including data access.
- Powerful data binding, with great tool support.
- Support for client-side scripting that executes in the browser.
- Support for a variety of other capabilities, including routing, security, performance, internationalization, testing, debugging, error handling and state management.

## ASP.NET Web Forms Helps You Overcome Challenges

Web application programming presents challenges that do not typically arise when programming traditional client-based applications. Among the challenges are:

- **Implementing a rich Web user interface** - It can be difficult and tedious to design and implement a user interface using basic HTML facilities, especially if the page has a complex layout, a large amount of dynamic content, and full-featured user-interactive objects.
- **Separation of client and server** - In a Web application, the client (browser) and server are different programs often running on different computers (and even on different operating systems). Consequently, the two halves of the application share very little information; they can communicate, but typically exchange only small chunks of simple information.
- **Stateless execution** - When a Web server receives a request for a page, it finds the page, processes it, sends it to the browser, and then discards all page information. If the user requests the same page again, the server repeats the entire sequence, reprocessing the page from scratch. Put another way, a server has no memory of pages that it has processed—page are stateless. Therefore, if an application needs to maintain information about a page, its stateless nature can become a problem.
- **Unknown client capabilities** - In many cases, Web applications are accessible to many users using different browsers. Browsers have different capabilities, making it difficult to create an application that will run equally well on all of them.
- **Complications with data access** - Reading from and writing to a data source in traditional Web applications can be complicated and resource-intensive.
- **Complications with scalability** - In many cases Web applications designed with existing methods fail to meet scalability goals due to the lack of compatibility between the various components of the application. This is often a common failure point for applications under a heavy growth cycle.

Meeting these challenges for Web applications can require substantial time and effort. ASP.NET Web Forms and the ASP.NET framework address these challenges in the following ways:

- **Intuitive, consistent object model** - The ASP.NET page framework presents an object model that enables you to think of your forms as a unit, not as separate client and server pieces. In this model, you can program the page in a more intuitive way than in traditional Web applications, including the ability to set properties for page elements and respond to events. In addition, ASP.NET server controls are an abstraction from the physical contents of an HTML page and from the direct interaction between browser and server. In general, you can use server controls the way you might work with controls in a client application and not have to think about how to create the HTML to present and process the controls and their contents.
- **Event-driven programming model** - ASP.NET Web Forms bring to Web applications the familiar model of writing event handlers for events that occur on either the client or server. The ASP.NET page framework abstracts this model in such a way that the underlying mechanism of capturing an event on the client, transmitting it to the server, and calling the appropriate method is all automatic and invisible to you. The result is a clear, easily written code structure that supports event-driven development.
- **Intuitive state management** - The ASP.NET page framework automatically handles the task of maintaining the state of your page and its controls, and it provides you with explicit ways to maintain the state of application-specific information. This is accomplished without heavy use of server resources and can be implemented with or without sending cookies to the browser.
- **Browser-independent applications** - The ASP.NET page framework enables you to create all application logic on the server, eliminating the need to explicitly code for differences in browsers. However, it still enables you to take advantage of browser-specific features by writing client-side code to provide improved performance and a richer client experience.
- **.NET Framework common language runtime support** - The ASP.NET page framework is built on the .NET Framework, so the entire framework is available to any ASP.NET application. Your applications can be written in any language that is compatible that is with the runtime. In addition, data access is simplified using the data access infrastructure provided by the .NET Framework, including ADO.NET.
- **.NET Framework scalable server performance** - The ASP.NET page framework enables you to scale your Web application from one computer with a single processor to a multi-computer Web farm cleanly and without complicated changes to the application's logic.

## Features of ASP.NET Web Forms

- **Server Controls**- ASP.NET Web server controls are objects on ASP.NET Web pages that run when the page is requested and that render markup to the browser. Many Web server controls are similar to familiar HTML elements, such as buttons and text boxes. Other controls encompass complex behavior, such as a calendar controls, and controls that you can use to connect to data sources and display data.
- **Master Pages**- ASP.NET master pages allow you to create a consistent layout for the pages in your application. A single master page defines the look and feel and standard behavior that you want for all of the pages (or a group of pages) in your application. You can then create individual content pages that contain the content you want to display. When users request the content pages, they merge with the master page to produce output that combines the layout of the master page with the content from the content page.
- **Working with Data**- ASP.NET provides many options for storing, retrieving, and displaying data. In an ASP.NET Web Forms application, you use  data-bound controls to automate the presentation or input of data in web page UI elements such as tables and text boxes and drop-down lists.
- **Membership**- ASP.NET Identity stores your users' credentials in a database created by the application. When your users log in, the application validates their credentials by reading the database. Your project's *Account* folder contains the files that implement the various parts of membership: registering, logging in, changing a password, and authorizing access. Additionally, ASP.NET Web Forms supports OAuth and OpenID. These authentication enhancements allow users to log into your site using existing credentials, from such accounts as Facebook, Twitter, Windows Live, and Google. By default, the template creates a membership database using a default database name on an instance of SQL Server Express LocalDB, the development database server that comes with Visual Studio Express 2013 for Web.
- **Client Script and Client Frameworks**- You can enhance the server-based features of ASP.NET by including client-script functionality in ASP.NET Web Form pages. You can use client script to provide a richer, more responsive user interface to users. You can also use client script to make asynchronous calls to the Web server while a page is running in the browser.
- **Routing**- URL routing allows you to configure an application to accept request URLs that do not map to physical files. A request URL is simply the URL a user enters into their browser to find a page on your web site. You use routing to define URLs that are semantically meaningful to users and that can help with search-engine optimization (SEO).
- **State Management**- ASP.NET Web Forms includes several options that help you preserve data on both a per-page basis and an application-wide basis.
- **Security**- An important part of developing a more secure application is to understand the threats to it. Microsoft has developed a way to categorize threats: Spoofing, Tampering, Repudiation, Information disclosure, Denial of service, Elevation of privilege (STRIDE). In ASP.NET Web Forms, you can add extensibility points and configuration options that enable you to customize various security behaviors in ASP.NET Web Forms.
- **Performance**- Performance can be a key factor in a successful Web site or project. ASP.NET Web Forms allows you to modify performance related to page and server control processing, state management, data access, application configuration and loading, and efficient coding practices.
- **Internationalization**- ASP.NET Web Forms enables you to create web pages that can obtain content and other data based on the preferred language setting for the browser or based on the user's explicit choice of language. Content and other data is referred to as resources and such data can be stored in resource files or other sources. In an ASP.NET Web Forms page, you configure controls to get their property values from resources. At run time, the resource expressions are replaced by resources from the appropriate localized resource file.
- **Debugging and Error Handling**- ASP.NET includes features to help you diagnose problems that might arise in your Web Forms application. Debugging and error handling are well supported within ASP.NET Web Forms so that your applications compile and run effectively.
- **Deployment and Hosting**- Visual Studio, ASP.NET, Azure, and IIS provide tools that help you with the process of deploying and hosting your Web Forms application.

## Deciding When to Create a Web Forms Application

You must consider carefully whether to implement a Web application by using either the ASP.NET Web Forms model or another model, such as the ASP.NET MVC framework. The MVC framework does not replace the Web Forms model; you can use either framework for Web applications. Before you decide to use the Web Forms model or the MVC framework for a specific Web site, weigh the advantages of each approach.

### Advantages of a Web Forms-Based Web Application

The Web Forms-based framework offers the following advantages:

- It supports an event model that preserves state over HTTP, which benefits line-of-business Web application development. The Web Forms-based application provides dozens of events that are supported in hundreds of server controls.
- It uses a Page Controller pattern that adds functionality to individual pages. For more information, see [Page Controller](https://go.microsoft.com/fwlink/?LinkId=106359 "Page Controller") on the MSDN Web site.
- It uses view state or server-based forms, which can make managing state information easier.
- It works well for small teams of Web developers and designers who want to take advantage of the large number of components available for rapid application development.
- In general, it is less complex for application development, because the components (the **Page** class, controls, and so on) are tightly integrated and usually require less code than the MVC model.

### Advantages of an MVC-Based Web Application

The ASP.NET MVC framework offers the following advantages:

- It makes it easier to manage complexity by dividing an application into the model, the view, and the controller.
- It does not use view state or server-based forms. This makes the MVC framework ideal for developers who want full control over the behavior of an application.
- It uses a Front Controller pattern that processes Web application requests through a single controller. This enables you to design an application that supports a rich routing infrastructure. For more information, see [Front Controller](https://go.microsoft.com/fwlink/?LinkId=106357 "Front Controller") on the MSDN Web site.
- It provides better support for test-driven development (TDD).
- It works well for Web applications that are supported by large teams of developers and Web designers who need a high degree of control over the application behavior.