

IHttpApplication<TContext> Interface
====================================






Represents an application.


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

    public interface IHttpApplication<TContext>








.. dn:interface:: Microsoft.AspNetCore.Hosting.Server.IHttpApplication`1
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Hosting.Server.IHttpApplication<TContext>

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Hosting.Server.IHttpApplication<TContext>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Hosting.Server.IHttpApplication<TContext>.CreateContext(Microsoft.AspNetCore.Http.Features.IFeatureCollection)
    
        
    
        
        Create a TContext given a collection of HTTP features.
    
        
    
        
        :param contextFeatures: A collection of HTTP features to be used for creating the TContext.
        
        :type contextFeatures: Microsoft.AspNetCore.Http.Features.IFeatureCollection
        :rtype: TContext
        :return: The created TContext.
    
        
        .. code-block:: csharp
    
            TContext CreateContext(IFeatureCollection contextFeatures)
    
    .. dn:method:: Microsoft.AspNetCore.Hosting.Server.IHttpApplication<TContext>.DisposeContext(TContext, System.Exception)
    
        
    
        
        Dispose a given TContext.
    
        
    
        
        :param context: The TContext to be disposed.
        
        :type context: TContext
    
        
        :param exception: The Exception thrown when processing did not complete successfully, otherwise null.
        
        :type exception: System.Exception
    
        
        .. code-block:: csharp
    
            void DisposeContext(TContext context, Exception exception)
    
    .. dn:method:: Microsoft.AspNetCore.Hosting.Server.IHttpApplication<TContext>.ProcessRequestAsync(TContext)
    
        
    
        
        Asynchronously processes an TContext.
    
        
    
        
        :param context: The TContext that the operation will process.
        
        :type context: TContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            Task ProcessRequestAsync(TContext context)
    

