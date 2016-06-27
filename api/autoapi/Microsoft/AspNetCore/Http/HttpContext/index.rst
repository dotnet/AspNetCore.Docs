

HttpContext Class
=================






Encapsulates all HTTP-specific information about an individual HTTP request.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Http`
Assemblies
    * Microsoft.AspNetCore.Http.Abstractions

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Http.HttpContext`








Syntax
------

.. code-block:: csharp

    public abstract class HttpContext








.. dn:class:: Microsoft.AspNetCore.Http.HttpContext
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Http.HttpContext

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Http.HttpContext
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Http.HttpContext.Abort()
    
        
    
        
        Aborts the connection underlying this request.
    
        
    
        
        .. code-block:: csharp
    
            public abstract void Abort()
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Http.HttpContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Http.HttpContext.Authentication
    
        
    
        
        Gets an object that facilitates authentication for this request.
    
        
        :rtype: Microsoft.AspNetCore.Http.Authentication.AuthenticationManager
    
        
        .. code-block:: csharp
    
            public abstract AuthenticationManager Authentication { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Http.HttpContext.Connection
    
        
    
        
        Gets information about the underlying connection for this request.
    
        
        :rtype: Microsoft.AspNetCore.Http.ConnectionInfo
    
        
        .. code-block:: csharp
    
            public abstract ConnectionInfo Connection { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Http.HttpContext.Features
    
        
    
        
        Gets the collection of HTTP features provided by the server and middleware available on this request.
    
        
        :rtype: Microsoft.AspNetCore.Http.Features.IFeatureCollection
    
        
        .. code-block:: csharp
    
            public abstract IFeatureCollection Features { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Http.HttpContext.Items
    
        
    
        
        Gets or sets a key/value collection that can be used to share data within the scope of this request.
    
        
        :rtype: System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{System.Object<System.Object>, System.Object<System.Object>}
    
        
        .. code-block:: csharp
    
            public abstract IDictionary<object, object> Items { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Http.HttpContext.Request
    
        
    
        
        Gets the :any:`Microsoft.AspNetCore.Http.HttpRequest` object for this request.
    
        
        :rtype: Microsoft.AspNetCore.Http.HttpRequest
    
        
        .. code-block:: csharp
    
            public abstract HttpRequest Request { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Http.HttpContext.RequestAborted
    
        
    
        
        Notifies when the connection underlying this request is aborted and thus request operations should be
        cancelled.
    
        
        :rtype: System.Threading.CancellationToken
    
        
        .. code-block:: csharp
    
            public abstract CancellationToken RequestAborted { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Http.HttpContext.RequestServices
    
        
    
        
        Gets or sets the :any:`System.IServiceProvider` that provides access to the request's service container.
    
        
        :rtype: System.IServiceProvider
    
        
        .. code-block:: csharp
    
            public abstract IServiceProvider RequestServices { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Http.HttpContext.Response
    
        
    
        
        Gets the :any:`Microsoft.AspNetCore.Http.HttpResponse` object for this request.
    
        
        :rtype: Microsoft.AspNetCore.Http.HttpResponse
    
        
        .. code-block:: csharp
    
            public abstract HttpResponse Response { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Http.HttpContext.Session
    
        
    
        
        Gets or sets the object used to manage user session data for this request.
    
        
        :rtype: Microsoft.AspNetCore.Http.ISession
    
        
        .. code-block:: csharp
    
            public abstract ISession Session { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Http.HttpContext.TraceIdentifier
    
        
    
        
        Gets or sets a unique identifier to represent this request in trace logs.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public abstract string TraceIdentifier { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Http.HttpContext.User
    
        
    
        
        Gets or sets the the user for this request.
    
        
        :rtype: System.Security.Claims.ClaimsPrincipal
    
        
        .. code-block:: csharp
    
            public abstract ClaimsPrincipal User { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Http.HttpContext.WebSockets
    
        
    
        
        Gets an object that manages the establishment of WebSocket connections for this request.
    
        
        :rtype: Microsoft.AspNetCore.Http.WebSocketManager
    
        
        .. code-block:: csharp
    
            public abstract WebSocketManager WebSockets { get; }
    

