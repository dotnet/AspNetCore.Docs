

DefaultHttpContext Class
========================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Http.HttpContext`
* :dn:cls:`Microsoft.AspNet.Http.Internal.DefaultHttpContext`








Syntax
------

.. code-block:: csharp

   public class DefaultHttpContext : HttpContext, IFeatureCache





GitHub
------

`View on GitHub <https://github.com/aspnet/httpabstractions/blob/master/src/Microsoft.AspNet.Http/DefaultHttpContext.cs>`_





.. dn:class:: Microsoft.AspNet.Http.Internal.DefaultHttpContext

Constructors
------------

.. dn:class:: Microsoft.AspNet.Http.Internal.DefaultHttpContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Http.Internal.DefaultHttpContext.DefaultHttpContext()
    
        
    
        
        .. code-block:: csharp
    
           public DefaultHttpContext()
    
    .. dn:constructor:: Microsoft.AspNet.Http.Internal.DefaultHttpContext.DefaultHttpContext(Microsoft.AspNet.Http.Features.IFeatureCollection)
    
        
        
        
        :type features: Microsoft.AspNet.Http.Features.IFeatureCollection
    
        
        .. code-block:: csharp
    
           public DefaultHttpContext(IFeatureCollection features)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Http.Internal.DefaultHttpContext
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Http.Internal.DefaultHttpContext.Abort()
    
        
    
        
        .. code-block:: csharp
    
           public override void Abort()
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Http.Internal.DefaultHttpContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Http.Internal.DefaultHttpContext.ApplicationServices
    
        
        :rtype: System.IServiceProvider
    
        
        .. code-block:: csharp
    
           public override IServiceProvider ApplicationServices { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.Internal.DefaultHttpContext.Authentication
    
        
        :rtype: Microsoft.AspNet.Http.Authentication.AuthenticationManager
    
        
        .. code-block:: csharp
    
           public override AuthenticationManager Authentication { get; }
    
    .. dn:property:: Microsoft.AspNet.Http.Internal.DefaultHttpContext.Connection
    
        
        :rtype: Microsoft.AspNet.Http.ConnectionInfo
    
        
        .. code-block:: csharp
    
           public override ConnectionInfo Connection { get; }
    
    .. dn:property:: Microsoft.AspNet.Http.Internal.DefaultHttpContext.Features
    
        
        :rtype: Microsoft.AspNet.Http.Features.IFeatureCollection
    
        
        .. code-block:: csharp
    
           public override IFeatureCollection Features { get; }
    
    .. dn:property:: Microsoft.AspNet.Http.Internal.DefaultHttpContext.Items
    
        
        :rtype: System.Collections.Generic.IDictionary{System.Object,System.Object}
    
        
        .. code-block:: csharp
    
           public override IDictionary<object, object> Items { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.Internal.DefaultHttpContext.Request
    
        
        :rtype: Microsoft.AspNet.Http.HttpRequest
    
        
        .. code-block:: csharp
    
           public override HttpRequest Request { get; }
    
    .. dn:property:: Microsoft.AspNet.Http.Internal.DefaultHttpContext.RequestAborted
    
        
        :rtype: System.Threading.CancellationToken
    
        
        .. code-block:: csharp
    
           public override CancellationToken RequestAborted { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.Internal.DefaultHttpContext.RequestServices
    
        
        :rtype: System.IServiceProvider
    
        
        .. code-block:: csharp
    
           public override IServiceProvider RequestServices { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.Internal.DefaultHttpContext.Response
    
        
        :rtype: Microsoft.AspNet.Http.HttpResponse
    
        
        .. code-block:: csharp
    
           public override HttpResponse Response { get; }
    
    .. dn:property:: Microsoft.AspNet.Http.Internal.DefaultHttpContext.Session
    
        
        :rtype: Microsoft.AspNet.Http.Features.ISession
    
        
        .. code-block:: csharp
    
           public override ISession Session { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.Internal.DefaultHttpContext.TraceIdentifier
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public override string TraceIdentifier { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.Internal.DefaultHttpContext.User
    
        
        :rtype: System.Security.Claims.ClaimsPrincipal
    
        
        .. code-block:: csharp
    
           public override ClaimsPrincipal User { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Http.Internal.DefaultHttpContext.WebSockets
    
        
        :rtype: Microsoft.AspNet.Http.WebSocketManager
    
        
        .. code-block:: csharp
    
           public override WebSocketManager WebSockets { get; }
    

