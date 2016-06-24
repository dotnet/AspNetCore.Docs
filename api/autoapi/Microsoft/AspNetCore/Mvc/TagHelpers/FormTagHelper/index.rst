

FormTagHelper Class
===================






:any:`Microsoft.AspNetCore.Razor.TagHelpers.ITagHelper` implementation targeting <form> elements.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper`








Syntax
------

.. code-block:: csharp

    [HtmlTargetElement("form", Attributes = "asp-action")]
    [HtmlTargetElement("form", Attributes = "asp-antiforgery")]
    [HtmlTargetElement("form", Attributes = "asp-area")]
    [HtmlTargetElement("form", Attributes = "asp-controller")]
    [HtmlTargetElement("form", Attributes = "asp-route")]
    [HtmlTargetElement("form", Attributes = "asp-all-route-data")]
    [HtmlTargetElement("form", Attributes = "asp-route-*")]
    public class FormTagHelper : TagHelper, ITagHelper








.. dn:class:: Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper.FormTagHelper(Microsoft.AspNetCore.Mvc.ViewFeatures.IHtmlGenerator)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper`\.
    
        
    
        
        :param generator: The :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.IHtmlGenerator`\.
        
        :type generator: Microsoft.AspNetCore.Mvc.ViewFeatures.IHtmlGenerator
    
        
        .. code-block:: csharp
    
            public FormTagHelper(IHtmlGenerator generator)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper.Action
    
        
    
        
        The name of the action method.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            [HtmlAttributeName("asp-action")]
            public string Action { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper.Antiforgery
    
        
    
        
        Whether the antiforgery token should be generated.
    
        
        :rtype: System.Nullable<System.Nullable`1>{System.Boolean<System.Boolean>}
        :return: Defaults to <code>false</code> if user provides an <code>action</code> attribute
            or if the <code>method</code> is :dn:field:`Microsoft.AspNetCore.Mvc.Rendering.FormMethod.Get`\; <code>true</code> otherwise.
    
        
        .. code-block:: csharp
    
            [HtmlAttributeName("asp-antiforgery")]
            public bool ? Antiforgery { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper.Area
    
        
    
        
        The name of the area.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            [HtmlAttributeName("asp-area")]
            public string Area { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper.Controller
    
        
    
        
        The name of the controller.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            [HtmlAttributeName("asp-controller")]
            public string Controller { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper.Generator
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ViewFeatures.IHtmlGenerator
    
        
        .. code-block:: csharp
    
            protected IHtmlGenerator Generator { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper.Method
    
        
    
        
        The HTTP method to use.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            [EditorBrowsable(EditorBrowsableState.Never)]
            public string Method { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper.Order
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public override int Order { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper.Route
    
        
    
        
        Name of the route.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            [HtmlAttributeName("asp-route")]
            public string Route { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper.RouteValues
    
        
    
        
        Additional parameters for the route.
    
        
        :rtype: System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{System.String<System.String>, System.String<System.String>}
    
        
        .. code-block:: csharp
    
            [HtmlAttributeName("asp-all-route-data", DictionaryAttributePrefix = "asp-route-")]
            public IDictionary<string, string> RouteValues { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper.ViewContext
    
        
        :rtype: Microsoft.AspNetCore.Mvc.Rendering.ViewContext
    
        
        .. code-block:: csharp
    
            [HtmlAttributeNotBound]
            public ViewContext ViewContext { get; set; }
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper.Process(Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContext, Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput)
    
        
    
        
        :type context: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContext
    
        
        :type output: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput
    
        
        .. code-block:: csharp
    
            public override void Process(TagHelperContext context, TagHelperOutput output)
    

