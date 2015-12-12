

DiagnosticSourceAdapter Class
=============================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.DiagnosticAdapter.DiagnosticSourceAdapter`








Syntax
------

.. code-block:: csharp

   public class DiagnosticSourceAdapter : IObserver<KeyValuePair<string, object>>





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/eventnotification/src/Microsoft.Extensions.DiagnosticAdapter/DiagnosticSourceAdapter.cs>`_





.. dn:class:: Microsoft.Extensions.DiagnosticAdapter.DiagnosticSourceAdapter

Constructors
------------

.. dn:class:: Microsoft.Extensions.DiagnosticAdapter.DiagnosticSourceAdapter
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Extensions.DiagnosticAdapter.DiagnosticSourceAdapter.DiagnosticSourceAdapter(System.Object)
    
        
        
        
        :type target: System.Object
    
        
        .. code-block:: csharp
    
           public DiagnosticSourceAdapter(object target)
    
    .. dn:constructor:: Microsoft.Extensions.DiagnosticAdapter.DiagnosticSourceAdapter.DiagnosticSourceAdapter(System.Object, System.Func<System.String, System.Boolean>)
    
        
        
        
        :type target: System.Object
        
        
        :type isEnabled: System.Func{System.String,System.Boolean}
    
        
        .. code-block:: csharp
    
           public DiagnosticSourceAdapter(object target, Func<string, bool> isEnabled)
    
    .. dn:constructor:: Microsoft.Extensions.DiagnosticAdapter.DiagnosticSourceAdapter.DiagnosticSourceAdapter(System.Object, System.Func<System.String, System.Boolean>, Microsoft.Extensions.DiagnosticAdapter.IDiagnosticSourceMethodAdapter)
    
        
        
        
        :type target: System.Object
        
        
        :type isEnabled: System.Func{System.String,System.Boolean}
        
        
        :type methodAdapter: Microsoft.Extensions.DiagnosticAdapter.IDiagnosticSourceMethodAdapter
    
        
        .. code-block:: csharp
    
           public DiagnosticSourceAdapter(object target, Func<string, bool> isEnabled, IDiagnosticSourceMethodAdapter methodAdapter)
    

Methods
-------

.. dn:class:: Microsoft.Extensions.DiagnosticAdapter.DiagnosticSourceAdapter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.DiagnosticAdapter.DiagnosticSourceAdapter.IsEnabled(System.String)
    
        
        
        
        :type diagnosticName: System.String
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool IsEnabled(string diagnosticName)
    
    .. dn:method:: Microsoft.Extensions.DiagnosticAdapter.DiagnosticSourceAdapter.System.IObserver<System.Collections.Generic.KeyValuePair<System.String, System.Object>>.OnCompleted()
    
        
    
        
        .. code-block:: csharp
    
           void IObserver<KeyValuePair<string, object>>.OnCompleted()
    
    .. dn:method:: Microsoft.Extensions.DiagnosticAdapter.DiagnosticSourceAdapter.System.IObserver<System.Collections.Generic.KeyValuePair<System.String, System.Object>>.OnError(System.Exception)
    
        
        
        
        :type error: System.Exception
    
        
        .. code-block:: csharp
    
           void IObserver<KeyValuePair<string, object>>.OnError(Exception error)
    
    .. dn:method:: Microsoft.Extensions.DiagnosticAdapter.DiagnosticSourceAdapter.System.IObserver<System.Collections.Generic.KeyValuePair<System.String, System.Object>>.OnNext(System.Collections.Generic.KeyValuePair<System.String, System.Object>)
    
        
        
        
        :type value: System.Collections.Generic.KeyValuePair{System.String,System.Object}
    
        
        .. code-block:: csharp
    
           void IObserver<KeyValuePair<string, object>>.OnNext(KeyValuePair<string, object> value)
    
    .. dn:method:: Microsoft.Extensions.DiagnosticAdapter.DiagnosticSourceAdapter.Write(System.String, System.Object)
    
        
        
        
        :type diagnosticName: System.String
        
        
        :type parameters: System.Object
    
        
        .. code-block:: csharp
    
           public void Write(string diagnosticName, object parameters)
    

