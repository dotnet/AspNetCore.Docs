---
title: File Uploads | Microsoft Docs
author: ardalis
description: 
keywords: ASP.NET Core,
ms.author: riande
manager: wpickett
ms.date: 11/10/2016
ms.topic: article
ms.assetid: ebc98159-a028-4a94-b06c-43981c79c6be
ms.technology: aspnet
ms.prod: aspnet-core
uid: mvc/models/file-uploads
---
  # File Uploads

By [Steve Smith](http://ardalis.com)

ASP.NET MVC actions support uploading of one or more files, using simple model binding for smaller files, or streaming for larger files.

[View or download sample from GitHub](https://github.com/aspnet/Docs/tree/master/aspnet/mvc/models/file-uploads/sample).

  ## Uploading Small Files with Model Binding

To upload small files, you can use a multi-part HTML form or construct a POST request using JavaScript. An example form using Razor which supports multiple uploaded files is shown below:

<!-- literal_block {"xml:space": "preserve", "language": "html", "dupnames": [], "linenos": false, "classes": [], "ids": [], "backrefs": [], "source": "/Users/shirhatti/src/Docs/aspnet/mvc/models/file-uploads/sample/FileUploadSample/Views/Home/Index.cshtml", "highlight_args": {"linenostart": 1}, "names": []} -->

````html

   <form method="post" enctype="multipart/form-data"
         asp-controller="UploadFiles" asp-action="Index">
       <div class="form-group">
           <div class="col-md-10">
               <p>Upload one or more files using this form:</p>
               <input type="file" name="files" multiple />
           </div>
       </div>
       <div class="form-group">
           <div class="col-md-10">
               <input type="submit" value="Upload" />
           </div>
       </div>
   </form>

   ````

In order to support file uploads, HTML forms must specify an `enctype` of `multipart/form-data`. The `files` input element shown above supports uploading multiple files; omit the `multiple` attribute on this input element to allow just a single file to be uploaded. The above markup renders in a browser as:

![image](file-uploads/_static/upload-form.png)

The individual files uploaded to the server can be accessed through [Model Binding](model-binding.md) using the [IFormFile](http://docs.asp.net/projects/api/en/latest/autoapi/Microsoft/AspNetCore/Http/IFormFile/index.html.md#Microsoft.AspNetCore.Http.IFormFile.md) interface. `IFormFile` has the following structure:

<!-- literal_block {"xml:space": "preserve", "language": "c#", "dupnames": [], "linenos": false, "classes": [], "ids": [], "backrefs": [], "highlight_args": {}, "names": []} -->

````c#

   public interface IFormFile
   {
     string ContentType { get; }
     string ContentDisposition { get; }
     IHeaderDictionary Headers { get; }
     long Length { get; }
     string Name { get; }
     string FileName { get; }
     Stream OpenReadStream();
     void CopyTo(Stream target);
     Task CopyToAsync(Stream target, CancellationToken cancellationToken = null);
   }
   ````

When uploading files using model binding and the `IFormFile` interface, the action method can accept either a single `IFormFile` or an `IEnumerable<IFormFile>` (or `List<IFormFile>`) representing several files. The following example loops through one or more uploaded files, saves them to the local file system, and then returns the total number and size of files uploaded.

<!-- literal_block {"xml:space": "preserve", "language": "c#", "dupnames": [], "linenos": false, "classes": [], "ids": [], "backrefs": [], "source": "/Users/shirhatti/src/Docs/aspnet/mvc/models/file-uploads/sample/FileUploadSample/Controllers/UploadFilesController.cs", "highlight_args": {"linenostart": 1, "hl_lines": [21, 27, 34]}, "names": []} -->

````c#

    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    namespace FileUploadSample.Controllers
    {
        public class UploadFilesController : Controller
        {
            [HttpPost("UploadFiles")]
            public async Task<IActionResult> Post(List<IFormFile> files)
            {
                long size = files.Sum(f => f.Length);

                // full path to file in temp location
                var filePath = Path.GetTempFileName();

                foreach (var formFile in files)
                {
                    if (formFile.Length > 0)
                    {
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await formFile.CopyToAsync(stream);
                        }
                    }
                }

                // process uploaded files

                return Ok(new { count = files.Count, size, filePath});
            }
        }
    }

   ````

Files uploaded using the `IFormFile` technique are buffered in memory or on disk on the web server before being processed. Inside the action method, the `IFormFile` contents are accessible as a stream. In addition to the local file system, files can be streamed to *Azure blob storage <https://azure.microsoft.com/en-us/documentation/articles/vs-storage-aspnet5-getting-started-blobs/>* or Entity Framework.

To store binary file data in a database using Entity Framework, define a property of type `byte[]` on the entity:

<!-- literal_block {"xml:space": "preserve", "language": "c#", "dupnames": [], "linenos": false, "classes": [], "ids": [], "backrefs": [], "highlight_args": {}, "names": []} -->

````c#

   public class ApplicationUser : IdentityUser
   {
       public byte[] AvatarImage { get; set; }
   }
   ````

Specify a viewmodel property of type `IFormFile`:

<!-- literal_block {"xml:space": "preserve", "language": "c#", "dupnames": [], "linenos": false, "classes": [], "ids": [], "backrefs": [], "highlight_args": {}, "names": []} -->

````c#

   public class RegisterViewModel
   {
       // other properties omitted

       public IFormFile AvatarImage { get; set; }
   }
   ````

Note: `IFormFile` can be used directly as an action method parameter or as a viewmodel property, as shown above.

Copy the `IFormFile` to a stream and save it to the byte array:

<!-- literal_block {"xml:space": "preserve", "language": "c#", "dupnames": [], "linenos": false, "classes": [], "ids": [], "backrefs": [], "highlight_args": {}, "names": []} -->

````c#

   //
   // POST: /Account/Register
   [HttpPost]
   [AllowAnonymous]
   [ValidateAntiForgeryToken]
   public async Task<IActionResult> Register(RegisterViewModel model)
   {
     ViewData["ReturnUrl"] = returnUrl;
     if (ModelState.IsValid)
     {
         var user = new ApplicationUser {
           UserName = model.Email,
           Email = model.Email
         };
         using (var memoryStream = new MemoryStream())
         {
             await model.AvatarImage.CopyToAsync(memoryStream);
             user.AvatarImage = memoryStream.ToArray();
         }
     // additional logic omitted
   }
   ````

Note: Use caution when storing binary data in relational databases, as it can adversely impact performance.

  ## Uploading Large Files with Streaming

If the size or frequency of file uploads is causing resource problems for the app, consider streaming the file upload rather than buffering it in its entirety (as the model binding approach shown above does). Using `IFormFile` and model binding is a much simpler solution; streaming requires a number of steps to implement properly.

Note: Any single buffered file exceeding 64KB will be moved from RAM to a temp file on disk on the server. The resources (disk, RAM) used by file uploads depend on the number and size of the files being uploaded concurrently. Streaming is not so much about perf, it's about scale. If you try to buffer too many uploads your site will crash when it runs out of memory or disk.

The following example demonstrates using JavaScript/Angular to stream to a controller action. The file's antiforgery token is generated using a custom filter attribute, and then passed in HTTP headers instead of in the request body. Because the action method processes the uploaded data directly, model binding is disabled by another filter. Within the action, the form's contents are read using a `MultipartReader`, which reads each individual `MultipartSection`, processing the file or storing the contents as appropriate. Once all sections have been read, the action performs its own model binding.

The initial action loads the form and saves an antiforgery token in a cookie (via the `GenerateAntiforgeryTokenCookieForAjax` attribute):

<!-- literal_block {"xml:space": "preserve", "language": "c#", "dupnames": [], "linenos": false, "classes": [], "ids": [], "backrefs": [], "source": "/Users/shirhatti/src/Docs/aspnet/mvc/models/file-uploads/sample/FileUploadSample/Controllers/StreamingController.cs", "highlight_args": {"linenostart": 1, "hl_lines": [2]}, "names": []} -->

````c#

           [HttpGet]
           [GenerateAntiforgeryTokenCookieForAjax]
           public IActionResult Index()
           {
               return View();
           }

   ````

The attribute uses ASP.NET Core's built-in [Antiforgery](../../security/anti-request-forgery.md) support to set a cookie with a request token:

<!-- literal_block {"xml:space": "preserve", "language": "c#", "dupnames": [], "linenos": false, "classes": [], "ids": [], "backrefs": [], "source": "/Users/shirhatti/src/Docs/aspnet/mvc/models/file-uploads/sample/FileUploadSample/Filters/GenerateAntiforgeryTokenCookieForAjaxAttribute.cs", "highlight_args": {"linenostart": 1, "hl_lines": [16, 17, 18, 19]}, "names": []} -->

````c#

   using Microsoft.AspNetCore.Antiforgery;
   using Microsoft.AspNetCore.Http;
   using Microsoft.AspNetCore.Mvc.Filters;
   using Microsoft.Extensions.DependencyInjection;

   namespace FileUploadSample.Filters
   {
       public class GenerateAntiforgeryTokenCookieForAjaxAttribute : ActionFilterAttribute
       {
           public override void OnActionExecuted(ActionExecutedContext context)
           {
               var antiforgery = context.HttpContext.RequestServices.GetService<IAntiforgery>();

               // We can send the request token as a JavaScript-readable cookie, and Angular will use it by default.
               var tokens = antiforgery.GetAndStoreTokens(context.HttpContext);
               context.HttpContext.Response.Cookies.Append(
                   "XSRF-TOKEN",
                   tokens.RequestToken,
                   new CookieOptions() { HttpOnly = false });
           }
       }
   }
   ````

Angular automatically passes an antiforgery token in a request header named `X-XSRF-TOKEN`; the ASP.NET Core MVC app is configured to refer to this header in its configuration in `Startup.cs`:

<!-- literal_block {"xml:space": "preserve", "language": "c#", "dupnames": [], "linenos": false, "classes": [], "ids": [], "backrefs": [], "source": "/Users/shirhatti/src/Docs/aspnet/mvc/models/file-uploads/sample/FileUploadSample/Startup.cs", "highlight_args": {"linenostart": 1, "hl_lines": [3, 4]}, "names": []} -->

````c#

           public void ConfigureServices(IServiceCollection services)
           {
               // Angular's default header name for sending the XSRF token.
               services.AddAntiforgery(options => options.HeaderName = "X-XSRF-TOKEN");

               services.AddMvc();
           }

   ````

The `DisableFormValueModelBinding` attribute is used to disable model binding for the `Upload` action method:

<!-- literal_block {"xml:space": "preserve", "language": "c#", "dupnames": [], "linenos": false, "classes": [], "ids": [], "backrefs": [], "source": "/Users/shirhatti/src/Docs/aspnet/mvc/models/file-uploads/sample/FileUploadSample/Filters/DisableFormValueModelBindingAttribute.cs", "highlight_args": {"linenostart": 1, "hl_lines": [18, 26]}, "names": []} -->

````c#

   using System;
   using System.Linq;
   using Microsoft.AspNetCore.Mvc.Filters;
   using Microsoft.AspNetCore.Mvc.ModelBinding;

   namespace FileUploadSample.Filters
   {
       [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
       public class DisableFormValueModelBindingAttribute : Attribute, IResourceFilter
       {
           public void OnResourceExecuting(ResourceExecutingContext context)
           {
               var formValueProviderFactory = context.ValueProviderFactories
                   .OfType<FormValueProviderFactory>()
                   .FirstOrDefault();
               if (formValueProviderFactory != null)
               {
                   context.ValueProviderFactories.Remove(formValueProviderFactory);
               }

               var jqueryFormValueProviderFactory = context.ValueProviderFactories
                   .OfType<JQueryFormValueProviderFactory>()
                   .FirstOrDefault();
               if (jqueryFormValueProviderFactory != null)
               {
                   context.ValueProviderFactories.Remove(jqueryFormValueProviderFactory);
               }
           }

           public void OnResourceExecuted(ResourceExecutedContext context)
           {
           }
       }
   }
   ````

Since model binding is disabled, the `Upload` action method doesn't accept any parameters. It works directly with the `Request` property of `ControllerBase`. A `MultipartReader` is used to read each section. The file is saved with a GUID filename and the the key/value data is stored in a `KeyValueAccumulator`. Once all sections have been read, the contents of the `KeyValueAccumulator` are used to bind the form data to a model type.

The complete `Upload` method is shown below:

<!-- literal_block {"xml:space": "preserve", "language": "c#", "dupnames": [], "linenos": false, "classes": [], "ids": [], "backrefs": [], "source": "/Users/shirhatti/src/Docs/aspnet/mvc/models/file-uploads/sample/FileUploadSample/Controllers/StreamingController.cs", "highlight_args": {"linenostart": 1, "hl_lines": [6, 7, 17, 25, 32, 42, 44, 51, 72, 95, 96, 105, 106, 107, 108, 109, 110, 111]}, "names": []} -->

````c#

    // 1. Disable the form value model binding here to take control of handling potentially large files.
    // 2. Typically antiforgery tokens are sent in request body, but since we do not want to read the request body
    //    early, the tokens are made to be sent via headers. The antiforgery token filter first looks for tokens
    //    in the request header and then falls back to reading the body.
    [HttpPost]
    [DisableFormValueModelBinding]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Upload()
    {
        if (!MultipartRequestHelper.IsMultipartContentType(Request.ContentType))
        {
            return BadRequest("Expected a multipart request, but got " +
                Request.ContentType);
        }

        // Used to accumulate all the form url encoded key value pairs in the request.
        var formAccumulator = new KeyValueAccumulator();
        string targetFilePath = null;

        var boundary = MultipartRequestHelper.GetBoundary(
            MediaTypeHeaderValue.Parse(Request.ContentType),
            _defaultFormOptions.MultipartBoundaryLengthLimit);
        var reader = new MultipartReader(boundary, HttpContext.Request.Body);

        var section = await reader.ReadNextSectionAsync();
        while (section != null)
        {
            ContentDispositionHeaderValue contentDisposition;
            var hasContentDispositionHeader = ContentDispositionHeaderValue.TryParse(section.ContentDisposition,
                out contentDisposition);

            if (hasContentDispositionHeader)
            {
                if (MultipartRequestHelper.HasFileContentDisposition(contentDisposition))
                {
                    targetFilePath = Path.GetTempFileName();
                    using (var targetStream = System.IO.File.Create(targetFilePath))
                    {
                        await section.Body.CopyToAsync(targetStream);

                        _logger.LogInformation($"Copied the uploaded file '{targetFilePath}'");
                    }
                }
                else if (MultipartRequestHelper.HasFormDataContentDisposition(contentDisposition))
                {
                    // Content-Disposition: form-data; name="key"
                    //
                    // value

                    // Do not limit the key name length here because the multipart headers length
                    // limit is already in effect.
                    var key = HeaderUtilities.RemoveQuotes(contentDisposition.Name);
                    var encoding = GetEncoding(section);
                    using (var streamReader = new StreamReader(
                        section.Body,
                        encoding,
                        detectEncodingFromByteOrderMarks: true,
                        bufferSize: 1024,
                        leaveOpen: true))
                    {
                        // The value length limit is enforced by MultipartBodyLengthLimit
                        var value = await streamReader.ReadToEndAsync();
                        if (String.Equals(value, "undefined", StringComparison.OrdinalIgnoreCase))
                        {
                            value = String.Empty;
                        }
                        formAccumulator.Append(key, value);

                        if (formAccumulator.ValueCount > _defaultFormOptions.ValueCountLimit)
                        {
                            throw new InvalidDataException(
                                "Form key count limit " + _defaultFormOptions.ValueCountLimit +
                                " exceeded.");
                        }
                    }
                }
            }

            // Drains any remaining section body that has not been consumed and
            // reads the headers for the next section.
            section = await reader.ReadNextSectionAsync();
        }

        // Bind form data to a model
        var user = new User();
        var formValueProvider = new FormValueProvider(
            BindingSource.Form,
            new FormCollection(formAccumulator.GetResults()),
            CultureInfo.CurrentCulture);

        var bindingSuccessful = await TryUpdateModelAsync(user, prefix: "",
            valueProvider: formValueProvider);
        if (!bindingSuccessful)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
        }

        var uploadedData = new UploadedData()
        {
            Name = user.Name,
            Age = user.Age,
            Zipcode = user.Zipcode,
            FilePath = targetFilePath
        };
        return Json(uploadedData);
    }

   ````

  ## Troubleshooting

Below are some common problems encountered when working with uploading files, and their possible solutions.

  ### Unexpected Not Found Error with IIS

The following error indicates your file upload exceeds the server's configured `maxAllowedContentLength`:

<!-- literal_block {"xml:space": "preserve", "language": "text", "dupnames": [], "linenos": false, "classes": [], "ids": [], "backrefs": [], "highlight_args": {}, "names": []} -->

````text

   HTTP 404.13 - Not Found
   The request filtering module is configured to deny a request that exceeds the request content length.
   ````

The default setting is `30000000`, which is approxmiately 28.6MB. The value can be customized by editing `web.config`:

<!-- literal_block {"xml:space": "preserve", "language": "xml", "dupnames": [], "linenos": false, "classes": [], "ids": [], "backrefs": [], "highlight_args": {}, "names": []} -->

````xml

   <system.webServer>
     <security>
       <requestFiltering>
         <!-- This will handle requests up to 50MB -->
         <requestLimits maxAllowedContentLength="52428800" />
       </requestFiltering>
     </security>
   </system.webServer>
   ````

This setting only applies to IIS; the behavior doesn't occur by default when hosting on Kestrel. [Learn more](https://www.iis.net/configreference/system.webserver/security/requestfiltering/requestlimits).

  ### Null Reference Exception with IFormFile

If your controller is accepting uploaded files using `IFormFile`, but you find that the value is always null, be sure that your HTML form is specifying an `enctype` value of `multipart/form-data`. If this attribute is not set on the `<form>` element, the file upload will not occur (and any bound `IFormFile` arguments will be null).

