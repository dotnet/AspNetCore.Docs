

ActionInvokerProviderContext Class
==================================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Abstractions`
Assemblies
    * Microsoft.AspNetCore.Mvc.Abstractions

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Abstractions.ActionInvokerProviderContext`








Syntax
------

.. code-block:: csharp

    public class ActionInvokerProviderContext








.. dn:class:: Microsoft.AspNetCore.Mvc.Abstractions.ActionInvokerProviderContext
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Abstractions.ActionInvokerProviderContext

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Abstractions.ActionInvokerProviderContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Abstractions.ActionInvokerProviderContext.ActionInvokerProviderContext(Microsoft.AspNetCore.Mvc.ActionContext)
    
        
    
        
        :type actionContext: Microsoft.AspNetCore.Mvc.ActionContext
    
        
        .. code-block:: csharp
    
            public ActionInvokerProviderContext(ActionContext actionContext)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.Abstractions.ActionInvokerProviderContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Abstractions.ActionInvokerProviderContext.ActionContext
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ActionContext
    
        
        .. code-block:: csharp
    
            public ActionContext ActionContext { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Abstractions.ActionInvokerProviderContext.Result
    
        
        :rtype: Microsoft.AspNetCore.Mvc.Abstractions.IActionInvoker
    
        
        .. code-block:: csharp
    
            public IActionInvoker Result { get; set; }
    

