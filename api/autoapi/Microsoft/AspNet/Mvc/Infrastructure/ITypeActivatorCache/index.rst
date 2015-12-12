

ITypeActivatorCache Interface
=============================



.. contents:: 
   :local:



Summary
-------

Caches :any:`Microsoft.Extensions.DependencyInjection.ObjectFactory` instances produced by 
:dn:meth:`Microsoft.Extensions.DependencyInjection.ActivatorUtilities.CreateFactory(System.Type,System.Type[])`\.











Syntax
------

.. code-block:: csharp

   public interface ITypeActivatorCache





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Core/Infrastructure/ITypeActivatorCache.cs>`_





.. dn:interface:: Microsoft.AspNet.Mvc.Infrastructure.ITypeActivatorCache

Methods
-------

.. dn:interface:: Microsoft.AspNet.Mvc.Infrastructure.ITypeActivatorCache
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Infrastructure.ITypeActivatorCache.CreateInstance<TInstance>(System.IServiceProvider, System.Type)
    
        
    
        Creates an instance of ``TInstance``.
    
        
        
        
        :param serviceProvider: The  used to resolve dependencies for
            .
        
        :type serviceProvider: System.IServiceProvider
        
        
        :type optionType: System.Type
        :rtype: {TInstance}
    
        
        .. code-block:: csharp
    
           TInstance CreateInstance<TInstance>(IServiceProvider serviceProvider, Type optionType)
    

