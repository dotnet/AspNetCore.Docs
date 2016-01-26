

ProxyMethodEmitter Class
========================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.DiagnosticAdapter.Internal.ProxyMethodEmitter`








Syntax
------

.. code-block:: csharp

   public class ProxyMethodEmitter





GitHub
------

`View on GitHub <https://github.com/aspnet/eventnotification/blob/master/src/Microsoft.Extensions.DiagnosticAdapter/Internal/ProxyMethodEmitter.cs>`_





.. dn:class:: Microsoft.Extensions.DiagnosticAdapter.Internal.ProxyMethodEmitter

Methods
-------

.. dn:class:: Microsoft.Extensions.DiagnosticAdapter.Internal.ProxyMethodEmitter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.DiagnosticAdapter.Internal.ProxyMethodEmitter.CreateProxyMethod(System.Reflection.MethodInfo, System.Type)
    
        
        
        
        :type method: System.Reflection.MethodInfo
        
        
        :type inputType: System.Type
        :rtype: System.Func{System.Object,System.Object,Microsoft.Extensions.DiagnosticAdapter.Infrastructure.IProxyFactory,System.Boolean}
    
        
        .. code-block:: csharp
    
           public static Func<object, object, IProxyFactory, bool> CreateProxyMethod(MethodInfo method, Type inputType)
    

