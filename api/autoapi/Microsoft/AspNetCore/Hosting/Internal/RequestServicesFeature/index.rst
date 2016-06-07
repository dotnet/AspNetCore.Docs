

RequestServicesFeature Class
============================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Hosting.Internal`
Assemblies
    * Microsoft.AspNetCore.Hosting

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Hosting.Internal.RequestServicesFeature`








Syntax
------

.. code-block:: csharp

    public class RequestServicesFeature : IServiceProvidersFeature, IDisposable








.. dn:class:: Microsoft.AspNetCore.Hosting.Internal.RequestServicesFeature
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Hosting.Internal.RequestServicesFeature

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Hosting.Internal.RequestServicesFeature
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Hosting.Internal.RequestServicesFeature.RequestServices
    
        
        :rtype: System.IServiceProvider
    
        
        .. code-block:: csharp
    
            public IServiceProvider RequestServices
            {
                get;
                set;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Hosting.Internal.RequestServicesFeature
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Hosting.Internal.RequestServicesFeature.RequestServicesFeature(Microsoft.Extensions.DependencyInjection.IServiceScopeFactory)
    
        
    
        
        :type scopeFactory: Microsoft.Extensions.DependencyInjection.IServiceScopeFactory
    
        
        .. code-block:: csharp
    
            public RequestServicesFeature(IServiceScopeFactory scopeFactory)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Hosting.Internal.RequestServicesFeature
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Hosting.Internal.RequestServicesFeature.Dispose()
    
        
    
        
        .. code-block:: csharp
    
            public void Dispose()
    

