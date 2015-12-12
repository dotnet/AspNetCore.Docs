

IServiceScope Interface
=======================



.. contents:: 
   :local:



Summary
-------

The :dn:meth:`System.IDisposable.Dispose` method ends the scope lifetime. Once Dispose
is called, any scoped services that have been resolved from 
:dn:prop:`Microsoft.Extensions.DependencyInjection.IServiceScope.ServiceProvider` will be
disposed.











Syntax
------

.. code-block:: csharp

   public interface IServiceScope : IDisposable





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/dependencyinjection/src/Microsoft.Extensions.DependencyInjection.Abstractions/IServiceScope.cs>`_





.. dn:interface:: Microsoft.Extensions.DependencyInjection.IServiceScope

Properties
----------

.. dn:interface:: Microsoft.Extensions.DependencyInjection.IServiceScope
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.DependencyInjection.IServiceScope.ServiceProvider
    
        
    
        The :any:`System.IServiceProvider` used to resolve dependencies from the scope.
    
        
        :rtype: System.IServiceProvider
    
        
        .. code-block:: csharp
    
           IServiceProvider ServiceProvider { get; }
    

