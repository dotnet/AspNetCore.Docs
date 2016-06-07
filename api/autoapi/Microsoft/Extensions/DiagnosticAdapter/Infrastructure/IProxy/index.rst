

IProxy Interface
================






An interface for unwrappable proxy objects.


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

    public interface IProxy








.. dn:interface:: Microsoft.Extensions.DiagnosticAdapter.Infrastructure.IProxy
    :hidden:

.. dn:interface:: Microsoft.Extensions.DiagnosticAdapter.Infrastructure.IProxy

Methods
-------

.. dn:interface:: Microsoft.Extensions.DiagnosticAdapter.Infrastructure.IProxy
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.DiagnosticAdapter.Infrastructure.IProxy.Upwrap<T>()
    
        
    
        
        Unwraps the underlying object and performs a cast to <em>T</em>.
    
        
        :rtype: T
        :return: The underlying object.
    
        
        .. code-block:: csharp
    
            T Upwrap<T>()
    

