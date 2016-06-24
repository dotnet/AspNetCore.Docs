

IServer Interface
=================






Represents a server.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Hosting.Server`
Assemblies
    * Microsoft.AspNetCore.Hosting.Server.Abstractions

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IServer : IDisposable








.. dn:interface:: Microsoft.AspNetCore.Hosting.Server.IServer
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Hosting.Server.IServer

Properties
----------

.. dn:interface:: Microsoft.AspNetCore.Hosting.Server.IServer
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Hosting.Server.IServer.Features
    
        
    
        
        A collection of HTTP features of the server.
    
        
        :rtype: Microsoft.AspNetCore.Http.Features.IFeatureCollection
    
        
        .. code-block:: csharp
    
            IFeatureCollection Features { get; }
    

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Hosting.Server.IServer
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Hosting.Server.IServer.Start<TContext>(Microsoft.AspNetCore.Hosting.Server.IHttpApplication<TContext>)
    
        
    
        
        Start the server with an application.
    
        
    
        
        :param application: An instance of :any:`Microsoft.AspNetCore.Hosting.Server.IHttpApplication\`1`\.
        
        :type application: Microsoft.AspNetCore.Hosting.Server.IHttpApplication<Microsoft.AspNetCore.Hosting.Server.IHttpApplication`1>{TContext}
    
        
        .. code-block:: csharp
    
            void Start<TContext>(IHttpApplication<TContext> application)
    

