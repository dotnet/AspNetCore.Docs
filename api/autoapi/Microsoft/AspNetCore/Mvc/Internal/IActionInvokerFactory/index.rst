

IActionInvokerFactory Interface
===============================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Internal`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IActionInvokerFactory








.. dn:interface:: Microsoft.AspNetCore.Mvc.Internal.IActionInvokerFactory
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Mvc.Internal.IActionInvokerFactory

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Mvc.Internal.IActionInvokerFactory
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.IActionInvokerFactory.CreateInvoker(Microsoft.AspNetCore.Mvc.ActionContext)
    
        
    
        
        :type actionContext: Microsoft.AspNetCore.Mvc.ActionContext
        :rtype: Microsoft.AspNetCore.Mvc.Abstractions.IActionInvoker
    
        
        .. code-block:: csharp
    
            IActionInvoker CreateInvoker(ActionContext actionContext)
    

