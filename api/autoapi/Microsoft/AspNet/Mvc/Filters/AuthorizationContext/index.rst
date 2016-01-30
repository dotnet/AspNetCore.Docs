

AuthorizationContext Class
==========================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ActionContext`
* :dn:cls:`Microsoft.AspNet.Mvc.Filters.FilterContext`
* :dn:cls:`Microsoft.AspNet.Mvc.Filters.AuthorizationContext`








Syntax
------

.. code-block:: csharp

   public class AuthorizationContext : FilterContext





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Abstractions/Filters/AuthorizationContext.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Filters.AuthorizationContext

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.Filters.AuthorizationContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Filters.AuthorizationContext.AuthorizationContext(Microsoft.AspNet.Mvc.ActionContext, System.Collections.Generic.IList<Microsoft.AspNet.Mvc.Filters.IFilterMetadata>)
    
        
        
        
        :type actionContext: Microsoft.AspNet.Mvc.ActionContext
        
        
        :type filters: System.Collections.Generic.IList{Microsoft.AspNet.Mvc.Filters.IFilterMetadata}
    
        
        .. code-block:: csharp
    
           public AuthorizationContext(ActionContext actionContext, IList<IFilterMetadata> filters)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.Filters.AuthorizationContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Filters.AuthorizationContext.Result
    
        
        :rtype: Microsoft.AspNet.Mvc.IActionResult
    
        
        .. code-block:: csharp
    
           public virtual IActionResult Result { get; set; }
    

