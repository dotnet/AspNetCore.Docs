---
title: "Part 8: Final Pages, Exception Handling, and Conclusion | Microsoft Docs"
author: JoeStagner
description: "This tutorial series details all of the steps taken to build the Tailspin Spyworks sample application. Part 8 adds a contact page, about page, and exception..."
ms.author: riande
manager: wpickett
ms.date: 07/21/2010
ms.topic: article
ms.assetid: 
ms.technology: dotnet-webforms
ms.prod: .net-framework
msc.legacyurl: /web-forms/overview/older-versions-getting-started/tailspin-spyworks/tailspin-spyworks-part-8
---
Part 8: Final Pages, Exception Handling, and Conclusion
====================
by [Joe Stagner](https://github.com/JoeStagner)

> Tailspin Spyworks demonstrates how extraordinarily simple it is to create powerful, scalable applications for the .NET platform. It shows off how to use the great new features in ASP.NET 4 to build an online store, including shopping, checkout, and administration.
> 
> This tutorial series details all of the steps taken to build the Tailspin Spyworks sample application. Part 8 adds a contact page, about page, and exception handling. This is the conclusion of the series.


## <a id="_Toc260221680"></a>  Contact Page (Sending email from ASP.NET)

Create a new page named ContactUs.aspx

Using the designer, create the following form taking special note to include the ToolkitScriptManager and the Editor control from the AjaxdControlToolkit. .

![](tailspin-spyworks-part-8/_static/image1.jpg)

Double click on the "Submit" button to generate a click event handler in the code behind file and implement a method to send the contact information as an email.

    protected void ImageButton_Submit_Click(object sender, ImageClickEventArgs e)
      {
      try 
        {
        MailMessage mMailMessage = new MailMessage();
        mMailMessage.From = new MailAddress(HttpUtility.HtmlEncode(TextBoxEmail.Text));
        mMailMessage.To.Add(new MailAddress("Your Email Here")); 
    
        // mMailMessage.Bcc.Add(new MailAddress(bcc));
        // mMailMessage.CC.Add(new MailAddress(cc));
    
       mMailMessage.Subject = "From:" + HttpUtility.HtmlEncode(TextBoxYourName.Text) + "-" + 
                                        HttpUtility.HtmlEncode(TextBoxSubject.Text);
       mMailMessage.Body = HttpUtility.HtmlEncode(EditorEmailMessageBody.Content); 
       mMailMessage.IsBodyHtml = true;
       mMailMessage.Priority = MailPriority.Normal;
       SmtpClient mSmtpClient = new SmtpClient();
       mSmtpClient.Send(mMailMessage);
       LabelMessage.Text = "Thank You - Your Message was sent.";
       }
     catch (Exception exp)
       {
       throw new Exception("ERROR: Unable to Send Contact - " + exp.Message.ToString(), exp);
       }
    }

This code requires that your web.config file contain an entry in the configuration section that specifies the SMTP server to use for sending mail.

    <system.net>
            <mailSettings>
                <smtp>
                    <network
                         host="mail..com"
                         port="25"
                         userName=""
                         password="" />
                </smtp>
            </mailSettings>
        </system.net>

## <a id="_Toc260221681"></a>  About Page

Create a page named AboutUs.aspx and add whatever content you like.

## <a id="_Toc260221682"></a>  Global Exception Handler

Lastly, throughout the application we have thrown exceptions and there are unforeseen circumstances that cold also cause unhandled exceptions in our web application.

We never want an unhandled exception to be displayed to a web site visitor.

![](tailspin-spyworks-part-8/_static/image2.jpg)

Apart from being a terrible user experience unhandled exceptions can also be a security problem.

To solve this problem we will implement a global exception handler.

To do this, open the Global.asax file and note the following pre-generated event handler.

    void Application_Error(object sender, EventArgs e)
         {
         // Code that runs when an unhandled error occurs
         }

Add code to implement the Application\_Error handler as follows.

    void Application_Error(object sender, EventArgs e)
         {
         Exception myEx =  Server.GetLastError();
        String RedirectUrlString = "~/Error.aspx?InnerErr=" + 
               myEx.InnerException.Message.ToString() + "&Err=" + myEx.Message.ToString();
         Response.Redirect(RedirectUrlString);
         }

Then add a page named Error.aspx to the solution and add this markup snippet.

    <center>
      <div class="ContentHead">ERROR</div><br /><br />
      <asp:Label ID="Label_ErrorFrom" runat="server" Text="Label"></asp:Label><br /><br />
      <asp:Label ID="Label_ErrorMessage" runat="server" Text="Label"></asp:Label><br /><br />
    </center>

Now in the Page\_Load event handler extract the error messages from the Request Object.

    protected void Page_Load(object sender, EventArgs e)
    {
        Label_ErrorFrom.Text = Request["Err"].ToString();
        Label_ErrorMessage.Text = Request["InnerErr"].ToString();
    }

## <a id="_Toc260221683"></a>  Conclusion

We've seen that that ASP.NET WebForms makes it easy to create a sophisticated website with database access, membership, AJAX, etc. pretty quickly.

Hopefully this tutorial has given you the tools you need to get started building your own ASP.NET WebForms applications!

>[!div class="step-by-step"] [Previous](tailspin-spyworks-part-7.md)