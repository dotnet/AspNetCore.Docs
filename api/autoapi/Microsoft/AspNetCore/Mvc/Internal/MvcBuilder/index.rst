

MvcBuilder Class
================






Allows fine grained configuration of MVC services.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Internal`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Internal.MvcBuilder`








Syntax
------

.. code-block:: csharp

    public class MvcBuilder : IMvcBuilder








.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.MvcBuilder
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.MvcBuilder

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.MvcBuilder
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Internal.MvcBuilder.MvcBuilder(Microsoft.Extensions.DependencyInjection.IServiceCollection, Microsoft.AspNetCore.Mvc.ApplicationParts.ApplicationPartManager)
    
        
    
        
        Initializes a new :any:`Microsoft.AspNetCore.Mvc.Internal.MvcBuilder` instance.
    
        
    
        
        :param services: The :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection` to add services to.
        
        :type services: Microsoft.Extensions.DependencyInjection.IServiceCollection
    
        
        :param manager: The :any:`Microsoft.AspNetCore.Mvc.ApplicationParts.ApplicationPartManager` of the application.
        
        :type manager: Microsoft.AspNetCore.Mvc.ApplicationParts.ApplicationPartManager
    
        
        .. code-block:: csharp
    
            public MvcBuilder(IServiceCollection services, ApplicationPartManager manager)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.MvcBuilder
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Internal.MvcBuilder.PartManager
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ApplicationParts.ApplicationPartManager
    
        
        .. code-block:: csharp
    
            public ApplicationPartManager PartManager { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Internal.MvcBuilder.Services
    
        
        :rtype: Microsoft.Extensions.DependencyInjection.IServiceCollection
    
        
        .. code-block:: csharp
    
            public IServiceCollection Services { get; }
    

