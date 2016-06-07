

TagHelperContentExtensions Class
================================






Extension methods for :any:`Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContent`\.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.TagHelpers.TagHelperContentExtensions`








Syntax
------

.. code-block:: csharp

    public class TagHelperContentExtensions








.. dn:class:: Microsoft.AspNetCore.Mvc.TagHelpers.TagHelperContentExtensions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.TagHelpers.TagHelperContentExtensions

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.TagHelpers.TagHelperContentExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.TagHelpers.TagHelperContentExtensions.Append(Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContent, System.Text.Encodings.Web.HtmlEncoder, System.Object)
    
        
    
        
        Writes the specified <em>value</em> with HTML encoding to given <em>content</em>.
    
        
    
        
        :param content: The :any:`Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContent` to write to.
        
        :type content: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContent
    
        
        :param encoder: The :any:`System.Text.Encodings.Web.HtmlEncoder` to use when encoding <em>value</em>.
        
        :type encoder: System.Text.Encodings.Web.HtmlEncoder
    
        
        :param value: The :any:`System.Object` to write.
        
        :type value: System.Object
        :rtype: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContent
        :return: <em>content</em> after the write operation has completed.
    
        
        .. code-block:: csharp
    
            public static TagHelperContent Append(TagHelperContent content, HtmlEncoder encoder, object value)
    

