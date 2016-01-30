

AnchorTagHelper Class
=====================



.. contents:: 
   :local:



Summary
-------

:any:`Microsoft.AspNet.Razor.TagHelpers.ITagHelper` implementation targeting &lt;a&gt; elements.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.TagHelpers.TagHelper`
* :dn:cls:`Microsoft.AspNet.Mvc.TagHelpers.AnchorTagHelper`








Syntax
------

.. code-block:: csharp

   public class AnchorTagHelper : TagHelper, ITagHelper





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.TagHelpers/AnchorTagHelper.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.TagHelpers.AnchorTagHelper

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.TagHelpers.AnchorTagHelper
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.TagHelpers.AnchorTagHelper.AnchorTagHelper(Microsoft.AspNet.Mvc.ViewFeatures.IHtmlGenerator)
    
        
    
        Creates a new :any:`Microsoft.AspNet.Mvc.TagHelpers.AnchorTagHelper`\.
    
        
        
        
        :param generator: The .
        
        :type generator: Microsoft.AspNet.Mvc.ViewFeatures.IHtmlGenerator
    
        
        .. code-block:: csharp
    
           public AnchorTagHelper(IHtmlGenerator generator)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.TagHelpers.AnchorTagHelper
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.TagHelpers.AnchorTagHelper.Process(Microsoft.AspNet.Razor.TagHelpers.TagHelperContext, Microsoft.AspNet.Razor.TagHelpers.TagHelperOutput)
    
        
        
        
        :type context: Microsoft.AspNet.Razor.TagHelpers.TagHelperContext
        
        
        :type output: Microsoft.AspNet.Razor.TagHelpers.TagHelperOutput
    
        
        .. code-block:: csharp
    
           public override void Process(TagHelperContext context, TagHelperOutput output)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.TagHelpers.AnchorTagHelper
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.TagHelpers.AnchorTagHelper.Action
    
        
    
        The name of the action method.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Action { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.TagHelpers.AnchorTagHelper.Controller
    
        
    
        The name of the controller.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Controller { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.TagHelpers.AnchorTagHelper.Fragment
    
        
    
        The URL fragment name.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Fragment { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.TagHelpers.AnchorTagHelper.Generator
    
        
        :rtype: Microsoft.AspNet.Mvc.ViewFeatures.IHtmlGenerator
    
        
        .. code-block:: csharp
    
           protected IHtmlGenerator Generator { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.TagHelpers.AnchorTagHelper.Host
    
        
    
        The host name.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Host { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.TagHelpers.AnchorTagHelper.Order
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public override int Order { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.TagHelpers.AnchorTagHelper.Protocol
    
        
    
        The protocol for the URL, such as "http" or "https".
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Protocol { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.TagHelpers.AnchorTagHelper.Route
    
        
    
        Name of the route.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Route { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.TagHelpers.AnchorTagHelper.RouteValues
    
        
    
        Additional parameters for the route.
    
        
        :rtype: System.Collections.Generic.IDictionary{System.String,System.String}
    
        
        .. code-block:: csharp
    
           public IDictionary<string, string> RouteValues { get; set; }
    

