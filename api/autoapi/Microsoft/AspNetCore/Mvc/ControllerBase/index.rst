

ControllerBase Class
====================






A base class for an MVC controller without view support.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ControllerBase`








Syntax
------

.. code-block:: csharp

    public abstract class ControllerBase








.. dn:class:: Microsoft.AspNetCore.Mvc.ControllerBase
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ControllerBase

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.ControllerBase
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ControllerBase.ControllerContext
    
        
    
        
        Gets or sets the :any:`Microsoft.AspNetCore.Mvc.ControllerContext`\.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ControllerContext
    
        
        .. code-block:: csharp
    
            public ControllerContext ControllerContext
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ControllerBase.HttpContext
    
        
    
        
        Gets the :any:`Microsoft.AspNetCore.Http.HttpContext` for the executing action.
    
        
        :rtype: Microsoft.AspNetCore.Http.HttpContext
    
        
        .. code-block:: csharp
    
            public HttpContext HttpContext
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ControllerBase.MetadataProvider
    
        
    
        
        Gets or sets the :any:`Microsoft.AspNetCore.Mvc.ModelBinding.IModelMetadataProvider`\.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.IModelMetadataProvider
    
        
        .. code-block:: csharp
    
            public IModelMetadataProvider MetadataProvider
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ControllerBase.ModelBinderFactory
    
        
    
        
        Gets or sets the :any:`Microsoft.AspNetCore.Mvc.ModelBinding.IModelBinderFactory`\.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.IModelBinderFactory
    
        
        .. code-block:: csharp
    
            public IModelBinderFactory ModelBinderFactory
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ControllerBase.ModelState
    
        
    
        
        Gets the :any:`Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary` that contains the state of the model and of model-binding validation.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary
    
        
        .. code-block:: csharp
    
            public ModelStateDictionary ModelState
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ControllerBase.ObjectValidator
    
        
    
        
        Gets or sets the :any:`Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IObjectModelValidator`\.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IObjectModelValidator
    
        
        .. code-block:: csharp
    
            public IObjectModelValidator ObjectValidator
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ControllerBase.Request
    
        
    
        
        Gets the :any:`Microsoft.AspNetCore.Http.HttpRequest` for the executing action.
    
        
        :rtype: Microsoft.AspNetCore.Http.HttpRequest
    
        
        .. code-block:: csharp
    
            public HttpRequest Request
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ControllerBase.Response
    
        
    
        
        Gets the :any:`Microsoft.AspNetCore.Http.HttpResponse` for the executing action.
    
        
        :rtype: Microsoft.AspNetCore.Http.HttpResponse
    
        
        .. code-block:: csharp
    
            public HttpResponse Response
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ControllerBase.RouteData
    
        
    
        
        Gets the :any:`Microsoft.AspNetCore.Routing.RouteData` for the executing action.
    
        
        :rtype: Microsoft.AspNetCore.Routing.RouteData
    
        
        .. code-block:: csharp
    
            public RouteData RouteData
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ControllerBase.Url
    
        
    
        
        Gets or sets the :any:`Microsoft.AspNetCore.Mvc.IUrlHelper`\.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.IUrlHelper
    
        
        .. code-block:: csharp
    
            public IUrlHelper Url
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ControllerBase.User
    
        
    
        
        Gets or sets the :any:`System.Security.Claims.ClaimsPrincipal` for user associated with the executing action.
    
        
        :rtype: System.Security.Claims.ClaimsPrincipal
    
        
        .. code-block:: csharp
    
            public ClaimsPrincipal User
            {
                get;
            }
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.ControllerBase
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ControllerBase.BadRequest()
    
        
    
        
        Creates an :any:`Microsoft.AspNetCore.Mvc.BadRequestResult` that produces a Bad Request (400) response.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.BadRequestResult
        :return: The created :any:`Microsoft.AspNetCore.Mvc.BadRequestResult` for the response.
    
        
        .. code-block:: csharp
    
            public virtual BadRequestResult BadRequest()
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ControllerBase.BadRequest(Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary)
    
        
    
        
        Creates an :any:`Microsoft.AspNetCore.Mvc.BadRequestObjectResult` that produces a Bad Request (400) response.
    
        
    
        
        :type modelState: Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary
        :rtype: Microsoft.AspNetCore.Mvc.BadRequestObjectResult
        :return: The created :any:`Microsoft.AspNetCore.Mvc.BadRequestObjectResult` for the response.
    
        
        .. code-block:: csharp
    
            public virtual BadRequestObjectResult BadRequest(ModelStateDictionary modelState)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ControllerBase.BadRequest(System.Object)
    
        
    
        
        Creates an :any:`Microsoft.AspNetCore.Mvc.BadRequestObjectResult` that produces a Bad Request (400) response.
    
        
    
        
        :type error: System.Object
        :rtype: Microsoft.AspNetCore.Mvc.BadRequestObjectResult
        :return: The created :any:`Microsoft.AspNetCore.Mvc.BadRequestObjectResult` for the response.
    
        
        .. code-block:: csharp
    
            public virtual BadRequestObjectResult BadRequest(object error)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ControllerBase.Challenge()
    
        
    
        
        Creates a :any:`Microsoft.AspNetCore.Mvc.ChallengeResult`\.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ChallengeResult
        :return: The created :any:`Microsoft.AspNetCore.Mvc.ChallengeResult` for the response.
    
        
        .. code-block:: csharp
    
            public virtual ChallengeResult Challenge()
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ControllerBase.Challenge(Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties)
    
        
    
        
        Creates a :any:`Microsoft.AspNetCore.Mvc.ChallengeResult` with the specified <em>properties</em>.
    
        
    
        
        :param properties: :any:`Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties` used to perform the authentication
            challenge.
        
        :type properties: Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties
        :rtype: Microsoft.AspNetCore.Mvc.ChallengeResult
        :return: The created :any:`Microsoft.AspNetCore.Mvc.ChallengeResult` for the response.
    
        
        .. code-block:: csharp
    
            public virtual ChallengeResult Challenge(AuthenticationProperties properties)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ControllerBase.Challenge(Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties, System.String[])
    
        
    
        
        Creates a :any:`Microsoft.AspNetCore.Mvc.ChallengeResult` with the specified specified authentication schemes and
        <em>properties</em>.
    
        
    
        
        :param properties: :any:`Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties` used to perform the authentication
            challenge.
        
        :type properties: Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties
    
        
        :param authenticationSchemes: The authentication schemes to challenge.
        
        :type authenticationSchemes: System.String<System.String>[]
        :rtype: Microsoft.AspNetCore.Mvc.ChallengeResult
        :return: The created :any:`Microsoft.AspNetCore.Mvc.ChallengeResult` for the response.
    
        
        .. code-block:: csharp
    
            public virtual ChallengeResult Challenge(AuthenticationProperties properties, params string[] authenticationSchemes)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ControllerBase.Challenge(System.String[])
    
        
    
        
        Creates a :any:`Microsoft.AspNetCore.Mvc.ChallengeResult` with the specified authentication schemes.
    
        
    
        
        :param authenticationSchemes: The authentication schemes to challenge.
        
        :type authenticationSchemes: System.String<System.String>[]
        :rtype: Microsoft.AspNetCore.Mvc.ChallengeResult
        :return: The created :any:`Microsoft.AspNetCore.Mvc.ChallengeResult` for the response.
    
        
        .. code-block:: csharp
    
            public virtual ChallengeResult Challenge(params string[] authenticationSchemes)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ControllerBase.Content(System.String)
    
        
    
        
        Creates a :any:`Microsoft.AspNetCore.Mvc.ContentResult` object by specifying a <em>content</em> string.
    
        
    
        
        :param content: The content to write to the response.
        
        :type content: System.String
        :rtype: Microsoft.AspNetCore.Mvc.ContentResult
        :return: The created :any:`Microsoft.AspNetCore.Mvc.ContentResult` object for the response.
    
        
        .. code-block:: csharp
    
            public virtual ContentResult Content(string content)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ControllerBase.Content(System.String, Microsoft.Net.Http.Headers.MediaTypeHeaderValue)
    
        
    
        
        Creates a :any:`Microsoft.AspNetCore.Mvc.ContentResult` object by specifying a <em>content</em>
        string and a <em>contentType</em>.
    
        
    
        
        :param content: The content to write to the response.
        
        :type content: System.String
    
        
        :param contentType: The content type (MIME type).
        
        :type contentType: Microsoft.Net.Http.Headers.MediaTypeHeaderValue
        :rtype: Microsoft.AspNetCore.Mvc.ContentResult
        :return: The created :any:`Microsoft.AspNetCore.Mvc.ContentResult` object for the response.
    
        
        .. code-block:: csharp
    
            public virtual ContentResult Content(string content, MediaTypeHeaderValue contentType)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ControllerBase.Content(System.String, System.String)
    
        
    
        
        Creates a :any:`Microsoft.AspNetCore.Mvc.ContentResult` object by specifying a <em>content</em> string
        and a content type.
    
        
    
        
        :param content: The content to write to the response.
        
        :type content: System.String
    
        
        :param contentType: The content type (MIME type).
        
        :type contentType: System.String
        :rtype: Microsoft.AspNetCore.Mvc.ContentResult
        :return: The created :any:`Microsoft.AspNetCore.Mvc.ContentResult` object for the response.
    
        
        .. code-block:: csharp
    
            public virtual ContentResult Content(string content, string contentType)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ControllerBase.Content(System.String, System.String, System.Text.Encoding)
    
        
    
        
        Creates a :any:`Microsoft.AspNetCore.Mvc.ContentResult` object by specifying a <em>content</em> string,
        a <em>contentType</em>, and <em>contentEncoding</em>.
    
        
    
        
        :param content: The content to write to the response.
        
        :type content: System.String
    
        
        :param contentType: The content type (MIME type).
        
        :type contentType: System.String
    
        
        :param contentEncoding: The content encoding.
        
        :type contentEncoding: System.Text.Encoding
        :rtype: Microsoft.AspNetCore.Mvc.ContentResult
        :return: The created :any:`Microsoft.AspNetCore.Mvc.ContentResult` object for the response.
    
        
        .. code-block:: csharp
    
            public virtual ContentResult Content(string content, string contentType, Encoding contentEncoding)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ControllerBase.Created(System.String, System.Object)
    
        
    
        
        Creates a :any:`Microsoft.AspNetCore.Mvc.CreatedResult` object that produces a Created (201) response.
    
        
    
        
        :param uri: The URI at which the content has been created.
        
        :type uri: System.String
    
        
        :param value: The content value to format in the entity body.
        
        :type value: System.Object
        :rtype: Microsoft.AspNetCore.Mvc.CreatedResult
        :return: The created :any:`Microsoft.AspNetCore.Mvc.CreatedResult` for the response.
    
        
        .. code-block:: csharp
    
            public virtual CreatedResult Created(string uri, object value)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ControllerBase.Created(System.Uri, System.Object)
    
        
    
        
        Creates a :any:`Microsoft.AspNetCore.Mvc.CreatedResult` object that produces a Created (201) response.
    
        
    
        
        :param uri: The URI at which the content has been created.
        
        :type uri: System.Uri
    
        
        :param value: The content value to format in the entity body.
        
        :type value: System.Object
        :rtype: Microsoft.AspNetCore.Mvc.CreatedResult
        :return: The created :any:`Microsoft.AspNetCore.Mvc.CreatedResult` for the response.
    
        
        .. code-block:: csharp
    
            public virtual CreatedResult Created(Uri uri, object value)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ControllerBase.CreatedAtAction(System.String, System.Object)
    
        
    
        
        Creates a :any:`Microsoft.AspNetCore.Mvc.CreatedAtActionResult` object that produces a Created (201) response.
    
        
    
        
        :param actionName: The name of the action to use for generating the URL.
        
        :type actionName: System.String
    
        
        :param value: The content value to format in the entity body.
        
        :type value: System.Object
        :rtype: Microsoft.AspNetCore.Mvc.CreatedAtActionResult
        :return: The created :any:`Microsoft.AspNetCore.Mvc.CreatedAtActionResult` for the response.
    
        
        .. code-block:: csharp
    
            public virtual CreatedAtActionResult CreatedAtAction(string actionName, object value)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ControllerBase.CreatedAtAction(System.String, System.Object, System.Object)
    
        
    
        
        Creates a :any:`Microsoft.AspNetCore.Mvc.CreatedAtActionResult` object that produces a Created (201) response.
    
        
    
        
        :param actionName: The name of the action to use for generating the URL.
        
        :type actionName: System.String
    
        
        :param routeValues: The route data to use for generating the URL.
        
        :type routeValues: System.Object
    
        
        :param value: The content value to format in the entity body.
        
        :type value: System.Object
        :rtype: Microsoft.AspNetCore.Mvc.CreatedAtActionResult
        :return: The created :any:`Microsoft.AspNetCore.Mvc.CreatedAtActionResult` for the response.
    
        
        .. code-block:: csharp
    
            public virtual CreatedAtActionResult CreatedAtAction(string actionName, object routeValues, object value)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ControllerBase.CreatedAtAction(System.String, System.String, System.Object, System.Object)
    
        
    
        
        Creates a :any:`Microsoft.AspNetCore.Mvc.CreatedAtActionResult` object that produces a Created (201) response.
    
        
    
        
        :param actionName: The name of the action to use for generating the URL.
        
        :type actionName: System.String
    
        
        :param controllerName: The name of the controller to use for generating the URL.
        
        :type controllerName: System.String
    
        
        :param routeValues: The route data to use for generating the URL.
        
        :type routeValues: System.Object
    
        
        :param value: The content value to format in the entity body.
        
        :type value: System.Object
        :rtype: Microsoft.AspNetCore.Mvc.CreatedAtActionResult
        :return: The created :any:`Microsoft.AspNetCore.Mvc.CreatedAtActionResult` for the response.
    
        
        .. code-block:: csharp
    
            public virtual CreatedAtActionResult CreatedAtAction(string actionName, string controllerName, object routeValues, object value)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ControllerBase.CreatedAtRoute(System.Object, System.Object)
    
        
    
        
        Creates a :any:`Microsoft.AspNetCore.Mvc.CreatedAtRouteResult` object that produces a Created (201) response.
    
        
    
        
        :param routeValues: The route data to use for generating the URL.
        
        :type routeValues: System.Object
    
        
        :param value: The content value to format in the entity body.
        
        :type value: System.Object
        :rtype: Microsoft.AspNetCore.Mvc.CreatedAtRouteResult
        :return: The created :any:`Microsoft.AspNetCore.Mvc.CreatedAtRouteResult` for the response.
    
        
        .. code-block:: csharp
    
            public virtual CreatedAtRouteResult CreatedAtRoute(object routeValues, object value)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ControllerBase.CreatedAtRoute(System.String, System.Object)
    
        
    
        
        Creates a :any:`Microsoft.AspNetCore.Mvc.CreatedAtRouteResult` object that produces a Created (201) response.
    
        
    
        
        :param routeName: The name of the route to use for generating the URL.
        
        :type routeName: System.String
    
        
        :param value: The content value to format in the entity body.
        
        :type value: System.Object
        :rtype: Microsoft.AspNetCore.Mvc.CreatedAtRouteResult
        :return: The created :any:`Microsoft.AspNetCore.Mvc.CreatedAtRouteResult` for the response.
    
        
        .. code-block:: csharp
    
            public virtual CreatedAtRouteResult CreatedAtRoute(string routeName, object value)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ControllerBase.CreatedAtRoute(System.String, System.Object, System.Object)
    
        
    
        
        Creates a :any:`Microsoft.AspNetCore.Mvc.CreatedAtRouteResult` object that produces a Created (201) response.
    
        
    
        
        :param routeName: The name of the route to use for generating the URL.
        
        :type routeName: System.String
    
        
        :param routeValues: The route data to use for generating the URL.
        
        :type routeValues: System.Object
    
        
        :param value: The content value to format in the entity body.
        
        :type value: System.Object
        :rtype: Microsoft.AspNetCore.Mvc.CreatedAtRouteResult
        :return: The created :any:`Microsoft.AspNetCore.Mvc.CreatedAtRouteResult` for the response.
    
        
        .. code-block:: csharp
    
            public virtual CreatedAtRouteResult CreatedAtRoute(string routeName, object routeValues, object value)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ControllerBase.File(System.Byte[], System.String)
    
        
    
        
        Returns a file with the specified <em>fileContents</em> as content and the
        specified <em>contentType</em> as the Content-Type.
    
        
    
        
        :param fileContents: The file contents.
        
        :type fileContents: System.Byte<System.Byte>[]
    
        
        :param contentType: The Content-Type of the file.
        
        :type contentType: System.String
        :rtype: Microsoft.AspNetCore.Mvc.FileContentResult
        :return: The created :any:`Microsoft.AspNetCore.Mvc.FileContentResult` for the response.
    
        
        .. code-block:: csharp
    
            public virtual FileContentResult File(byte[] fileContents, string contentType)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ControllerBase.File(System.Byte[], System.String, System.String)
    
        
    
        
        Returns a file with the specified <em>fileContents</em> as content, the
        specified <em>contentType</em> as the Content-Type and the
        specified <em>fileDownloadName</em> as the suggested file name.
    
        
    
        
        :param fileContents: The file contents.
        
        :type fileContents: System.Byte<System.Byte>[]
    
        
        :param contentType: The Content-Type of the file.
        
        :type contentType: System.String
    
        
        :param fileDownloadName: The suggested file name.
        
        :type fileDownloadName: System.String
        :rtype: Microsoft.AspNetCore.Mvc.FileContentResult
        :return: The created :any:`Microsoft.AspNetCore.Mvc.FileContentResult` for the response.
    
        
        .. code-block:: csharp
    
            public virtual FileContentResult File(byte[] fileContents, string contentType, string fileDownloadName)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ControllerBase.File(System.IO.Stream, System.String)
    
        
    
        
        Returns a file in the specified <em>fileStream</em> with the
        specified <em>contentType</em> as the Content-Type.
    
        
    
        
        :param fileStream: The :any:`System.IO.Stream` with the contents of the file.
        
        :type fileStream: System.IO.Stream
    
        
        :param contentType: The Content-Type of the file.
        
        :type contentType: System.String
        :rtype: Microsoft.AspNetCore.Mvc.FileStreamResult
        :return: The created :any:`Microsoft.AspNetCore.Mvc.FileStreamResult` for the response.
    
        
        .. code-block:: csharp
    
            public virtual FileStreamResult File(Stream fileStream, string contentType)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ControllerBase.File(System.IO.Stream, System.String, System.String)
    
        
    
        
        Returns a file in the specified <em>fileStream</em> with the
        specified <em>contentType</em> as the Content-Type and the
        specified <em>fileDownloadName</em> as the suggested file name.
    
        
    
        
        :param fileStream: The :any:`System.IO.Stream` with the contents of the file.
        
        :type fileStream: System.IO.Stream
    
        
        :param contentType: The Content-Type of the file.
        
        :type contentType: System.String
    
        
        :param fileDownloadName: The suggested file name.
        
        :type fileDownloadName: System.String
        :rtype: Microsoft.AspNetCore.Mvc.FileStreamResult
        :return: The created :any:`Microsoft.AspNetCore.Mvc.FileStreamResult` for the response.
    
        
        .. code-block:: csharp
    
            public virtual FileStreamResult File(Stream fileStream, string contentType, string fileDownloadName)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ControllerBase.File(System.String, System.String)
    
        
    
        
        Returns the file specified by <em>virtualPath</em> with the
        specified <em>contentType</em> as the Content-Type.
    
        
    
        
        :param virtualPath: The virtual path of the file to be returned.
        
        :type virtualPath: System.String
    
        
        :param contentType: The Content-Type of the file.
        
        :type contentType: System.String
        :rtype: Microsoft.AspNetCore.Mvc.VirtualFileResult
        :return: The created :any:`Microsoft.AspNetCore.Mvc.VirtualFileResult` for the response.
    
        
        .. code-block:: csharp
    
            public virtual VirtualFileResult File(string virtualPath, string contentType)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ControllerBase.File(System.String, System.String, System.String)
    
        
    
        
        Returns the file specified by <em>virtualPath</em> with the
        specified <em>contentType</em> as the Content-Type and the
        specified <em>fileDownloadName</em> as the suggested file name.
    
        
    
        
        :param virtualPath: The virtual path of the file to be returned.
        
        :type virtualPath: System.String
    
        
        :param contentType: The Content-Type of the file.
        
        :type contentType: System.String
    
        
        :param fileDownloadName: The suggested file name.
        
        :type fileDownloadName: System.String
        :rtype: Microsoft.AspNetCore.Mvc.VirtualFileResult
        :return: The created :any:`Microsoft.AspNetCore.Mvc.VirtualFileResult` for the response.
    
        
        .. code-block:: csharp
    
            public virtual VirtualFileResult File(string virtualPath, string contentType, string fileDownloadName)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ControllerBase.Forbid()
    
        
    
        
        Creates a :any:`Microsoft.AspNetCore.Mvc.ForbidResult`\.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ForbidResult
        :return: The created :any:`Microsoft.AspNetCore.Mvc.ForbidResult` for the response.
    
        
        .. code-block:: csharp
    
            public virtual ForbidResult Forbid()
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ControllerBase.Forbid(Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties)
    
        
    
        
        Creates a :any:`Microsoft.AspNetCore.Mvc.ForbidResult` with the specified <em>properties</em>.
    
        
    
        
        :param properties: :any:`Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties` used to perform the authentication
            challenge.
        
        :type properties: Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties
        :rtype: Microsoft.AspNetCore.Mvc.ForbidResult
        :return: The created :any:`Microsoft.AspNetCore.Mvc.ForbidResult` for the response.
    
        
        .. code-block:: csharp
    
            public virtual ForbidResult Forbid(AuthenticationProperties properties)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ControllerBase.Forbid(Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties, System.String[])
    
        
    
        
        Creates a :any:`Microsoft.AspNetCore.Mvc.ForbidResult` with the specified specified authentication schemes and
        <em>properties</em>.
    
        
    
        
        :param properties: :any:`Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties` used to perform the authentication
            challenge.
        
        :type properties: Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties
    
        
        :param authenticationSchemes: The authentication schemes to challenge.
        
        :type authenticationSchemes: System.String<System.String>[]
        :rtype: Microsoft.AspNetCore.Mvc.ForbidResult
        :return: The created :any:`Microsoft.AspNetCore.Mvc.ForbidResult` for the response.
    
        
        .. code-block:: csharp
    
            public virtual ForbidResult Forbid(AuthenticationProperties properties, params string[] authenticationSchemes)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ControllerBase.Forbid(System.String[])
    
        
    
        
        Creates a :any:`Microsoft.AspNetCore.Mvc.ForbidResult` with the specified authentication schemes.
    
        
    
        
        :param authenticationSchemes: The authentication schemes to challenge.
        
        :type authenticationSchemes: System.String<System.String>[]
        :rtype: Microsoft.AspNetCore.Mvc.ForbidResult
        :return: The created :any:`Microsoft.AspNetCore.Mvc.ForbidResult` for the response.
    
        
        .. code-block:: csharp
    
            public virtual ForbidResult Forbid(params string[] authenticationSchemes)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ControllerBase.LocalRedirect(System.String)
    
        
    
        
        Creates a :any:`Microsoft.AspNetCore.Mvc.LocalRedirectResult` object that redirects to
        the specified local <em>localUrl</em>.
    
        
    
        
        :param localUrl: The local URL to redirect to.
        
        :type localUrl: System.String
        :rtype: Microsoft.AspNetCore.Mvc.LocalRedirectResult
        :return: The created :any:`Microsoft.AspNetCore.Mvc.LocalRedirectResult` for the response.
    
        
        .. code-block:: csharp
    
            public virtual LocalRedirectResult LocalRedirect(string localUrl)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ControllerBase.LocalRedirectPermanent(System.String)
    
        
    
        
        Creates a :any:`Microsoft.AspNetCore.Mvc.LocalRedirectResult` object with :dn:prop:`Microsoft.AspNetCore.Mvc.LocalRedirectResult.Permanent`
        set to true using the specified <em>localUrl</em>.
    
        
    
        
        :param localUrl: The local URL to redirect to.
        
        :type localUrl: System.String
        :rtype: Microsoft.AspNetCore.Mvc.LocalRedirectResult
        :return: The created :any:`Microsoft.AspNetCore.Mvc.LocalRedirectResult` for the response.
    
        
        .. code-block:: csharp
    
            public virtual LocalRedirectResult LocalRedirectPermanent(string localUrl)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ControllerBase.NoContent()
    
        
    
        
        Creates a :any:`Microsoft.AspNetCore.Mvc.NoContentResult` object that produces an empty No Content (204) response.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.NoContentResult
        :return: The created :any:`Microsoft.AspNetCore.Mvc.NoContentResult` object for the response.
    
        
        .. code-block:: csharp
    
            public virtual NoContentResult NoContent()
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ControllerBase.NotFound()
    
        
    
        
        Creates an :any:`Microsoft.AspNetCore.Mvc.NotFoundResult` that produces a Not Found (404) response.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.NotFoundResult
        :return: The created :any:`Microsoft.AspNetCore.Mvc.NotFoundResult` for the response.
    
        
        .. code-block:: csharp
    
            public virtual NotFoundResult NotFound()
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ControllerBase.NotFound(System.Object)
    
        
    
        
        Creates an :any:`Microsoft.AspNetCore.Mvc.NotFoundObjectResult` that produces a Not Found (404) response.
    
        
    
        
        :type value: System.Object
        :rtype: Microsoft.AspNetCore.Mvc.NotFoundObjectResult
        :return: The created :any:`Microsoft.AspNetCore.Mvc.NotFoundObjectResult` for the response.
    
        
        .. code-block:: csharp
    
            public virtual NotFoundObjectResult NotFound(object value)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ControllerBase.Ok()
    
        
    
        
        Creates a :any:`Microsoft.AspNetCore.Mvc.OkResult` object that produces an empty OK (200) response.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.OkResult
        :return: The created :any:`Microsoft.AspNetCore.Mvc.OkResult` for the response.
    
        
        .. code-block:: csharp
    
            public virtual OkResult Ok()
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ControllerBase.Ok(System.Object)
    
        
    
        
        Creates an :any:`Microsoft.AspNetCore.Mvc.OkObjectResult` object that produces an OK (200) response.
    
        
    
        
        :param value: The content value to format in the entity body.
        
        :type value: System.Object
        :rtype: Microsoft.AspNetCore.Mvc.OkObjectResult
        :return: The created :any:`Microsoft.AspNetCore.Mvc.OkObjectResult` for the response.
    
        
        .. code-block:: csharp
    
            public virtual OkObjectResult Ok(object value)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ControllerBase.PhysicalFile(System.String, System.String)
    
        
    
        
        Returns the file specified by <em>physicalPath</em> with the
        specified <em>contentType</em> as the Content-Type.
    
        
    
        
        :param physicalPath: The physical path of the file to be returned.
        
        :type physicalPath: System.String
    
        
        :param contentType: The Content-Type of the file.
        
        :type contentType: System.String
        :rtype: Microsoft.AspNetCore.Mvc.PhysicalFileResult
        :return: The created :any:`Microsoft.AspNetCore.Mvc.PhysicalFileResult` for the response.
    
        
        .. code-block:: csharp
    
            public virtual PhysicalFileResult PhysicalFile(string physicalPath, string contentType)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ControllerBase.PhysicalFile(System.String, System.String, System.String)
    
        
    
        
        Returns the file specified by <em>physicalPath</em> with the
        specified <em>contentType</em> as the Content-Type and the
        specified <em>fileDownloadName</em> as the suggested file name.
    
        
    
        
        :param physicalPath: The physical path of the file to be returned.
        
        :type physicalPath: System.String
    
        
        :param contentType: The Content-Type of the file.
        
        :type contentType: System.String
    
        
        :param fileDownloadName: The suggested file name.
        
        :type fileDownloadName: System.String
        :rtype: Microsoft.AspNetCore.Mvc.PhysicalFileResult
        :return: The created :any:`Microsoft.AspNetCore.Mvc.PhysicalFileResult` for the response.
    
        
        .. code-block:: csharp
    
            public virtual PhysicalFileResult PhysicalFile(string physicalPath, string contentType, string fileDownloadName)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ControllerBase.Redirect(System.String)
    
        
    
        
        Creates a :any:`Microsoft.AspNetCore.Mvc.RedirectResult` object that redirects to the specified <em>url</em>.
    
        
    
        
        :param url: The URL to redirect to.
        
        :type url: System.String
        :rtype: Microsoft.AspNetCore.Mvc.RedirectResult
        :return: The created :any:`Microsoft.AspNetCore.Mvc.RedirectResult` for the response.
    
        
        .. code-block:: csharp
    
            public virtual RedirectResult Redirect(string url)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ControllerBase.RedirectPermanent(System.String)
    
        
    
        
        Creates a :any:`Microsoft.AspNetCore.Mvc.RedirectResult` object with :dn:prop:`Microsoft.AspNetCore.Mvc.RedirectResult.Permanent` set to true
        using the specified <em>url</em>.
    
        
    
        
        :param url: The URL to redirect to.
        
        :type url: System.String
        :rtype: Microsoft.AspNetCore.Mvc.RedirectResult
        :return: The created :any:`Microsoft.AspNetCore.Mvc.RedirectResult` for the response.
    
        
        .. code-block:: csharp
    
            public virtual RedirectResult RedirectPermanent(string url)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ControllerBase.RedirectToAction(System.String)
    
        
    
        
        Redirects to the specified action using the <em>actionName</em>.
    
        
    
        
        :param actionName: The name of the action.
        
        :type actionName: System.String
        :rtype: Microsoft.AspNetCore.Mvc.RedirectToActionResult
        :return: The created :any:`Microsoft.AspNetCore.Mvc.RedirectToActionResult` for the response.
    
        
        .. code-block:: csharp
    
            public virtual RedirectToActionResult RedirectToAction(string actionName)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ControllerBase.RedirectToAction(System.String, System.Object)
    
        
    
        
        Redirects to the specified action using the <em>actionName</em>
        and <em>routeValues</em>.
    
        
    
        
        :param actionName: The name of the action.
        
        :type actionName: System.String
    
        
        :param routeValues: The parameters for a route.
        
        :type routeValues: System.Object
        :rtype: Microsoft.AspNetCore.Mvc.RedirectToActionResult
        :return: The created :any:`Microsoft.AspNetCore.Mvc.RedirectToActionResult` for the response.
    
        
        .. code-block:: csharp
    
            public virtual RedirectToActionResult RedirectToAction(string actionName, object routeValues)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ControllerBase.RedirectToAction(System.String, System.String)
    
        
    
        
        Redirects to the specified action using the <em>actionName</em>
        and the <em>controllerName</em>.
    
        
    
        
        :param actionName: The name of the action.
        
        :type actionName: System.String
    
        
        :param controllerName: The name of the controller.
        
        :type controllerName: System.String
        :rtype: Microsoft.AspNetCore.Mvc.RedirectToActionResult
        :return: The created :any:`Microsoft.AspNetCore.Mvc.RedirectToActionResult` for the response.
    
        
        .. code-block:: csharp
    
            public virtual RedirectToActionResult RedirectToAction(string actionName, string controllerName)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ControllerBase.RedirectToAction(System.String, System.String, System.Object)
    
        
    
        
        Redirects to the specified action using the specified <em>actionName</em>,
        <em>controllerName</em>, and <em>routeValues</em>.
    
        
    
        
        :param actionName: The name of the action.
        
        :type actionName: System.String
    
        
        :param controllerName: The name of the controller.
        
        :type controllerName: System.String
    
        
        :param routeValues: The parameters for a route.
        
        :type routeValues: System.Object
        :rtype: Microsoft.AspNetCore.Mvc.RedirectToActionResult
        :return: The created :any:`Microsoft.AspNetCore.Mvc.RedirectToActionResult` for the response.
    
        
        .. code-block:: csharp
    
            public virtual RedirectToActionResult RedirectToAction(string actionName, string controllerName, object routeValues)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ControllerBase.RedirectToActionPermanent(System.String)
    
        
    
        
        Redirects to the specified action with :dn:prop:`Microsoft.AspNetCore.Mvc.RedirectToActionResult.Permanent` set to true
        using the specified <em>actionName</em>.
    
        
    
        
        :param actionName: The name of the action.
        
        :type actionName: System.String
        :rtype: Microsoft.AspNetCore.Mvc.RedirectToActionResult
        :return: The created :any:`Microsoft.AspNetCore.Mvc.RedirectToActionResult` for the response.
    
        
        .. code-block:: csharp
    
            public virtual RedirectToActionResult RedirectToActionPermanent(string actionName)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ControllerBase.RedirectToActionPermanent(System.String, System.Object)
    
        
    
        
        Redirects to the specified action with :dn:prop:`Microsoft.AspNetCore.Mvc.RedirectToActionResult.Permanent` set to true
        using the specified <em>actionName</em> and <em>routeValues</em>.
    
        
    
        
        :param actionName: The name of the action.
        
        :type actionName: System.String
    
        
        :param routeValues: The parameters for a route.
        
        :type routeValues: System.Object
        :rtype: Microsoft.AspNetCore.Mvc.RedirectToActionResult
        :return: The created :any:`Microsoft.AspNetCore.Mvc.RedirectToActionResult` for the response.
    
        
        .. code-block:: csharp
    
            public virtual RedirectToActionResult RedirectToActionPermanent(string actionName, object routeValues)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ControllerBase.RedirectToActionPermanent(System.String, System.String)
    
        
    
        
        Redirects to the specified action with :dn:prop:`Microsoft.AspNetCore.Mvc.RedirectToActionResult.Permanent` set to true
        using the specified <em>actionName</em> and <em>controllerName</em>.
    
        
    
        
        :param actionName: The name of the action.
        
        :type actionName: System.String
    
        
        :param controllerName: The name of the controller.
        
        :type controllerName: System.String
        :rtype: Microsoft.AspNetCore.Mvc.RedirectToActionResult
        :return: The created :any:`Microsoft.AspNetCore.Mvc.RedirectToActionResult` for the response.
    
        
        .. code-block:: csharp
    
            public virtual RedirectToActionResult RedirectToActionPermanent(string actionName, string controllerName)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ControllerBase.RedirectToActionPermanent(System.String, System.String, System.Object)
    
        
    
        
        Redirects to the specified action with :dn:prop:`Microsoft.AspNetCore.Mvc.RedirectToActionResult.Permanent` set to true
        using the specified <em>actionName</em>, <em>controllerName</em>,
        and <em>routeValues</em>.
    
        
    
        
        :param actionName: The name of the action.
        
        :type actionName: System.String
    
        
        :param controllerName: The name of the controller.
        
        :type controllerName: System.String
    
        
        :param routeValues: The parameters for a route.
        
        :type routeValues: System.Object
        :rtype: Microsoft.AspNetCore.Mvc.RedirectToActionResult
        :return: The created :any:`Microsoft.AspNetCore.Mvc.RedirectToActionResult` for the response.
    
        
        .. code-block:: csharp
    
            public virtual RedirectToActionResult RedirectToActionPermanent(string actionName, string controllerName, object routeValues)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ControllerBase.RedirectToRoute(System.Object)
    
        
    
        
        Redirects to the specified route using the specified <em>routeValues</em>.
    
        
    
        
        :param routeValues: The parameters for a route.
        
        :type routeValues: System.Object
        :rtype: Microsoft.AspNetCore.Mvc.RedirectToRouteResult
        :return: The created :any:`Microsoft.AspNetCore.Mvc.RedirectToRouteResult` for the response.
    
        
        .. code-block:: csharp
    
            public virtual RedirectToRouteResult RedirectToRoute(object routeValues)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ControllerBase.RedirectToRoute(System.String)
    
        
    
        
        Redirects to the specified route using the specified <em>routeName</em>.
    
        
    
        
        :param routeName: The name of the route.
        
        :type routeName: System.String
        :rtype: Microsoft.AspNetCore.Mvc.RedirectToRouteResult
        :return: The created :any:`Microsoft.AspNetCore.Mvc.RedirectToRouteResult` for the response.
    
        
        .. code-block:: csharp
    
            public virtual RedirectToRouteResult RedirectToRoute(string routeName)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ControllerBase.RedirectToRoute(System.String, System.Object)
    
        
    
        
        Redirects to the specified route using the specified <em>routeName</em>
        and <em>routeValues</em>.
    
        
    
        
        :param routeName: The name of the route.
        
        :type routeName: System.String
    
        
        :param routeValues: The parameters for a route.
        
        :type routeValues: System.Object
        :rtype: Microsoft.AspNetCore.Mvc.RedirectToRouteResult
        :return: The created :any:`Microsoft.AspNetCore.Mvc.RedirectToRouteResult` for the response.
    
        
        .. code-block:: csharp
    
            public virtual RedirectToRouteResult RedirectToRoute(string routeName, object routeValues)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ControllerBase.RedirectToRoutePermanent(System.Object)
    
        
    
        
        Redirects to the specified route with :dn:prop:`Microsoft.AspNetCore.Mvc.RedirectToRouteResult.Permanent` set to true
        using the specified <em>routeValues</em>.
    
        
    
        
        :param routeValues: The parameters for a route.
        
        :type routeValues: System.Object
        :rtype: Microsoft.AspNetCore.Mvc.RedirectToRouteResult
        :return: The created :any:`Microsoft.AspNetCore.Mvc.RedirectToRouteResult` for the response.
    
        
        .. code-block:: csharp
    
            public virtual RedirectToRouteResult RedirectToRoutePermanent(object routeValues)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ControllerBase.RedirectToRoutePermanent(System.String)
    
        
    
        
        Redirects to the specified route with :dn:prop:`Microsoft.AspNetCore.Mvc.RedirectToRouteResult.Permanent` set to true
        using the specified <em>routeName</em>.
    
        
    
        
        :param routeName: The name of the route.
        
        :type routeName: System.String
        :rtype: Microsoft.AspNetCore.Mvc.RedirectToRouteResult
        :return: The created :any:`Microsoft.AspNetCore.Mvc.RedirectToRouteResult` for the response.
    
        
        .. code-block:: csharp
    
            public virtual RedirectToRouteResult RedirectToRoutePermanent(string routeName)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ControllerBase.RedirectToRoutePermanent(System.String, System.Object)
    
        
    
        
        Redirects to the specified route with :dn:prop:`Microsoft.AspNetCore.Mvc.RedirectToRouteResult.Permanent` set to true
        using the specified <em>routeName</em> and <em>routeValues</em>.
    
        
    
        
        :param routeName: The name of the route.
        
        :type routeName: System.String
    
        
        :param routeValues: The parameters for a route.
        
        :type routeValues: System.Object
        :rtype: Microsoft.AspNetCore.Mvc.RedirectToRouteResult
        :return: The created :any:`Microsoft.AspNetCore.Mvc.RedirectToRouteResult` for the response.
    
        
        .. code-block:: csharp
    
            public virtual RedirectToRouteResult RedirectToRoutePermanent(string routeName, object routeValues)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ControllerBase.SignIn(System.Security.Claims.ClaimsPrincipal, Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties, System.String)
    
        
    
        
        Creates a :any:`Microsoft.AspNetCore.Mvc.SignInResult` with the specified specified authentication scheme and
        <em>properties</em>.
    
        
    
        
        :param principal: The :any:`System.Security.Claims.ClaimsPrincipal` containing the user claims.
        
        :type principal: System.Security.Claims.ClaimsPrincipal
    
        
        :param properties: :any:`Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties` used to perform the sign-in operation.
        
        :type properties: Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties
    
        
        :param authenticationScheme: The authentication scheme to use for the sign-in operation.
        
        :type authenticationScheme: System.String
        :rtype: Microsoft.AspNetCore.Mvc.SignInResult
        :return: The created :any:`Microsoft.AspNetCore.Mvc.SignInResult` for the response.
    
        
        .. code-block:: csharp
    
            public virtual SignInResult SignIn(ClaimsPrincipal principal, AuthenticationProperties properties, string authenticationScheme)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ControllerBase.SignIn(System.Security.Claims.ClaimsPrincipal, System.String)
    
        
    
        
        Creates a :any:`Microsoft.AspNetCore.Mvc.SignInResult` with the specified authentication scheme.
    
        
    
        
        :param principal: The :any:`System.Security.Claims.ClaimsPrincipal` containing the user claims.
        
        :type principal: System.Security.Claims.ClaimsPrincipal
    
        
        :param authenticationScheme: The authentication scheme to use for the sign-in operation.
        
        :type authenticationScheme: System.String
        :rtype: Microsoft.AspNetCore.Mvc.SignInResult
        :return: The created :any:`Microsoft.AspNetCore.Mvc.SignInResult` for the response.
    
        
        .. code-block:: csharp
    
            public virtual SignInResult SignIn(ClaimsPrincipal principal, string authenticationScheme)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ControllerBase.SignOut(Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties, System.String[])
    
        
    
        
        Creates a :any:`Microsoft.AspNetCore.Mvc.SignOutResult` with the specified specified authentication schemes and
        <em>properties</em>.
    
        
    
        
        :param properties: :any:`Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties` used to perform the sign-out operation.
        
        :type properties: Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties
    
        
        :param authenticationSchemes: The authentication scheme to use for the sign-out operation.
        
        :type authenticationSchemes: System.String<System.String>[]
        :rtype: Microsoft.AspNetCore.Mvc.SignOutResult
        :return: The created :any:`Microsoft.AspNetCore.Mvc.SignOutResult` for the response.
    
        
        .. code-block:: csharp
    
            public virtual SignOutResult SignOut(AuthenticationProperties properties, params string[] authenticationSchemes)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ControllerBase.SignOut(System.String[])
    
        
    
        
        Creates a :any:`Microsoft.AspNetCore.Mvc.SignOutResult` with the specified authentication schemes.
    
        
    
        
        :param authenticationSchemes: The authentication schemes to use for the sign-out operation.
        
        :type authenticationSchemes: System.String<System.String>[]
        :rtype: Microsoft.AspNetCore.Mvc.SignOutResult
        :return: The created :any:`Microsoft.AspNetCore.Mvc.SignOutResult` for the response.
    
        
        .. code-block:: csharp
    
            public virtual SignOutResult SignOut(params string[] authenticationSchemes)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ControllerBase.StatusCode(System.Int32)
    
        
    
        
        Creates a :any:`Microsoft.AspNetCore.Mvc.StatusCodeResult` object by specifying a <em>statusCode</em>.
    
        
    
        
        :param statusCode: The status code to set on the response.
        
        :type statusCode: System.Int32
        :rtype: Microsoft.AspNetCore.Mvc.StatusCodeResult
        :return: The created :any:`Microsoft.AspNetCore.Mvc.StatusCodeResult` object for the response.
    
        
        .. code-block:: csharp
    
            public virtual StatusCodeResult StatusCode(int statusCode)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ControllerBase.StatusCode(System.Int32, System.Object)
    
        
    
        
        Creates a :any:`Microsoft.AspNetCore.Mvc.ObjectResult` object by specifying a <em>statusCode</em> and <em>value</em>
    
        
    
        
        :param statusCode: The status code to set on the response.
        
        :type statusCode: System.Int32
    
        
        :param value: The value to set on the :any:`Microsoft.AspNetCore.Mvc.ObjectResult`\.
        
        :type value: System.Object
        :rtype: Microsoft.AspNetCore.Mvc.ObjectResult
        :return: The created :any:`Microsoft.AspNetCore.Mvc.ObjectResult` object for the response.
    
        
        .. code-block:: csharp
    
            public virtual ObjectResult StatusCode(int statusCode, object value)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ControllerBase.TryUpdateModelAsync(System.Object, System.Type, System.String)
    
        
    
        
        Updates the specified <em>model</em> instance using values from the controller's current
        :any:`Microsoft.AspNetCore.Mvc.ModelBinding.IValueProvider` and a <em>prefix</em>.
    
        
    
        
        :param model: The model instance to update.
        
        :type model: System.Object
    
        
        :param modelType: The type of model instance to update.
        
        :type modelType: System.Type
    
        
        :param prefix: The prefix to use when looking up values in the current :any:`Microsoft.AspNetCore.Mvc.ModelBinding.IValueProvider`\.
            
        
        :type prefix: System.String
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Boolean<System.Boolean>}
        :return: A :any:`System.Threading.Tasks.Task` that on completion returns <code>true</code> if the update is successful.
    
        
        .. code-block:: csharp
    
            public virtual Task<bool> TryUpdateModelAsync(object model, Type modelType, string prefix)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ControllerBase.TryUpdateModelAsync(System.Object, System.Type, System.String, Microsoft.AspNetCore.Mvc.ModelBinding.IValueProvider, System.Func<Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata, System.Boolean>)
    
        
    
        
        Updates the specified <em>model</em> instance using the <em>valueProvider</em> and a
        <em>prefix</em>.
    
        
    
        
        :param model: The model instance to update.
        
        :type model: System.Object
    
        
        :param modelType: The type of model instance to update.
        
        :type modelType: System.Type
    
        
        :param prefix: The prefix to use when looking up values in the <em>valueProvider</em>.
            
        
        :type prefix: System.String
    
        
        :param valueProvider: The :any:`Microsoft.AspNetCore.Mvc.ModelBinding.IValueProvider` used for looking up values.
        
        :type valueProvider: Microsoft.AspNetCore.Mvc.ModelBinding.IValueProvider
    
        
        :param propertyFilter: A predicate which can be used to filter properties at runtime.
        
        :type propertyFilter: System.Func<System.Func`2>{Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata<Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata>, System.Boolean<System.Boolean>}
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Boolean<System.Boolean>}
        :return: A :any:`System.Threading.Tasks.Task` that on completion returns <code>true</code> if the update is successful.
    
        
        .. code-block:: csharp
    
            public Task<bool> TryUpdateModelAsync(object model, Type modelType, string prefix, IValueProvider valueProvider, Func<ModelMetadata, bool> propertyFilter)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ControllerBase.TryUpdateModelAsync<TModel>(TModel)
    
        
    
        
        Updates the specified <em>model</em> instance using values from the controller's current
        :any:`Microsoft.AspNetCore.Mvc.ModelBinding.IValueProvider`\.
    
        
    
        
        :param model: The model instance to update.
        
        :type model: TModel
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Boolean<System.Boolean>}
        :return: A :any:`System.Threading.Tasks.Task` that on completion returns <code>true</code> if the update is successful.
    
        
        .. code-block:: csharp
    
            public virtual Task<bool> TryUpdateModelAsync<TModel>(TModel model)where TModel : class
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ControllerBase.TryUpdateModelAsync<TModel>(TModel, System.String)
    
        
    
        
        Updates the specified <em>model</em> instance using values from the controller's current
        :any:`Microsoft.AspNetCore.Mvc.ModelBinding.IValueProvider` and a <em>prefix</em>.
    
        
    
        
        :param model: The model instance to update.
        
        :type model: TModel
    
        
        :param prefix: The prefix to use when looking up values in the current :any:`Microsoft.AspNetCore.Mvc.ModelBinding.IValueProvider`\.
            
        
        :type prefix: System.String
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Boolean<System.Boolean>}
        :return: A :any:`System.Threading.Tasks.Task` that on completion returns <code>true</code> if the update is successful.
    
        
        .. code-block:: csharp
    
            public virtual Task<bool> TryUpdateModelAsync<TModel>(TModel model, string prefix)where TModel : class
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ControllerBase.TryUpdateModelAsync<TModel>(TModel, System.String, Microsoft.AspNetCore.Mvc.ModelBinding.IValueProvider)
    
        
    
        
        Updates the specified <em>model</em> instance using the <em>valueProvider</em> and a
        <em>prefix</em>.
    
        
    
        
        :param model: The model instance to update.
        
        :type model: TModel
    
        
        :param prefix: The prefix to use when looking up values in the <em>valueProvider</em>.
            
        
        :type prefix: System.String
    
        
        :param valueProvider: The :any:`Microsoft.AspNetCore.Mvc.ModelBinding.IValueProvider` used for looking up values.
        
        :type valueProvider: Microsoft.AspNetCore.Mvc.ModelBinding.IValueProvider
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Boolean<System.Boolean>}
        :return: A :any:`System.Threading.Tasks.Task` that on completion returns <code>true</code> if the update is successful.
    
        
        .. code-block:: csharp
    
            public virtual Task<bool> TryUpdateModelAsync<TModel>(TModel model, string prefix, IValueProvider valueProvider)where TModel : class
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ControllerBase.TryUpdateModelAsync<TModel>(TModel, System.String, Microsoft.AspNetCore.Mvc.ModelBinding.IValueProvider, System.Func<Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata, System.Boolean>)
    
        
    
        
        Updates the specified <em>model</em> instance using the <em>valueProvider</em> and a
        <em>prefix</em>.
    
        
    
        
        :param model: The model instance to update.
        
        :type model: TModel
    
        
        :param prefix: The prefix to use when looking up values in the <em>valueProvider</em>.
            
        
        :type prefix: System.String
    
        
        :param valueProvider: The :any:`Microsoft.AspNetCore.Mvc.ModelBinding.IValueProvider` used for looking up values.
        
        :type valueProvider: Microsoft.AspNetCore.Mvc.ModelBinding.IValueProvider
    
        
        :param propertyFilter: A predicate which can be used to filter properties at runtime.
        
        :type propertyFilter: System.Func<System.Func`2>{Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata<Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata>, System.Boolean<System.Boolean>}
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Boolean<System.Boolean>}
        :return: A :any:`System.Threading.Tasks.Task` that on completion returns <code>true</code> if the update is successful.
    
        
        .. code-block:: csharp
    
            public Task<bool> TryUpdateModelAsync<TModel>(TModel model, string prefix, IValueProvider valueProvider, Func<ModelMetadata, bool> propertyFilter)where TModel : class
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ControllerBase.TryUpdateModelAsync<TModel>(TModel, System.String, Microsoft.AspNetCore.Mvc.ModelBinding.IValueProvider, System.Linq.Expressions.Expression<System.Func<TModel, System.Object>>[])
    
        
    
        
        Updates the specified <em>model</em> instance using the <em>valueProvider</em> and a
        <em>prefix</em>.
    
        
    
        
        :param model: The model instance to update.
        
        :type model: TModel
    
        
        :param prefix: The prefix to use when looking up values in the <em>valueProvider</em>.
            
        
        :type prefix: System.String
    
        
        :param valueProvider: The :any:`Microsoft.AspNetCore.Mvc.ModelBinding.IValueProvider` used for looking up values.
        
        :type valueProvider: Microsoft.AspNetCore.Mvc.ModelBinding.IValueProvider
    
        
        :param includeExpressions:  :any:`System.Linq.Expressions.Expression`\(s) which represent top-level properties
            which need to be included for the current model.
        
        :type includeExpressions: System.Linq.Expressions.Expression<System.Linq.Expressions.Expression`1>{System.Func<System.Func`2>{TModel, System.Object<System.Object>}}[]
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Boolean<System.Boolean>}
        :return: A :any:`System.Threading.Tasks.Task` that on completion returns <code>true</code> if the update is successful.
    
        
        .. code-block:: csharp
    
            public Task<bool> TryUpdateModelAsync<TModel>(TModel model, string prefix, IValueProvider valueProvider, params Expression<Func<TModel, object>>[] includeExpressions)where TModel : class
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ControllerBase.TryUpdateModelAsync<TModel>(TModel, System.String, System.Func<Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata, System.Boolean>)
    
        
    
        
        Updates the specified <em>model</em> instance using values from the controller's current
        :any:`Microsoft.AspNetCore.Mvc.ModelBinding.IValueProvider` and a <em>prefix</em>.
    
        
    
        
        :param model: The model instance to update.
        
        :type model: TModel
    
        
        :param prefix: The prefix to use when looking up values in the current :any:`Microsoft.AspNetCore.Mvc.ModelBinding.IValueProvider`\.
            
        
        :type prefix: System.String
    
        
        :param propertyFilter: A predicate which can be used to filter properties at runtime.
        
        :type propertyFilter: System.Func<System.Func`2>{Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata<Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata>, System.Boolean<System.Boolean>}
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Boolean<System.Boolean>}
        :return: A :any:`System.Threading.Tasks.Task` that on completion returns <code>true</code> if the update is successful.
    
        
        .. code-block:: csharp
    
            public Task<bool> TryUpdateModelAsync<TModel>(TModel model, string prefix, Func<ModelMetadata, bool> propertyFilter)where TModel : class
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ControllerBase.TryUpdateModelAsync<TModel>(TModel, System.String, System.Linq.Expressions.Expression<System.Func<TModel, System.Object>>[])
    
        
    
        
        Updates the specified <em>model</em> instance using values from the controller's current
        :any:`Microsoft.AspNetCore.Mvc.ModelBinding.IValueProvider` and a <em>prefix</em>.
    
        
    
        
        :param model: The model instance to update.
        
        :type model: TModel
    
        
        :param prefix: The prefix to use when looking up values in the current :any:`Microsoft.AspNetCore.Mvc.ModelBinding.IValueProvider`\.
            
        
        :type prefix: System.String
    
        
        :param includeExpressions:  :any:`System.Linq.Expressions.Expression`\(s) which represent top-level properties
            which need to be included for the current model.
        
        :type includeExpressions: System.Linq.Expressions.Expression<System.Linq.Expressions.Expression`1>{System.Func<System.Func`2>{TModel, System.Object<System.Object>}}[]
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Boolean<System.Boolean>}
        :return: A :any:`System.Threading.Tasks.Task` that on completion returns <code>true</code> if the update is successful.
    
        
        .. code-block:: csharp
    
            public Task<bool> TryUpdateModelAsync<TModel>(TModel model, string prefix, params Expression<Func<TModel, object>>[] includeExpressions)where TModel : class
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ControllerBase.TryValidateModel(System.Object)
    
        
    
        
        Validates the specified <em>model</em> instance.
    
        
    
        
        :param model: The model to validate.
        
        :type model: System.Object
        :rtype: System.Boolean
        :return: <code>true</code> if the :dn:prop:`Microsoft.AspNetCore.Mvc.ControllerBase.ModelState` is valid; <code>false</code> otherwise.
    
        
        .. code-block:: csharp
    
            public virtual bool TryValidateModel(object model)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ControllerBase.TryValidateModel(System.Object, System.String)
    
        
    
        
        Validates the specified <em>model</em> instance.
    
        
    
        
        :param model: The model to validate.
        
        :type model: System.Object
    
        
        :param prefix: The key to use when looking up information in :dn:prop:`Microsoft.AspNetCore.Mvc.ControllerBase.ModelState`\.
            
        
        :type prefix: System.String
        :rtype: System.Boolean
        :return: <code>true</code> if the :dn:prop:`Microsoft.AspNetCore.Mvc.ControllerBase.ModelState` is valid;<code>false</code> otherwise.
    
        
        .. code-block:: csharp
    
            public virtual bool TryValidateModel(object model, string prefix)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ControllerBase.Unauthorized()
    
        
    
        
        Creates an :any:`Microsoft.AspNetCore.Mvc.UnauthorizedResult` that produces an Unauthorized (401) response.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.UnauthorizedResult
        :return: The created :any:`Microsoft.AspNetCore.Mvc.UnauthorizedResult` for the response.
    
        
        .. code-block:: csharp
    
            public virtual UnauthorizedResult Unauthorized()
    

