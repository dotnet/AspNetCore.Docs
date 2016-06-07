

IDiagnosticSourceMethodAdapter Interface
========================================





Namespace
    :dn:ns:`Microsoft.Extensions.DiagnosticAdapter`
Assemblies
    * Microsoft.Extensions.DiagnosticAdapter

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IDiagnosticSourceMethodAdapter








.. dn:interface:: Microsoft.Extensions.DiagnosticAdapter.IDiagnosticSourceMethodAdapter
    :hidden:

.. dn:interface:: Microsoft.Extensions.DiagnosticAdapter.IDiagnosticSourceMethodAdapter

Methods
-------

.. dn:interface:: Microsoft.Extensions.DiagnosticAdapter.IDiagnosticSourceMethodAdapter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.DiagnosticAdapter.IDiagnosticSourceMethodAdapter.Adapt(System.Reflection.MethodInfo, System.Type)
    
        
    
        
        :type method: System.Reflection.MethodInfo
    
        
        :type inputType: System.Type
        :rtype: System.Func<System.Func`3>{System.Object<System.Object>, System.Object<System.Object>, System.Boolean<System.Boolean>}
    
        
        .. code-block:: csharp
    
            Func<object, object, bool> Adapt(MethodInfo method, Type inputType)
    

