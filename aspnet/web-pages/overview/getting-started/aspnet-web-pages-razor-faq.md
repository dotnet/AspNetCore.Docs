---
uid: web-pages/overview/getting-started/aspnet-web-pages-razor-faq
title: "ASP.NET Web Pages (Razor) FAQ | Microsoft Docs"
author: tfitzmac
description: "This article lists some frequently asked questions about ASP.NET Web Pages (Razor) and WebMatrix. Software versions used in the tutorial ASP.NET Web Pages (R..."
ms.author: aspnetcontent
manager: wpickett
ms.date: 02/07/2014
ms.topic: article
ms.assetid: b137bd04-25e1-47cb-9d96-ef2e179ecf1f
ms.technology: dotnet-webpages
ms.prod: .net-framework
msc.legacyurl: /web-pages/overview/getting-started/aspnet-web-pages-razor-faq
msc.type: authoredcontent
---
ASP.NET Web Pages (Razor) FAQ
====================
by [Tom FitzMacken](https://github.com/tfitzmac)

> > [!NOTE] 
> > WebMatrix is no longer recommended as an integrated development environment for ASP.NET Web Pages. Use [Visual Studio](xref:aspnet/web-pages/overview/getting-started/program-asp-net-web-pages-in-visual-studio) or [Visual Studio Code](https://code.visualstudio.com/).
>
> This article lists some frequently asked questions about ASP.NET Web Pages (Razor) and WebMatrix.
> 
> ## Software versions used in the tutorial
> 
> 
> - ASP.NET Web Pages (Razor) 3
> - Visual Studio 2013
> - WebMatrix 3
>   
> 
> This tutorial also works with ASP.NET Web Pages 2, WebMatrix 2, and Visual Studio 2012.


- [What's the difference between ASP.NET Web Pages, ASP.NET Web Forms, and ASP.NET MVC?](#Whats_the_difference_between_ASP.NET_Web_Pages,_ASP.NET_Web_Forms,_and_ASP.NET_MVC)
- [Do I need WebMatrix in order to work with Web Pages?](#Do_I_need_WebMatrix_in_order_to_work_with_Web_Pages)
- [Can I use ASP.NET Web Forms controls on a Web Pages page?](#Can_I_use_ASP.NET_Web_Forms_controls_on_a_Web_Pages_page)
- [Can I deploy an ASP.NET Web Pages site without using WebMatrix?](#Can_I_deploy_an_ASP.NET_Web_Pages_site_without_using_WebMatrix)
- [Do I have to use the WebSecurity helper to support logins?](#Do_I_have_to_use_the_WebSecurity_helper_to_support_logins)
- [Does ASP.NET Web Pages support HTML5?](#Does_ASP.NET_Web_Pages_support_HTML5)
- [Can I use JavaScript and jQuery with Web Pages?](#Can_I_use_JavaScript_and_jQuery_with_Web_Pages)
- [Additional Resources](#AdditionalResources)

For questions about errors and other issues, see the [ASP.NET Web Pages (Razor) Troubleshooting Guide](https://go.microsoft.com/fwlink/?LinkId=253001).

<a id="Whats_the_difference_between_ASP.NET_Web_Pages,_ASP.NET_Web_Forms,_and_ASP.NET_MVC"></a>
## What's the difference between ASP.NET Web Pages, ASP.NET Web Forms, and ASP.NET MVC?

All three are ASP.NET technologies for creating dynamic web applications:

- ASP.NET Web Pages focuses on adding dynamic (server-side) code and database access to HTML pages, and features simple and lightweight syntax.
- ASP.NET Web Forms is based on a page object model and traditional window-type controls (buttons, lists, etc.). Web Forms uses an event-based model that's familiar to those who've worked with client-based (Windows forms) development.
- ASP.NET MVC implements the model-view-controller pattern for ASP.NET. The emphasis is on "separation of concerns" (processing, data, and UI layers).

All three frameworks are fully supported and continue to be developed by the ASP.NET team. In general, the choice of which framework to use depends on your background and experience with ASP.NET.

ASP.NET Web Pages in particular was designed to make it easy for people who already know HTML to add server processing to their pages. It's a good choice for students, hobbyists, people in general who are new to programming. It can also be a good choice for developers who have experience with non-ASP.NET web technologies.

<a id="Do_I_need_WebMatrix_in_order_to_work_with_Web_Pages"></a>
## Do I need WebMatrix in order to work with Web Pages?

No. WebMatrix is no longer recommended as an integrated development environment for ASP.NET Web Pages. Use [Visual Studio](program-asp-net-web-pages-in-visual-studio.md) or [Visual Studio Code](https://code.visualstudio.com/).

If you don't want to use either Visual Studio or Visual Studio Code, you can install the component products individually using [Microsoft Web Platform Installer](https://www.microsoft.com/web/downloads/platform.aspx). You need the following products:

- Microsoft .NET Framework 4.5
- ASP.NET MVC 5 (which installs the ASP.NET Web Pages framework as well)
- IIS Express (the web server)
- Microsoft SQL Server Compact 4.0 (the database)

You can use a text editor to edit *.cshtml* (or *.vbhtml*) pages.

Managing SQL Server Compact databases (*.sdf* files) without a tool is a bit harder. Visual Studio containds tools for managing *.sdf* databases. You can also run SQL commands in code to perform many SQL Server management tasks.

To test *.cshtml* pages without using an integrated development environment (IDE), you can deploy them to a live server. (See [Can I deploy an ASP.NET Web Pages site without using WebMatrix?](#Can_I_deploy_an_ASP.NET_Web_Pages_site_without_using_WebMatrix))

### Running IIS Express without using an IDE

If you install IIS Express on your computer as a web server, you can use that to test the pages. You can run IIS Express from the command line and associate it with a specific port number. You then specify that port when you request *.cshtml* files in your browser.

In Windows, open a command prompt with administrator privileges and change to *C:\Program Files\IIS Express.* (For 64-bit systems, use the folder *C:\Program Files (x86)\IIS Express.)* Then enter the following command, using the actual path to your site:

`iisexpress.exe /port:35896 /path:C:\BasicWebSite`

You can use any port number that isn't already reserved by some other process. (Port numbers above 1024 are typically free.) For the `path` value, use the path of the website folder where the *.cshtml* files are.

After you run this command to set up IIS Express to serve your pages, you can open a browser and browse to a *.cshtml* file. Use a URL like the following:

`http://localhost:35896/default.cshtml`

For help with IIS Express command line options, enter `iisexpress.exe /?` at the command line.

<a id="Can_I_use_ASP.NET_Web_Forms_controls_on_a_Web_Pages_page"></a>
## Can I use ASP.NET Web Forms controls on a Web Pages page?

No. Web Forms controls like the [CheckBox](https://msdn.microsoft.com/en-us/library/system.web.ui.webcontrols.checkbox) control, the [validation controls](https://msdn.microsoft.com/en-us/library/bwd43d0x), and the [GridView](https://msdn.microsoft.com/en-us/library/system.web.ui.webcontrols.gridview) control only work in Web Forms pages (*.aspx* files). These controls require the Web Forms page framework.

<a id="Can_I_deploy_an_ASP.NET_Web_Pages_site_without_using_WebMatrix"></a>
## Can I deploy an ASP.NET Web Pages site without using WebMatrix?

Yes. You can manually copy website files to a server (typically by using FTP). If you perform a manual copy, you also have to copy the files that support SQL Server Compact (the database). For details, see the blog entry [Deploying Web Pages applications without a tool](http://mikepope.com/blog/DisplayBlog.aspx?permalink=2317).

<a id="Do_I_have_to_use_the_WebSecurity_helper_to_support_logins"></a>
## Do I have to use the WebSecurity helper to support logins?

No. The `SimpleMembership` provider that is part of ASP.NET Web Pages is one option. The security providers that are part of ASP.NET (that you might be used to working with in Web Forms) are also available. For example, you can use forms authentication in ASP.NET Web Pages just as you would in Web Forms. For one example of how to use forms authentication, see the Microsoft Support article [How To Implement Forms-Based Authentication in Your ASP.NET Application by Using C#.NET](https://support.microsoft.com/kb/301240). To download a simple example, see [ASP.NET version of "Login &amp; Password](http://www.codeguru.com/csharp/.net/net_asp/scripting/article.php/c19295/ASPNET-version-of-Login--Password.htm).

For information about how to use Windows authentication, see the blog post [Using Windows authentication in ASP.NET Web Pages](http://mikepope.com/blog/DisplayBlog.aspx?permalink=2298).

<a id="Does_ASP.NET_Web_Pages_support_HTML5"></a>
## Does ASP.NET Web Pages support HTML5?

Yes. The pages you create with ASP.NET Web Pages (*.cshtml* or *.vbhtml* pages) are essentially HTML pages that also contain code that runs on the server, before the page is rendered. As long as the user's browser supports HTML5, you can use HTML5 elements in a *.cshtml* or *.vbhtml* page.

<a id="Can_I_use_JavaScript_and_jQuery_with_Web_Pages"></a>
## Can I use JavaScript and jQuery with Web Pages?

Absolutely. The pages you create with ASP.NET Web Pages (*.cshtml* or *.vbhtml* pages) are just HTML pages with server code in them. Therefore, anything you can do in a normal HTML page by using JavaScript or jQuery you can also do in a *.cshtml* or *.vbhtml* page.

The **Starter Site** template in WebMatrix contains a number of jQuery libraries. If you create a site by using that template, the *Scripts* folder contains a jQuery core library (*jquery-1.6.2.js)* and libraries for jQuery validation (*jquery.validate.js*, etc.).

Here are some blog posts that illustrate ways to use jQuery with ASP.NET Web Pages:

- [Adding jQuery Goodness to ASP.NET Web Pages using WebMatrix](http://rachelappel.com/jquery/adding-jquery-goodness-to-asp-net-web-pages-using-webmatrix/) by Rachel Appel
- [5 min: WebMatrix + jQuery UI + json + jQuery templates](http://joeriks.com/2011/01/30/5-min-webmatrix-jquery-ui-json-jquery-templates/) by Jonas Eriksson
- [WebMatrix And jQuery Forms](http://mikesdotnetting.com/Article/155/WebMatrix-And-jQuery-Forms) by Mike Brind

<a id="AdditionalResources"></a>
## Additional Resources


[ASP.NET Web Pages (Razor) Troubleshooting Guide](https://go.microsoft.com/fwlink/?LinkId=253001)

[WebMatrix and ASP.NET Web Pages forum](https://forums.asp.net/1224.aspx/1?WebMatrix) on the ASP.NET website