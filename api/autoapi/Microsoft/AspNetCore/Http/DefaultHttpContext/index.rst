

DefaultHttpContext Class
========================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Http`
Assemblies
    * Microsoft.AspNetCore.Http

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Http.HttpContext`
* :dn:cls:`Microsoft.AspNetCore.Http.DefaultHttpContext`








Syntax
------

.. code-block:: csharp

    public class DefaultHttpContext : HttpContext








.. dn:class:: Microsoft.AspNetCore.Http.DefaultHttpContext
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Http.DefaultHttpContext

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Http.DefaultHttpContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Http.DefaultHttpContext.DefaultHttpContext()
    
        
    
        
        .. code-block:: csharp
    
            public DefaultHttpContext()
    
    .. dn:constructor:: Microsoft.AspNetCore.Http.DefaultHttpContext.DefaultHttpContext(Microsoft.AspNetCore.Http.Features.IFeatureCollection)
    
        
    
        
        :type features: Microsoft.AspNetCore.Http.Features.IFeatureCollection
    
        
        .. code-block:: csharp
    
            public DefaultHttpContext(IFeatureCollection features)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Http.DefaultHttpContext
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Http.DefaultHttpContext.Abort()
    
        
    
        
        .. code-block:: csharp
    
            public override void Abort()
    
    .. dn:method:: Microsoft.AspNetCore.Http.DefaultHttpContext.Initialize(Microsoft.AspNetCore.Http.Features.IFeatureCollection)
    
        
    
        
        :type features: Microsoft.AspNetCore.Http.Features.IFeatureCollection
    
        
        .. code-block:: csharp
    
            public virtual void Initialize(IFeatureCollection features)
    
    .. dn:method:: Microsoft.AspNetCore.Http.DefaultHttpContext.InitializeAuthenticationManager()
    
        
        :rtype: Microsoft.AspNetCore.Http.Authentication.AuthenticationManager
    
        
        .. code-block:: csharp
    
            protected virtual AuthenticationManager InitializeAuthenticationManager()
    
    .. dn:method:: Microsoft.AspNetCore.Http.DefaultHttpContext.InitializeConnectionInfo()
    
        
        :rtype: Microsoft.AspNetCore.Http.ConnectionInfo
    
        
        .. code-block:: csharp
    
            protected virtual ConnectionInfo InitializeConnectionInfo()
    
    .. dn:method:: Microsoft.AspNetCore.Http.DefaultHttpContext.InitializeHttpRequest()
    
        
        :rtype: Microsoft.AspNetCore.Http.HttpRequest
    
        
        .. code-block:: csharp
    
            protected virtual HttpRequest InitializeHttpRequest()
    
    .. dn:method:: Microsoft.AspNetCore.Http.DefaultHttpContext.InitializeHttpResponse()
    
        
        :rtype: Microsoft.AspNetCore.Http.HttpResponse
    
        
        .. code-block:: csharp
    
            protected virtual HttpResponse InitializeHttpResponse()
    
    .. dn:method:: Microsoft.AspNetCore.Http.DefaultHttpContext.InitializeWebSocketManager()
    
        
        :rtype: Microsoft.AspNetCore.Http.WebSocketManager
    
        
        .. code-block:: csharp
    
            protected virtual WebSocketManager InitializeWebSocketManager()
    
    .. dn:method:: Microsoft.AspNetCore.Http.DefaultHttpContext.Uninitialize()
    
        
    
        
        .. code-block:: csharp
    
            public virtual void Uninitialize()
    
    .. dn:method:: Microsoft.AspNetCore.Http.DefaultHttpContext.UninitializeAuthenticationManager(Microsoft.AspNetCore.Http.Authentication.AuthenticationManager)
    
        
    
        
        :type instance: Microsoft.AspNetCore.Http.Authentication.AuthenticationManager
    
        
        .. code-block:: csharp
    
            protected virtual void UninitializeAuthenticationManager(AuthenticationManager instance)
    
    .. dn:method:: Microsoft.AspNetCore.Http.DefaultHttpContext.UninitializeConnectionInfo(Microsoft.AspNetCore.Http.ConnectionInfo)
    
        
    
        
        :type instance: Microsoft.AspNetCore.Http.ConnectionInfo
    
        
        .. code-block:: csharp
    
            protected virtual void UninitializeConnectionInfo(ConnectionInfo instance)
    
    .. dn:method:: Microsoft.AspNetCore.Http.DefaultHttpContext.UninitializeHttpRequest(Microsoft.AspNetCore.Http.HttpRequest)
    
        
    
        
        :type instance: Microsoft.AspNetCore.Http.HttpRequest
    
        
        .. code-block:: csharp
    
            protected virtual void UninitializeHttpRequest(HttpRequest instance)
    
    .. dn:method:: Microsoft.AspNetCore.Http.DefaultHttpContext.UninitializeHttpResponse(Microsoft.AspNetCore.Http.HttpResponse)
    
        
    
        
        :type instance: Microsoft.AspNetCore.Http.HttpResponse
    
        
        .. code-block:: csharp
    
            protected virtual void UninitializeHttpResponse(HttpResponse instance)
    
    .. dn:method:: Microsoft.AspNetCore.Http.DefaultHttpContext.UninitializeWebSocketManager(Microsoft.AspNetCore.Http.WebSocketManager)
    
        
    
        
        :type instance: Microsoft.AspNetCore.Http.WebSocketManager
    
        
        .. code-block:: csharp
    
            protected virtual void UninitializeWebSocketManager(WebSocketManager instance)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Http.DefaultHttpContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Http.DefaultHttpContext.Authentication
    
        
        :rtype: Microsoft.AspNetCore.Http.Authentication.AuthenticationManager
    
        
        .. code-block:: csharp
    
            public override AuthenticationManager Authentication { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Http.DefaultHttpContext.Connection
    
        
        :rtype: Microsoft.AspNetCore.Http.ConnectionInfo
    
        
        .. code-block:: csharp
    
            public override ConnectionInfo Connection { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Http.DefaultHttpContext.Features
    
        
        :rtype: Microsoft.AspNetCore.Http.Features.IFeatureCollection
    
        
        .. code-block:: csharp
    
            public override IFeatureCollection Features { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Http.DefaultHttpContext.Items
    
        
        :rtype: System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{System.Object<System.Object>, System.Object<System.Object>}
    
        
        .. code-block:: csharp
    
            public override IDictionary<object, object> Items { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Http.DefaultHttpContext.Request
    
        
        :rtype: Microsoft.AspNetCore.Http.HttpRequest
    
        
        .. code-block:: csharp
    
            public override HttpRequest Request { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Http.DefaultHttpContext.RequestAborted
    
        
        :rtype: System.Threading.CancellationToken
    
        
        .. code-block:: csharp
    
            public override CancellationToken RequestAborted { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Http.DefaultHttpContext.RequestServices
    
        
        :rtype: System.IServiceProvider
    
        
        .. code-block:: csharp
    
            public override IServiceProvider RequestServices { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Http.DefaultHttpContext.Response
    
        
        :rtype: Microsoft.AspNetCore.Http.HttpResponse
    
        
        .. code-block:: csharp
    
            public override HttpResponse Response { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Http.DefaultHttpContext.Session
    
        
        :rtype: Microsoft.AspNetCore.Http.ISession
    
        
        .. code-block:: csharp
    
            public override ISession Session { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Http.DefaultHttpContext.TraceIdentifier
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public override string TraceIdentifier { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Http.DefaultHttpContext.User
    
        
        :rtype: System.Security.Claims.ClaimsPrincipal
    
        
        .. code-block:: csharp
    
            public override ClaimsPrincipal User { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Http.DefaultHttpContext.WebSockets
    
        
        :rtype: Microsoft.AspNetCore.Http.WebSocketManager
    
        
        .. code-block:: csharp
    
            public override WebSocketManager WebSockets { get; }
    

