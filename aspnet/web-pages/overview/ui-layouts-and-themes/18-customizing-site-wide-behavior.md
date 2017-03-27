---
uid: web-pages/overview/ui-layouts-and-themes/18-customizing-site-wide-behavior
title: "Customizing Site-Wide Behavior for ASP.NET Web Pages (Razor) Sites | Microsoft Docs"
author: tfitzmac
description: "This chapter explains how to make settings to your entire website or an entire folder, rather than just a page."
ms.author: aspnetcontent
manager: wpickett
ms.date: 02/17/2014
ms.topic: article
ms.assetid: e158bed7-226f-4275-b02e-7553bd58c669
ms.technology: dotnet-webpages
ms.prod: .net-framework
msc.legacyurl: /web-pages/overview/ui-layouts-and-themes/18-customizing-site-wide-behavior
msc.type: authoredcontent
---
Customizing Site-Wide Behavior for ASP.NET Web Pages (Razor) Sites
====================
by [Tom FitzMacken](https://github.com/tfitzmac)

> This article explains how to make site-side settings for pages in an ASP.NET Web Pages (Razor) website.
> 
> What you'll learn:
> 
> - How to run code that lets you set values (global values or helper settings) for all pages in a site.
> - How to run code that lets you set values for all pages in a folder.
> - How to run code before and after a page loads.
> - How to send errors to a central error page.
> - How to add authentication to all pages in a folder.
>   
> 
> ## Software versions used in the tutorial
> 
> 
> - ASP.NET Web Pages (Razor) 2
> - WebMatrix 3
> - ASP.NET Web Helpers Library (NuGet package)
>   
> 
> This tutorial also works with ASP.NET Web Pages 3 and Visual Studio 2013 (or Visual Studio Express 2013 for Web), except you cannot use the ASP.NET Web Helpers Library.


<a id="Adding_Website_Startup_Code"></a>
## Adding Website Startup Code for ASP.NET Web Pages

For much of the code that you write in ASP.NET Web Pages, an individual page can contain all the code that's required for that page. For example, if a page sends an email message, it's possible to put all the code for that operation in a single page. This can include the code to initialize the settings for sending email (that is, for the SMTP server) and for sending the email message.

However, in some situations, you might want to run some code before any page on the site runs. This is useful for setting values that can be used anywhere in the site (referred to as *global values*.) For example, some helpers require you to provide values like email settings or account keys. It can be handy to keep these settings in global values.

You can do this by creating a page named *\_AppStart.cshtml* in the root of the site. If this page exists, it runs the first time any page in the site is requested. Therefore, it's a good place to run code to set global values. (Because *\_AppStart.cshtml* has an underscore prefix, ASP.NET won't send the page to a browser even if users request it directly.)

The following diagram shows how the *\_AppStart.cshtml* page works. When a request comes in for a page, and if this is the first request for any page in the site, ASP.NET first checks whether a *\_AppStart.cshtml* page exists. If so, any code in the *\_AppStart.cshtml* page runs, and then the requested page runs.

![[image]](18-customizing-site-wide-behavior/_static/image1.jpg)

## Setting Global Values for Your Website

1. In the root folder of a WebMatrix website, create a file named *\_AppStart.cshtml*. The file must be in the root of the site.
2. Replace the existing content with the following: 

    [!code-cshtml[Main](18-customizing-site-wide-behavior/samples/sample1.cshtml)]

    This code stores a value in the `AppState` dictionary, which is automatically available to all pages in the site. Notice that the *\_AppStart.cshtml* file does not have any markup in it. The page will run the code and then redirect to the page that was originally requested.

    > [!NOTE]
    > Be careful when you put code in the *\_AppStart.cshtml* file. If any errors occur in code in the *\_AppStart.cshtml* file, the website won't start.
3. In the root folder, create a new page named *AppName.cshtml*.
4. Replace the default markup and code with the following: 

    [!code-html[Main](18-customizing-site-wide-behavior/samples/sample2.html)]

    This code extracts the value from the `AppState` object that you set in the *\_AppStart.cshtml* page.
5. Run the *AppName.cshtml* page in a browser. (Make sure the page is selected in the **Files** workspace before you run it.) The page displays the global value. 

    ![[image]](18-customizing-site-wide-behavior/_static/image2.jpg)

<a id="Setting_Values_For_Helpers"></a>
## Setting Values for Helpers

A good use for the *\_AppStart.cshtml* file is to set values for helpers that you use in your site and that have to be initialized. Typical examples are email settings for the `WebMail` helper and the private and public keys for the `ReCaptcha` helper. In cases like these, you can set the values once in the *\_AppStart.cshtml* and then they're already set for all the pages in your site.

This procedure shows you how to set `WebMail` settings globally. (For more information about using the `WebMail` helper, see [Adding Email to an ASP.NET Web Pages Site](../getting-started/11-adding-email-to-your-web-site.md).)

1. Add the ASP.NET Web Helpers Library to your website as described in [Installing Helpers in an ASP.NET Web Pages Site](https://go.microsoft.com/fwlink/?LinkId=252372), if you haven't already added it.
2. If you don't already have a *\_AppStart.cshtml* file, in the root folder of a website create a file named *\_AppStart.cshtml*.
3. Add the following `WebMail` settings to the *\_AppStart.cshtml* file: 

    [!code-cshtml[Main](18-customizing-site-wide-behavior/samples/sample3.cshtml?highlight=2-7)]

    Modify the following email related settings in the code:

    - Set `your-SMTP-host` to the name of the SMTP server that you have access to.
    - Set `your-user-name-here` to the user name for your SMTP server account.
    - Set `your-account-password` to the password for your SMTP server account.
    - Set `your-email-address-here` to your own email address. This is the email address that the message is sent from. (Some email providers don't let you specify a different `From` address and will use your user name as the `From` address.)

    For more information about SMTP settings, see [Configuring Email Settings](https://go.microsoft.com/fwlink/?LinkID=202899#configuring_email_settings) in the article [Sending Email from an ASP.NET Web Pages (Razor) Site](https://go.microsoft.com/fwlink/?LinkID=202899) and [Issues with Sending Email](https://go.microsoft.com/fwlink/?LinkId=253001#email) in the [ASP.NET Web Pages (Razor) Troubleshooting Guide](https://go.microsoft.com/fwlink/?LinkId=253001).
- Save the *\_AppStart.cshtml* file and close it.
- In the root folder of a website, create new page named *TestEmail.cshtml*.
- Replace the existing content with the following: 

    [!code-cshtml[Main](18-customizing-site-wide-behavior/samples/sample4.cshtml)]
- Run the *TestEmail.cshtml* page in a browser.
- Fill in the fields to send yourself an email message and then click **Send**.
- Check your email to make sure you've gotten the message.

The important part of this example is that the settings that you don't usually change — like the name of your SMTP server and your email credentials — are set in the *\_AppStart.cshtml* file. That way you don't need to set them again in each page where you send email. (Although if for some reason you need to change those settings, you can set them individually in a page.) In the page, you only set the values that typically change each time, like the recipient and the body of the email message.

<a id="Running_Code_Before_and_After"></a>
## Running Code Before and After Files in a Folder

Just like you can use *\_AppStart.cshtml* to write code before pages in the site run, you can write code that runs before (and after) any page in a particular folder run. This is useful for things like setting the same layout page for all the pages in a folder, or for checking that a user is logged in before running a page in the folder.

For pages in particular folders, you can create code in a file named *\_PageStart.cshtml*. The following diagram shows how the *\_PageStart.cshtml* page works. When a request comes in for a page, ASP.NET first checks for a *\_AppStart.cshtml* page and runs that. Then ASP.NET checks whether there's a *\_PageStart.cshtml* page, and if so, runs that. It then runs the requested page.

Inside the *\_PageStart.cshtml* page, you can specify where during processing you want the requested page to run by including a `RunPage` method. This lets you run code before the requested page runs and then again after it. If you don't include `RunPage`, all the code in *\_PageStart.cshtml* runs, and then the requested page runs automatically.

![[image]](18-customizing-site-wide-behavior/_static/image3.jpg)

ASP.NET lets you create a hierarchy of *\_PageStart.cshtml* files. You can put a *\_PageStart.cshtml* file in the root of the site and in any subfolder. When a page is requested, the *\_PageStart.cshtml* file at the top-most level (nearest to the site root) runs, followed by the *\_PageStart.cshtml* file in the next subfolder, and so on down the subfolder structure until the request reaches the folder that contains the requested page. After all the applicable *\_PageStart.cshtml* files have run, the requested page runs.

For example, you might have the following combination of *\_PageStart.cshtml* files and *Default.cshtml* file:

[!code-cshtml[Main](18-customizing-site-wide-behavior/samples/sample5.cshtml)]

[!code-cshtml[Main](18-customizing-site-wide-behavior/samples/sample6.cshtml)]

[!code-cshtml[Main](18-customizing-site-wide-behavior/samples/sample7.cshtml)]

When you run */myfolder/default.cshtml*, you'll see the following:

[!code-console[Main](18-customizing-site-wide-behavior/samples/sample8.cmd)]

## Running Initialization Code for All Pages in a Folder

A good use for *\_PageStart.cshtml* files is to initialize the same layout page for all files in a single folder.

1. In the root folder, create a new folder named *InitPages*.
2. In the *InitPages* folder of your website, create a file named *\_PageStart.cshtml* and replace the default markup and code with the following: 

    [!code-cshtml[Main](18-customizing-site-wide-behavior/samples/sample9.cshtml)]
3. In the root of the website, create a folder named *Shared*.
4. In the *Shared* folder, create a file named *\_Layout1.cshtml* and replace the default markup and code with the following: 

    [!code-cshtml[Main](18-customizing-site-wide-behavior/samples/sample10.cshtml)]
5. In the *InitPages* folder, create a file named *Content1.cshtml* and replace the existing content with the following: 

    [!code-html[Main](18-customizing-site-wide-behavior/samples/sample11.html)]
6. In the *InitPages* folder, create another file named *Content2.cshtml* and replace the default markup with the following: 

    [!code-html[Main](18-customizing-site-wide-behavior/samples/sample12.html)]
7. Run *Content1.cshtml* in a browser. 

    ![[image]](18-customizing-site-wide-behavior/_static/image4.jpg)

    When the *Content1.cshtml* page runs, the *\_PageStart.cshtml* file sets `Layout` and also sets `PageData["MyBackground"]` to a color. In *Content1.cshtml*, the layout and color are applied.
8. Display *Content2.cshtml* in a browser. 

    The layout is the same, because both pages use the same layout page and color as initialized in *\_PageStart.cshtml*.

## Using \_PageStart.cshtml to Handle Errors

Another good use for the *\_PageStart.cshtml* file is to create a way to handle programming errors (exceptions) that might occur in any *.cshtml* page in a folder. This example shows you one way to do this.

1. In the root folder, create a folder named *InitCatch*.
2. In the *InitCatch* folder of your website, create a file named *\_PageStart.cshtml* and replace the existing markup and code with the following: 

    [!code-cshtml[Main](18-customizing-site-wide-behavior/samples/sample13.cshtml)]

    In this code, you try running the requested page explicitly by calling the `RunPage` method inside a `try` block. If any programming errors occur in the requested page, the code inside the `catch` block runs. In this case, the code redirects to a page (*Error.cshtml*) and passes the name of the file that experienced the error as part of the URL. (You'll create the page shortly.)
3. In the *InitCatch* folder of your website, create a file named *Exception.cshtml* and replace the existing markup and code with the following: 

    [!code-cshtml[Main](18-customizing-site-wide-behavior/samples/sample14.cshtml)]

    For purposes of this example, what you're doing in this page is deliberately creating an error by trying to open a database file that doesn't exist.
4. In the root folder, create a file named *Error.cshtml* and replace the existing markup and code with the following: 

    [!code-html[Main](18-customizing-site-wide-behavior/samples/sample15.html)]

    In this page, the expression `@Request["source"]` gets the value out of the URL and displays it.
5. In the toolbar, click **Save**.
6. Run *Exception.cshtml* in a browser. 

    ![[image]](18-customizing-site-wide-behavior/_static/image5.jpg)

    Because an error occurs in *Exception.cshtml*, the *\_PageStart.cshtml* page redirects to the *Error.cshtml* file, which displays the message.

    For more information about exceptions, see [Introduction to ASP.NET Web Pages Programming Using the Razor Syntax](https://go.microsoft.com/fwlink/?LinkID=251587).

<a id="Using__PageStart.cshtml_to_Restrict_Folder_Access"></a>
## Using \_PageStart.cshtml to Restrict Folder Access

You can also use the *\_PageStart.cshtml* file to restrict access to all the files in a folder.

1. In WebMatrix, create a new website using the **Site From Template** option.
2. From the available templates, select **Starter Site**.
3. In the root folder, create a folder named *AuthenticatedContent*.
4. In the *AuthenticatedContent* folder, create a file named *\_PageStart.cshtml* and replace the existing markup and code with the following: 

    [!code-cshtml[Main](18-customizing-site-wide-behavior/samples/sample16.cshtml)]

    The code starts by preventing all files in the folder from being cached. (This is required for scenarios like public computers, where you don't want one user's cached pages to be available to the next user.) Next, the code determines whether the user has signed in to the site before they can view any of the pages in the folder. If the user is not signed in, the code redirects to the login page. The login page can return the user to the page that was originally requested if you include a query string value named `ReturnUrl`.
5. Create a new page in the *AuthenticatedContent* folder named *Page.cshtml*.
6. Replace the default markup with the following:  

    [!code-cshtml[Main](18-customizing-site-wide-behavior/samples/sample17.cshtml)]
7. Run *Page.cshtml* in a browser. The code redirects you to a login page. You must register before logging in. After you've registered and logged in, you can navigate to the page and view its contents.

<a id="Additional_Resources"></a>
## Additional Resources

[Introduction to ASP.NET Web Pages Programming Using the Razor Syntax](https://go.microsoft.com/fwlink/?LinkID=251587)