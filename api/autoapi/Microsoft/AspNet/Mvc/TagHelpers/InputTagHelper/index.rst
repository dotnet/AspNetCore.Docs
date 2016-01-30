

InputTagHelper Class
====================



.. contents:: 
   :local:



Summary
-------

:any:`Microsoft.AspNet.Razor.TagHelpers.ITagHelper` implementation targeting &lt;input&gt; elements with an <c>asp-for</c> attribute.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.TagHelpers.TagHelper`
* :dn:cls:`Microsoft.AspNet.Mvc.TagHelpers.InputTagHelper`








Syntax
------

.. code-block:: csharp

   public class InputTagHelper : TagHelper, ITagHelper





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.TagHelpers/InputTagHelper.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.TagHelpers.InputTagHelper

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.TagHelpers.InputTagHelper
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.TagHelpers.InputTagHelper.InputTagHelper(Microsoft.AspNet.Mvc.ViewFeatures.IHtmlGenerator)
    
        
    
        Creates a new :any:`Microsoft.AspNet.Mvc.TagHelpers.InputTagHelper`\.
    
        
        
        
        :param generator: The .
        
        :type generator: Microsoft.AspNet.Mvc.ViewFeatures.IHtmlGenerator
    
        
        .. code-block:: csharp
    
           public InputTagHelper(IHtmlGenerator generator)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.TagHelpers.InputTagHelper
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.TagHelpers.InputTagHelper.Process(Microsoft.AspNet.Razor.TagHelpers.TagHelperContext, Microsoft.AspNet.Razor.TagHelpers.TagHelperOutput)
    
        
        
        
        :type context: Microsoft.AspNet.Razor.TagHelpers.TagHelperContext
        
        
        :type output: Microsoft.AspNet.Razor.TagHelpers.TagHelperOutput
    
        
        .. code-block:: csharp
    
           public override void Process(TagHelperContext context, TagHelperOutput output)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.TagHelpers.InputTagHelper
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.TagHelpers.InputTagHelper.For
    
        
    
        An expression to be evaluated against the current model.
    
        
        :rtype: Microsoft.AspNet.Mvc.Rendering.ModelExpression
    
        
        .. code-block:: csharp
    
           public ModelExpression For { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.TagHelpers.InputTagHelper.Format
    
        
    
        The composite format :any:`System.String` (see http://msdn.microsoft.com/en-us/library/txafckwd.aspx) to
        apply when converting the :dn:prop:`Microsoft.AspNet.Mvc.TagHelpers.InputTagHelper.For` result to a :any:`System.String`\. Sets the generated "value"
        attribute to that formatted :any:`System.String`\.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Format { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.TagHelpers.InputTagHelper.Generator
    
        
        :rtype: Microsoft.AspNet.Mvc.ViewFeatures.IHtmlGenerator
    
        
        .. code-block:: csharp
    
           protected IHtmlGenerator Generator { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.TagHelpers.InputTagHelper.InputTypeName
    
        
    
        The type of the &lt;input&gt; element.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string InputTypeName { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.TagHelpers.InputTagHelper.Order
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public override int Order { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.TagHelpers.InputTagHelper.Value
    
        
    
        The value of the &lt;input&gt; element.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string Value { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.TagHelpers.InputTagHelper.ViewContext
    
        
        :rtype: Microsoft.AspNet.Mvc.Rendering.ViewContext
    
        
        .. code-block:: csharp
    
           public ViewContext ViewContext { get; set; }
    

