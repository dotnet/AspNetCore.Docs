

ProxyDiagnosticSourceMethodAdapter Class
========================================





Namespace
    :dn:ns:`Microsoft.Extensions.DiagnosticAdapter`
Assemblies
    * Microsoft.Extensions.DiagnosticAdapter

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.DiagnosticAdapter.ProxyDiagnosticSourceMethodAdapter`








Syntax
------

.. code-block:: csharp

    public class ProxyDiagnosticSourceMethodAdapter : IDiagnosticSourceMethodAdapter








.. dn:class:: Microsoft.Extensions.DiagnosticAdapter.ProxyDiagnosticSourceMethodAdapter
    :hidden:

.. dn:class:: Microsoft.Extensions.DiagnosticAdapter.ProxyDiagnosticSourceMethodAdapter

Methods
-------

.. dn:class:: Microsoft.Extensions.DiagnosticAdapter.ProxyDiagnosticSourceMethodAdapter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.DiagnosticAdapter.ProxyDiagnosticSourceMethodAdapter.Adapt(System.Reflection.MethodInfo, System.Type)
    
        
    
        
        :type method: System.Reflection.MethodInfo
    
        
        :type inputType: System.Type
        :rtype: System.Func<System.Func`3>{System.Object<System.Object>, System.Object<System.Object>, System.Boolean<System.Boolean>}
    
        
        .. code-block:: csharp
    
            public Func<object, object, bool> Adapt(MethodInfo method, Type inputType)
    

