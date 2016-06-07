

Frame<TContext> Class
=====================





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
* :dn:cls:`Microsoft.AspNetCore.Server.Kestrel.Http.FrameContext`
* :dn:cls:`Microsoft.AspNetCore.Server.Kestrel.Http.Frame`
* :dn:cls:`Microsoft.AspNetCore.Server.Kestrel.Http.Frame\<TContext>`








Syntax
------

.. code-block:: csharp

    public class Frame<TContext> : Frame, IFrameControl, IFeatureCollection, IEnumerable<KeyValuePair<Type, object>>, IEnumerable, IHttpRequestFeature, IHttpResponseFeature, IHttpUpgradeFeature, IHttpConnectionFeature, IHttpRequestLifetimeFeature








.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Http.Frame`1
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Http.Frame<TContext>

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Http.Frame<TContext>
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Server.Kestrel.Http.Frame<TContext>.Frame(Microsoft.AspNetCore.Hosting.Server.IHttpApplication<TContext>, Microsoft.AspNetCore.Server.Kestrel.Http.ConnectionContext)
    
        
    
        
        :type application: Microsoft.AspNetCore.Hosting.Server.IHttpApplication<Microsoft.AspNetCore.Hosting.Server.IHttpApplication`1>{TContext}
    
        
        :type context: Microsoft.AspNetCore.Server.Kestrel.Http.ConnectionContext
    
        
        .. code-block:: csharp
    
            public Frame(IHttpApplication<TContext> application, ConnectionContext context)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Http.Frame<TContext>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Http.Frame<TContext>.RequestProcessingAsync()
    
        
    
        
        Primary loop which consumes socket input, parses it for protocol framing, and invokes the
        application delegate for as long as the socket is intended to remain open.
        The resulting Task from this loop is preserved in a field which is used when the server needs
        to drain and close all currently active connections.
    
        
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public override Task RequestProcessingAsync()
    

