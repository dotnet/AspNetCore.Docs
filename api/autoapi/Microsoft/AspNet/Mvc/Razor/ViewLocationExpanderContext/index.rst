

ViewLocationExpanderContext Class
=================================



.. contents:: 
   :local:



Summary
-------

A context for containing information for :any:`Microsoft.AspNet.Mvc.Razor.IViewLocationExpander`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.Razor.ViewLocationExpanderContext`








Syntax
------

.. code-block:: csharp

   public class ViewLocationExpanderContext





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Razor/ViewLocationExpanderContext.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Razor.ViewLocationExpanderContext

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.Razor.ViewLocationExpanderContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Razor.ViewLocationExpanderContext.ViewLocationExpanderContext(Microsoft.AspNet.Mvc.ActionContext, System.String, System.Boolean)
    
        
    
        Initializes a new instance of :any:`Microsoft.AspNet.Mvc.Razor.ViewLocationExpanderContext`\.
    
        
        
        
        :param actionContext: The  for the current executing action.
        
        :type actionContext: Microsoft.AspNet.Mvc.ActionContext
        
        
        :param viewName: The view name.
        
        :type viewName: System.String
        
        
        :param isPartial: Determines if the view being discovered is a partial.
        
        :type isPartial: System.Boolean
    
        
        .. code-block:: csharp
    
           public ViewLocationExpanderContext(ActionContext actionContext, string viewName, bool isPartial)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.Razor.ViewLocationExpanderContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Razor.ViewLocationExpanderContext.ActionContext
    
        
    
        Gets the :any:`Microsoft.AspNet.Mvc.ActionContext` for the current executing action.
    
        
        :rtype: Microsoft.AspNet.Mvc.ActionContext
    
        
        .. code-block:: csharp
    
           public ActionContext ActionContext { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Razor.ViewLocationExpanderContext.IsPartial
    
        
    
        Gets a value that determines if a partial view is being discovered.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool IsPartial { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Razor.ViewLocationExpanderContext.Values
    
        
    
        Gets or sets the :any:`System.Collections.Generic.IDictionary\`2` that is populated with values as part of 
        :dn:meth:`Microsoft.AspNet.Mvc.Razor.IViewLocationExpander.PopulateValues(Microsoft.AspNet.Mvc.Razor.ViewLocationExpanderContext)`\.
    
        
        :rtype: System.Collections.Generic.IDictionary{System.String,System.String}
    
        
        .. code-block:: csharp
    
           public IDictionary<string, string> Values { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Razor.ViewLocationExpanderContext.ViewName
    
        
    
        Gets the view name.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string ViewName { get; }
    

