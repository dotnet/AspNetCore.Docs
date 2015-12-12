

ProxyDiagnosticSourceMethodAdapter Class
========================================



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





GitHub
------

`View on GitHub <https://github.com/aspnet/eventnotification/blob/master/src/Microsoft.Extensions.DiagnosticAdapter/ProxyDiagnosticSourceMethodAdapter.cs>`_





.. dn:class:: Microsoft.Extensions.DiagnosticAdapter.ProxyDiagnosticSourceMethodAdapter

Methods
-------

.. dn:class:: Microsoft.Extensions.DiagnosticAdapter.ProxyDiagnosticSourceMethodAdapter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.DiagnosticAdapter.ProxyDiagnosticSourceMethodAdapter.Adapt(System.Reflection.MethodInfo, System.Type)
    
        
        
        
        :type method: System.Reflection.MethodInfo
        
        
        :type inputType: System.Type
        :rtype: System.Func{System.Object,System.Object,System.Boolean}
    
        
        .. code-block:: csharp
    
           public Func<object, object, bool> Adapt(MethodInfo method, Type inputType)
    

