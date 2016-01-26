

FormTagHelper Class
===================



.. contents:: 
   :local:



Summary
-------

:any:`Microsoft.AspNet.Razor.TagHelpers.ITagHelper` implementation targeting &lt;form&gt; elements.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.TagHelpers.TagHelper`
* :dn:cls:`Microsoft.AspNet.Mvc.TagHelpers.FormTagHelper`








Syntax
------

.. code-block:: csharp

   public class FormTagHelper : TagHelper, ITagHelper





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.TagHelpers/FormTagHelper.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.TagHelpers.FormTagHelper

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.TagHelpers.FormTagHelper
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.TagHelpers.FormTagHelper.FormTagHelper(Microsoft.AspNet.Mvc.ViewFeatures.IHtmlGenerator)
    
        
    
        Creates a new :any:`Microsoft.AspNet.Mvc.TagHelpers.FormTagHelper`\.
    
        
        
        
        :param generator: The .
        
        :type generator: Microsoft.AspNet.Mvc.ViewFeatures.IHtmlGenerator
    
        
        .. code-block:: csharp
    
           public FormTagHelper(IHtmlGenerator generator)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.TagHelpers.FormTagHelper
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.TagHelpers.FormTagHelper.Process(Microsoft.AspNet.Razor.TagHelpers.TagHelperContext, Microsoft.AspNet.Razor.TagHelpers.TagHelperOutput)
    
        
        
        
        :type context: Microsoft.AspNet.Razor.TagHelpers.TagHelperContext
        
        
        :type output: Microsoft.AspNet.Razor.TagHelpers.TagHelperOutput
    
        
        .. code-block:: csharp
    
           public override void Process(TagHelperContext context, TagHelperOutput output)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.TagHelpers.FormTagHelper
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.TagHelpers.FormTagHelper.Action
    
        
    
        The name of the action method.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Action { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.TagHelpers.FormTagHelper.Antiforgery
    
        
    
        Whether the antiforgery token should be generated.
    
        
        :rtype: System.Nullable{System.Boolean}
    
        
        .. code-block:: csharp
    
           public bool ? Antiforgery { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.TagHelpers.FormTagHelper.Controller
    
        
    
        The name of the controller.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Controller { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.TagHelpers.FormTagHelper.Generator
    
        
        :rtype: Microsoft.AspNet.Mvc.ViewFeatures.IHtmlGenerator
    
        
        .. code-block:: csharp
    
           protected IHtmlGenerator Generator { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.TagHelpers.FormTagHelper.Order
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public override int Order { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.TagHelpers.FormTagHelper.Route
    
        
    
        Name of the route.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Route { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.TagHelpers.FormTagHelper.RouteValues
    
        
    
        Additional parameters for the route.
    
        
        :rtype: System.Collections.Generic.IDictionary{System.String,System.String}
    
        
        .. code-block:: csharp
    
           public IDictionary<string, string> RouteValues { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.TagHelpers.FormTagHelper.ViewContext
    
        
        :rtype: Microsoft.AspNet.Mvc.Rendering.ViewContext
    
        
        .. code-block:: csharp
    
           public ViewContext ViewContext { get; set; }
    

