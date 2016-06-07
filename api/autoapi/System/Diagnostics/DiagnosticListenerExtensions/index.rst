

DiagnosticListenerExtensions Class
==================================





Namespace
    :dn:ns:`System.Diagnostics`
Assemblies
    * Microsoft.Extensions.DiagnosticAdapter

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.Diagnostics.DiagnosticListenerExtensions`








Syntax
------

.. code-block:: csharp

    public class DiagnosticListenerExtensions








.. dn:class:: System.Diagnostics.DiagnosticListenerExtensions
    :hidden:

.. dn:class:: System.Diagnostics.DiagnosticListenerExtensions

Methods
-------

.. dn:class:: System.Diagnostics.DiagnosticListenerExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: System.Diagnostics.DiagnosticListenerExtensions.SubscribeWithAdapter(System.Diagnostics.DiagnosticListener, System.Object)
    
        
    
        
        :type diagnostic: System.Diagnostics.DiagnosticListener
    
        
        :type target: System.Object
        :rtype: System.IDisposable
    
        
        .. code-block:: csharp
    
            public static IDisposable SubscribeWithAdapter(DiagnosticListener diagnostic, object target)
    
    .. dn:method:: System.Diagnostics.DiagnosticListenerExtensions.SubscribeWithAdapter(System.Diagnostics.DiagnosticListener, System.Object, System.Func<System.String, System.Boolean>)
    
        
    
        
        :type diagnostic: System.Diagnostics.DiagnosticListener
    
        
        :type target: System.Object
    
        
        :type isEnabled: System.Func<System.Func`2>{System.String<System.String>, System.Boolean<System.Boolean>}
        :rtype: System.IDisposable
    
        
        .. code-block:: csharp
    
            public static IDisposable SubscribeWithAdapter(DiagnosticListener diagnostic, object target, Func<string, bool> isEnabled)
    

