

IProxyFactory Interface
=======================



.. contents:: 
   :local:



Summary
-------

A factory for runtime creation of proxy objects.











Syntax
------

.. code-block:: csharp

   public interface IProxyFactory





GitHub
------

`View on GitHub <https://github.com/aspnet/eventnotification/blob/master/src/Microsoft.Extensions.DiagnosticAdapter/Infrastructure/IProxyFactory.cs>`_





.. dn:interface:: Microsoft.Extensions.DiagnosticAdapter.Infrastructure.IProxyFactory

Methods
-------

.. dn:interface:: Microsoft.Extensions.DiagnosticAdapter.Infrastructure.IProxyFactory
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.DiagnosticAdapter.Infrastructure.IProxyFactory.CreateProxy<TProxy>(System.Object)
    
        
    
        Creates a proxy object that is assignable to type ``TProxy``
    
        
        
        
        :param obj: The object to wrap in a proxy.
        
        :type obj: System.Object
        :rtype: {TProxy}
        :return: A proxy object, or <paramref name="obj" /> if a proxy is not needed.
    
        
        .. code-block:: csharp
    
           TProxy CreateProxy<TProxy>(object obj)
    

