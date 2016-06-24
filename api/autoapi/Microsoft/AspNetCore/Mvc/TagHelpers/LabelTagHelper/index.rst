

LabelTagHelper Class
====================






:any:`Microsoft.AspNetCore.Razor.TagHelpers.ITagHelper` implementation targeting <label> elements with an <code>asp-for</code> attribute.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper`








Syntax
------

.. code-block:: csharp

    [HtmlTargetElement("label", Attributes = "asp-for")]
    public class LabelTagHelper : TagHelper, ITagHelper








.. dn:class:: Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper.LabelTagHelper(Microsoft.AspNetCore.Mvc.ViewFeatures.IHtmlGenerator)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper`\.
    
        
    
        
        :param generator: The :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.IHtmlGenerator`\.
        
        :type generator: Microsoft.AspNetCore.Mvc.ViewFeatures.IHtmlGenerator
    
        
        .. code-block:: csharp
    
            public LabelTagHelper(IHtmlGenerator generator)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper.For
    
        
    
        
        An expression to be evaluated against the current model.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExpression
    
        
        .. code-block:: csharp
    
            [HtmlAttributeName("asp-for")]
            public ModelExpression For { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper.Generator
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ViewFeatures.IHtmlGenerator
    
        
        .. code-block:: csharp
    
            protected IHtmlGenerator Generator { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper.Order
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public override int Order { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper.ViewContext
    
        
        :rtype: Microsoft.AspNetCore.Mvc.Rendering.ViewContext
    
        
        .. code-block:: csharp
    
            [HtmlAttributeNotBound]
            public ViewContext ViewContext { get; set; }
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper.ProcessAsync(Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContext, Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput)
    
        
    
        
        :type context: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContext
    
        
        :type output: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    

