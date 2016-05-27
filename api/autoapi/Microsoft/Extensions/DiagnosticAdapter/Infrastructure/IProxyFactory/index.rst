

IProxyFactory Interface
=======================






A factory for runtime creation of proxy objects.


Namespace
    :dn:ns:`Microsoft.Extensions.DiagnosticAdapter.Infrastructure`
Assemblies
    * Microsoft.Extensions.DiagnosticAdapter

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IProxyFactory








.. dn:interface:: Microsoft.Extensions.DiagnosticAdapter.Infrastructure.IProxyFactory
    :hidden:

.. dn:interface:: Microsoft.Extensions.DiagnosticAdapter.Infrastructure.IProxyFactory

Methods
-------

.. dn:interface:: Microsoft.Extensions.DiagnosticAdapter.Infrastructure.IProxyFactory
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.DiagnosticAdapter.Infrastructure.IProxyFactory.CreateProxy<TProxy>(System.Object)
    
        
    
        
        Creates a proxy object that is assignable to type <em>TProxy</em>
    
        
    
        
        :param obj: The object to wrap in a proxy.
        
        :type obj: System.Object
        :rtype: TProxy
        :return: A proxy object, or <em>obj</em> if a proxy is not needed.
    
        
        .. code-block:: csharp
    
            TProxy CreateProxy<TProxy>(object obj)
    

