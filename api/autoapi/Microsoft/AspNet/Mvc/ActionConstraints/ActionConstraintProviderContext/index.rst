

ActionConstraintProviderContext Class
=====================================



.. contents:: 
   :local:



Summary
-------

Context for an action constraint provider.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ActionConstraints.ActionConstraintProviderContext`








Syntax
------

.. code-block:: csharp

   public class ActionConstraintProviderContext





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Abstractions/ActionConstraints/ActionConstraintProviderContext.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ActionConstraints.ActionConstraintProviderContext

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.ActionConstraints.ActionConstraintProviderContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ActionConstraints.ActionConstraintProviderContext.ActionConstraintProviderContext(Microsoft.AspNet.Http.HttpContext, Microsoft.AspNet.Mvc.Abstractions.ActionDescriptor, System.Collections.Generic.IList<Microsoft.AspNet.Mvc.ActionConstraints.ActionConstraintItem>)
    
        
    
        Creates a new :any:`Microsoft.AspNet.Mvc.ActionConstraints.ActionConstraintProviderContext`\.
    
        
        
        
        :type context: Microsoft.AspNet.Http.HttpContext
        
        
        :param action: The  for which constraints are being created.
        
        :type action: Microsoft.AspNet.Mvc.Abstractions.ActionDescriptor
        
        
        :param items: The list of  objects.
        
        :type items: System.Collections.Generic.IList{Microsoft.AspNet.Mvc.ActionConstraints.ActionConstraintItem}
    
        
        .. code-block:: csharp
    
           public ActionConstraintProviderContext(HttpContext context, ActionDescriptor action, IList<ActionConstraintItem> items)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.ActionConstraints.ActionConstraintProviderContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.ActionConstraints.ActionConstraintProviderContext.Action
    
        
    
        The :any:`Microsoft.AspNet.Mvc.Abstractions.ActionDescriptor` for which constraints are being created.
    
        
        :rtype: Microsoft.AspNet.Mvc.Abstractions.ActionDescriptor
    
        
        .. code-block:: csharp
    
           public ActionDescriptor Action { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ActionConstraints.ActionConstraintProviderContext.HttpContext
    
        
        :rtype: Microsoft.AspNet.Http.HttpContext
    
        
        .. code-block:: csharp
    
           public HttpContext HttpContext { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ActionConstraints.ActionConstraintProviderContext.Results
    
        
    
        The list of :any:`Microsoft.AspNet.Mvc.ActionConstraints.ActionConstraintItem` objects.
    
        
        :rtype: System.Collections.Generic.IList{Microsoft.AspNet.Mvc.ActionConstraints.ActionConstraintItem}
    
        
        .. code-block:: csharp
    
           public IList<ActionConstraintItem> Results { get; }
    

