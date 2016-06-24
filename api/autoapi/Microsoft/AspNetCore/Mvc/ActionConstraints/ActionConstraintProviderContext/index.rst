

ActionConstraintProviderContext Class
=====================================






Context for an action constraint provider.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.ActionConstraints`
Assemblies
    * Microsoft.AspNetCore.Mvc.Abstractions

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ActionConstraints.ActionConstraintProviderContext`








Syntax
------

.. code-block:: csharp

    public class ActionConstraintProviderContext








.. dn:class:: Microsoft.AspNetCore.Mvc.ActionConstraints.ActionConstraintProviderContext
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ActionConstraints.ActionConstraintProviderContext

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.ActionConstraints.ActionConstraintProviderContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ActionConstraints.ActionConstraintProviderContext.ActionConstraintProviderContext(Microsoft.AspNetCore.Http.HttpContext, Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor, System.Collections.Generic.IList<Microsoft.AspNetCore.Mvc.ActionConstraints.ActionConstraintItem>)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.ActionConstraints.ActionConstraintProviderContext`\.
    
        
    
        
        :param context: The :any:`Microsoft.AspNetCore.Http.HttpContext` associated with the request.
        
        :type context: Microsoft.AspNetCore.Http.HttpContext
    
        
        :param action: The :any:`Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor` for which constraints are being created.
        
        :type action: Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor
    
        
        :param items: The list of :any:`Microsoft.AspNetCore.Mvc.ActionConstraints.ActionConstraintItem` objects.
        
        :type items: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.AspNetCore.Mvc.ActionConstraints.ActionConstraintItem<Microsoft.AspNetCore.Mvc.ActionConstraints.ActionConstraintItem>}
    
        
        .. code-block:: csharp
    
            public ActionConstraintProviderContext(HttpContext context, ActionDescriptor action, IList<ActionConstraintItem> items)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.ActionConstraints.ActionConstraintProviderContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ActionConstraints.ActionConstraintProviderContext.Action
    
        
    
        
        The :any:`Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor` for which constraints are being created.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor
    
        
        .. code-block:: csharp
    
            public ActionDescriptor Action { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ActionConstraints.ActionConstraintProviderContext.HttpContext
    
        
    
        
        The :any:`Microsoft.AspNetCore.Http.HttpContext` associated with the request.
    
        
        :rtype: Microsoft.AspNetCore.Http.HttpContext
    
        
        .. code-block:: csharp
    
            public HttpContext HttpContext { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ActionConstraints.ActionConstraintProviderContext.Results
    
        
    
        
        The list of :any:`Microsoft.AspNetCore.Mvc.ActionConstraints.ActionConstraintItem` objects.
    
        
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.AspNetCore.Mvc.ActionConstraints.ActionConstraintItem<Microsoft.AspNetCore.Mvc.ActionConstraints.ActionConstraintItem>}
    
        
        .. code-block:: csharp
    
            public IList<ActionConstraintItem> Results { get; }
    

