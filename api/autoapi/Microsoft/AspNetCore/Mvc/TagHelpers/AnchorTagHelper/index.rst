

AnchorTagHelper Class
=====================






:any:`Microsoft.AspNetCore.Razor.TagHelpers.ITagHelper` implementation targeting <a> elements.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.TagHelpers`
Assemblies
    * Microsoft.AspNetCore.Mvc.TagHelpers

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Razor.TagHelpers.TagHelper`
* :dn:cls:`Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper`








Syntax
------

.. code-block:: csharp

    [HtmlTargetElement("a", Attributes = "asp-action")]
    [HtmlTargetElement("a", Attributes = "asp-controller")]
    [HtmlTargetElement("a", Attributes = "asp-area")]
    [HtmlTargetElement("a", Attributes = "asp-fragment")]
    [HtmlTargetElement("a", Attributes = "asp-host")]
    [HtmlTargetElement("a", Attributes = "asp-protocol")]
    [HtmlTargetElement("a", Attributes = "asp-route")]
    [HtmlTargetElement("a", Attributes = "asp-all-route-data")]
    [HtmlTargetElement("a", Attributes = "asp-route-*")]
    public class AnchorTagHelper : TagHelper, ITagHelper








.. dn:class:: Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper.AnchorTagHelper(Microsoft.AspNetCore.Mvc.ViewFeatures.IHtmlGenerator)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper`\.
    
        
    
        
        :param generator: The :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.IHtmlGenerator`\.
        
        :type generator: Microsoft.AspNetCore.Mvc.ViewFeatures.IHtmlGenerator
    
        
        .. code-block:: csharp
    
            public AnchorTagHelper(IHtmlGenerator generator)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper.Action
    
        
    
        
        The name of the action method.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            [HtmlAttributeName("asp-action")]
            public string Action { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper.Area
    
        
    
        
        The name of the area.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            [HtmlAttributeName("asp-area")]
            public string Area { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper.Controller
    
        
    
        
        The name of the controller.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            [HtmlAttributeName("asp-controller")]
            public string Controller { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper.Fragment
    
        
    
        
        The URL fragment name.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            [HtmlAttributeName("asp-fragment")]
            public string Fragment { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper.Generator
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ViewFeatures.IHtmlGenerator
    
        
        .. code-block:: csharp
    
            protected IHtmlGenerator Generator { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper.Host
    
        
    
        
        The host name.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            [HtmlAttributeName("asp-host")]
            public string Host { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper.Order
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public override int Order { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper.Protocol
    
        
    
        
        The protocol for the URL, such as "http" or "https".
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            [HtmlAttributeName("asp-protocol")]
            public string Protocol { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper.Route
    
        
    
        
        Name of the route.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            [HtmlAttributeName("asp-route")]
            public string Route { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper.RouteValues
    
        
    
        
        Additional parameters for the route.
    
        
        :rtype: System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{System.String<System.String>, System.String<System.String>}
    
        
        .. code-block:: csharp
    
            [HtmlAttributeName("asp-all-route-data", DictionaryAttributePrefix = "asp-route-")]
            public IDictionary<string, string> RouteValues { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper.ViewContext
    
        
    
        
        Gets or sets the :any:`Microsoft.AspNetCore.Mvc.Rendering.ViewContext` for the current request.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.Rendering.ViewContext
    
        
        .. code-block:: csharp
    
            [HtmlAttributeNotBound]
            public ViewContext ViewContext { get; set; }
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper.Process(Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContext, Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput)
    
        
    
        
        :type context: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContext
    
        
        :type output: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput
    
        
        .. code-block:: csharp
    
            public override void Process(TagHelperContext context, TagHelperOutput output)
    

