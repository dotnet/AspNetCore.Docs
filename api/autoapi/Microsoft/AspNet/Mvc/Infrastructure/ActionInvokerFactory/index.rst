

ActionInvokerFactory Class
==========================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Infrastructure.ActionInvokerFactory`








Syntax
------

.. code-block:: csharp

   public class ActionInvokerFactory : IActionInvokerFactory





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Core/Infrastructure/ActionInvokerFactory.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Infrastructure.ActionInvokerFactory

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.Infrastructure.ActionInvokerFactory
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Infrastructure.ActionInvokerFactory.ActionInvokerFactory(System.Collections.Generic.IEnumerable<Microsoft.AspNet.Mvc.Abstractions.IActionInvokerProvider>)
    
        
        
        
        :type actionInvokerProviders: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Mvc.Abstractions.IActionInvokerProvider}
    
        
        .. code-block:: csharp
    
           public ActionInvokerFactory(IEnumerable<IActionInvokerProvider> actionInvokerProviders)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Infrastructure.ActionInvokerFactory
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Infrastructure.ActionInvokerFactory.CreateInvoker(Microsoft.AspNet.Mvc.ActionContext)
    
        
        
        
        :type actionContext: Microsoft.AspNet.Mvc.ActionContext
        :rtype: Microsoft.AspNet.Mvc.Abstractions.IActionInvoker
    
        
        .. code-block:: csharp
    
           public IActionInvoker CreateInvoker(ActionContext actionContext)
    

