

IDiagnosticSourceMethodAdapter Interface
========================================



.. contents:: 
   :local:













Syntax
------

.. code-block:: csharp

   public interface IDiagnosticSourceMethodAdapter





GitHub
------

`View on GitHub <https://github.com/aspnet/eventnotification/blob/master/src/Microsoft.Extensions.DiagnosticAdapter/IDiagnosticSourceMethodAdapter.cs>`_





.. dn:interface:: Microsoft.Extensions.DiagnosticAdapter.IDiagnosticSourceMethodAdapter

Methods
-------

.. dn:interface:: Microsoft.Extensions.DiagnosticAdapter.IDiagnosticSourceMethodAdapter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.DiagnosticAdapter.IDiagnosticSourceMethodAdapter.Adapt(System.Reflection.MethodInfo, System.Type)
    
        
        
        
        :type method: System.Reflection.MethodInfo
        
        
        :type inputType: System.Type
        :rtype: System.Func{System.Object,System.Object,System.Boolean}
    
        
        .. code-block:: csharp
    
           Func<object, object, bool> Adapt(MethodInfo method, Type inputType)
    

