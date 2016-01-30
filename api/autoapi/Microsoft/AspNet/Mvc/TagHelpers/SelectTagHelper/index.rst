

SelectTagHelper Class
=====================



.. contents:: 
   :local:



Summary
-------

:any:`Microsoft.AspNet.Razor.TagHelpers.ITagHelper` implementation targeting &lt;select&gt; elements with an <c>asp-for</c> attribute.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.TagHelpers.TagHelper`
* :dn:cls:`Microsoft.AspNet.Mvc.TagHelpers.SelectTagHelper`








Syntax
------

.. code-block:: csharp

   public class SelectTagHelper : TagHelper, ITagHelper





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.TagHelpers/SelectTagHelper.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.TagHelpers.SelectTagHelper

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.TagHelpers.SelectTagHelper
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.TagHelpers.SelectTagHelper.SelectTagHelper(Microsoft.AspNet.Mvc.ViewFeatures.IHtmlGenerator)
    
        
    
        Creates a new :any:`Microsoft.AspNet.Mvc.TagHelpers.SelectTagHelper`\.
    
        
        
        
        :param generator: The .
        
        :type generator: Microsoft.AspNet.Mvc.ViewFeatures.IHtmlGenerator
    
        
        .. code-block:: csharp
    
           public SelectTagHelper(IHtmlGenerator generator)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.TagHelpers.SelectTagHelper
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.TagHelpers.SelectTagHelper.Init(Microsoft.AspNet.Razor.TagHelpers.TagHelperContext)
    
        
        
        
        :type context: Microsoft.AspNet.Razor.TagHelpers.TagHelperContext
    
        
        .. code-block:: csharp
    
           public override void Init(TagHelperContext context)
    
    .. dn:method:: Microsoft.AspNet.Mvc.TagHelpers.SelectTagHelper.Process(Microsoft.AspNet.Razor.TagHelpers.TagHelperContext, Microsoft.AspNet.Razor.TagHelpers.TagHelperOutput)
    
        
        
        
        :type context: Microsoft.AspNet.Razor.TagHelpers.TagHelperContext
        
        
        :type output: Microsoft.AspNet.Razor.TagHelpers.TagHelperOutput
    
        
        .. code-block:: csharp
    
           public override void Process(TagHelperContext context, TagHelperOutput output)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.TagHelpers.SelectTagHelper
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.TagHelpers.SelectTagHelper.For
    
        
    
        An expression to be evaluated against the current model.
    
        
        :rtype: Microsoft.AspNet.Mvc.Rendering.ModelExpression
    
        
        .. code-block:: csharp
    
           public ModelExpression For { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.TagHelpers.SelectTagHelper.Generator
    
        
        :rtype: Microsoft.AspNet.Mvc.ViewFeatures.IHtmlGenerator
    
        
        .. code-block:: csharp
    
           protected IHtmlGenerator Generator { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.TagHelpers.SelectTagHelper.Items
    
        
    
        A collection of :any:`Microsoft.AspNet.Mvc.Rendering.SelectListItem` objects used to populate the &lt;select&gt; element with
        &lt;optgroup&gt; and &lt;option&gt; elements.
    
        
        :rtype: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Mvc.Rendering.SelectListItem}
    
        
        .. code-block:: csharp
    
           public IEnumerable<SelectListItem> Items { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.TagHelpers.SelectTagHelper.Order
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public override int Order { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.TagHelpers.SelectTagHelper.ViewContext
    
        
        :rtype: Microsoft.AspNet.Mvc.Rendering.ViewContext
    
        
        .. code-block:: csharp
    
           public ViewContext ViewContext { get; set; }
    

