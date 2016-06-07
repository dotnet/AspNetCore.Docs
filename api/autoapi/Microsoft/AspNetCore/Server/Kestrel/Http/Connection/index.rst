

Connection Class
================





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
* :dn:cls:`Microsoft.AspNetCore.Server.Kestrel.Http.Connection`








Syntax
------

.. code-block:: csharp

    public class Connection : ConnectionContext, IConnectionControl








.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Http.Connection
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Http.Connection

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Http.Connection
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Server.Kestrel.Http.Connection.Connection(Microsoft.AspNetCore.Server.Kestrel.Http.ListenerContext, Microsoft.AspNetCore.Server.Kestrel.Networking.UvStreamHandle)
    
        
    
        
        :type context: Microsoft.AspNetCore.Server.Kestrel.Http.ListenerContext
    
        
        :type socket: Microsoft.AspNetCore.Server.Kestrel.Networking.UvStreamHandle
    
        
        .. code-block:: csharp
    
            public Connection(ListenerContext context, UvStreamHandle socket)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Http.Connection
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.Connection.Abort()
    
        
    
        
        .. code-block:: csharp
    
            public virtual void Abort()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.Connection.Microsoft.AspNetCore.Server.Kestrel.Http.IConnectionControl.End(Microsoft.AspNetCore.Server.Kestrel.Http.ProduceEndType)
    
        
    
        
        :type endType: Microsoft.AspNetCore.Server.Kestrel.Http.ProduceEndType
    
        
        .. code-block:: csharp
    
            void IConnectionControl.End(ProduceEndType endType)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.Connection.Microsoft.AspNetCore.Server.Kestrel.Http.IConnectionControl.Pause()
    
        
    
        
        .. code-block:: csharp
    
            void IConnectionControl.Pause()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.Connection.Microsoft.AspNetCore.Server.Kestrel.Http.IConnectionControl.Resume()
    
        
    
        
        .. code-block:: csharp
    
            void IConnectionControl.Resume()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.Connection.OnSocketClosed()
    
        
    
        
        .. code-block:: csharp
    
            public virtual void OnSocketClosed()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.Connection.Start()
    
        
    
        
        .. code-block:: csharp
    
            public void Start()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.Connection.StopAsync()
    
        
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public Task StopAsync()
    

