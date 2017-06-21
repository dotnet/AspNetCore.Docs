---
uid: web-pages/overview/getting-started/11-adding-email-to-your-web-site
title: "Sending Email from an ASP.NET Web Pages (Razor) Site | Microsoft Docs"
author: tfitzmac
description: "This chapter explains how to send an automated email message from a website."
ms.author: aspnetcontent
manager: wpickett
ms.date: 02/20/2014
ms.topic: article
ms.assetid: fc49bcb9-f1a9-4048-8c3f-b60951853200
ms.technology: dotnet-webpages
ms.prod: .net-framework
msc.legacyurl: /web-pages/overview/getting-started/11-adding-email-to-your-web-site
msc.type: authoredcontent
---
Sending Email from an ASP.NET Web Pages (Razor) Site
====================
by [Tom FitzMacken](https://github.com/tfitzmac)

> This article explains how to send an email message from a website when you use ASP.NET Web Pages (Razor).
> 
> What you'll learn:
> 
> - How to send an email message from your website.
> - How to attach a file to an email message.
> 
> This is the ASP.NET feature introduced in the article:
> 
> - The `WebMail` helper.
>   
> 
> ## Software versions used in the tutorial
> 
> 
> - ASP.NET Web Pages (Razor) 3
>   
> 
> This tutorial also works with ASP.NET Web Pages 2.


<a id="Sending_Email_Messages"></a>
## Sending Email Messages from Your Website

There are all sorts of reasons why you might need to send email from your website. You might send confirmation messages to users, or you might send notifications to yourself (for example, that a new user has registered.) The `WebMail` helper makes it easy for you to send email.

To use the `WebMail` helper, you have to have access to an SMTP server. (SMTP stands for *Simple Mail Transfer Protocol*.) An SMTP server is an email server that only forwards messages to the recipient's server &#8212; it's the outbound side of email. If you use a hosting provider for your website, they probably set you up with email and they can tell you what your SMTP server name is. If you're working inside a corporate network, an administrator or your IT department can usually give you the information about an SMTP server that you can use. If you're working at home, you might even be able to test using your ordinary email provider, who can tell you the name of their SMTP server. You typically need:

- The name of the SMTP server.
- The port number. This is almost always 25. However, your ISP may require you to use port 587. If you are using secure sockets layer (SSL) for email, you might need a different port. Check with your email provider.
- Credentials (user name, password).

In this procedure, you create two pages. The first page has a form that lets users enter a description, as if they were filling in a technical-support form. The first page submits its information to a second page. In the second page, code extracts the user's information and sends an email message. It also displays a message confirming that the problem report has been received.

![[image]](11-adding-email-to-your-web-site/_static/image1.jpg)

> [!NOTE]
> To keep this example simple, the code initializes the `WebMail` helper right in the page where you use it. However, for real websites, it's a better idea to put initialization code like this in a global file, so that you initialize the `WebMail` helper for all files in your website. For more information, see [Customizing Site-Wide Behavior for ASP.NET Web Pages](https://go.microsoft.com/fwlink/?LinkId=202906#Setting_Values_For_Helpers).


1. Create a new website.
2. Add a new page named *EmailRequest.cshtml* and add the following markup: 

    [!code-html[Main](11-adding-email-to-your-web-site/samples/sample1.html)]

    Notice that the `action` attribute of the form element has been set to *ProcessRequest.cshtml*. This means that the form will be submitted to that page instead of back to the current page.
3. Add a new page named *ProcessRequest.cshtml* to the website and add the following code and markup:   

    [!code-cshtml[Main](11-adding-email-to-your-web-site/samples/sample2.cshtml)]

    In the code, you get the values of the form fields that were submitted to the page. You then call the `WebMail` helper's `Send` method to create and send the email message. In this case, the values to use are made up of text that you concatenate with the values that were submitted from the form.

    The code for this page is inside a `try/catch` block. If for any reason the attempt to send an email doesn't work (for example, the settings aren't right), the code in the `catch` block runs and sets the `errorMessage` variable to the error that has occurred. (For more information about `try/catch` blocks or the `<text>` tag, see [Introduction to ASP.NET Web Pages Programming Using the Razor Syntax](https://go.microsoft.com/fwlink/?LinkID=251587#ID_HandlingErrors).)

    In the body of the page, if the `errorMessage` variable is empty (the default), the user sees a message that the email message has been sent. If the `errorMessage` variable is set to true, the user sees a message that there's been a problem sending the message.

    Notice that in the portion of the page that displays an error message, there's an additional test: `if(debuggingFlag)`. This is a variable that you can set to true if you're having trouble sending email. When `debuggingFlag` is true, and if there's a problem sending email, an additional error message is displayed that shows whatever ASP.NET has reported when it tried to send the email message. Fair warning, though: the error messages that ASP.NET reports when it can't send an email message can be generic. For example, if ASP.NET can't contact the SMTP server (for example, because you made an error in the server name), the error is `Failure sending mail`.

    > [!NOTE] 
    > 
    > **Important** When you get an error message from an exception object (`ex` in the code), do *not* routinely pass that message through to users. Exception objects often include information that users should not see and that can even be a security vulnerability. That's why this code includes the variable `debuggingFlag` that's used as a switch to display the error message, and why the variable by default is set to false. You should set that variable to true (and therefore display the error message) *only* if you're having a problem with sending email and you need to debug. Once you have fixed any problems, set `debuggingFlag` back to false.

    Modify the following email related settings in the code:

    - Set `your-SMTP-host` to the name of the SMTP server that you have access to.
    - Set `your-user-name-here` to the user name for your SMTP server account.
    - Set `your-account-password` to the password for your SMTP server account.
    - Set `your-email-address-here` to your own email address. This is the email address that the message is sent from. (Some email providers don't let you specify a different `From` address and will use your user name as the `From` address.)

    > [!TIP] 
    > 
    > <a id="configuring_email_settings"></a>
    > ### Configuring Email Settings
    > 
    > It can be a challenge sometimes to make sure you have the right settings for the SMTP server, port number, and so on. Here are a few tips:
    > 
    > - The SMTP server name is often something like `smtp.provider.com` or `smtp.provider.net`. However, if you publish your site to a hosting provider, the SMTP server name at that point might be `localhost`. This is because after you've published and your site is running on the provider's server, the email server might be local from the perspective of your application. This change in server names might mean you have to change the SMTP server name as part of your publishing process.
    > - The port number is usually 25. However, some providers require you to use port 587 or some other port.
    > - Make sure that you use the right credentials. If you've published your site to a hosting provider, use the credentials that the provider has specifically indicated are for email. These might be different from the credentials you use to publish.
    > - Sometimes you don't need credentials at all. If you're sending email using your personal ISP, your email provider might already know your credentials. After you publish, you might need to use different credentials than when you test on your local computer.
    > - If your email provider uses encryption, you have to set `WebMail.EnableSsl` to `true`.
4. Run the *EmailRequest.cshtml* page in a browser. (Make sure the page is selected in the **Files** workspace before you run it.)
5. Enter your name and a problem description, and then click the **Submit** button. You're redirected to the *ProcessRequest.cshtml* page, which confirms your message and which sends you an email message. 

    ![[image]](11-adding-email-to-your-web-site/_static/image2.jpg)

<a id="Sending_a_File"></a>
## Sending a File Using Email

You can also send files that are attached to email messages. In this procedure, you create a text file and two HTML pages. You'll use the text file as an email attachment.

1. In the website, add a new text file and name it *MyFile.txt*.
2. Copy the following text and paste it in the file: 

    `Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.`
3. Create a page named *SendFile.cshtml* and add the following markup: 

    [!code-html[Main](11-adding-email-to-your-web-site/samples/sample3.html)]
4. Create a page named *ProcessFile.cshtml* and add the following markup: 

    [!code-cshtml[Main](11-adding-email-to-your-web-site/samples/sample4.cshtml)]
5. Modify the following email related settings in the code from the example:

    - Set `your-SMTP-host` to the name of an SMTP server that you have access to.
    - Set `your-user-name-here` to the user name for your SMTP server account.
    - Set `your-email-address-here` to your own email address. This is the email address that the message is sent from.
    - Set `your-account-password` to the password for your SMTP server account.
    - Set `target-email-address-here` to your own email address. (As before, you'd normally send an email to someone else, but for testing, you can send it to yourself.)
6. Run the *SendFile.cshtml* page in a browser.
7. Enter your name, a subject line, and the name of the text file to attach (*MyFile.txt*).
8. Click the `Submit` button. As before, you're redirected to the *ProcessFile.cshtml* page, which confirms your message and which sends you an email message with the attached file.

<a id="Additional_Resources"></a>
## Additional Resources


- [ASP.NET Web Pages (Razor) Troubleshooting Guide](https://go.microsoft.com/fwlink/?LinkId=253001)
- [Simple Mail Transfer Protocol](https://msdn.microsoft.com/en-us/library/aa480435.aspx)
- [Customizing Site-Wide Behavior for ASP.NET Web Pages](https://go.microsoft.com/fwlink/?LinkId=202906)