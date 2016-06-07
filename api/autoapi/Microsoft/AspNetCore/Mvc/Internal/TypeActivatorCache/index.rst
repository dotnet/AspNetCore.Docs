

TypeActivatorCache Class
========================






Caches :any:`Microsoft.Extensions.DependencyInjection.ObjectFactory` instances produced by 
:dn:meth:`Microsoft.Extensions.DependencyInjection.ActivatorUtilities.CreateFactory(System.Type,System.Type[])`\.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.Internal.TypeActivatorCache`








Syntax
------

.. code-block:: csharp

    public class TypeActivatorCache : ITypeActivatorCache








.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.TypeActivatorCache
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.TypeActivatorCache

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.TypeActivatorCache
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.TypeActivatorCache.CreateInstance<TInstance>(System.IServiceProvider, System.Type)
    
        
    
        
        :type serviceProvider: System.IServiceProvider
    
        
        :type implementationType: System.Type
        :rtype: TInstance
    
        
        .. code-block:: csharp
    
            public TInstance CreateInstance<TInstance>(IServiceProvider serviceProvider, Type implementationType)
    

