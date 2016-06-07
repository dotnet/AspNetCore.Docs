

ServiceLifetime Enum
====================






Specifies the lifetime of a service in an :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection`\.


Namespace
    :dn:ns:`Microsoft.Extensions.DependencyInjection`
Assemblies
    * Microsoft.Extensions.DependencyInjection.Abstractions

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public enum ServiceLifetime








.. dn:enumeration:: Microsoft.Extensions.DependencyInjection.ServiceLifetime
    :hidden:

.. dn:enumeration:: Microsoft.Extensions.DependencyInjection.ServiceLifetime

Fields
------

.. dn:enumeration:: Microsoft.Extensions.DependencyInjection.ServiceLifetime
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.Extensions.DependencyInjection.ServiceLifetime.Scoped
    
        
    
        
        Specifies that a new instance of the service will be created for each scope.
    
        
        :rtype: Microsoft.Extensions.DependencyInjection.ServiceLifetime
    
        
        .. code-block:: csharp
    
            Scoped = 1
    
    .. dn:field:: Microsoft.Extensions.DependencyInjection.ServiceLifetime.Singleton
    
        
    
        
        Specifies that a single instance of the service will be created.
    
        
        :rtype: Microsoft.Extensions.DependencyInjection.ServiceLifetime
    
        
        .. code-block:: csharp
    
            Singleton = 0
    
    .. dn:field:: Microsoft.Extensions.DependencyInjection.ServiceLifetime.Transient
    
        
    
        
        Specifies that a new instance of the service will be created every time it is requested.
    
        
        :rtype: Microsoft.Extensions.DependencyInjection.ServiceLifetime
    
        
        .. code-block:: csharp
    
            Transient = 2
    

