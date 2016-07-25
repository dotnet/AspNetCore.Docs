

ValidationSummaryTagHelper Class
================================






:any:`Microsoft.AspNetCore.Razor.TagHelpers.ITagHelper` implementation targeting any HTML element with an <code>asp-validation-summary</code>
attribute.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper`








Syntax
------

.. code-block:: csharp

    [HtmlTargetElement("div", Attributes = "asp-validation-summary")]
    public class ValidationSummaryTagHelper : TagHelper, ITagHelper








.. dn:class:: Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper.ValidationSummaryTagHelper(Microsoft.AspNetCore.Mvc.ViewFeatures.IHtmlGenerator)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper`\.
    
        
    
        
        :param generator: The :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.IHtmlGenerator`\.
        
        :type generator: Microsoft.AspNetCore.Mvc.ViewFeatures.IHtmlGenerator
    
        
        .. code-block:: csharp
    
            public ValidationSummaryTagHelper(IHtmlGenerator generator)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper.Generator
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ViewFeatures.IHtmlGenerator
    
        
        .. code-block:: csharp
    
            [HtmlAttributeNotBound]
            protected IHtmlGenerator Generator { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper.Order
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public override int Order { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper.ValidationSummary
    
        
    
        
        If :dn:field:`Microsoft.AspNetCore.Mvc.Rendering.ValidationSummary.All` or :dn:field:`Microsoft.AspNetCore.Mvc.Rendering.ValidationSummary.ModelOnly`\, appends a validation
        summary. Otherwise ( :dn:field:`Microsoft.AspNetCore.Mvc.Rendering.ValidationSummary.None`\, the default), this tag helper does nothing.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.Rendering.ValidationSummary
    
        
        .. code-block:: csharp
    
            [HtmlAttributeName("asp-validation-summary")]
            public ValidationSummary ValidationSummary { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper.ViewContext
    
        
        :rtype: Microsoft.AspNetCore.Mvc.Rendering.ViewContext
    
        
        .. code-block:: csharp
    
            [HtmlAttributeNotBound]
            public ViewContext ViewContext { get; set; }
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper.Process(Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContext, Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput)
    
        
    
        
        :type context: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContext
    
        
        :type output: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput
    
        
        .. code-block:: csharp
    
            public override void Process(TagHelperContext context, TagHelperOutput output)
    

