

Controller Class
================



.. contents:: 
   :local:



Summary
-------

Base class for an MVC controller.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Controller`








Syntax
------

.. code-block:: csharp

   public abstract class Controller : IActionFilter, IAsyncActionFilter, IFilterMetadata, IDisposable





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.ViewFeatures/Controller.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Controller

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Controller
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Controller.Content(System.String)
    
        
    
        Creates a :any:`Microsoft.AspNet.Mvc.ContentResult` object by specifying a ``content`` string.
    
        
        
        
        :param content: The content to write to the response.
        
        :type content: System.String
        :rtype: Microsoft.AspNet.Mvc.ContentResult
        :return: The created <see cref="T:Microsoft.AspNet.Mvc.ContentResult" /> object for the response.
    
        
        .. code-block:: csharp
    
           public virtual ContentResult Content(string content)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Controller.Content(System.String, Microsoft.Net.Http.Headers.MediaTypeHeaderValue)
    
        
    
        Creates a :any:`Microsoft.AspNet.Mvc.ContentResult` object by specifying a ``content``
        string and a ``contentType``.
    
        
        
        
        :param content: The content to write to the response.
        
        :type content: System.String
        
        
        :param contentType: The content type (MIME type).
        
        :type contentType: Microsoft.Net.Http.Headers.MediaTypeHeaderValue
        :rtype: Microsoft.AspNet.Mvc.ContentResult
        :return: The created <see cref="T:Microsoft.AspNet.Mvc.ContentResult" /> object for the response.
    
        
        .. code-block:: csharp
    
           public virtual ContentResult Content(string content, MediaTypeHeaderValue contentType)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Controller.Content(System.String, System.String)
    
        
    
        Creates a :any:`Microsoft.AspNet.Mvc.ContentResult` object by specifying a ``content`` string
        and a content type.
    
        
        
        
        :param content: The content to write to the response.
        
        :type content: System.String
        
        
        :param contentType: The content type (MIME type).
        
        :type contentType: System.String
        :rtype: Microsoft.AspNet.Mvc.ContentResult
        :return: The created <see cref="T:Microsoft.AspNet.Mvc.ContentResult" /> object for the response.
    
        
        .. code-block:: csharp
    
           public virtual ContentResult Content(string content, string contentType)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Controller.Content(System.String, System.String, System.Text.Encoding)
    
        
    
        Creates a :any:`Microsoft.AspNet.Mvc.ContentResult` object by specifying a ``content`` string,
        a ``contentType``, and ``contentEncoding``.
    
        
        
        
        :param content: The content to write to the response.
        
        :type content: System.String
        
        
        :param contentType: The content type (MIME type).
        
        :type contentType: System.String
        
        
        :param contentEncoding: The content encoding.
        
        :type contentEncoding: System.Text.Encoding
        :rtype: Microsoft.AspNet.Mvc.ContentResult
        :return: The created <see cref="T:Microsoft.AspNet.Mvc.ContentResult" /> object for the response.
    
        
        .. code-block:: csharp
    
           public virtual ContentResult Content(string content, string contentType, Encoding contentEncoding)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Controller.Created(System.String, System.Object)
    
        
    
        Creates a :any:`Microsoft.AspNet.Mvc.CreatedResult` object that produces a Created (201) response.
    
        
        
        
        :param uri: The URI at which the content has been created.
        
        :type uri: System.String
        
        
        :param value: The content value to format in the entity body.
        
        :type value: System.Object
        :rtype: Microsoft.AspNet.Mvc.CreatedResult
        :return: The created <see cref="T:Microsoft.AspNet.Mvc.CreatedResult" /> for the response.
    
        
        .. code-block:: csharp
    
           public virtual CreatedResult Created(string uri, object value)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Controller.Created(System.Uri, System.Object)
    
        
    
        Creates a :any:`Microsoft.AspNet.Mvc.CreatedResult` object that produces a Created (201) response.
    
        
        
        
        :param uri: The URI at which the content has been created.
        
        :type uri: System.Uri
        
        
        :param value: The content value to format in the entity body.
        
        :type value: System.Object
        :rtype: Microsoft.AspNet.Mvc.CreatedResult
        :return: The created <see cref="T:Microsoft.AspNet.Mvc.CreatedResult" /> for the response.
    
        
        .. code-block:: csharp
    
           public virtual CreatedResult Created(Uri uri, object value)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Controller.CreatedAtAction(System.String, System.Object)
    
        
    
        Creates a :any:`Microsoft.AspNet.Mvc.CreatedAtActionResult` object that produces a Created (201) response.
    
        
        
        
        :param actionName: The name of the action to use for generating the URL.
        
        :type actionName: System.String
        
        
        :param value: The content value to format in the entity body.
        
        :type value: System.Object
        :rtype: Microsoft.AspNet.Mvc.CreatedAtActionResult
        :return: The created <see cref="T:Microsoft.AspNet.Mvc.CreatedAtRouteResult" /> for the response.
    
        
        .. code-block:: csharp
    
           public virtual CreatedAtActionResult CreatedAtAction(string actionName, object value)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Controller.CreatedAtAction(System.String, System.Object, System.Object)
    
        
    
        Creates a :any:`Microsoft.AspNet.Mvc.CreatedAtActionResult` object that produces a Created (201) response.
    
        
        
        
        :param actionName: The name of the action to use for generating the URL.
        
        :type actionName: System.String
        
        
        :param routeValues: The route data to use for generating the URL.
        
        :type routeValues: System.Object
        
        
        :param value: The content value to format in the entity body.
        
        :type value: System.Object
        :rtype: Microsoft.AspNet.Mvc.CreatedAtActionResult
        :return: The created <see cref="T:Microsoft.AspNet.Mvc.CreatedAtRouteResult" /> for the response.
    
        
        .. code-block:: csharp
    
           public virtual CreatedAtActionResult CreatedAtAction(string actionName, object routeValues, object value)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Controller.CreatedAtAction(System.String, System.String, System.Object, System.Object)
    
        
    
        Creates a :any:`Microsoft.AspNet.Mvc.CreatedAtActionResult` object that produces a Created (201) response.
    
        
        
        
        :param actionName: The name of the action to use for generating the URL.
        
        :type actionName: System.String
        
        
        :param controllerName: The name of the controller to use for generating the URL.
        
        :type controllerName: System.String
        
        
        :param routeValues: The route data to use for generating the URL.
        
        :type routeValues: System.Object
        
        
        :param value: The content value to format in the entity body.
        
        :type value: System.Object
        :rtype: Microsoft.AspNet.Mvc.CreatedAtActionResult
        :return: The created <see cref="T:Microsoft.AspNet.Mvc.CreatedAtRouteResult" /> for the response.
    
        
        .. code-block:: csharp
    
           public virtual CreatedAtActionResult CreatedAtAction(string actionName, string controllerName, object routeValues, object value)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Controller.CreatedAtRoute(System.Object, System.Object)
    
        
    
        Creates a :any:`Microsoft.AspNet.Mvc.CreatedAtRouteResult` object that produces a Created (201) response.
    
        
        
        
        :param routeValues: The route data to use for generating the URL.
        
        :type routeValues: System.Object
        
        
        :param value: The content value to format in the entity body.
        
        :type value: System.Object
        :rtype: Microsoft.AspNet.Mvc.CreatedAtRouteResult
        :return: The created <see cref="T:Microsoft.AspNet.Mvc.CreatedAtRouteResult" /> for the response.
    
        
        .. code-block:: csharp
    
           public virtual CreatedAtRouteResult CreatedAtRoute(object routeValues, object value)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Controller.CreatedAtRoute(System.String, System.Object)
    
        
    
        Creates a :any:`Microsoft.AspNet.Mvc.CreatedAtRouteResult` object that produces a Created (201) response.
    
        
        
        
        :param routeName: The name of the route to use for generating the URL.
        
        :type routeName: System.String
        
        
        :param value: The content value to format in the entity body.
        
        :type value: System.Object
        :rtype: Microsoft.AspNet.Mvc.CreatedAtRouteResult
        :return: The created <see cref="T:Microsoft.AspNet.Mvc.CreatedAtRouteResult" /> for the response.
    
        
        .. code-block:: csharp
    
           public virtual CreatedAtRouteResult CreatedAtRoute(string routeName, object value)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Controller.CreatedAtRoute(System.String, System.Object, System.Object)
    
        
    
        Creates a :any:`Microsoft.AspNet.Mvc.CreatedAtRouteResult` object that produces a Created (201) response.
    
        
        
        
        :param routeName: The name of the route to use for generating the URL.
        
        :type routeName: System.String
        
        
        :param routeValues: The route data to use for generating the URL.
        
        :type routeValues: System.Object
        
        
        :param value: The content value to format in the entity body.
        
        :type value: System.Object
        :rtype: Microsoft.AspNet.Mvc.CreatedAtRouteResult
        :return: The created <see cref="T:Microsoft.AspNet.Mvc.CreatedAtRouteResult" /> for the response.
    
        
        .. code-block:: csharp
    
           public virtual CreatedAtRouteResult CreatedAtRoute(string routeName, object routeValues, object value)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Controller.Dispose()
    
        
    
        
        .. code-block:: csharp
    
           public void Dispose()
    
    .. dn:method:: Microsoft.AspNet.Mvc.Controller.Dispose(System.Boolean)
    
        
    
        Releases all resources currently used by this :any:`Microsoft.AspNet.Mvc.Controller` instance.
    
        
        
        
        :param disposing: true if this method is being invoked by the  method,
            otherwise false.
        
        :type disposing: System.Boolean
    
        
        .. code-block:: csharp
    
           protected virtual void Dispose(bool disposing)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Controller.File(System.Byte[], System.String)
    
        
    
        Returns a file with the specified ``fileContents`` as content and the
        specified ``contentType`` as the Content-Type.
    
        
        
        
        :param fileContents: The file contents.
        
        :type fileContents: System.Byte[]
        
        
        :param contentType: The Content-Type of the file.
        
        :type contentType: System.String
        :rtype: Microsoft.AspNet.Mvc.FileContentResult
        :return: The created <see cref="T:Microsoft.AspNet.Mvc.FileContentResult" /> for the response.
    
        
        .. code-block:: csharp
    
           public virtual FileContentResult File(byte[] fileContents, string contentType)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Controller.File(System.Byte[], System.String, System.String)
    
        
    
        Returns a file with the specified ``fileContents`` as content, the
        specified ``contentType`` as the Content-Type and the
        specified ``fileDownloadName`` as the suggested file name.
    
        
        
        
        :param fileContents: The file contents.
        
        :type fileContents: System.Byte[]
        
        
        :param contentType: The Content-Type of the file.
        
        :type contentType: System.String
        
        
        :param fileDownloadName: The suggested file name.
        
        :type fileDownloadName: System.String
        :rtype: Microsoft.AspNet.Mvc.FileContentResult
        :return: The created <see cref="T:Microsoft.AspNet.Mvc.FileContentResult" /> for the response.
    
        
        .. code-block:: csharp
    
           public virtual FileContentResult File(byte[] fileContents, string contentType, string fileDownloadName)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Controller.File(System.IO.Stream, System.String)
    
        
    
        Returns a file in the specified ``fileStream`` with the
        specified ``contentType`` as the Content-Type.
    
        
        
        
        :param fileStream: The  with the contents of the file.
        
        :type fileStream: System.IO.Stream
        
        
        :param contentType: The Content-Type of the file.
        
        :type contentType: System.String
        :rtype: Microsoft.AspNet.Mvc.FileStreamResult
        :return: The created <see cref="T:Microsoft.AspNet.Mvc.FileStreamResult" /> for the response.
    
        
        .. code-block:: csharp
    
           public virtual FileStreamResult File(Stream fileStream, string contentType)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Controller.File(System.IO.Stream, System.String, System.String)
    
        
    
        Returns a file in the specified ``fileStream`` with the
        specified ``contentType`` as the Content-Type and the
        specified ``fileDownloadName`` as the suggested file name.
    
        
        
        
        :param fileStream: The  with the contents of the file.
        
        :type fileStream: System.IO.Stream
        
        
        :param contentType: The Content-Type of the file.
        
        :type contentType: System.String
        
        
        :param fileDownloadName: The suggested file name.
        
        :type fileDownloadName: System.String
        :rtype: Microsoft.AspNet.Mvc.FileStreamResult
        :return: The created <see cref="T:Microsoft.AspNet.Mvc.FileStreamResult" /> for the response.
    
        
        .. code-block:: csharp
    
           public virtual FileStreamResult File(Stream fileStream, string contentType, string fileDownloadName)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Controller.File(System.String, System.String)
    
        
    
        Returns the file specified by ``virtualPath`` with the
        specified ``contentType`` as the Content-Type.
    
        
        
        
        :param virtualPath: The virtual path of the file to be returned.
        
        :type virtualPath: System.String
        
        
        :param contentType: The Content-Type of the file.
        
        :type contentType: System.String
        :rtype: Microsoft.AspNet.Mvc.VirtualFileResult
        :return: The created <see cref="T:Microsoft.AspNet.Mvc.VirtualFileResult" /> for the response.
    
        
        .. code-block:: csharp
    
           public virtual VirtualFileResult File(string virtualPath, string contentType)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Controller.File(System.String, System.String, System.String)
    
        
    
        Returns the file specified by ``virtualPath`` with the
        specified ``contentType`` as the Content-Type and the
        specified ``fileDownloadName`` as the suggested file name.
    
        
        
        
        :param virtualPath: The virtual path of the file to be returned.
        
        :type virtualPath: System.String
        
        
        :param contentType: The Content-Type of the file.
        
        :type contentType: System.String
        
        
        :param fileDownloadName: The suggested file name.
        
        :type fileDownloadName: System.String
        :rtype: Microsoft.AspNet.Mvc.VirtualFileResult
        :return: The created <see cref="T:Microsoft.AspNet.Mvc.VirtualFileResult" /> for the response.
    
        
        .. code-block:: csharp
    
           public virtual VirtualFileResult File(string virtualPath, string contentType, string fileDownloadName)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Controller.HttpBadRequest()
    
        
    
        Creates an :any:`Microsoft.AspNet.Mvc.BadRequestResult` that produces a Bad Request (400) response.
    
        
        :rtype: Microsoft.AspNet.Mvc.BadRequestResult
        :return: The created <see cref="T:Microsoft.AspNet.Mvc.BadRequestResult" /> for the response.
    
        
        .. code-block:: csharp
    
           public virtual BadRequestResult HttpBadRequest()
    
    .. dn:method:: Microsoft.AspNet.Mvc.Controller.HttpBadRequest(Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary)
    
        
    
        Creates an :any:`Microsoft.AspNet.Mvc.BadRequestObjectResult` that produces a Bad Request (400) response.
    
        
        
        
        :type modelState: Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary
        :rtype: Microsoft.AspNet.Mvc.BadRequestObjectResult
        :return: The created <see cref="T:Microsoft.AspNet.Mvc.BadRequestObjectResult" /> for the response.
    
        
        .. code-block:: csharp
    
           public virtual BadRequestObjectResult HttpBadRequest(ModelStateDictionary modelState)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Controller.HttpBadRequest(System.Object)
    
        
    
        Creates an :any:`Microsoft.AspNet.Mvc.BadRequestObjectResult` that produces a Bad Request (400) response.
    
        
        
        
        :type error: System.Object
        :rtype: Microsoft.AspNet.Mvc.BadRequestObjectResult
        :return: The created <see cref="T:Microsoft.AspNet.Mvc.BadRequestObjectResult" /> for the response.
    
        
        .. code-block:: csharp
    
           public virtual BadRequestObjectResult HttpBadRequest(object error)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Controller.HttpNotFound()
    
        
    
        Creates an :any:`Microsoft.AspNet.Mvc.HttpNotFoundResult` that produces a Not Found (404) response.
    
        
        :rtype: Microsoft.AspNet.Mvc.HttpNotFoundResult
        :return: The created <see cref="T:Microsoft.AspNet.Mvc.HttpNotFoundResult" /> for the response.
    
        
        .. code-block:: csharp
    
           public virtual HttpNotFoundResult HttpNotFound()
    
    .. dn:method:: Microsoft.AspNet.Mvc.Controller.HttpNotFound(System.Object)
    
        
    
        Creates an :any:`Microsoft.AspNet.Mvc.HttpNotFoundObjectResult` that produces a Not Found (404) response.
    
        
        
        
        :type value: System.Object
        :rtype: Microsoft.AspNet.Mvc.HttpNotFoundObjectResult
        :return: The created <see cref="T:Microsoft.AspNet.Mvc.HttpNotFoundObjectResult" /> for the response.
    
        
        .. code-block:: csharp
    
           public virtual HttpNotFoundObjectResult HttpNotFound(object value)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Controller.HttpUnauthorized()
    
        
    
        Creates an :any:`Microsoft.AspNet.Mvc.HttpUnauthorizedResult` that produces an Unauthorized (401) response.
    
        
        :rtype: Microsoft.AspNet.Mvc.HttpUnauthorizedResult
        :return: The created <see cref="T:Microsoft.AspNet.Mvc.HttpUnauthorizedResult" /> for the response.
    
        
        .. code-block:: csharp
    
           public virtual HttpUnauthorizedResult HttpUnauthorized()
    
    .. dn:method:: Microsoft.AspNet.Mvc.Controller.Json(System.Object)
    
        
    
        Creates a :any:`Microsoft.AspNet.Mvc.JsonResult` object that serializes the specified ``data`` object
        to JSON.
    
        
        
        
        :param data: The object to serialize.
        
        :type data: System.Object
        :rtype: Microsoft.AspNet.Mvc.JsonResult
        :return: The created <see cref="T:Microsoft.AspNet.Mvc.JsonResult" /> that serializes the specified <paramref name="data" />
            to JSON format for the response.
    
        
        .. code-block:: csharp
    
           public virtual JsonResult Json(object data)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Controller.Json(System.Object, Newtonsoft.Json.JsonSerializerSettings)
    
        
    
        Creates a :any:`Microsoft.AspNet.Mvc.JsonResult` object that serializes the specified ``data`` object
        to JSON.
    
        
        
        
        :param data: The object to serialize.
        
        :type data: System.Object
        
        
        :param serializerSettings: The  to be used by
            the formatter.
        
        :type serializerSettings: Newtonsoft.Json.JsonSerializerSettings
        :rtype: Microsoft.AspNet.Mvc.JsonResult
        :return: The created <see cref="T:Microsoft.AspNet.Mvc.JsonResult" /> that serializes the specified <paramref name="data" />
            as JSON format for the response.
    
        
        .. code-block:: csharp
    
           public virtual JsonResult Json(object data, JsonSerializerSettings serializerSettings)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Controller.LocalRedirect(System.String)
    
        
    
        Creates a :any:`Microsoft.AspNet.Mvc.LocalRedirectResult` object that redirects to
        the specified local ``localUrl``.
    
        
        
        
        :param localUrl: The local URL to redirect to.
        
        :type localUrl: System.String
        :rtype: Microsoft.AspNet.Mvc.LocalRedirectResult
        :return: The created <see cref="T:Microsoft.AspNet.Mvc.LocalRedirectResult" /> for the response.
    
        
        .. code-block:: csharp
    
           public virtual LocalRedirectResult LocalRedirect(string localUrl)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Controller.LocalRedirectPermanent(System.String)
    
        
    
        Creates a :any:`Microsoft.AspNet.Mvc.LocalRedirectResult` object with :dn:prop:`Microsoft.AspNet.Mvc.LocalRedirectResult.Permanent`
        set to true using the specified ``localUrl``.
    
        
        
        
        :param localUrl: The local URL to redirect to.
        
        :type localUrl: System.String
        :rtype: Microsoft.AspNet.Mvc.LocalRedirectResult
        :return: The created <see cref="T:Microsoft.AspNet.Mvc.LocalRedirectResult" /> for the response.
    
        
        .. code-block:: csharp
    
           public virtual LocalRedirectResult LocalRedirectPermanent(string localUrl)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Controller.Ok()
    
        
    
        Creates a :any:`Microsoft.AspNet.Mvc.HttpOkResult` object that produces an empty OK (200) response.
    
        
        :rtype: Microsoft.AspNet.Mvc.HttpOkResult
        :return: The created <see cref="T:Microsoft.AspNet.Mvc.HttpOkResult" /> for the response.
    
        
        .. code-block:: csharp
    
           public virtual HttpOkResult Ok()
    
    .. dn:method:: Microsoft.AspNet.Mvc.Controller.Ok(System.Object)
    
        
    
        Creates an :any:`Microsoft.AspNet.Mvc.HttpOkObjectResult` object that produces an OK (200) response.
    
        
        
        
        :param value: The content value to format in the entity body.
        
        :type value: System.Object
        :rtype: Microsoft.AspNet.Mvc.HttpOkObjectResult
        :return: The created <see cref="T:Microsoft.AspNet.Mvc.HttpOkObjectResult" /> for the response.
    
        
        .. code-block:: csharp
    
           public virtual HttpOkObjectResult Ok(object value)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Controller.OnActionExecuted(Microsoft.AspNet.Mvc.Filters.ActionExecutedContext)
    
        
    
        Called after the action method is invoked.
    
        
        
        
        :param context: The action executed context.
        
        :type context: Microsoft.AspNet.Mvc.Filters.ActionExecutedContext
    
        
        .. code-block:: csharp
    
           public virtual void OnActionExecuted(ActionExecutedContext context)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Controller.OnActionExecuting(Microsoft.AspNet.Mvc.Filters.ActionExecutingContext)
    
        
    
        Called before the action method is invoked.
    
        
        
        
        :param context: The action executing context.
        
        :type context: Microsoft.AspNet.Mvc.Filters.ActionExecutingContext
    
        
        .. code-block:: csharp
    
           public virtual void OnActionExecuting(ActionExecutingContext context)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Controller.OnActionExecutionAsync(Microsoft.AspNet.Mvc.Filters.ActionExecutingContext, Microsoft.AspNet.Mvc.Filters.ActionExecutionDelegate)
    
        
    
        Called before the action method is invoked.
    
        
        
        
        :param context: The action executing context.
        
        :type context: Microsoft.AspNet.Mvc.Filters.ActionExecutingContext
        
        
        :param next: The  to execute. Invoke this delegate in the body
            of  to continue execution of the action.
        
        :type next: Microsoft.AspNet.Mvc.Filters.ActionExecutionDelegate
        :rtype: System.Threading.Tasks.Task
        :return: A <see cref="T:System.Threading.Tasks.Task" /> instance.
    
        
        .. code-block:: csharp
    
           public virtual Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Controller.PartialView()
    
        
    
        Creates a :any:`Microsoft.AspNet.Mvc.PartialViewResult` object that renders a partial view to the response.
    
        
        :rtype: Microsoft.AspNet.Mvc.PartialViewResult
        :return: The created <see cref="T:Microsoft.AspNet.Mvc.PartialViewResult" /> object for the response.
    
        
        .. code-block:: csharp
    
           public virtual PartialViewResult PartialView()
    
    .. dn:method:: Microsoft.AspNet.Mvc.Controller.PartialView(System.Object)
    
        
    
        Creates a :any:`Microsoft.AspNet.Mvc.PartialViewResult` object by specifying a ``model``
        to be rendered by the partial view.
    
        
        
        
        :param model: The model that is rendered by the partial view.
        
        :type model: System.Object
        :rtype: Microsoft.AspNet.Mvc.PartialViewResult
        :return: The created <see cref="T:Microsoft.AspNet.Mvc.PartialViewResult" /> object for the response.
    
        
        .. code-block:: csharp
    
           public virtual PartialViewResult PartialView(object model)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Controller.PartialView(System.String)
    
        
    
        Creates a :any:`Microsoft.AspNet.Mvc.PartialViewResult` object by specifying a ``viewName``.
    
        
        
        
        :param viewName: The name of the view that is rendered to the response.
        
        :type viewName: System.String
        :rtype: Microsoft.AspNet.Mvc.PartialViewResult
        :return: The created <see cref="T:Microsoft.AspNet.Mvc.PartialViewResult" /> object for the response.
    
        
        .. code-block:: csharp
    
           public virtual PartialViewResult PartialView(string viewName)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Controller.PartialView(System.String, System.Object)
    
        
    
        Creates a :any:`Microsoft.AspNet.Mvc.PartialViewResult` object by specifying a ``viewName``
        and the ``model`` to be rendered by the partial view.
    
        
        
        
        :param viewName: The name of the partial view that is rendered to the response.
        
        :type viewName: System.String
        
        
        :param model: The model that is rendered by the partial view.
        
        :type model: System.Object
        :rtype: Microsoft.AspNet.Mvc.PartialViewResult
        :return: The created <see cref="T:Microsoft.AspNet.Mvc.PartialViewResult" /> object for the response.
    
        
        .. code-block:: csharp
    
           public virtual PartialViewResult PartialView(string viewName, object model)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Controller.PhysicalFile(System.String, System.String)
    
        
    
        Returns the file specified by ``physicalPath`` with the
        specified ``contentType`` as the Content-Type.
    
        
        
        
        :param physicalPath: The physical path of the file to be returned.
        
        :type physicalPath: System.String
        
        
        :param contentType: The Content-Type of the file.
        
        :type contentType: System.String
        :rtype: Microsoft.AspNet.Mvc.PhysicalFileResult
        :return: The created <see cref="T:Microsoft.AspNet.Mvc.PhysicalFileResult" /> for the response.
    
        
        .. code-block:: csharp
    
           public virtual PhysicalFileResult PhysicalFile(string physicalPath, string contentType)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Controller.PhysicalFile(System.String, System.String, System.String)
    
        
    
        Returns the file specified by ``physicalPath`` with the
        specified ``contentType`` as the Content-Type and the
        specified ``fileDownloadName`` as the suggested file name.
    
        
        
        
        :param physicalPath: The physical path of the file to be returned.
        
        :type physicalPath: System.String
        
        
        :param contentType: The Content-Type of the file.
        
        :type contentType: System.String
        
        
        :param fileDownloadName: The suggested file name.
        
        :type fileDownloadName: System.String
        :rtype: Microsoft.AspNet.Mvc.PhysicalFileResult
        :return: The created <see cref="T:Microsoft.AspNet.Mvc.PhysicalFileResult" /> for the response.
    
        
        .. code-block:: csharp
    
           public virtual PhysicalFileResult PhysicalFile(string physicalPath, string contentType, string fileDownloadName)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Controller.Redirect(System.String)
    
        
    
        Creates a :any:`Microsoft.AspNet.Mvc.RedirectResult` object that redirects to the specified ``url``.
    
        
        
        
        :param url: The URL to redirect to.
        
        :type url: System.String
        :rtype: Microsoft.AspNet.Mvc.RedirectResult
        :return: The created <see cref="T:Microsoft.AspNet.Mvc.RedirectResult" /> for the response.
    
        
        .. code-block:: csharp
    
           public virtual RedirectResult Redirect(string url)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Controller.RedirectPermanent(System.String)
    
        
    
        Creates a :any:`Microsoft.AspNet.Mvc.RedirectResult` object with :dn:prop:`Microsoft.AspNet.Mvc.RedirectResult.Permanent` set to true
        using the specified ``url``.
    
        
        
        
        :param url: The URL to redirect to.
        
        :type url: System.String
        :rtype: Microsoft.AspNet.Mvc.RedirectResult
        :return: The created <see cref="T:Microsoft.AspNet.Mvc.RedirectResult" /> for the response.
    
        
        .. code-block:: csharp
    
           public virtual RedirectResult RedirectPermanent(string url)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Controller.RedirectToAction(System.String)
    
        
    
        Redirects to the specified action using the ``actionName``.
    
        
        
        
        :param actionName: The name of the action.
        
        :type actionName: System.String
        :rtype: Microsoft.AspNet.Mvc.RedirectToActionResult
        :return: The created <see cref="T:Microsoft.AspNet.Mvc.RedirectToActionResult" /> for the response.
    
        
        .. code-block:: csharp
    
           public virtual RedirectToActionResult RedirectToAction(string actionName)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Controller.RedirectToAction(System.String, System.Object)
    
        
    
        Redirects to the specified action using the ``actionName``
        and ``routeValues``.
    
        
        
        
        :param actionName: The name of the action.
        
        :type actionName: System.String
        
        
        :param routeValues: The parameters for a route.
        
        :type routeValues: System.Object
        :rtype: Microsoft.AspNet.Mvc.RedirectToActionResult
        :return: The created <see cref="T:Microsoft.AspNet.Mvc.RedirectToActionResult" /> for the response.
    
        
        .. code-block:: csharp
    
           public virtual RedirectToActionResult RedirectToAction(string actionName, object routeValues)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Controller.RedirectToAction(System.String, System.String)
    
        
    
        Redirects to the specified action using the ``actionName``
        and the ``controllerName``.
    
        
        
        
        :param actionName: The name of the action.
        
        :type actionName: System.String
        
        
        :param controllerName: The name of the controller.
        
        :type controllerName: System.String
        :rtype: Microsoft.AspNet.Mvc.RedirectToActionResult
        :return: The created <see cref="T:Microsoft.AspNet.Mvc.RedirectToActionResult" /> for the response.
    
        
        .. code-block:: csharp
    
           public virtual RedirectToActionResult RedirectToAction(string actionName, string controllerName)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Controller.RedirectToAction(System.String, System.String, System.Object)
    
        
    
        Redirects to the specified action using the specified ``actionName``,
        ``controllerName``, and ``routeValues``.
    
        
        
        
        :param actionName: The name of the action.
        
        :type actionName: System.String
        
        
        :param controllerName: The name of the controller.
        
        :type controllerName: System.String
        
        
        :param routeValues: The parameters for a route.
        
        :type routeValues: System.Object
        :rtype: Microsoft.AspNet.Mvc.RedirectToActionResult
        :return: The created <see cref="T:Microsoft.AspNet.Mvc.RedirectToActionResult" /> for the response.
    
        
        .. code-block:: csharp
    
           public virtual RedirectToActionResult RedirectToAction(string actionName, string controllerName, object routeValues)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Controller.RedirectToActionPermanent(System.String)
    
        
    
        Redirects to the specified action with :dn:prop:`Microsoft.AspNet.Mvc.RedirectToActionResult.Permanent` set to true
        using the specified ``actionName``.
    
        
        
        
        :param actionName: The name of the action.
        
        :type actionName: System.String
        :rtype: Microsoft.AspNet.Mvc.RedirectToActionResult
        :return: The created <see cref="T:Microsoft.AspNet.Mvc.RedirectToActionResult" /> for the response.
    
        
        .. code-block:: csharp
    
           public virtual RedirectToActionResult RedirectToActionPermanent(string actionName)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Controller.RedirectToActionPermanent(System.String, System.Object)
    
        
    
        Redirects to the specified action with :dn:prop:`Microsoft.AspNet.Mvc.RedirectToActionResult.Permanent` set to true
        using the specified ``actionName`` and ``routeValues``.
    
        
        
        
        :param actionName: The name of the action.
        
        :type actionName: System.String
        
        
        :param routeValues: The parameters for a route.
        
        :type routeValues: System.Object
        :rtype: Microsoft.AspNet.Mvc.RedirectToActionResult
        :return: The created <see cref="T:Microsoft.AspNet.Mvc.RedirectToActionResult" /> for the response.
    
        
        .. code-block:: csharp
    
           public virtual RedirectToActionResult RedirectToActionPermanent(string actionName, object routeValues)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Controller.RedirectToActionPermanent(System.String, System.String)
    
        
    
        Redirects to the specified action with :dn:prop:`Microsoft.AspNet.Mvc.RedirectToActionResult.Permanent` set to true
        using the specified ``actionName`` and ``controllerName``.
    
        
        
        
        :param actionName: The name of the action.
        
        :type actionName: System.String
        
        
        :param controllerName: The name of the controller.
        
        :type controllerName: System.String
        :rtype: Microsoft.AspNet.Mvc.RedirectToActionResult
        :return: The created <see cref="T:Microsoft.AspNet.Mvc.RedirectToActionResult" /> for the response.
    
        
        .. code-block:: csharp
    
           public virtual RedirectToActionResult RedirectToActionPermanent(string actionName, string controllerName)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Controller.RedirectToActionPermanent(System.String, System.String, System.Object)
    
        
    
        Redirects to the specified action with :dn:prop:`Microsoft.AspNet.Mvc.RedirectToActionResult.Permanent` set to true
        using the specified ``actionName``, ``controllerName``,
        and ``routeValues``.
    
        
        
        
        :param actionName: The name of the action.
        
        :type actionName: System.String
        
        
        :param controllerName: The name of the controller.
        
        :type controllerName: System.String
        
        
        :param routeValues: The parameters for a route.
        
        :type routeValues: System.Object
        :rtype: Microsoft.AspNet.Mvc.RedirectToActionResult
        :return: The created <see cref="T:Microsoft.AspNet.Mvc.RedirectToActionResult" /> for the response.
    
        
        .. code-block:: csharp
    
           public virtual RedirectToActionResult RedirectToActionPermanent(string actionName, string controllerName, object routeValues)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Controller.RedirectToRoute(System.Object)
    
        
    
        Redirects to the specified route using the specified ``routeValues``.
    
        
        
        
        :param routeValues: The parameters for a route.
        
        :type routeValues: System.Object
        :rtype: Microsoft.AspNet.Mvc.RedirectToRouteResult
        :return: The created <see cref="T:Microsoft.AspNet.Mvc.RedirectToRouteResult" /> for the response.
    
        
        .. code-block:: csharp
    
           public virtual RedirectToRouteResult RedirectToRoute(object routeValues)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Controller.RedirectToRoute(System.String)
    
        
    
        Redirects to the specified route using the specified ``routeName``.
    
        
        
        
        :param routeName: The name of the route.
        
        :type routeName: System.String
        :rtype: Microsoft.AspNet.Mvc.RedirectToRouteResult
        :return: The created <see cref="T:Microsoft.AspNet.Mvc.RedirectToRouteResult" /> for the response.
    
        
        .. code-block:: csharp
    
           public virtual RedirectToRouteResult RedirectToRoute(string routeName)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Controller.RedirectToRoute(System.String, System.Object)
    
        
    
        Redirects to the specified route using the specified ``routeName``
        and ``routeValues``.
    
        
        
        
        :param routeName: The name of the route.
        
        :type routeName: System.String
        
        
        :param routeValues: The parameters for a route.
        
        :type routeValues: System.Object
        :rtype: Microsoft.AspNet.Mvc.RedirectToRouteResult
        :return: The created <see cref="T:Microsoft.AspNet.Mvc.RedirectToRouteResult" /> for the response.
    
        
        .. code-block:: csharp
    
           public virtual RedirectToRouteResult RedirectToRoute(string routeName, object routeValues)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Controller.RedirectToRoutePermanent(System.Object)
    
        
    
        Redirects to the specified route with :dn:prop:`Microsoft.AspNet.Mvc.RedirectToRouteResult.Permanent` set to true
        using the specified ``routeValues``.
    
        
        
        
        :param routeValues: The parameters for a route.
        
        :type routeValues: System.Object
        :rtype: Microsoft.AspNet.Mvc.RedirectToRouteResult
        :return: The created <see cref="T:Microsoft.AspNet.Mvc.RedirectToRouteResult" /> for the response.
    
        
        .. code-block:: csharp
    
           public virtual RedirectToRouteResult RedirectToRoutePermanent(object routeValues)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Controller.RedirectToRoutePermanent(System.String)
    
        
    
        Redirects to the specified route with :dn:prop:`Microsoft.AspNet.Mvc.RedirectToRouteResult.Permanent` set to true
        using the specified ``routeName``.
    
        
        
        
        :param routeName: The name of the route.
        
        :type routeName: System.String
        :rtype: Microsoft.AspNet.Mvc.RedirectToRouteResult
        :return: The created <see cref="T:Microsoft.AspNet.Mvc.RedirectToRouteResult" /> for the response.
    
        
        .. code-block:: csharp
    
           public virtual RedirectToRouteResult RedirectToRoutePermanent(string routeName)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Controller.RedirectToRoutePermanent(System.String, System.Object)
    
        
    
        Redirects to the specified route with :dn:prop:`Microsoft.AspNet.Mvc.RedirectToRouteResult.Permanent` set to true
        using the specified ``routeName`` and ``routeValues``.
    
        
        
        
        :param routeName: The name of the route.
        
        :type routeName: System.String
        
        
        :param routeValues: The parameters for a route.
        
        :type routeValues: System.Object
        :rtype: Microsoft.AspNet.Mvc.RedirectToRouteResult
        :return: The created <see cref="T:Microsoft.AspNet.Mvc.RedirectToRouteResult" /> for the response.
    
        
        .. code-block:: csharp
    
           public virtual RedirectToRouteResult RedirectToRoutePermanent(string routeName, object routeValues)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Controller.TryUpdateModelAsync(System.Object, System.Type, System.String)
    
        
    
        Updates the specified ``model`` instance using values from the controller's current 
        :any:`Microsoft.AspNet.Mvc.ModelBinding.IValueProvider` and a ``prefix``.
    
        
        
        
        :param model: The model instance to update.
        
        :type model: System.Object
        
        
        :param modelType: The type of model instance to update.
        
        :type modelType: System.Type
        
        
        :param prefix: The prefix to use when looking up values in the current .
        
        :type prefix: System.String
        :rtype: System.Threading.Tasks.Task{System.Boolean}
        :return: A <see cref="T:System.Threading.Tasks.Task" /> that on completion returns <c>true</c> if the update is successful.
    
        
        .. code-block:: csharp
    
           public virtual Task<bool> TryUpdateModelAsync(object model, Type modelType, string prefix)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Controller.TryUpdateModelAsync(System.Object, System.Type, System.String, Microsoft.AspNet.Mvc.ModelBinding.IValueProvider, System.Func<Microsoft.AspNet.Mvc.ModelBinding.ModelBindingContext, System.String, System.Boolean>)
    
        
    
        Updates the specified ``model`` instance using the ``valueProvider`` and a
        ``prefix``.
    
        
        
        
        :param model: The model instance to update.
        
        :type model: System.Object
        
        
        :param modelType: The type of model instance to update.
        
        :type modelType: System.Type
        
        
        :param prefix: The prefix to use when looking up values in the .
        
        :type prefix: System.String
        
        
        :param valueProvider: The  used for looking up values.
        
        :type valueProvider: Microsoft.AspNet.Mvc.ModelBinding.IValueProvider
        
        
        :param predicate: A predicate which can be used to filter properties at runtime.
        
        :type predicate: System.Func{Microsoft.AspNet.Mvc.ModelBinding.ModelBindingContext,System.String,System.Boolean}
        :rtype: System.Threading.Tasks.Task{System.Boolean}
        :return: A <see cref="T:System.Threading.Tasks.Task" /> that on completion returns <c>true</c> if the update is successful.
    
        
        .. code-block:: csharp
    
           public Task<bool> TryUpdateModelAsync(object model, Type modelType, string prefix, IValueProvider valueProvider, Func<ModelBindingContext, string, bool> predicate)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Controller.TryUpdateModelAsync<TModel>(TModel)
    
        
    
        Updates the specified ``model`` instance using values from the controller's current 
        :any:`Microsoft.AspNet.Mvc.ModelBinding.IValueProvider`\.
    
        
        
        
        :param model: The model instance to update.
        
        :type model: {TModel}
        :rtype: System.Threading.Tasks.Task{System.Boolean}
        :return: A <see cref="T:System.Threading.Tasks.Task" /> that on completion returns <c>true</c> if the update is successful.
    
        
        .. code-block:: csharp
    
           public virtual Task<bool> TryUpdateModelAsync<TModel>(TModel model)where TModel : class
    
    .. dn:method:: Microsoft.AspNet.Mvc.Controller.TryUpdateModelAsync<TModel>(TModel, System.String)
    
        
    
        Updates the specified ``model`` instance using values from the controller's current 
        :any:`Microsoft.AspNet.Mvc.ModelBinding.IValueProvider` and a ``prefix``.
    
        
        
        
        :param model: The model instance to update.
        
        :type model: {TModel}
        
        
        :param prefix: The prefix to use when looking up values in the current .
        
        :type prefix: System.String
        :rtype: System.Threading.Tasks.Task{System.Boolean}
        :return: A <see cref="T:System.Threading.Tasks.Task" /> that on completion returns <c>true</c> if the update is successful.
    
        
        .. code-block:: csharp
    
           public virtual Task<bool> TryUpdateModelAsync<TModel>(TModel model, string prefix)where TModel : class
    
    .. dn:method:: Microsoft.AspNet.Mvc.Controller.TryUpdateModelAsync<TModel>(TModel, System.String, Microsoft.AspNet.Mvc.ModelBinding.IValueProvider)
    
        
    
        Updates the specified ``model`` instance using the ``valueProvider`` and a
        ``prefix``.
    
        
        
        
        :param model: The model instance to update.
        
        :type model: {TModel}
        
        
        :param prefix: The prefix to use when looking up values in the .
        
        :type prefix: System.String
        
        
        :param valueProvider: The  used for looking up values.
        
        :type valueProvider: Microsoft.AspNet.Mvc.ModelBinding.IValueProvider
        :rtype: System.Threading.Tasks.Task{System.Boolean}
        :return: A <see cref="T:System.Threading.Tasks.Task" /> that on completion returns <c>true</c> if the update is successful.
    
        
        .. code-block:: csharp
    
           public virtual Task<bool> TryUpdateModelAsync<TModel>(TModel model, string prefix, IValueProvider valueProvider)where TModel : class
    
    .. dn:method:: Microsoft.AspNet.Mvc.Controller.TryUpdateModelAsync<TModel>(TModel, System.String, Microsoft.AspNet.Mvc.ModelBinding.IValueProvider, System.Func<Microsoft.AspNet.Mvc.ModelBinding.ModelBindingContext, System.String, System.Boolean>)
    
        
    
        Updates the specified ``model`` instance using the ``valueProvider`` and a
        ``prefix``.
    
        
        
        
        :param model: The model instance to update.
        
        :type model: {TModel}
        
        
        :param prefix: The prefix to use when looking up values in the .
        
        :type prefix: System.String
        
        
        :param valueProvider: The  used for looking up values.
        
        :type valueProvider: Microsoft.AspNet.Mvc.ModelBinding.IValueProvider
        
        
        :param predicate: A predicate which can be used to filter properties at runtime.
        
        :type predicate: System.Func{Microsoft.AspNet.Mvc.ModelBinding.ModelBindingContext,System.String,System.Boolean}
        :rtype: System.Threading.Tasks.Task{System.Boolean}
        :return: A <see cref="T:System.Threading.Tasks.Task" /> that on completion returns <c>true</c> if the update is successful.
    
        
        .. code-block:: csharp
    
           public Task<bool> TryUpdateModelAsync<TModel>(TModel model, string prefix, IValueProvider valueProvider, Func<ModelBindingContext, string, bool> predicate)where TModel : class
    
    .. dn:method:: Microsoft.AspNet.Mvc.Controller.TryUpdateModelAsync<TModel>(TModel, System.String, Microsoft.AspNet.Mvc.ModelBinding.IValueProvider, System.Linq.Expressions.Expression<System.Func<TModel, System.Object>>[])
    
        
    
        Updates the specified ``model`` instance using the ``valueProvider`` and a
        ``prefix``.
    
        
        
        
        :param model: The model instance to update.
        
        :type model: {TModel}
        
        
        :param prefix: The prefix to use when looking up values in the .
        
        :type prefix: System.String
        
        
        :param valueProvider: The  used for looking up values.
        
        :type valueProvider: Microsoft.AspNet.Mvc.ModelBinding.IValueProvider
        
        
        :param includeExpressions: (s) which represent top-level properties
            which need to be included for the current model.
        
        :type includeExpressions: System.Linq.Expressions.Expression{System.Func{{TModel},System.Object}}[]
        :rtype: System.Threading.Tasks.Task{System.Boolean}
        :return: A <see cref="T:System.Threading.Tasks.Task" /> that on completion returns <c>true</c> if the update is successful.
    
        
        .. code-block:: csharp
    
           public Task<bool> TryUpdateModelAsync<TModel>(TModel model, string prefix, IValueProvider valueProvider, params Expression<Func<TModel, object>>[] includeExpressions)where TModel : class
    
    .. dn:method:: Microsoft.AspNet.Mvc.Controller.TryUpdateModelAsync<TModel>(TModel, System.String, System.Func<Microsoft.AspNet.Mvc.ModelBinding.ModelBindingContext, System.String, System.Boolean>)
    
        
    
        Updates the specified ``model`` instance using values from the controller's current 
        :any:`Microsoft.AspNet.Mvc.ModelBinding.IValueProvider` and a ``prefix``.
    
        
        
        
        :param model: The model instance to update.
        
        :type model: {TModel}
        
        
        :param prefix: The prefix to use when looking up values in the current .
        
        :type prefix: System.String
        
        
        :param predicate: A predicate which can be used to filter properties at runtime.
        
        :type predicate: System.Func{Microsoft.AspNet.Mvc.ModelBinding.ModelBindingContext,System.String,System.Boolean}
        :rtype: System.Threading.Tasks.Task{System.Boolean}
        :return: A <see cref="T:System.Threading.Tasks.Task" /> that on completion returns <c>true</c> if the update is successful.
    
        
        .. code-block:: csharp
    
           public Task<bool> TryUpdateModelAsync<TModel>(TModel model, string prefix, Func<ModelBindingContext, string, bool> predicate)where TModel : class
    
    .. dn:method:: Microsoft.AspNet.Mvc.Controller.TryUpdateModelAsync<TModel>(TModel, System.String, System.Linq.Expressions.Expression<System.Func<TModel, System.Object>>[])
    
        
    
        Updates the specified ``model`` instance using values from the controller's current 
        :any:`Microsoft.AspNet.Mvc.ModelBinding.IValueProvider` and a ``prefix``.
    
        
        
        
        :param model: The model instance to update.
        
        :type model: {TModel}
        
        
        :param prefix: The prefix to use when looking up values in the current .
        
        :type prefix: System.String
        
        
        :param includeExpressions: (s) which represent top-level properties
            which need to be included for the current model.
        
        :type includeExpressions: System.Linq.Expressions.Expression{System.Func{{TModel},System.Object}}[]
        :rtype: System.Threading.Tasks.Task{System.Boolean}
        :return: A <see cref="T:System.Threading.Tasks.Task" /> that on completion returns <c>true</c> if the update is successful.
    
        
        .. code-block:: csharp
    
           public Task<bool> TryUpdateModelAsync<TModel>(TModel model, string prefix, params Expression<Func<TModel, object>>[] includeExpressions)where TModel : class
    
    .. dn:method:: Microsoft.AspNet.Mvc.Controller.TryValidateModel(System.Object)
    
        
    
        Validates the specified ``model`` instance.
    
        
        
        
        :param model: The model to validate.
        
        :type model: System.Object
        :rtype: System.Boolean
        :return: <c>true</c> if the <see cref="P:Microsoft.AspNet.Mvc.Controller.ModelState" /> is valid; <c>false</c> otherwise.
    
        
        .. code-block:: csharp
    
           public virtual bool TryValidateModel(object model)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Controller.TryValidateModel(System.Object, System.String)
    
        
    
        Validates the specified ``model`` instance.
    
        
        
        
        :param model: The model to validate.
        
        :type model: System.Object
        
        
        :param prefix: The key to use when looking up information in .
        
        :type prefix: System.String
        :rtype: System.Boolean
        :return: <c>true</c> if the <see cref="P:Microsoft.AspNet.Mvc.Controller.ModelState" /> is valid;<c>false</c> otherwise.
    
        
        .. code-block:: csharp
    
           public virtual bool TryValidateModel(object model, string prefix)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Controller.View()
    
        
    
        Creates a :any:`Microsoft.AspNet.Mvc.ViewResult` object that renders a view to the response.
    
        
        :rtype: Microsoft.AspNet.Mvc.ViewResult
        :return: The created <see cref="T:Microsoft.AspNet.Mvc.ViewResult" /> object for the response.
    
        
        .. code-block:: csharp
    
           public virtual ViewResult View()
    
    .. dn:method:: Microsoft.AspNet.Mvc.Controller.View(System.Object)
    
        
    
        Creates a :any:`Microsoft.AspNet.Mvc.ViewResult` object by specifying a ``model``
        to be rendered by the view.
    
        
        
        
        :param model: The model that is rendered by the view.
        
        :type model: System.Object
        :rtype: Microsoft.AspNet.Mvc.ViewResult
        :return: The created <see cref="T:Microsoft.AspNet.Mvc.ViewResult" /> object for the response.
    
        
        .. code-block:: csharp
    
           public virtual ViewResult View(object model)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Controller.View(System.String)
    
        
    
        Creates a :any:`Microsoft.AspNet.Mvc.ViewResult` object by specifying a ``viewName``.
    
        
        
        
        :param viewName: The name of the view that is rendered to the response.
        
        :type viewName: System.String
        :rtype: Microsoft.AspNet.Mvc.ViewResult
        :return: The created <see cref="T:Microsoft.AspNet.Mvc.ViewResult" /> object for the response.
    
        
        .. code-block:: csharp
    
           public virtual ViewResult View(string viewName)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Controller.View(System.String, System.Object)
    
        
    
        Creates a :any:`Microsoft.AspNet.Mvc.ViewResult` object by specifying a ``viewName``
        and the ``model`` to be rendered by the view.
    
        
        
        
        :param viewName: The name of the view that is rendered to the response.
        
        :type viewName: System.String
        
        
        :param model: The model that is rendered by the view.
        
        :type model: System.Object
        :rtype: Microsoft.AspNet.Mvc.ViewResult
        :return: The created <see cref="T:Microsoft.AspNet.Mvc.ViewResult" /> object for the response.
    
        
        .. code-block:: csharp
    
           public virtual ViewResult View(string viewName, object model)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Controller.ViewComponent(System.String, System.Object[])
    
        
    
        Creates a :any:`Microsoft.AspNet.Mvc.ViewComponentResult` by specifying the name of a view component to render.
    
        
        
        
        :param componentName: The view component name. Can be a view component
            or
            .
        
        :type componentName: System.String
        
        
        :param arguments: The arguments to pass to the view component.
        
        :type arguments: System.Object[]
        :rtype: Microsoft.AspNet.Mvc.ViewComponentResult
        :return: The created <see cref="T:Microsoft.AspNet.Mvc.ViewComponentResult" /> object for the response.
    
        
        .. code-block:: csharp
    
           public virtual ViewComponentResult ViewComponent(string componentName, params object[] arguments)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Controller.ViewComponent(System.Type, System.Object[])
    
        
    
        Creates a :any:`Microsoft.AspNet.Mvc.ViewComponentResult` by specifying the :any:`System.Type` of a view component to
        render.
    
        
        
        
        :param componentType: The view component .
        
        :type componentType: System.Type
        
        
        :param arguments: The arguments to pass to the view component.
        
        :type arguments: System.Object[]
        :rtype: Microsoft.AspNet.Mvc.ViewComponentResult
        :return: The created <see cref="T:Microsoft.AspNet.Mvc.ViewComponentResult" /> object for the response.
    
        
        .. code-block:: csharp
    
           public virtual ViewComponentResult ViewComponent(Type componentType, params object[] arguments)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.Controller
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Controller.ActionContext
    
        
    
        Gets or sets the :any:`Microsoft.AspNet.Mvc.ActionContext` object.
    
        
        :rtype: Microsoft.AspNet.Mvc.ActionContext
    
        
        .. code-block:: csharp
    
           public ActionContext ActionContext { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Controller.BindingContext
    
        
    
        Gets or sets the :any:`Microsoft.AspNet.Mvc.ActionBindingContext`\.
    
        
        :rtype: Microsoft.AspNet.Mvc.ActionBindingContext
    
        
        .. code-block:: csharp
    
           public ActionBindingContext BindingContext { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Controller.HttpContext
    
        
    
        Gets the :any:`Microsoft.AspNet.Http.HttpContext` for the executing action.
    
        
        :rtype: Microsoft.AspNet.Http.HttpContext
    
        
        .. code-block:: csharp
    
           public HttpContext HttpContext { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Controller.MetadataProvider
    
        
    
        Gets or sets the :any:`Microsoft.AspNet.Mvc.ModelBinding.IModelMetadataProvider`\.
    
        
        :rtype: Microsoft.AspNet.Mvc.ModelBinding.IModelMetadataProvider
    
        
        .. code-block:: csharp
    
           public IModelMetadataProvider MetadataProvider { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Controller.ModelState
    
        
    
        Gets the :any:`Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary` that contains the state of the model and of model-binding validation.
    
        
        :rtype: Microsoft.AspNet.Mvc.ModelBinding.ModelStateDictionary
    
        
        .. code-block:: csharp
    
           public ModelStateDictionary ModelState { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Controller.ObjectValidator
    
        
    
        Gets or sets the :any:`Microsoft.AspNet.Mvc.ModelBinding.Validation.IObjectModelValidator`\.
    
        
        :rtype: Microsoft.AspNet.Mvc.ModelBinding.Validation.IObjectModelValidator
    
        
        .. code-block:: csharp
    
           public IObjectModelValidator ObjectValidator { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Controller.Request
    
        
    
        Gets the :any:`Microsoft.AspNet.Http.HttpRequest` for the executing action.
    
        
        :rtype: Microsoft.AspNet.Http.HttpRequest
    
        
        .. code-block:: csharp
    
           public HttpRequest Request { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Controller.Resolver
    
        
    
        Gets the request-specific :any:`System.IServiceProvider`\.
    
        
        :rtype: System.IServiceProvider
    
        
        .. code-block:: csharp
    
           public IServiceProvider Resolver { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Controller.Response
    
        
    
        Gets the :any:`Microsoft.AspNet.Http.HttpResponse` for the executing action.
    
        
        :rtype: Microsoft.AspNet.Http.HttpResponse
    
        
        .. code-block:: csharp
    
           public HttpResponse Response { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Controller.RouteData
    
        
    
        Gets the :any:`Microsoft.AspNet.Routing.RouteData` for the executing action.
    
        
        :rtype: Microsoft.AspNet.Routing.RouteData
    
        
        .. code-block:: csharp
    
           public RouteData RouteData { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Controller.TempData
    
        
    
        Gets or sets :any:`Microsoft.AspNet.Mvc.ViewFeatures.ITempDataDictionary` used by :any:`Microsoft.AspNet.Mvc.ViewResult`\.
    
        
        :rtype: Microsoft.AspNet.Mvc.ViewFeatures.ITempDataDictionary
    
        
        .. code-block:: csharp
    
           public ITempDataDictionary TempData { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Controller.Url
    
        
    
        Gets or sets the :any:`Microsoft.AspNet.Mvc.IUrlHelper`\.
    
        
        :rtype: Microsoft.AspNet.Mvc.IUrlHelper
    
        
        .. code-block:: csharp
    
           public IUrlHelper Url { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Controller.User
    
        
    
        Gets or sets the :any:`System.Security.Claims.ClaimsPrincipal` for user associated with the executing action.
    
        
        :rtype: System.Security.Claims.ClaimsPrincipal
    
        
        .. code-block:: csharp
    
           public ClaimsPrincipal User { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Controller.ViewBag
    
        
    
        Gets the dynamic view bag.
    
        
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
           public dynamic ViewBag { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Controller.ViewData
    
        
    
        Gets or sets :any:`Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary` used by :any:`Microsoft.AspNet.Mvc.ViewResult` and :dn:prop:`Microsoft.AspNet.Mvc.Controller.ViewBag`\.
    
        
        :rtype: Microsoft.AspNet.Mvc.ViewFeatures.ViewDataDictionary
    
        
        .. code-block:: csharp
    
           public ViewDataDictionary ViewData { get; set; }
    

