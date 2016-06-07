

IServiceScopeFactory Interface
==============================





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

    public interface IServiceScopeFactory








.. dn:interface:: Microsoft.Extensions.DependencyInjection.IServiceScopeFactory
    :hidden:

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
        :return: 
            An :any:`Microsoft.Extensions.DependencyInjection.IServiceScope` controlling the
            lifetime of the scope. Once this is disposed, any scoped services that have been resolved
            from the :dn:prop:`Microsoft.Extensions.DependencyInjection.IServiceScope.ServiceProvider`
            will also be disposed.
    
        
        .. code-block:: csharp
    
            IServiceScope CreateScope()
    

