

HttpContext Class
=================



.. contents:: 
   :local:



Summary
-------

Encapsulates all HTTP-specific information about an individual HTTP request.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Http.HttpContext`








Syntax
------

.. code-block:: csharp

   public abstract class HttpContext





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/httpabstractions/src/Microsoft.AspNet.Http.Abstractions/HttpContext.cs>`_





.. dn:class:: Microsoft.AspNet.Http.HttpContext

Methods
-------

.. dn:class:: Microsoft.AspNet.Http.HttpContext
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Http.HttpContext.Abort()
    
        
    
        Aborts the connection underlying this request.
    
        
    
        
        .. code-block:: csharp
    
           public abstract void Abort()
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Http.HttpContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Http.HttpContext.ApplicationServices
    
        
    
        Gets or sets the :any:`System.IServiceProvider` that provides access to the application's service container.
    
        
        :rtype: System.IServiceProvider
    
        
        .. code-block:: csharp
    
           public abstract IServiceProvider ApplicationServices { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.HttpContext.Authentication
    
        
    
        Gets an object that facilitates authentication for this request.
    
        
        :rtype: Microsoft.AspNet.Http.Authentication.AuthenticationManager
    
        
        .. code-block:: csharp
    
           public abstract AuthenticationManager Authentication { get; }
    
    .. dn:property:: Microsoft.AspNet.Http.HttpContext.Connection
    
        
    
        Gets information about the underlying connection for this request.
    
        
        :rtype: Microsoft.AspNet.Http.ConnectionInfo
    
        
        .. code-block:: csharp
    
           public abstract ConnectionInfo Connection { get; }
    
    .. dn:property:: Microsoft.AspNet.Http.HttpContext.Features
    
        
    
        Gets the collection of HTTP features provided by the server and middleware available on this request.
    
        
        :rtype: Microsoft.AspNet.Http.Features.IFeatureCollection
    
        
        .. code-block:: csharp
    
           public abstract IFeatureCollection Features { get; }
    
    .. dn:property:: Microsoft.AspNet.Http.HttpContext.Items
    
        
    
        Gets or sets a key/value collection that can be used to share data within the scope of this request.
    
        
        :rtype: System.Collections.Generic.IDictionary{System.Object,System.Object}
    
        
        .. code-block:: csharp
    
           public abstract IDictionary<object, object> Items { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.HttpContext.Request
    
        
    
        Gets the :any:`Microsoft.AspNet.Http.HttpRequest` object for this request.
    
        
        :rtype: Microsoft.AspNet.Http.HttpRequest
    
        
        .. code-block:: csharp
    
           public abstract HttpRequest Request { get; }
    
    .. dn:property:: Microsoft.AspNet.Http.HttpContext.RequestAborted
    
        
    
        Notifies when the connection underlying this request is aborted and thus request operations should be
        cancelled.
    
        
        :rtype: System.Threading.CancellationToken
    
        
        .. code-block:: csharp
    
           public abstract CancellationToken RequestAborted { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.HttpContext.RequestServices
    
        
    
        Gets or sets the :any:`System.IServiceProvider` that provides access to the request's service container.
    
        
        :rtype: System.IServiceProvider
    
        
        .. code-block:: csharp
    
           public abstract IServiceProvider RequestServices { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.HttpContext.Response
    
        
    
        Gets the :any:`Microsoft.AspNet.Http.HttpResponse` object for this request.
    
        
        :rtype: Microsoft.AspNet.Http.HttpResponse
    
        
        .. code-block:: csharp
    
           public abstract HttpResponse Response { get; }
    
    .. dn:property:: Microsoft.AspNet.Http.HttpContext.Session
    
        
    
        Gets or sets the object used to manage user session data for this request.
    
        
        :rtype: Microsoft.AspNet.Http.Features.ISession
    
        
        .. code-block:: csharp
    
           public abstract ISession Session { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.HttpContext.TraceIdentifier
    
        
    
        Gets or sets a unique identifier to represent this request in trace logs.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public abstract string TraceIdentifier { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.HttpContext.User
    
        
    
        Gets or sets the the user for this request.
    
        
        :rtype: System.Security.Claims.ClaimsPrincipal
    
        
        .. code-block:: csharp
    
           public abstract ClaimsPrincipal User { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.HttpContext.WebSockets
    
        
    
        Gets an object that manages the establishment of WebSocket connections for this request.
    
        
        :rtype: Microsoft.AspNet.Http.WebSocketManager
    
        
        .. code-block:: csharp
    
           public abstract WebSocketManager WebSockets { get; }
    

