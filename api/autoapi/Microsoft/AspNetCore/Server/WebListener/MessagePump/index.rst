

MessagePump Class
=================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Server.WebListener`
Assemblies
    * Microsoft.AspNetCore.Server.WebListener

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Server.WebListener.MessagePump`








Syntax
------

.. code-block:: csharp

    public class MessagePump : IServer, IDisposable








.. dn:class:: Microsoft.AspNetCore.Server.WebListener.MessagePump
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Server.WebListener.MessagePump

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Server.WebListener.MessagePump
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Server.WebListener.MessagePump.Features
    
        
        :rtype: Microsoft.AspNetCore.Http.Features.IFeatureCollection
    
        
        .. code-block:: csharp
    
            public IFeatureCollection Features
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Server.WebListener.MessagePump.Listener
    
        
        :rtype: Microsoft.Net.Http.Server.WebListener
    
        
        .. code-block:: csharp
    
            public WebListener Listener
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Server.WebListener.MessagePump
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Server.WebListener.MessagePump.MessagePump(Microsoft.Extensions.Options.IOptions<Microsoft.AspNetCore.Server.WebListener.WebListenerOptions>, Microsoft.Extensions.Logging.ILoggerFactory)
    
        
    
        
        :type options: Microsoft.Extensions.Options.IOptions<Microsoft.Extensions.Options.IOptions`1>{Microsoft.AspNetCore.Server.WebListener.WebListenerOptions<Microsoft.AspNetCore.Server.WebListener.WebListenerOptions>}
    
        
        :type loggerFactory: Microsoft.Extensions.Logging.ILoggerFactory
    
        
        .. code-block:: csharp
    
            public MessagePump(IOptions<WebListenerOptions> options, ILoggerFactory loggerFactory)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Server.WebListener.MessagePump
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Server.WebListener.MessagePump.Dispose()
    
        
    
        
        .. code-block:: csharp
    
            public void Dispose()
    
    .. dn:method:: Microsoft.AspNetCore.Server.WebListener.MessagePump.Start<TContext>(Microsoft.AspNetCore.Hosting.Server.IHttpApplication<TContext>)
    
        
    
        
        :type application: Microsoft.AspNetCore.Hosting.Server.IHttpApplication<Microsoft.AspNetCore.Hosting.Server.IHttpApplication`1>{TContext}
    
        
        .. code-block:: csharp
    
            public void Start<TContext>(IHttpApplication<TContext> application)
    

