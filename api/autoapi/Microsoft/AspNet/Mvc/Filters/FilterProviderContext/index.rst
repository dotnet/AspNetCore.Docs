

FilterProviderContext Class
===========================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Filters.FilterProviderContext`








Syntax
------

.. code-block:: csharp

   public class FilterProviderContext





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Abstractions/Filters/FilterProviderContext.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Filters.FilterProviderContext

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.Filters.FilterProviderContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Filters.FilterProviderContext.FilterProviderContext(Microsoft.AspNet.Mvc.ActionContext, System.Collections.Generic.IList<Microsoft.AspNet.Mvc.Filters.FilterItem>)
    
        
        
        
        :type actionContext: Microsoft.AspNet.Mvc.ActionContext
        
        
        :type items: System.Collections.Generic.IList{Microsoft.AspNet.Mvc.Filters.FilterItem}
    
        
        .. code-block:: csharp
    
           public FilterProviderContext(ActionContext actionContext, IList<FilterItem> items)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.Filters.FilterProviderContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Filters.FilterProviderContext.ActionContext
    
        
        :rtype: Microsoft.AspNet.Mvc.ActionContext
    
        
        .. code-block:: csharp
    
           public ActionContext ActionContext { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Filters.FilterProviderContext.Results
    
        
        :rtype: System.Collections.Generic.IList{Microsoft.AspNet.Mvc.Filters.FilterItem}
    
        
        .. code-block:: csharp
    
           public IList<FilterItem> Results { get; set; }
    

