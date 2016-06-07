

ViewLocationExpanderContext Class
=================================






A context for containing information for :any:`Microsoft.AspNetCore.Mvc.Razor.IViewLocationExpander`\.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.Razor`
Assemblies
    * Microsoft.AspNetCore.Mvc.Razor

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.Razor.ViewLocationExpanderContext`








Syntax
------

.. code-block:: csharp

    public class ViewLocationExpanderContext








.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.ViewLocationExpanderContext
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.ViewLocationExpanderContext

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.ViewLocationExpanderContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Razor.ViewLocationExpanderContext.ActionContext
    
        
    
        
        Gets the :any:`Microsoft.AspNetCore.Mvc.ActionContext` for the current executing action.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ActionContext
    
        
        .. code-block:: csharp
    
            public ActionContext ActionContext
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Razor.ViewLocationExpanderContext.AreaName
    
        
    
        
        Gets the area name.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string AreaName
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Razor.ViewLocationExpanderContext.ControllerName
    
        
    
        
        Gets the controller name.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string ControllerName
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Razor.ViewLocationExpanderContext.IsMainPage
    
        
    
        
        Determines if the page being found is the main page for an action.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool IsMainPage
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Razor.ViewLocationExpanderContext.Values
    
        
    
        
        Gets or sets the :any:`System.Collections.Generic.IDictionary\`2` that is populated with values as part of
        :dn:meth:`Microsoft.AspNetCore.Mvc.Razor.IViewLocationExpander.PopulateValues(Microsoft.AspNetCore.Mvc.Razor.ViewLocationExpanderContext)`\.
    
        
        :rtype: System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{System.String<System.String>, System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public IDictionary<string, string> Values
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.Razor.ViewLocationExpanderContext.ViewName
    
        
    
        
        Gets the view name.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string ViewName
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.Razor.ViewLocationExpanderContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.Razor.ViewLocationExpanderContext.ViewLocationExpanderContext(Microsoft.AspNetCore.Mvc.ActionContext, System.String, System.String, System.String, System.Boolean)
    
        
    
        
        Initializes a new instance of :any:`Microsoft.AspNetCore.Mvc.Razor.ViewLocationExpanderContext`\.
    
        
    
        
        :param actionContext: The :any:`Microsoft.AspNetCore.Mvc.ActionContext` for the current executing action.
        
        :type actionContext: Microsoft.AspNetCore.Mvc.ActionContext
    
        
        :param viewName: The view name.
        
        :type viewName: System.String
    
        
        :param controllerName: The controller name.
        
        :type controllerName: System.String
    
        
        :param areaName: The area name.
        
        :type areaName: System.String
    
        
        :param isMainPage: Determines if the page being found is the main page for an action.
        
        :type isMainPage: System.Boolean
    
        
        .. code-block:: csharp
    
            public ViewLocationExpanderContext(ActionContext actionContext, string viewName, string controllerName, string areaName, bool isMainPage)
    

