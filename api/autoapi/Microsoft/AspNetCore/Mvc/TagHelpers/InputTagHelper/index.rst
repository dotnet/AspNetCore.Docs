

InputTagHelper Class
====================






:any:`Microsoft.AspNetCore.Razor.TagHelpers.ITagHelper` implementation targeting <input> elements with an <code>asp-for</code> attribute.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper`








Syntax
------

.. code-block:: csharp

    [HtmlTargetElement("input", Attributes = "asp-for", TagStructure = TagStructure.WithoutEndTag)]
    public class InputTagHelper : TagHelper, ITagHelper








.. dn:class:: Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper.InputTagHelper(Microsoft.AspNetCore.Mvc.ViewFeatures.IHtmlGenerator)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper`\.
    
        
    
        
        :param generator: The :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.IHtmlGenerator`\.
        
        :type generator: Microsoft.AspNetCore.Mvc.ViewFeatures.IHtmlGenerator
    
        
        .. code-block:: csharp
    
            public InputTagHelper(IHtmlGenerator generator)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper.For
    
        
    
        
        An expression to be evaluated against the current model.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ViewFeatures.ModelExpression
    
        
        .. code-block:: csharp
    
            [HtmlAttributeName("asp-for")]
            public ModelExpression For { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper.Format
    
        
    
        
        The composite format :any:`System.String` (see http://msdn.microsoft.com/en-us/library/txafckwd.aspx) to
        apply when converting the :dn:prop:`Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper.For` result to a :any:`System.String`\. Sets the generated "value"
        attribute to that formatted :any:`System.String`\.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            [HtmlAttributeName("asp-format")]
            public string Format { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper.Generator
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ViewFeatures.IHtmlGenerator
    
        
        .. code-block:: csharp
    
            protected IHtmlGenerator Generator { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper.InputTypeName
    
        
    
        
        The type of the <input> element.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            [HtmlAttributeName("type")]
            public string InputTypeName { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper.Order
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public override int Order { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper.Value
    
        
    
        
        The value of the <input> element.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Value { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper.ViewContext
    
        
        :rtype: Microsoft.AspNetCore.Mvc.Rendering.ViewContext
    
        
        .. code-block:: csharp
    
            [HtmlAttributeNotBound]
            public ViewContext ViewContext { get; set; }
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper.Process(Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContext, Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput)
    
        
    
        
        :type context: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContext
    
        
        :type output: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput
    
        
        .. code-block:: csharp
    
            public override void Process(TagHelperContext context, TagHelperOutput output)
    

