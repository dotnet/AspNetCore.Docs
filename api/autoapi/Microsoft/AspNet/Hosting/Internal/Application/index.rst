

Application Class
=================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Hosting.Internal.Application`








Syntax
------

.. code-block:: csharp

   public class Application : IApplication, IDisposable





GitHub
------

`View on GitHub <https://github.com/aspnet/hosting/blob/master/src/Microsoft.AspNet.Hosting/Internal/Application.cs>`_





.. dn:class:: Microsoft.AspNet.Hosting.Internal.Application

Constructors
------------

.. dn:class:: Microsoft.AspNet.Hosting.Internal.Application
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Hosting.Internal.Application.Application(System.IServiceProvider, Microsoft.AspNet.Http.Features.IFeatureCollection, System.IDisposable)
    
        
        
        
        :type services: System.IServiceProvider
        
        
        :type server: Microsoft.AspNet.Http.Features.IFeatureCollection
        
        
        :type stop: System.IDisposable
    
        
        .. code-block:: csharp
    
           public Application(IServiceProvider services, IFeatureCollection server, IDisposable stop)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Hosting.Internal.Application
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Hosting.Internal.Application.Dispose()
    
        
    
        
        .. code-block:: csharp
    
           public void Dispose()
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Hosting.Internal.Application
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Hosting.Internal.Application.ServerFeatures
    
        
        :rtype: Microsoft.AspNet.Http.Features.IFeatureCollection
    
        
        .. code-block:: csharp
    
           public IFeatureCollection ServerFeatures { get; }
    
    .. dn:property:: Microsoft.AspNet.Hosting.Internal.Application.Services
    
        
        :rtype: System.IServiceProvider
    
        
        .. code-block:: csharp
    
           public IServiceProvider Services { get; }
    

