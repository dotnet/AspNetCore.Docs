---
title: "Sending HTML Form Data in ASP.NET Web API: File Upload and Multipart MIME | Microsoft Docs"
author: MikeWasson
description: ""
ms.author: riande
manager: wpickett
ms.date: 06/21/2012
ms.topic: article
ms.assetid: 
ms.technology: dotnet-webapi
ms.prod: .net-framework
msc.legacyurl: /web-api/overview/advanced/sending-html-form-data-part-2
---
Sending HTML Form Data in ASP.NET Web API: File Upload and Multipart MIME
====================
by [Mike Wasson](https://github.com/MikeWasson)

## Part 2: File Upload and Multipart MIME

This tutorial shows how to upload files to a web API. It also describes how to process multipart MIME data.

> [!NOTE] [Download the completed project](https://code.msdn.microsoft.com/ASPNET-Web-API-File-Upload-a8c0fb0d).


Here is an example of an HTML form for uploading a file:

    <form name="form1" method="post" enctype="multipart/form-data" action="api/upload">
        <div>
            <label for="caption">Image Caption</label>
            <input name="caption" type="text" />
        </div>
        <div>
            <label for="image1">Image File</label>
            <input name="image1" type="file" />
        </div>
        <div>
            <input type="submit" value="Submit" />
        </div>
    </form>

![](sending-html-form-data-part-2/_static/image1.png)

This form contains a text input control and a file input control. When a form contains a file input control, the **enctype** attribute should always be &quot;multipart/form-data&quot;, which specifies that the form will be sent as a multipart MIME message.

The format of a multipart MIME message is easiest to understand by looking at an example request:

    POST http://localhost:50460/api/values/1 HTTP/1.1
    User-Agent: Mozilla/5.0 (Windows NT 6.1; WOW64; rv:12.0) Gecko/20100101 Firefox/12.0
    Accept: text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8
    Accept-Language: en-us,en;q=0.5
    Accept-Encoding: gzip, deflate
    Content-Type: multipart/form-data; boundary=---------------------------41184676334
    Content-Length: 29278
    
    -----------------------------41184676334
    Content-Disposition: form-data; name="caption"
    
    Summer vacation
    -----------------------------41184676334
    Content-Disposition: form-data; name="image1"; filename="GrandCanyon.jpg"
    Content-Type: image/jpeg
    
    (Binary data not shown)
    -----------------------------41184676334--

This message is divided into two *parts*, one for each form control. Part boundaries are indicated by the lines that start with dashes.

> [!NOTE] The part boundary includes a random component (&quot;41184676334&quot;) to ensure that the boundary string does not accidentally appear inside a message part.


Each message part contains one or more headers, followed by the part contents.

- The Content-Disposition header includes the name of the control. For files, it also contains the file name.
- The Content-Type header describes the data in the part. If this header is omitted, the default is text/plain.

In the previous example, the user uploaded a file named GrandCanyon.jpg, with content type image/jpeg; and the value of the text input was &quot;Summer Vacation&quot;.

## File Upload

Now let's look at a Web API controller that reads files from a multipart MIME message. The controller will read the files asynchronously. Web API supports asynchronous actions using the [task-based programming model](https://msdn.microsoft.com/library/dd460693.aspx). First, here is the code if you are targeting .NET Framework 4.5, which supports the **async** and **await** keywords.

    using System.Diagnostics;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Web;
    using System.Web.Http;
    
    public class UploadController : ApiController
    {
        public async Task<HttpResponseMessage> PostFormData()
        {
            // Check if the request contains multipart/form-data.
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }
    
            string root = HttpContext.Current.Server.MapPath("~/App_Data");
            var provider = new MultipartFormDataStreamProvider(root);
    
            try
            {
                // Read the form data.
                await Request.Content.ReadAsMultipartAsync(provider);
    
                // This illustrates how to get the file names.
                foreach (MultipartFileData file in provider.FileData)
                {
                    Trace.WriteLine(file.Headers.ContentDisposition.FileName);
                    Trace.WriteLine("Server file path: " + file.LocalFileName);
                }
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (System.Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }
    
    }

Notice that the controller action does not take any parameters. That's because we process the request body inside the action, without invoking a media-type formatter.

The **IsMultipartContent** method checks whether the request contains a multipart MIME message. If not, the controller returns HTTP status code 415 (Unsupported Media Type).

The **MultipartFormDataStreamProvider** class is a helper object that allocates file streams for uploaded files. To read the multipart MIME message, call the **ReadAsMultipartAsync** method. This method extracts all of the message parts and writes them into the streams provided by the **MultipartFormDataStreamProvider**.

When the method completes, you can get information about the files from the **FileData** property, which is a collection of **MultipartFileData** objects.

- **MultipartFileData.FileName** is the local file name on the server, where the file was saved.
- **MultipartFileData.Headers** contains the part header (*not* the request header). You can use this to access the Content\_Disposition and Content-Type headers.

As the name suggests, **ReadAsMultipartAsync** is an asynchronous method. To perform work after the method completes, use a [continuation task](https://msdn.microsoft.com/en-us/library/ee372288.aspx) (.NET 4.0) or the **await** keyword (.NET 4.5).

Here is the .NET Framework 4.0 version of the previous code:

    public Task<HttpResponseMessage> PostFormData()
    {
        // Check if the request contains multipart/form-data.
        if (!Request.Content.IsMimeMultipartContent())
        {
            throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
        }
    
        string root = HttpContext.Current.Server.MapPath("~/App_Data");
        var provider = new MultipartFormDataStreamProvider(root);
    
        // Read the form data and return an async task.
        var task = Request.Content.ReadAsMultipartAsync(provider).
            ContinueWith<HttpResponseMessage>(t =>
            {
                if (t.IsFaulted || t.IsCanceled)
                {
                    Request.CreateErrorResponse(HttpStatusCode.InternalServerError, t.Exception);
                }
    
                // This illustrates how to get the file names.
                foreach (MultipartFileData file in provider.FileData)
                {
                    Trace.WriteLine(file.Headers.ContentDisposition.FileName);
                    Trace.WriteLine("Server file path: " + file.LocalFileName);
                }
                return Request.CreateResponse(HttpStatusCode.OK);
            });
    
        return task;
    }

## Reading Form Control Data

The HTML form that I showed earlier had a text input control.

    <div>
            <label for="caption">Image Caption</label>
            <input name="caption" type="text" />
        </div>

You can get the value of the control from the **FormData** property of the **MultipartFormDataStreamProvider**.

[!code[Main](sending-html-form-data-part-2/samples/sample1.xml?highlight=15)]

**FormData** is a **NameValueCollection** that contains name/value pairs for the form controls. The collection can contain duplicate keys. Consider this form:

    <form name="trip_search" method="post" enctype="multipart/form-data" action="api/upload">
        <div>
            <input type="radio" name="trip" value="round-trip"/>
            Round-Trip
        </div>
        <div>
            <input type="radio" name="trip" value="one-way"/>
            One-Way
        </div>
    
        <div>
            <input type="checkbox" name="options" value="nonstop" />
            Only show non-stop flights
        </div>
        <div>
            <input type="checkbox" name="options" value="airports" />
            Compare nearby airports
        </div>
        <div>
            <input type="checkbox" name="options" value="dates" />
            My travel dates are flexible
        </div>
    
        <div>
            <label for="seat">Seating Preference</label>
            <select name="seat">
                <option value="aisle">Aisle</option>
                <option value="window">Window</option>
                <option value="center">Center</option>
                <option value="none">No Preference</option>
            </select>
        </div>
    </form>

![](sending-html-form-data-part-2/_static/image2.png)

The request body might look like this:

    -----------------------------7dc1d13623304d6
    Content-Disposition: form-data; name="trip"
    
    round-trip
    -----------------------------7dc1d13623304d6
    Content-Disposition: form-data; name="options"
    
    nonstop
    -----------------------------7dc1d13623304d6
    Content-Disposition: form-data; name="options"
    
    dates
    -----------------------------7dc1d13623304d6
    Content-Disposition: form-data; name="seat"
    
    window
    -----------------------------7dc1d13623304d6--

In that case, the **FormData** collection would contain the following key/value pairs:

- trip: round-trip
- options: nonstop
- options: dates
- seat: window