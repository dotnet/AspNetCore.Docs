

TagHelperOutputExtensions Class
===============================






Utility related extensions for :any:`Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput`\.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.TagHelpers.TagHelperOutputExtensions`








Syntax
------

.. code-block:: csharp

    public class TagHelperOutputExtensions








.. dn:class:: Microsoft.AspNetCore.Mvc.TagHelpers.TagHelperOutputExtensions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.TagHelpers.TagHelperOutputExtensions

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.TagHelpers.TagHelperOutputExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.TagHelpers.TagHelperOutputExtensions.CopyHtmlAttribute(Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput, System.String, Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContext)
    
        
    
        
        Copies a user-provided attribute from <em>context</em>'s 
        :dn:prop:`Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContext.AllAttributes` to <em>tagHelperOutput</em>'s 
        :dn:prop:`Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput.Attributes`\.
    
        
    
        
        :param tagHelperOutput: The :any:`Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput` this method extends.
        
        :type tagHelperOutput: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput
    
        
        :param attributeName: The name of the bound attribute.
        
        :type attributeName: System.String
    
        
        :param context: The :any:`Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContext`\.
        
        :type context: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContext
    
        
        .. code-block:: csharp
    
            public static void CopyHtmlAttribute(this TagHelperOutput tagHelperOutput, string attributeName, TagHelperContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.TagHelpers.TagHelperOutputExtensions.MergeAttributes(Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput, Microsoft.AspNetCore.Mvc.Rendering.TagBuilder)
    
        
    
        
        Merges the given <em>tagBuilder</em>'s :dn:prop:`Microsoft.AspNetCore.Mvc.Rendering.TagBuilder.Attributes` into the
        <em>tagHelperOutput</em>.
    
        
    
        
        :param tagHelperOutput: The :any:`Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput` this method extends.
        
        :type tagHelperOutput: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput
    
        
        :param tagBuilder: The :any:`Microsoft.AspNetCore.Mvc.Rendering.TagBuilder` to merge attributes from.
        
        :type tagBuilder: Microsoft.AspNetCore.Mvc.Rendering.TagBuilder
    
        
        .. code-block:: csharp
    
            public static void MergeAttributes(this TagHelperOutput tagHelperOutput, TagBuilder tagBuilder)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.TagHelpers.TagHelperOutputExtensions.RemoveRange(Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput, System.Collections.Generic.IEnumerable<Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute>)
    
        
    
        
        Removes the given <em>attributes</em> from <em>tagHelperOutput</em>'s 
        :dn:prop:`Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput.Attributes`\.
    
        
    
        
        :param tagHelperOutput: The :any:`Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput` this method extends.
        
        :type tagHelperOutput: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput
    
        
        :param attributes: Attributes to remove.
        
        :type attributes: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute<Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute>}
    
        
        .. code-block:: csharp
    
            public static void RemoveRange(this TagHelperOutput tagHelperOutput, IEnumerable<TagHelperAttribute> attributes)
    

