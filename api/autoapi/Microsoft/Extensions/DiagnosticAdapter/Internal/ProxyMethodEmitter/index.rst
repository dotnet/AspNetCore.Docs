

ProxyMethodEmitter Class
========================





Namespace
    :dn:ns:`Microsoft.Extensions.DiagnosticAdapter.Internal`
Assemblies
    * Microsoft.Extensions.DiagnosticAdapter

----

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








.. dn:class:: Microsoft.Extensions.DiagnosticAdapter.Internal.ProxyMethodEmitter
    :hidden:

.. dn:class:: Microsoft.Extensions.DiagnosticAdapter.Internal.ProxyMethodEmitter

Methods
-------

.. dn:class:: Microsoft.Extensions.DiagnosticAdapter.Internal.ProxyMethodEmitter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.DiagnosticAdapter.Internal.ProxyMethodEmitter.CreateProxyMethod(System.Reflection.MethodInfo, System.Type)
    
        
    
        
        :type method: System.Reflection.MethodInfo
    
        
        :type inputType: System.Type
        :rtype: System.Func<System.Func`4>{System.Object<System.Object>, System.Object<System.Object>, Microsoft.Extensions.DiagnosticAdapter.Infrastructure.IProxyFactory<Microsoft.Extensions.DiagnosticAdapter.Infrastructure.IProxyFactory>, System.Boolean<System.Boolean>}
    
        
        .. code-block:: csharp
    
            public static Func<object, object, IProxyFactory, bool> CreateProxyMethod(MethodInfo method, Type inputType)
    

