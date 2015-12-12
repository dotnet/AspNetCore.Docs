

ValidationSummaryTagHelper Class
================================



.. contents:: 
   :local:



Summary
-------

:any:`Microsoft.AspNet.Razor.TagHelpers.ITagHelper` implementation targeting any HTML element with an <c>asp-validation-summary</c>
attribute.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.TagHelpers.TagHelper`
* :dn:cls:`Microsoft.AspNet.Mvc.TagHelpers.ValidationSummaryTagHelper`








Syntax
------

.. code-block:: csharp

   public class ValidationSummaryTagHelper : TagHelper, ITagHelper





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.TagHelpers/ValidationSummaryTagHelper.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.TagHelpers.ValidationSummaryTagHelper

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.TagHelpers.ValidationSummaryTagHelper
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.TagHelpers.ValidationSummaryTagHelper.ValidationSummaryTagHelper(Microsoft.AspNet.Mvc.ViewFeatures.IHtmlGenerator)
    
        
    
        Creates a new :any:`Microsoft.AspNet.Mvc.TagHelpers.ValidationSummaryTagHelper`\.
    
        
        
        
        :param generator: The .
        
        :type generator: Microsoft.AspNet.Mvc.ViewFeatures.IHtmlGenerator
    
        
        .. code-block:: csharp
    
           public ValidationSummaryTagHelper(IHtmlGenerator generator)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.TagHelpers.ValidationSummaryTagHelper
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.TagHelpers.ValidationSummaryTagHelper.Process(Microsoft.AspNet.Razor.TagHelpers.TagHelperContext, Microsoft.AspNet.Razor.TagHelpers.TagHelperOutput)
    
        
        
        
        :type context: Microsoft.AspNet.Razor.TagHelpers.TagHelperContext
        
        
        :type output: Microsoft.AspNet.Razor.TagHelpers.TagHelperOutput
    
        
        .. code-block:: csharp
    
           public override void Process(TagHelperContext context, TagHelperOutput output)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.TagHelpers.ValidationSummaryTagHelper
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.TagHelpers.ValidationSummaryTagHelper.Generator
    
        
        :rtype: Microsoft.AspNet.Mvc.ViewFeatures.IHtmlGenerator
    
        
        .. code-block:: csharp
    
           protected IHtmlGenerator Generator { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.TagHelpers.ValidationSummaryTagHelper.Order
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public override int Order { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.TagHelpers.ValidationSummaryTagHelper.ValidationSummary
    
        
    
        If :dn:field:`Microsoft.AspNet.Mvc.Rendering.ValidationSummary.All` or :dn:field:`Microsoft.AspNet.Mvc.Rendering.ValidationSummary.ModelOnly`\, appends a validation
        summary. Otherwise ( :dn:field:`Microsoft.AspNet.Mvc.Rendering.ValidationSummary.None`\, the default), this tag helper does nothing.
    
        
        :rtype: Microsoft.AspNet.Mvc.Rendering.ValidationSummary
    
        
        .. code-block:: csharp
    
           public ValidationSummary ValidationSummary { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.TagHelpers.ValidationSummaryTagHelper.ViewContext
    
        
        :rtype: Microsoft.AspNet.Mvc.Rendering.ViewContext
    
        
        .. code-block:: csharp
    
           public ViewContext ViewContext { get; set; }
    

