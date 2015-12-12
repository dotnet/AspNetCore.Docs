

ActionInvokerProviderContext Class
==================================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Abstractions.ActionInvokerProviderContext`








Syntax
------

.. code-block:: csharp

   public class ActionInvokerProviderContext





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Abstractions/Abstractions/ActionInvokerProviderContext.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Abstractions.ActionInvokerProviderContext

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.Abstractions.ActionInvokerProviderContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Abstractions.ActionInvokerProviderContext.ActionInvokerProviderContext(Microsoft.AspNet.Mvc.ActionContext)
    
        
        
        
        :type actionContext: Microsoft.AspNet.Mvc.ActionContext
    
        
        .. code-block:: csharp
    
           public ActionInvokerProviderContext(ActionContext actionContext)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.Abstractions.ActionInvokerProviderContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Abstractions.ActionInvokerProviderContext.ActionContext
    
        
        :rtype: Microsoft.AspNet.Mvc.ActionContext
    
        
        .. code-block:: csharp
    
           public ActionContext ActionContext { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Abstractions.ActionInvokerProviderContext.Result
    
        
        :rtype: Microsoft.AspNet.Mvc.Abstractions.IActionInvoker
    
        
        .. code-block:: csharp
    
           public IActionInvoker Result { get; set; }
    

