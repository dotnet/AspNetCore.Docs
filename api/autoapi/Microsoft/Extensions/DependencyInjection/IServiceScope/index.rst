

IServiceScope Interface
=======================






The :dn:meth:`System.IDisposable.Dispose` method ends the scope lifetime. Once Dispose
is called, any scoped services that have been resolved from
:dn:prop:`Microsoft.Extensions.DependencyInjection.IServiceScope.ServiceProvider` will be
disposed.


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

    public interface IServiceScope : IDisposable








.. dn:interface:: Microsoft.Extensions.DependencyInjection.IServiceScope
    :hidden:

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
    
            IServiceProvider ServiceProvider
            {
                get;
            }
    

