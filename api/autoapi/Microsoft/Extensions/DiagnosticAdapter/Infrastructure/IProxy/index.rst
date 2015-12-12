

IProxy Interface
================



.. contents:: 
   :local:



Summary
-------

An interface for unwrappable proxy objects.











Syntax
------

.. code-block:: csharp

   public interface IProxy





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/eventnotification/src/Microsoft.Extensions.DiagnosticAdapter/Infrastructure/IProxy.cs>`_





.. dn:interface:: Microsoft.Extensions.DiagnosticAdapter.Infrastructure.IProxy

Methods
-------

.. dn:interface:: Microsoft.Extensions.DiagnosticAdapter.Infrastructure.IProxy
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.DiagnosticAdapter.Infrastructure.IProxy.Upwrap<T>()
    
        
    
        Unwraps the underlying object and performs a cast to ``T``.
    
        
        :rtype: {T}
        :return: The underlying object.
    
        
        .. code-block:: csharp
    
           T Upwrap<T>()
    

