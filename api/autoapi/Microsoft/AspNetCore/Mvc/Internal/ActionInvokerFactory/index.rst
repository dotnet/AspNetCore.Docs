

ActionInvokerFactory Class
==========================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Internal`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Internal.ActionInvokerFactory`








Syntax
------

.. code-block:: csharp

    public class ActionInvokerFactory : IActionInvokerFactory








.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.ActionInvokerFactory
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.ActionInvokerFactory

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.ActionInvokerFactory
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Internal.ActionInvokerFactory.ActionInvokerFactory(System.Collections.Generic.IEnumerable<Microsoft.AspNetCore.Mvc.Abstractions.IActionInvokerProvider>)
    
        
    
        
        :type actionInvokerProviders: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Mvc.Abstractions.IActionInvokerProvider<Microsoft.AspNetCore.Mvc.Abstractions.IActionInvokerProvider>}
    
        
        .. code-block:: csharp
    
            public ActionInvokerFactory(IEnumerable<IActionInvokerProvider> actionInvokerProviders)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.Internal.ActionInvokerFactory
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.Internal.ActionInvokerFactory.CreateInvoker(Microsoft.AspNetCore.Mvc.ActionContext)
    
        
    
        
        :type actionContext: Microsoft.AspNetCore.Mvc.ActionContext
        :rtype: Microsoft.AspNetCore.Mvc.Abstractions.IActionInvoker
    
        
        .. code-block:: csharp
    
            public IActionInvoker CreateInvoker(ActionContext actionContext)
    

