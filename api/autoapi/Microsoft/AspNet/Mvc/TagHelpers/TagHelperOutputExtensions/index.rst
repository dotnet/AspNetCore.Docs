

TagHelperOutputExtensions Class
===============================



.. contents:: 
   :local:



Summary
-------

Utility related extensions for :any:`Microsoft.AspNet.Razor.TagHelpers.TagHelperOutput`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.TagHelpers.TagHelperOutputExtensions`








Syntax
------

.. code-block:: csharp

   public class TagHelperOutputExtensions





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.TagHelpers/TagHelperOutputExtensions.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.TagHelpers.TagHelperOutputExtensions

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.TagHelpers.TagHelperOutputExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.TagHelpers.TagHelperOutputExtensions.CopyHtmlAttribute(Microsoft.AspNet.Razor.TagHelpers.TagHelperOutput, System.String, Microsoft.AspNet.Razor.TagHelpers.TagHelperContext)
    
        
    
        Copies a user-provided attribute from ``context``'s 
        :dn:prop:`Microsoft.AspNet.Razor.TagHelpers.TagHelperContext.AllAttributes` to ``tagHelperOutput``'s 
        :dn:prop:`Microsoft.AspNet.Razor.TagHelpers.TagHelperOutput.Attributes`\.
    
        
        
        
        :param tagHelperOutput: The  this method extends.
        
        :type tagHelperOutput: Microsoft.AspNet.Razor.TagHelpers.TagHelperOutput
        
        
        :param attributeName: The name of the bound attribute.
        
        :type attributeName: System.String
        
        
        :param context: The .
        
        :type context: Microsoft.AspNet.Razor.TagHelpers.TagHelperContext
    
        
        .. code-block:: csharp
    
           public static void CopyHtmlAttribute(TagHelperOutput tagHelperOutput, string attributeName, TagHelperContext context)
    
    .. dn:method:: Microsoft.AspNet.Mvc.TagHelpers.TagHelperOutputExtensions.MergeAttributes(Microsoft.AspNet.Razor.TagHelpers.TagHelperOutput, Microsoft.AspNet.Mvc.Rendering.TagBuilder)
    
        
    
        Merges the given ``tagBuilder``'s :dn:prop:`Microsoft.AspNet.Mvc.Rendering.TagBuilder.Attributes` into the
        ``tagHelperOutput``.
    
        
        
        
        :param tagHelperOutput: The  this method extends.
        
        :type tagHelperOutput: Microsoft.AspNet.Razor.TagHelpers.TagHelperOutput
        
        
        :param tagBuilder: The  to merge attributes from.
        
        :type tagBuilder: Microsoft.AspNet.Mvc.Rendering.TagBuilder
    
        
        .. code-block:: csharp
    
           public static void MergeAttributes(TagHelperOutput tagHelperOutput, TagBuilder tagBuilder)
    
    .. dn:method:: Microsoft.AspNet.Mvc.TagHelpers.TagHelperOutputExtensions.RemoveRange(Microsoft.AspNet.Razor.TagHelpers.TagHelperOutput, System.Collections.Generic.IEnumerable<Microsoft.AspNet.Razor.TagHelpers.TagHelperAttribute>)
    
        
    
        Removes the given ``attributes`` from ``tagHelperOutput``'s 
        :dn:prop:`Microsoft.AspNet.Razor.TagHelpers.TagHelperOutput.Attributes`\.
    
        
        
        
        :param tagHelperOutput: The  this method extends.
        
        :type tagHelperOutput: Microsoft.AspNet.Razor.TagHelpers.TagHelperOutput
        
        
        :param attributes: Attributes to remove.
        
        :type attributes: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Razor.TagHelpers.TagHelperAttribute}
    
        
        .. code-block:: csharp
    
           public static void RemoveRange(TagHelperOutput tagHelperOutput, IEnumerable<TagHelperAttribute> attributes)
    

