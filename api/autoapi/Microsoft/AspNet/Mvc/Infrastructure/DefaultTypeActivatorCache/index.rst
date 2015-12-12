

DefaultTypeActivatorCache Class
===============================



.. contents:: 
   :local:



Summary
-------

Caches :any:`Microsoft.Extensions.DependencyInjection.ObjectFactory` instances produced by 
:dn:meth:`Microsoft.Extensions.DependencyInjection.ActivatorUtilities.CreateFactory(System.Type,System.Type[])`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Infrastructure.DefaultTypeActivatorCache`








Syntax
------

.. code-block:: csharp

   public class DefaultTypeActivatorCache : ITypeActivatorCache





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Core/Infrastructure/DefaultTypeActivatorCache.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Infrastructure.DefaultTypeActivatorCache

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Infrastructure.DefaultTypeActivatorCache
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Infrastructure.DefaultTypeActivatorCache.CreateInstance<TInstance>(System.IServiceProvider, System.Type)
    
        
        
        
        :type serviceProvider: System.IServiceProvider
        
        
        :type implementationType: System.Type
        :rtype: {TInstance}
    
        
        .. code-block:: csharp
    
           public TInstance CreateInstance<TInstance>(IServiceProvider serviceProvider, Type implementationType)
    

