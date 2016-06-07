

ConnectionContext Class
=======================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Server.Kestrel.Http`
Assemblies
    * Microsoft.AspNetCore.Server.Kestrel

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Server.Kestrel.ServiceContext`
* :dn:cls:`Microsoft.AspNetCore.Server.Kestrel.Http.ListenerContext`
* :dn:cls:`Microsoft.AspNetCore.Server.Kestrel.Http.ConnectionContext`








Syntax
------

.. code-block:: csharp

    public class ConnectionContext : ListenerContext








.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Http.ConnectionContext
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Http.ConnectionContext

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Http.ConnectionContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Http.ConnectionContext.ConnectionControl
    
        
        :rtype: Microsoft.AspNetCore.Server.Kestrel.Http.IConnectionControl
    
        
        .. code-block:: csharp
    
            public IConnectionControl ConnectionControl
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Http.ConnectionContext.ConnectionId
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string ConnectionId
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Http.ConnectionContext.LocalEndPoint
    
        
        :rtype: System.Net.IPEndPoint
    
        
        .. code-block:: csharp
    
            public IPEndPoint LocalEndPoint
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Http.ConnectionContext.PrepareRequest
    
        
        :rtype: System.Action<System.Action`1>{Microsoft.AspNetCore.Http.Features.IFeatureCollection<Microsoft.AspNetCore.Http.Features.IFeatureCollection>}
    
        
        .. code-block:: csharp
    
            public Action<IFeatureCollection> PrepareRequest
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Http.ConnectionContext.RemoteEndPoint
    
        
        :rtype: System.Net.IPEndPoint
    
        
        .. code-block:: csharp
    
            public IPEndPoint RemoteEndPoint
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Http.ConnectionContext.SocketInput
    
        
        :rtype: Microsoft.AspNetCore.Server.Kestrel.Http.SocketInput
    
        
        .. code-block:: csharp
    
            public SocketInput SocketInput
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Http.ConnectionContext.SocketOutput
    
        
        :rtype: Microsoft.AspNetCore.Server.Kestrel.Http.ISocketOutput
    
        
        .. code-block:: csharp
    
            public ISocketOutput SocketOutput
            {
                get;
                set;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Http.ConnectionContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Server.Kestrel.Http.ConnectionContext.ConnectionContext()
    
        
    
        
        .. code-block:: csharp
    
            public ConnectionContext()
    
    .. dn:constructor:: Microsoft.AspNetCore.Server.Kestrel.Http.ConnectionContext.ConnectionContext(Microsoft.AspNetCore.Server.Kestrel.Http.ConnectionContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Server.Kestrel.Http.ConnectionContext
    
        
        .. code-block:: csharp
    
            public ConnectionContext(ConnectionContext context)
    
    .. dn:constructor:: Microsoft.AspNetCore.Server.Kestrel.Http.ConnectionContext.ConnectionContext(Microsoft.AspNetCore.Server.Kestrel.Http.ListenerContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Server.Kestrel.Http.ListenerContext
    
        
        .. code-block:: csharp
    
            public ConnectionContext(ListenerContext context)
    

