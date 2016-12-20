---
title: "Sending HTML Form Data in ASP.NET Web API: Form-urlencoded Data | Microsoft Docs"
author: MikeWasson
description: ""
ms.author: riande
manager: wpickett
ms.date: 06/15/2012
ms.topic: article
ms.assetid: 
ms.technology: dotnet-webapi
ms.prod: .net-framework
msc.legacyurl: /web-api/overview/advanced/sending-html-form-data-part-1
---
Sending HTML Form Data in ASP.NET Web API: Form-urlencoded Data
====================
by [Mike Wasson](https://github.com/MikeWasson)

## Part 1: Form-urlencoded Data

This article shows how to post form-urlencoded data to a Web API controller.

- [Overview of HTML Forms](#overview_of_html_forms)
- [Sending Complex Types](#sending_complex_types)
- [Sending Form Data via AJAX](#sending_form_data_via_ajax)
- [Sending Simple Types](#sending_simple_types)

> [!NOTE] [Download the completed project](https://code.msdn.microsoft.com/ASPNET-Web-API-Sending-a6f9d007).


<a id="overview_of_html_forms"></a>
## Overview of HTML Forms

HTML forms use either GET or POST to send data to the server. The **method** attribute of the **form** element gives the HTTP method:

    <form action="api/values" method="post">

The default method is GET. If the form uses GET, the form data is encoded in the URI as a query string. If the form uses POST, the form data is placed in the request body. For POSTed data, the **enctype** attribute specifies the format of the request body:

| enctype | Description |
| --- | --- |
| application/x-www-form-urlencoded | Form data is encoded as name/value pairs, similar to a URI query string. This is the default format for POST. |
| multipart/form-data | Form data is encoded as a multipart MIME message. Use this format if you are uploading a file to the server. |

Part 1 of this article looks at x-www-form-urlencoded format. [Part 2](sending-html-form-data-part-2.md) describes multipart MIME.

<a id="sending_complex_types"></a>
## Sending Complex Types

Typically, you will send a complex type, composed of values taken from several form controls. Consider the following model that represents a status update:

    namespace FormEncode.Models
    {
        using System;
        using System.ComponentModel.DataAnnotations;
    
        public class Update
        {
            [Required]
            [MaxLength(140)]
            public string Status { get; set; }
    
            public DateTime Date { get; set; }
        }
    }

Here is a Web API controller that accepts an `Update` object via POST.

    namespace FormEncode.Controllers
    {
        using FormEncode.Models;
        using System;
        using System.Collections.Generic;
        using System.Net;
        using System.Net.Http;
        using System.Web;
        using System.Web.Http;
    
        public class UpdatesController : ApiController
        {
            static readonly Dictionary<Guid, Update> updates = new Dictionary<Guid, Update>();
    
            [HttpPost]
            [ActionName("Complex")]
            public HttpResponseMessage PostComplex(Update update)
            {
                if (ModelState.IsValid && update != null)
                {
                    // Convert any HTML markup in the status text.
                    update.Status = HttpUtility.HtmlEncode(update.Status);
    
                    // Assign a new ID.
                    var id = Guid.NewGuid();
                    updates[id] = update;
    
                    // Create a 201 response.
                    var response = new HttpResponseMessage(HttpStatusCode.Created)
                    {
                        Content = new StringContent(update.Status)
                    };
                    response.Headers.Location = 
                        new Uri(Url.Link("DefaultApi", new { action = "status", id = id }));
                    return response;
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
                }
            }
    
            [HttpGet]
            public Update Status(Guid id)
            {
                Update update;
                if (updates.TryGetValue(id, out update))
                {
                    return update;
                }
                else
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }
            }
    
        }
    }

> [!NOTE] This controller uses [action-based routing](../web-api-routing-and-actions/routing-in-aspnet-web-api.md#routing_by_action_name), so the route template is &quot;api/{controller}/{action}/{id}&quot;. The client will post the data to &quot;/api/updates/complex&quot;.


Now let's write an HTML form for users to submit a status update.

    <h1>Complex Type</h1>
    <form id="form1" method="post" action="api/updates/complex" 
        enctype="application/x-www-form-urlencoded">
        <div>
            <label for="status">Status</label>
        </div>
        <div>
            <input name="status" type="text" />
        </div>
        <div>
            <label for="date">Date</label>
        </div>
        <div>
            <input name="date" type="text" />
        </div>
        <div>
            <input type="submit" value="Submit" />
        </div>
    </form>

Notice that the **action** attribute on the form is the URI of our controller action. Here is the form with some values entered in:

![](sending-html-form-data-part-1/_static/image1.png)

When the user clicks Submit, the browser sends an HTTP request similar to the following:

    POST http://localhost:38899/api/updates/complex HTTP/1.1
    Accept: text/html, application/xhtml+xml, */*
    User-Agent: Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; WOW64; Trident/5.0)
    Content-Type: application/x-www-form-urlencoded
    Content-Length: 47
    
    status=Shopping+at+the+mall.&date=6%2F15%2F2012

Notice that the request body contains the form data, formatted as name/value pairs. Web API automatically converts the name/value pairs into an instance of the `Update` class.

<a id="sending_form_data_via_ajax"></a>
## Sending Form Data via AJAX

When a user submits a form, the browser navigates away from the current page and renders the body of the response message. That's OK when the response is an HTML page. With a web API, however, the response body is usually either empty or contains structured data, such as JSON. In that case, it makes more sense to send the form data using an AJAX request, so that the page can process the response.

The following code shows how to post form data using jQuery.

    <script type="text/javascript">
        $("#form1").submit(function () {
            var jqxhr = $.post('api/updates/complex', $('#form1').serialize())
                .success(function () {
                    var loc = jqxhr.getResponseHeader('Location');
                    var a = $('<a/>', { href: loc, text: loc });
                    $('#message').html(a);
                })
                .error(function () {
                    $('#message').html("Error posting the update.");
                });
            return false;
        });
    </script>

The jQuery **submit** function replaces the form action with a new function. This overrides the default behavior of the Submit button. The **serialize** function serializes the form data into name/value pairs. To send the form data to the server, call `$.post()`.

When the request completes, the `.success()` or `.error()` handler displays an appropriate message to the user.

![](sending-html-form-data-part-1/_static/image2.png)

<a id="sending_simple_types"></a>
## Sending Simple Types

In the previous sections, we sent a complex type, which Web API deserialized to an instance of a model class. You can also send simple types, such as a string.

> [!NOTE] Before sending a simple type, consider wrapping the value in a complex type instead. This gives you the benefits of model validation on the server side, and makes it easier to extend your model if needed.


The basic steps to send a simple type are the same, but there are two subtle differences. First, in the controller, you must decorate the parameter name with the **FromBody** attribute.

[!code[Main](sending-html-form-data-part-1/samples/sample1.xml?highlight=3)]

By default, Web API tries to get simple types from the request URI. The **FromBody** attribute tells Web API to read the value from the request body.

> [!NOTE] Web API reads the response body at most once, so only one parameter of an action can come from the request body. If you need to get multiple values from the request body, define a complex type.


Second, the client needs to send the value with the following format:

    =value

Specifically, the name portion of the name/value pair must be empty for a simple type. Not all browsers support this for HTML forms, but you create this format in script as follows:

    $.post('api/updates/simple', { "": $('#status1').val() });

Here is an example form:

    <h1>Simple Type</h1>
    <form id="form2">
        <div>
            <label for="status">Status</label>
        </div>
        <div>
            <input id="status1" type="text" />
        </div>
        <div>
            <input type="submit" value="Submit" />
        </div>
    </form>

And here is the script to submit the form value. The only difference from the previous script is the argument passed into the **post** function.

[!code[Main](sending-html-form-data-part-1/samples/sample2.xml?highlight=2)]

You can use the same approach to send an array of simple types:

    $.post('api/updates/postlist', { "": ["update one", "update two", "update three"] });

## Additional Resources

[Part 2: File Upload and Multipart MIME](sending-html-form-data-part-2.md)