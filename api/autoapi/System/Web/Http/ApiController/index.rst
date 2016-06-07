

ApiController Class
===================





Namespace
    :dn:ns:`System.Web.Http`
Assemblies
    * Microsoft.AspNetCore.Mvc.WebApiCompatShim

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.Web.Http.ApiController`








Syntax
------

.. code-block:: csharp

    public abstract class ApiController : IDisposable








.. dn:class:: System.Web.Http.ApiController
    :hidden:

.. dn:class:: System.Web.Http.ApiController

Properties
----------

.. dn:class:: System.Web.Http.ApiController
    :noindex:
    :hidden:

    
    .. dn:property:: System.Web.Http.ApiController.ActionContext
    
        
    
        
        Gets the :any:`Microsoft.AspNetCore.Mvc.ActionContext`\.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ActionContext
    
        
        .. code-block:: csharp
    
            public ActionContext ActionContext
            {
                get;
            }
    
    .. dn:property:: System.Web.Http.ApiController.Context
    
        
    
        
        Gets the http context.
    
        
        :rtype: Microsoft.AspNetCore.Http.HttpContext
    
        
        .. code-block:: csharp
    
            public HttpContext Context
            {
                get;
            }
    
    .. dn:property:: System.Web.Http.ApiController.ControllerContext
    
        
    
        
        Gets or sets the :dn:prop:`System.Web.Http.ApiController.ControllerContext`\.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ControllerContext
    
        
        .. code-block:: csharp
    
            public ControllerContext ControllerContext
            {
                get;
                set;
            }
    
    .. dn:property:: System.Web.Http.ApiController.MetadataProvider
    
        
    
        
        Gets the :any:`Microsoft.AspNetCore.Mvc.ModelBinding.IModelMetadataProvider`\.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.IModelMetadataProvider
    
        
        .. code-block:: csharp
    
            public IModelMetadataProvider MetadataProvider
            {
                get;
                set;
            }
    
    .. dn:property:: System.Web.Http.ApiController.ModelState
    
        
    
        
        Gets model state after the model binding process. This ModelState will be empty before model binding
        happens.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary
    
        
        .. code-block:: csharp
    
            public ModelStateDictionary ModelState
            {
                get;
            }
    
    .. dn:property:: System.Web.Http.ApiController.ObjectValidator
    
        
    
        
        Gets or sets the :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IObjectModelValidator`\.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IObjectModelValidator
    
        
        .. code-block:: csharp
    
            public IObjectModelValidator ObjectValidator
            {
                get;
                set;
            }
    
    .. dn:property:: System.Web.Http.ApiController.Request
    
        
    
        
        Gets or sets the HTTP request message.
    
        
        :rtype: System.Net.Http.HttpRequestMessage
    
        
        .. code-block:: csharp
    
            public HttpRequestMessage Request
            {
                get;
                set;
            }
    
    .. dn:property:: System.Web.Http.ApiController.Url
    
        
    
        
        Gets a factory used to generate URLs to other APIs.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.IUrlHelper
    
        
        .. code-block:: csharp
    
            public IUrlHelper Url
            {
                get;
                set;
            }
    
    .. dn:property:: System.Web.Http.ApiController.User
    
        
    
        
        Gets or sets the current principal associated with this request.
    
        
        :rtype: System.Security.Principal.IPrincipal
    
        
        .. code-block:: csharp
    
            public IPrincipal User
            {
                get;
            }
    

Methods
-------

.. dn:class:: System.Web.Http.ApiController
    :noindex:
    :hidden:

    
    .. dn:method:: System.Web.Http.ApiController.BadRequest()
    
        
    
        
        Creates a :any:`Microsoft.AspNetCore.Mvc.BadRequestResult` (400 Bad Request).
    
        
        :rtype: Microsoft.AspNetCore.Mvc.BadRequestResult
        :return: A :any:`Microsoft.AspNetCore.Mvc.BadRequestResult`\.
    
        
        .. code-block:: csharp
    
            public virtual BadRequestResult BadRequest()
    
    .. dn:method:: System.Web.Http.ApiController.BadRequest(Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary)
    
        
    
        
        Creates an :any:`System.Web.Http.InvalidModelStateResult` (400 Bad Request) with the specified model state.
    
        
    
        
        :param modelState: The model state to include in the error.
        
        :type modelState: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary
        :rtype: System.Web.Http.InvalidModelStateResult
        :return: An :any:`System.Web.Http.InvalidModelStateResult` with the specified model state.
    
        
        .. code-block:: csharp
    
            public virtual InvalidModelStateResult BadRequest(ModelStateDictionary modelState)
    
    .. dn:method:: System.Web.Http.ApiController.BadRequest(System.String)
    
        
    
        
        Creates a :any:`System.Web.Http.BadRequestErrorMessageResult` (400 Bad Request) with the specified error message.
    
        
    
        
        :param message: The user-visible error message.
        
        :type message: System.String
        :rtype: System.Web.Http.BadRequestErrorMessageResult
        :return: A :any:`System.Web.Http.BadRequestErrorMessageResult` with the specified error message.
    
        
        .. code-block:: csharp
    
            public virtual BadRequestErrorMessageResult BadRequest(string message)
    
    .. dn:method:: System.Web.Http.ApiController.Conflict()
    
        
    
        Creates a :any:`System.Web.Http.ConflictResult` (409 Conflict).
    
        
        :rtype: System.Web.Http.ConflictResult
        :return: A :any:`System.Web.Http.ConflictResult`\.
    
        
        .. code-block:: csharp
    
            public virtual ConflictResult Conflict()
    
    .. dn:method:: System.Web.Http.ApiController.Content<T>(System.Net.HttpStatusCode, T)
    
        
    
        
        Creates a :any:`System.Web.Http.NegotiatedContentResult\`1` with the specified values.
    
        
    
        
        :param statusCode: The HTTP status code for the response message.
        
        :type statusCode: System.Net.HttpStatusCode
    
        
        :param value: The content value to negotiate and format in the entity body.
        
        :type value: T
        :rtype: System.Web.Http.NegotiatedContentResult<System.Web.Http.NegotiatedContentResult`1>{T}
        :return: A :any:`System.Web.Http.NegotiatedContentResult\`1` with the specified values.
    
        
        .. code-block:: csharp
    
            public virtual NegotiatedContentResult<T> Content<T>(HttpStatusCode statusCode, T value)
    
    .. dn:method:: System.Web.Http.ApiController.Created(System.String, System.Object)
    
        
    
        
        Creates a :any:`Microsoft.AspNetCore.Mvc.CreatedResult` (201 Created) with the specified values.
    
        
    
        
        :param location: 
            The location at which the content has been created. Must be a relative or absolute URL.
        
        :type location: System.String
    
        
        :param content: The content value to format in the entity body.
        
        :type content: System.Object
        :rtype: Microsoft.AspNetCore.Mvc.CreatedResult
        :return: A :any:`Microsoft.AspNetCore.Mvc.CreatedResult` with the specified values.
    
        
        .. code-block:: csharp
    
            public virtual CreatedResult Created(string location, object content)
    
    .. dn:method:: System.Web.Http.ApiController.Created(System.Uri, System.Object)
    
        
    
        
        Creates a :any:`Microsoft.AspNetCore.Mvc.CreatedResult` (201 Created) with the specified values.
    
        
    
        
        :param uri: The location at which the content has been created.
        
        :type uri: System.Uri
    
        
        :param content: The content value to format in the entity body.
        
        :type content: System.Object
        :rtype: Microsoft.AspNetCore.Mvc.CreatedResult
        :return: A :any:`Microsoft.AspNetCore.Mvc.CreatedResult` with the specified values.
    
        
        .. code-block:: csharp
    
            public virtual CreatedResult Created(Uri uri, object content)
    
    .. dn:method:: System.Web.Http.ApiController.CreatedAtRoute(System.String, System.Object, System.Object)
    
        
    
        
        Creates a :any:`Microsoft.AspNetCore.Mvc.CreatedAtRouteResult` (201 Created) with the specified values.
    
        
    
        
        :param routeName: The name of the route to use for generating the URL.
        
        :type routeName: System.String
    
        
        :param routeValues: The route data to use for generating the URL.
        
        :type routeValues: System.Object
    
        
        :param content: The content value to format in the entity body.
        
        :type content: System.Object
        :rtype: Microsoft.AspNetCore.Mvc.CreatedAtRouteResult
        :return: A :any:`Microsoft.AspNetCore.Mvc.CreatedAtRouteResult` with the specified values.
    
        
        .. code-block:: csharp
    
            public virtual CreatedAtRouteResult CreatedAtRoute(string routeName, object routeValues, object content)
    
    .. dn:method:: System.Web.Http.ApiController.Dispose()
    
        
    
        
        .. code-block:: csharp
    
            public void Dispose()
    
    .. dn:method:: System.Web.Http.ApiController.Dispose(System.Boolean)
    
        
    
        
        :type disposing: System.Boolean
    
        
        .. code-block:: csharp
    
            protected virtual void Dispose(bool disposing)
    
    .. dn:method:: System.Web.Http.ApiController.InternalServerError()
    
        
    
        Creates an :any:`System.Web.Http.InternalServerErrorResult` (500 Internal Server Error).
        
    
        
        :rtype: System.Web.Http.InternalServerErrorResult
        :return: A :any:`System.Web.Http.InternalServerErrorResult`\.
    
        
        .. code-block:: csharp
    
            public virtual InternalServerErrorResult InternalServerError()
    
    .. dn:method:: System.Web.Http.ApiController.InternalServerError(System.Exception)
    
        
    
        
        Creates an :any:`System.Web.Http.ExceptionResult` (500 Internal Server Error) with the specified exception.
    
        
    
        
        :param exception: The exception to include in the error.
        
        :type exception: System.Exception
        :rtype: System.Web.Http.ExceptionResult
        :return: An :any:`System.Web.Http.ExceptionResult` with the specified exception.
    
        
        .. code-block:: csharp
    
            public virtual ExceptionResult InternalServerError(Exception exception)
    
    .. dn:method:: System.Web.Http.ApiController.Json<T>(T)
    
        
    
        
        Creates an :any:`Microsoft.AspNetCore.Mvc.JsonResult` (200 OK) with the specified value.
    
        
    
        
        :param content: The content value to serialize in the entity body.
        
        :type content: T
        :rtype: Microsoft.AspNetCore.Mvc.JsonResult
        :return: A :any:`Microsoft.AspNetCore.Mvc.JsonResult` with the specified value.
    
        
        .. code-block:: csharp
    
            public virtual JsonResult Json<T>(T content)
    
    .. dn:method:: System.Web.Http.ApiController.Json<T>(T, Newtonsoft.Json.JsonSerializerSettings)
    
        
    
        
        Creates an :any:`Microsoft.AspNetCore.Mvc.JsonResult` (200 OK) with the specified values.
    
        
    
        
        :param content: The content value to serialize in the entity body.
        
        :type content: T
    
        
        :param serializerSettings: The serializer settings.
        
        :type serializerSettings: Newtonsoft.Json.JsonSerializerSettings
        :rtype: Microsoft.AspNetCore.Mvc.JsonResult
        :return: A :any:`Microsoft.AspNetCore.Mvc.JsonResult` with the specified values.
    
        
        .. code-block:: csharp
    
            public virtual JsonResult Json<T>(T content, JsonSerializerSettings serializerSettings)
    
    .. dn:method:: System.Web.Http.ApiController.Json<T>(T, Newtonsoft.Json.JsonSerializerSettings, System.Text.Encoding)
    
        
    
        
        Creates an :any:`Microsoft.AspNetCore.Mvc.JsonResult` (200 OK) with the specified values.
    
        
    
        
        :param content: The content value to serialize in the entity body.
        
        :type content: T
    
        
        :param serializerSettings: The serializer settings.
        
        :type serializerSettings: Newtonsoft.Json.JsonSerializerSettings
    
        
        :param encoding: The content encoding.
        
        :type encoding: System.Text.Encoding
        :rtype: Microsoft.AspNetCore.Mvc.JsonResult
        :return: A :any:`Microsoft.AspNetCore.Mvc.JsonResult` with the specified values.
    
        
        .. code-block:: csharp
    
            public virtual JsonResult Json<T>(T content, JsonSerializerSettings serializerSettings, Encoding encoding)
    
    .. dn:method:: System.Web.Http.ApiController.NotFound()
    
        
    
        
        Creates an :any:`Microsoft.AspNetCore.Mvc.NotFoundResult` (404 Not Found).
    
        
        :rtype: Microsoft.AspNetCore.Mvc.NotFoundResult
        :return: A :any:`Microsoft.AspNetCore.Mvc.NotFoundResult`\.
    
        
        .. code-block:: csharp
    
            public virtual NotFoundResult NotFound()
    
    .. dn:method:: System.Web.Http.ApiController.Ok()
    
        
    
        
        Creates an :any:`Microsoft.AspNetCore.Mvc.OkResult` (200 OK).
    
        
        :rtype: Microsoft.AspNetCore.Mvc.OkResult
        :return: An :any:`Microsoft.AspNetCore.Mvc.OkResult`\.
    
        
        .. code-block:: csharp
    
            public virtual OkResult Ok()
    
    .. dn:method:: System.Web.Http.ApiController.Ok<T>(T)
    
        
    
        
        Creates an :any:`Microsoft.AspNetCore.Mvc.OkObjectResult` (200 OK) with the specified values.
    
        
    
        
        :param content: The content value to negotiate and format in the entity body.
        
        :type content: T
        :rtype: Microsoft.AspNetCore.Mvc.OkObjectResult
        :return: An :any:`Microsoft.AspNetCore.Mvc.OkObjectResult` with the specified values.
    
        
        .. code-block:: csharp
    
            public virtual OkObjectResult Ok<T>(T content)
    
    .. dn:method:: System.Web.Http.ApiController.Redirect(System.String)
    
        
    
        
        Creates a :any:`Microsoft.AspNetCore.Mvc.RedirectResult` (302 Found) with the specified value.
    
        
    
        
        :param location: The location to which to redirect.
        
        :type location: System.String
        :rtype: Microsoft.AspNetCore.Mvc.RedirectResult
        :return: A :any:`Microsoft.AspNetCore.Mvc.RedirectResult` with the specified value.
    
        
        .. code-block:: csharp
    
            public virtual RedirectResult Redirect(string location)
    
    .. dn:method:: System.Web.Http.ApiController.Redirect(System.Uri)
    
        
    
        
        Creates a :any:`Microsoft.AspNetCore.Mvc.RedirectResult` (302 Found) with the specified value.
    
        
    
        
        :param location: The location to which to redirect.
        
        :type location: System.Uri
        :rtype: Microsoft.AspNetCore.Mvc.RedirectResult
        :return: A :any:`Microsoft.AspNetCore.Mvc.RedirectResult` with the specified value.
    
        
        .. code-block:: csharp
    
            public virtual RedirectResult Redirect(Uri location)
    
    .. dn:method:: System.Web.Http.ApiController.RedirectToRoute(System.String, System.Object)
    
        
    
        
        Creates a :any:`Microsoft.AspNetCore.Mvc.RedirectToRouteResult` (302 Found) with the specified values.
    
        
    
        
        :param routeName: The name of the route to use for generating the URL.
        
        :type routeName: System.String
    
        
        :param routeValues: The route data to use for generating the URL.
        
        :type routeValues: System.Object
        :rtype: Microsoft.AspNetCore.Mvc.RedirectToRouteResult
        :return: A :any:`Microsoft.AspNetCore.Mvc.RedirectToRouteResult` with the specified values.
    
        
        .. code-block:: csharp
    
            public virtual RedirectToRouteResult RedirectToRoute(string routeName, object routeValues)
    
    .. dn:method:: System.Web.Http.ApiController.ResponseMessage(System.Net.Http.HttpResponseMessage)
    
        
    
        
        Creates a :any:`System.Web.Http.ResponseMessageResult` with the specified response.
    
        
    
        
        :param response: The HTTP response message.
        
        :type response: System.Net.Http.HttpResponseMessage
        :rtype: System.Web.Http.ResponseMessageResult
        :return: A :any:`System.Web.Http.ResponseMessageResult` for the specified response.
    
        
        .. code-block:: csharp
    
            public virtual ResponseMessageResult ResponseMessage(HttpResponseMessage response)
    
    .. dn:method:: System.Web.Http.ApiController.StatusCode(System.Net.HttpStatusCode)
    
        
    
        
        Creates a :any:`Microsoft.AspNetCore.Mvc.StatusCodeResult` with the specified status code.
    
        
    
        
        :param status: The HTTP status code for the response message
        
        :type status: System.Net.HttpStatusCode
        :rtype: Microsoft.AspNetCore.Mvc.StatusCodeResult
        :return: A :any:`Microsoft.AspNetCore.Mvc.StatusCodeResult` with the specified status code.
    
        
        .. code-block:: csharp
    
            public virtual StatusCodeResult StatusCode(HttpStatusCode status)
    
    .. dn:method:: System.Web.Http.ApiController.Validate<TEntity>(TEntity)
    
        
    
        
        Validates the given entity and adds the validation errors to the :dn:prop:`System.Web.Http.ApiController.ModelState`
        under an empty prefix.
    
        
    
        
        :param entity: The entity being validated.
        
        :type entity: TEntity
    
        
        .. code-block:: csharp
    
            public void Validate<TEntity>(TEntity entity)
    
    .. dn:method:: System.Web.Http.ApiController.Validate<TEntity>(TEntity, System.String)
    
        
    
        
        Validates the given entity and adds the validation errors to the :dn:prop:`System.Web.Http.ApiController.ModelState`\.
    
        
    
        
        :param entity: The entity being validated.
        
        :type entity: TEntity
    
        
        :param keyPrefix: 
            The key prefix under which the model state errors would be added in the
            :dn:prop:`System.Web.Http.ApiController.ModelState`\.
        
        :type keyPrefix: System.String
    
        
        .. code-block:: csharp
    
            public void Validate<TEntity>(TEntity entity, string keyPrefix)
    

