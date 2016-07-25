

SelectTagHelper Class
=====================






:any:`Microsoft.AspNetCore.Razor.TagHelpers.ITagHelper` implementation targeting <select> elements with <code>asp-for</code> and/or
<code>asp-items</code> attribute(s).


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper`








Syntax
------

.. code-block:: csharp

    [HtmlTargetElement("select", Attributes = "asp-for")]
    [HtmlTargetElement("select", Attributes = "asp-items")]
    public class SelectTagHelper : TagHelper, ITagHelper








.. dn:class:: Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper.SelectTagHelper(Microsoft.AspNetCore.Mvc.ViewFeatures.IHtmlGenerator)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper`\.
    
        
    
        
        :param generator: The :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.IHtmlGenerator`\.
        
        :type generator: Microsoft.AspNetCore.Mvc.ViewFeatures.IHtmlGenerator
    
        
        .. code-block:: csharp
    
            public SelectTagHelper(IHtmlGenerator generator)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper.For
    
        
    
        
        An expression to be evaluated against the current model.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExpression
    
        
        .. code-block:: csharp
    
            [HtmlAttributeName("asp-for")]
            public ModelExpression For { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper.Generator
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ViewFeatures.IHtmlGenerator
    
        
        .. code-block:: csharp
    
            protected IHtmlGenerator Generator { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper.Items
    
        
    
        
        A collection of :any:`Microsoft.AspNetCore.Mvc.Rendering.SelectListItem` objects used to populate the <select> element with
        <optgroup> and <option> elements.
    
        
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Mvc.Rendering.SelectListItem<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>}
    
        
        .. code-block:: csharp
    
            [HtmlAttributeName("asp-items")]
            public IEnumerable<SelectListItem> Items { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper.Order
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public override int Order { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper.ViewContext
    
        
        :rtype: Microsoft.AspNetCore.Mvc.Rendering.ViewContext
    
        
        .. code-block:: csharp
    
            [HtmlAttributeNotBound]
            public ViewContext ViewContext { get; set; }
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper.Init(Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContext
    
        
        .. code-block:: csharp
    
            public override void Init(TagHelperContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper.Process(Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContext, Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput)
    
        
    
        
        :type context: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContext
    
        
        :type output: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput
    
        
        .. code-block:: csharp
    
            public override void Process(TagHelperContext context, TagHelperOutput output)
    

