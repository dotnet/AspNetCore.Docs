

IActionInvokerFactory Interface
===============================



.. contents:: 
   :local:













Syntax
------

.. code-block:: csharp

   public interface IActionInvokerFactory





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Core/Infrastructure/IActionInvokerFactory.cs>`_





.. dn:interface:: Microsoft.AspNet.Mvc.Infrastructure.IActionInvokerFactory

Methods
-------

.. dn:interface:: Microsoft.AspNet.Mvc.Infrastructure.IActionInvokerFactory
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Infrastructure.IActionInvokerFactory.CreateInvoker(Microsoft.AspNet.Mvc.ActionContext)
    
        
        
        
        :type actionContext: Microsoft.AspNet.Mvc.ActionContext
        :rtype: Microsoft.AspNet.Mvc.Abstractions.IActionInvoker
    
        
        .. code-block:: csharp
    
           IActionInvoker CreateInvoker(ActionContext actionContext)
    

