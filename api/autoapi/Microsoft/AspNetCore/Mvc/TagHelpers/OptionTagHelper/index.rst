

OptionTagHelper Class
=====================






:any:`Microsoft.AspNetCore.Razor.TagHelpers.ITagHelper` implementation targeting <option> elements.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper`








Syntax
------

.. code-block:: csharp

    public class OptionTagHelper : TagHelper, ITagHelper








.. dn:class:: Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper.Generator
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ViewFeatures.IHtmlGenerator
    
        
        .. code-block:: csharp
    
            protected IHtmlGenerator Generator
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper.Order
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public override int Order
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper.Value
    
        
    
        
        Specifies a value for the <option> element.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Value
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper.ViewContext
    
        
        :rtype: Microsoft.AspNetCore.Mvc.Rendering.ViewContext
    
        
        .. code-block:: csharp
    
            [HtmlAttributeNotBound]
            public ViewContext ViewContext
            {
                get;
                set;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper.OptionTagHelper(Microsoft.AspNetCore.Mvc.ViewFeatures.IHtmlGenerator)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper`\.
    
        
    
        
        :param generator: The :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.IHtmlGenerator`\.
        
        :type generator: Microsoft.AspNetCore.Mvc.ViewFeatures.IHtmlGenerator
    
        
        .. code-block:: csharp
    
            public OptionTagHelper(IHtmlGenerator generator)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper.ProcessAsync(Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContext, Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput)
    
        
    
        
        :type context: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContext
    
        
        :type output: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    

