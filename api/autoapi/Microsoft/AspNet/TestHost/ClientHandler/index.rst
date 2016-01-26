

ClientHandler Class
===================



.. contents:: 
   :local:



Summary
-------

This adapts HttpRequestMessages to ASP.NET requests, dispatches them through the pipeline, and returns the
associated HttpResponseMessage.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.Net.Http.HttpMessageHandler`
* :dn:cls:`Microsoft.AspNet.TestHost.ClientHandler`








Syntax
------

.. code-block:: csharp

   public class ClientHandler : HttpMessageHandler, IDisposable





GitHub
------

`View on GitHub <https://github.com/aspnet/hosting/blob/master/src/Microsoft.AspNet.TestHost/ClientHandler.cs>`_





.. dn:class:: Microsoft.AspNet.TestHost.ClientHandler

Constructors
------------

.. dn:class:: Microsoft.AspNet.TestHost.ClientHandler
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.TestHost.ClientHandler.ClientHandler(System.Func<Microsoft.AspNet.Http.Features.IFeatureCollection, System.Threading.Tasks.Task>, Microsoft.AspNet.Http.PathString)
    
        
    
        Create a new handler.
    
        
        
        
        :param next: The pipeline entry point.
        
        :type next: System.Func{Microsoft.AspNet.Http.Features.IFeatureCollection,System.Threading.Tasks.Task}
        
        
        :type pathBase: Microsoft.AspNet.Http.PathString
    
        
        .. code-block:: csharp
    
           public ClientHandler(Func<IFeatureCollection, Task> next, PathString pathBase)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.TestHost.ClientHandler
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.TestHost.ClientHandler.SendAsync(System.Net.Http.HttpRequestMessage, System.Threading.CancellationToken)
    
        
    
        This adapts HttpRequestMessages to ASP.NET requests, dispatches them through the pipeline, and returns the
        associated HttpResponseMessage.
    
        
        
        
        :type request: System.Net.Http.HttpRequestMessage
        
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task{System.Net.Http.HttpResponseMessage}
    
        
        .. code-block:: csharp
    
           protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    

