

TagHelperContentExtensions Class
================================



.. contents:: 
   :local:



Summary
-------

Extension methods for :any:`Microsoft.AspNet.Razor.TagHelpers.TagHelperContent`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Mvc.TagHelpers.TagHelperContentExtensions`








Syntax
------

.. code-block:: csharp

   public class TagHelperContentExtensions





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.TagHelpers/TagHelperContentExtensions.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.TagHelpers.TagHelperContentExtensions

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.TagHelpers.TagHelperContentExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.TagHelpers.TagHelperContentExtensions.Append(Microsoft.AspNet.Razor.TagHelpers.TagHelperContent, Microsoft.Extensions.WebEncoders.IHtmlEncoder, System.Text.Encoding, System.Object)
    
        
    
        Writes the specified ``value`` with HTML encoding to given ``content``.
    
        
        
        
        :param content: The  to write to.
        
        :type content: Microsoft.AspNet.Razor.TagHelpers.TagHelperContent
        
        
        :param encoder: The  to use when encoding .
        
        :type encoder: Microsoft.Extensions.WebEncoders.IHtmlEncoder
        
        
        :param encoding: The character encoding in which the  is written.
        
        :type encoding: System.Text.Encoding
        
        
        :param value: The  to write.
        
        :type value: System.Object
        :rtype: Microsoft.AspNet.Razor.TagHelpers.TagHelperContent
        :return: <paramref name="content" /> after the write operation has completed.
    
        
        .. code-block:: csharp
    
           public static TagHelperContent Append(TagHelperContent content, IHtmlEncoder encoder, Encoding encoding, object value)
    

