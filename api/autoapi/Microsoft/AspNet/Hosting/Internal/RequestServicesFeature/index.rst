

RequestServicesFeature Class
============================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Hosting.Internal.RequestServicesFeature`








Syntax
------

.. code-block:: csharp

   public class RequestServicesFeature : IServiceProvidersFeature, IDisposable





GitHub
------

`View on GitHub <https://github.com/aspnet/hosting/blob/master/src/Microsoft.AspNet.Hosting/Internal/RequestServicesContainerFeature.cs>`_





.. dn:class:: Microsoft.AspNet.Hosting.Internal.RequestServicesFeature

Constructors
------------

.. dn:class:: Microsoft.AspNet.Hosting.Internal.RequestServicesFeature
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Hosting.Internal.RequestServicesFeature.RequestServicesFeature(System.IServiceProvider)
    
        
        
        
        :type applicationServices: System.IServiceProvider
    
        
        .. code-block:: csharp
    
           public RequestServicesFeature(IServiceProvider applicationServices)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Hosting.Internal.RequestServicesFeature
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Hosting.Internal.RequestServicesFeature.Dispose()
    
        
    
        
        .. code-block:: csharp
    
           public void Dispose()
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Hosting.Internal.RequestServicesFeature
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Hosting.Internal.RequestServicesFeature.ApplicationServices
    
        
        :rtype: System.IServiceProvider
    
        
        .. code-block:: csharp
    
           public IServiceProvider ApplicationServices { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Hosting.Internal.RequestServicesFeature.RequestServices
    
        
        :rtype: System.IServiceProvider
    
        
        .. code-block:: csharp
    
           public IServiceProvider RequestServices { get; set; }
    

