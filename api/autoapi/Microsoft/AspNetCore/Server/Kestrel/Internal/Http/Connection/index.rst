

Connection Class
================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Server.Kestrel.Internal.Http`
Assemblies
    * Microsoft.AspNetCore.Server.Kestrel

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Server.Kestrel.Internal.ServiceContext`
* :dn:cls:`Microsoft.AspNetCore.Server.Kestrel.Internal.Http.ListenerContext`
* :dn:cls:`Microsoft.AspNetCore.Server.Kestrel.Internal.Http.ConnectionContext`
* :dn:cls:`Microsoft.AspNetCore.Server.Kestrel.Internal.Http.Connection`








Syntax
------

.. code-block:: csharp

    public class Connection : ConnectionContext, IConnectionControl








.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.Connection
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.Connection

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.Connection
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.Connection.Connection(Microsoft.AspNetCore.Server.Kestrel.Internal.Http.ListenerContext, Microsoft.AspNetCore.Server.Kestrel.Internal.Networking.UvStreamHandle)
    
        
    
        
        :type context: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.ListenerContext
    
        
        :type socket: Microsoft.AspNetCore.Server.Kestrel.Internal.Networking.UvStreamHandle
    
        
        .. code-block:: csharp
    
            public Connection(ListenerContext context, UvStreamHandle socket)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.Connection
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.Connection.Abort()
    
        
    
        
        .. code-block:: csharp
    
            public virtual void Abort()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.Connection.Microsoft.AspNetCore.Server.Kestrel.Internal.Http.IConnectionControl.End(Microsoft.AspNetCore.Server.Kestrel.Internal.Http.ProduceEndType)
    
        
    
        
        :type endType: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.ProduceEndType
    
        
        .. code-block:: csharp
    
            void IConnectionControl.End(ProduceEndType endType)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.Connection.Microsoft.AspNetCore.Server.Kestrel.Internal.Http.IConnectionControl.Pause()
    
        
    
        
        .. code-block:: csharp
    
            void IConnectionControl.Pause()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.Connection.Microsoft.AspNetCore.Server.Kestrel.Internal.Http.IConnectionControl.Resume()
    
        
    
        
        .. code-block:: csharp
    
            void IConnectionControl.Resume()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.Connection.OnSocketClosed()
    
        
    
        
        .. code-block:: csharp
    
            public virtual void OnSocketClosed()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.Connection.Start()
    
        
    
        
        .. code-block:: csharp
    
            public void Start()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.Connection.StopAsync()
    
        
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public Task StopAsync()
    

