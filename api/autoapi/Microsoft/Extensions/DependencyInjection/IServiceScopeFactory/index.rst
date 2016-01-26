

IServiceScopeFactory Interface
==============================



.. contents:: 
   :local:













Syntax
------

.. code-block:: csharp

   public interface IServiceScopeFactory





GitHub
------

`View on GitHub <https://github.com/aspnet/dependencyinjection/blob/master/src/Microsoft.Extensions.DependencyInjection.Abstractions/IServiceScopeFactory.cs>`_





.. dn:interface:: Microsoft.Extensions.DependencyInjection.IServiceScopeFactory

Methods
-------

.. dn:interface:: Microsoft.Extensions.DependencyInjection.IServiceScopeFactory
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.IServiceScopeFactory.CreateScope()
    
        
    
        Create an :any:`Microsoft.Extensions.DependencyInjection.IServiceScope` which
        contains an :any:`System.IServiceProvider` used to resolve dependencies from a
        newly created scope.
    
        
        :rtype: Microsoft.Extensions.DependencyInjection.IServiceScope
        :return: An <see cref="T:Microsoft.Extensions.DependencyInjection.IServiceScope" /> controlling the
            lifetime of the scope. Once this is disposed, any scoped services that have been resolved
            from the <see cref="P:Microsoft.Extensions.DependencyInjection.IServiceScope.ServiceProvider" />
            will also be disposed.
    
        
        .. code-block:: csharp
    
           IServiceScope CreateScope()
    

