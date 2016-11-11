File Uploads
============

By `Steve Smith`_

ASP.NET MVC actions support uploading of one or more files, using simple model binding for smaller files, or streaming for larger files.

.. contents:: Sections
  :local:
  :depth: 1

`View or download sample from GitHub <https://github.com/aspnet/Docs/tree/master/aspnet/mvc/models/file-uploads/sample>`_.

Uploading Small Files with Model Binding
----------------------------------------

To upload small files, you can use a multi-part HTML form or construct a POST request using JavaScript. An example form using Razor which supports multiple uploaded files is shown below:

.. literalinclude:: file-uploads/sample/FileUploadSample/Views/Home/Index.cshtml
  :language: html
  :lines: 7-20
  :dedent: 8


In order to support file uploads, HTML forms must specify an ``enctype`` of ``multipart/form-data``. The ``files`` input element shown abovesupports uploading multiple files; omit the ``multiple`` attribute on this input element to allow just a single file to be uploaded. The above markup renders in a browser as:

.. image:: file-uploads/_static/upload-form.png

The individual files uploaded to the server can be accessed through :doc:`model-binding` using the :dn:iface:`~Microsoft.AspNetCore.Http.IFormFile` interface. ``IFormFile`` has the following structure:

.. code-block:: c#

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

When uploading files using model binding and the ``IFormFile`` interface, the action method can accept either a single ``IFormFile`` or an ``IEnumerable<IFormFile>`` (or ``List<IFormFile>``) representing several files. The following example loops through one or more uploaded files, saves them to the local file system, and then returns the total number and size of files uploaded.

.. literalinclude:: file-uploads/sample/FileUploadSample/Controllers/UploadFilesController.cs
  :language: c#
  :emphasize-lines: 21,27,34

Files uploaded using the ``IFormFile`` technique are buffered in memory on the web server before being processed. Inside the action method, the ``IFormFile`` contents are accessible as a stream. In addition to the local file system, files can be streamed to `Azure blob storage <https://azure.microsoft.com/en-us/documentation/articles/vs-storage-aspnet5-getting-started-blobs/>` or Entity Framework.

To store binary file data in a database using Entity Framework, define a property of type ``byte[]`` on the entity:

.. code-block:: c#

  public class ApplicationUser : IdentityUser
  {
      public byte[] AvatarImage { get; set; }
  }

Specify a viewmodel property of type ``IFormFile``:

.. code-block:: c#

  public class RegisterViewModel
  {
      // other properties omitted

      public IFormFile AvatarImage { get; set; }
  }

Copy the ``IFormFile`` to a stream and save it to the byte array:

.. code-block:: c#

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

.. note:: Use caution when storing binary data in relational databases, as it can adversely impact performance.

IFormFile and ViewModels
^^^^^^^^^^^^^^^^^^^^^^^^

In addition to accepting raw ``IFormFile`` parameters, action methods can accept viewmodel types with ``IFormFile`` properties. Consider the following ``ProfileEditViewModel``:

.. literalinclude:: file-uploads/sample/FileUploadSample/ViewModels/ProfileEditViewModel.cs
  :language: c#
  :emphasize-lines: 11

The following action method accepts this type and saves the associated ``AvatarFile`` property to the local file system:

.. literalinclude:: file-uploads/sample/FileUploadSample/Controllers/ProfileController.cs
  :language: c#
  :lines: 46-64
  :dedent: 8
  :emphasize-lines: 2,10,13

Uploading Large Files with Streaming
------------------------------------

If the size or frequency of file uploads is causing performance or resource problems for the app, consider streaming the file upload rather than buffering it in its entirety (as the model binding approach shown above does). Using ``IFormFile`` and model binding is a much simpler solution; streaming requires a number of steps to implement properly.

The following example demonstrates how to using JavaScript/Angular to stream to a controller action. The file's antiforgery token will be generated using a custom filter attribute, and then passed in HTTP headers instead of in the request body. Because the action method will be processing the uploaded data directly, model binding will be disabled by another filter. Within the action, the form's contents are read using a MultipartReader, which reads each individual MultipartSection, processing the file or storing the contents as appropriate. Once all sections have been read, the action performs its own model binding.

The initial action loads the form and saves an antiforgery token in a cookie (via the ``GenerateAntiforgeryTokenCookieForAjax`` attribute):

.. literalinclude:: file-uploads/sample/FileUploadSample/Controllers/StreamingController.cs
  :language: c#
  :lines: 36-41
  :emphasize-lines: 2

The attribute uses ASP.NET Core's built-in :doc:`Antiforgery </security/anti-request-forgery>` support to set a cookie with a request token:

.. literalinclude:: file-uploads/sample/FileUploadSample/Filters/GenerateAntiforgeryTokenCookieForAjaxAttribute.cs
  :language: c#
  :emphasize-lines: 16-19

Angular automatically passes an antiforgery token in a request header named ``X-XSRF-TOKEN``; the ASP.NET Core MVC app is configured to refer to this header in its configuration in ``Startup.cs``:

.. literalinclude:: file-uploads/sample/FileUploadSample/Startup.cs
  :language: c#
  :lines: 10-16
  :emphasize-lines: 3-4

The ``DisableFormValueModelBinding`` attribute is used to disable model binding for the ``Upload`` action method:

.. literalinclude:: file-uploads/sample/FileUploadSample/Filters/DisableFormValueModelBindingAttribute.cs
  :language: c#
  :emphasize-lines: 18,26

Since model binding is disabled, the ``Upload`` action method doesn't accept any parameters. It works directly with the ``Request`` property of ``ControllerBase``. A ``MultipartReader`` is used to read each section, and either save the file (with a GUID filename) or accumulate the key/value data in a ``KeyValueAccumulator``. Once all sections have been read, the contents of the ``KeyValueAccumulator`` are used to bind the form data to a model type.

The complete ``Upload`` method is shown below:

.. literalinclude:: file-uploads/sample/FileUploadSample/Controllers/StreamingController.cs
  :language: c#
  :lines: 43-155
  :dedent: 8
  :emphasize-lines: 6-7,17,25,32,42,44,51,72,95-96,105-111
  
Troubleshooting
---------------

Below are some common problems encountered when working with uploading files, and their possible solutions.

Unexpected Not Found Error with IIS
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

The following error indicates your file upload exceeds the server's configured ``maxAllowedContentLength``:

.. code-block:: text

  HTTP 404.13 - Not Found
  The request filtering module is configured to deny a request that exceeds the request content length.

The default setting is ``30000000``, which is approxmiately 28.6MB. The value can be customized by editing ``web.config``:

.. code-block:: xml

  <system.webServer>
    <security>
      <requestFiltering>
        <!-- This will handle requests up to 50MB -->
        <requestLimits maxAllowedContentLength="52428800" />
      </requestFiltering>
    </security>
  </system.webServer>

This setting only applies to IIS; the behavior doesn't occur by default when hosting on Kestrel. `Learn more <https://www.iis.net/configreference/system.webserver/security/requestfiltering/requestlimits>`_.

Null Reference Exception with IFormFile
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

If your controller is accepting uploaded files using ``IFormFile``, but you find that the value is always null, be sure that your HTML form is specifying an ``enctype`` value of ``multipart/form-data``. If this attribute is not set on the ``<form>`` element, the file upload will not occur (and any bound ``IFormFile`` arguments will be null).

.. tip:: HTML file uploads must specify ``<form enctype="multipart/form-data">``.
