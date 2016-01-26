

DiagnosticListenerExtensions Class
==================================



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





GitHub
------

`View on GitHub <https://github.com/aspnet/eventnotification/blob/master/src/Microsoft.Extensions.DiagnosticAdapter/DiagnosticListenerExtensions.cs>`_





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
        
        
        :type isEnabled: System.Func{System.String,System.Boolean}
        :rtype: System.IDisposable
    
        
        .. code-block:: csharp
    
           public static IDisposable SubscribeWithAdapter(DiagnosticListener diagnostic, object target, Func<string, bool> isEnabled)
    

