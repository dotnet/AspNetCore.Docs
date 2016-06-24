

TextAreaTagHelper Class
=======================






:any:`Microsoft.AspNetCore.Razor.TagHelpers.ITagHelper` implementation targeting <textarea> elements with an <code>asp-for</code> attribute.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.TagHelpers.TextAreaTagHelper`








Syntax
------

.. code-block:: csharp

    [HtmlTargetElement("textarea", Attributes = "asp-for")]
    public class TextAreaTagHelper : TagHelper, ITagHelper








.. dn:class:: Microsoft.AspNetCore.Mvc.TagHelpers.TextAreaTagHelper
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.TagHelpers.TextAreaTagHelper

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.TagHelpers.TextAreaTagHelper
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.TagHelpers.TextAreaTagHelper.TextAreaTagHelper(Microsoft.AspNetCore.Mvc.ViewFeatures.IHtmlGenerator)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.TagHelpers.TextAreaTagHelper`\.
    
        
    
        
        :param generator: The :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.IHtmlGenerator`\.
        
        :type generator: Microsoft.AspNetCore.Mvc.ViewFeatures.IHtmlGenerator
    
        
        .. code-block:: csharp
    
            public TextAreaTagHelper(IHtmlGenerator generator)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.TagHelpers.TextAreaTagHelper
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.TagHelpers.TextAreaTagHelper.For
    
        
    
        
        An expression to be evaluated against the current model.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExpression
    
        
        .. code-block:: csharp
    
            [HtmlAttributeName("asp-for")]
            public ModelExpression For { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.TagHelpers.TextAreaTagHelper.Generator
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ViewFeatures.IHtmlGenerator
    
        
        .. code-block:: csharp
    
            protected IHtmlGenerator Generator { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.TagHelpers.TextAreaTagHelper.Order
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public override int Order { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.TagHelpers.TextAreaTagHelper.ViewContext
    
        
        :rtype: Microsoft.AspNetCore.Mvc.Rendering.ViewContext
    
        
        .. code-block:: csharp
    
            [HtmlAttributeNotBound]
            public ViewContext ViewContext { get; set; }
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.TagHelpers.TextAreaTagHelper
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.TagHelpers.TextAreaTagHelper.Process(Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContext, Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput)
    
        
    
        
        :type context: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContext
    
        
        :type output: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput
    
        
        .. code-block:: csharp
    
            public override void Process(TagHelperContext context, TagHelperOutput output)
    

