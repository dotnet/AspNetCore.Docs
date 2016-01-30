

LabelTagHelper Class
====================



.. contents:: 
   :local:



Summary
-------

:any:`Microsoft.AspNet.Razor.TagHelpers.ITagHelper` implementation targeting &lt;label&gt; elements with an <c>asp-for</c> attribute.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.TagHelpers.TagHelper`
* :dn:cls:`Microsoft.AspNet.Mvc.TagHelpers.LabelTagHelper`








Syntax
------

.. code-block:: csharp

   public class LabelTagHelper : TagHelper, ITagHelper





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.TagHelpers/LabelTagHelper.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.TagHelpers.LabelTagHelper

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.TagHelpers.LabelTagHelper
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.TagHelpers.LabelTagHelper.LabelTagHelper(Microsoft.AspNet.Mvc.ViewFeatures.IHtmlGenerator)
    
        
    
        Creates a new :any:`Microsoft.AspNet.Mvc.TagHelpers.LabelTagHelper`\.
    
        
        
        
        :param generator: The .
        
        :type generator: Microsoft.AspNet.Mvc.ViewFeatures.IHtmlGenerator
    
        
        .. code-block:: csharp
    
           public LabelTagHelper(IHtmlGenerator generator)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.TagHelpers.LabelTagHelper
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.TagHelpers.LabelTagHelper.ProcessAsync(Microsoft.AspNet.Razor.TagHelpers.TagHelperContext, Microsoft.AspNet.Razor.TagHelpers.TagHelperOutput)
    
        
        
        
        :type context: Microsoft.AspNet.Razor.TagHelpers.TagHelperContext
        
        
        :type output: Microsoft.AspNet.Razor.TagHelpers.TagHelperOutput
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.TagHelpers.LabelTagHelper
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.TagHelpers.LabelTagHelper.For
    
        
    
        An expression to be evaluated against the current model.
    
        
        :rtype: Microsoft.AspNet.Mvc.Rendering.ModelExpression
    
        
        .. code-block:: csharp
    
           public ModelExpression For { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.TagHelpers.LabelTagHelper.Generator
    
        
        :rtype: Microsoft.AspNet.Mvc.ViewFeatures.IHtmlGenerator
    
        
        .. code-block:: csharp
    
           protected IHtmlGenerator Generator { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.TagHelpers.LabelTagHelper.Order
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public override int Order { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.TagHelpers.LabelTagHelper.ViewContext
    
        
        :rtype: Microsoft.AspNet.Mvc.Rendering.ViewContext
    
        
        .. code-block:: csharp
    
           public ViewContext ViewContext { get; set; }
    

