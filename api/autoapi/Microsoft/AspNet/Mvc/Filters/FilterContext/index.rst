

FilterContext Class
===================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.ActionContext`
* :dn:cls:`Microsoft.AspNet.Mvc.Filters.FilterContext`








Syntax
------

.. code-block:: csharp

   public abstract class FilterContext : ActionContext





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Abstractions/Filters/FilterContext.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Filters.FilterContext

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.Filters.FilterContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Filters.FilterContext.FilterContext(Microsoft.AspNet.Mvc.ActionContext, System.Collections.Generic.IList<Microsoft.AspNet.Mvc.Filters.IFilterMetadata>)
    
        
        
        
        :type actionContext: Microsoft.AspNet.Mvc.ActionContext
        
        
        :type filters: System.Collections.Generic.IList{Microsoft.AspNet.Mvc.Filters.IFilterMetadata}
    
        
        .. code-block:: csharp
    
           public FilterContext(ActionContext actionContext, IList<IFilterMetadata> filters)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.Filters.FilterContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Filters.FilterContext.Filters
    
        
        :rtype: System.Collections.Generic.IList{Microsoft.AspNet.Mvc.Filters.IFilterMetadata}
    
        
        .. code-block:: csharp
    
           public virtual IList<IFilterMetadata> Filters { get; }
    

