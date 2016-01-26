

DefaultTagHelperContent Class
=============================



.. contents:: 
   :local:



Summary
-------

Default concrete :any:`Microsoft.AspNet.Razor.TagHelpers.TagHelperContent`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.TagHelpers.TagHelperContent`
* :dn:cls:`Microsoft.AspNet.Razor.TagHelpers.DefaultTagHelperContent`








Syntax
------

.. code-block:: csharp

   public class DefaultTagHelperContent : TagHelperContent, IHtmlContentBuilder, IHtmlContent





GitHub
------

`View on GitHub <https://github.com/aspnet/razor/blob/master/src/Microsoft.AspNet.Razor.Runtime/TagHelpers/DefaultTagHelperContent.cs>`_





.. dn:class:: Microsoft.AspNet.Razor.TagHelpers.DefaultTagHelperContent

Methods
-------

.. dn:class:: Microsoft.AspNet.Razor.TagHelpers.DefaultTagHelperContent
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Razor.TagHelpers.DefaultTagHelperContent.Append(Microsoft.AspNet.Html.Abstractions.IHtmlContent)
    
        
        
        
        :type htmlContent: Microsoft.AspNet.Html.Abstractions.IHtmlContent
        :rtype: Microsoft.AspNet.Razor.TagHelpers.TagHelperContent
    
        
        .. code-block:: csharp
    
           public override TagHelperContent Append(IHtmlContent htmlContent)
    
    .. dn:method:: Microsoft.AspNet.Razor.TagHelpers.DefaultTagHelperContent.Append(System.String)
    
        
        
        
        :type unencoded: System.String
        :rtype: Microsoft.AspNet.Razor.TagHelpers.TagHelperContent
    
        
        .. code-block:: csharp
    
           public override TagHelperContent Append(string unencoded)
    
    .. dn:method:: Microsoft.AspNet.Razor.TagHelpers.DefaultTagHelperContent.AppendHtml(System.String)
    
        
        
        
        :type encoded: System.String
        :rtype: Microsoft.AspNet.Razor.TagHelpers.TagHelperContent
    
        
        .. code-block:: csharp
    
           public override TagHelperContent AppendHtml(string encoded)
    
    .. dn:method:: Microsoft.AspNet.Razor.TagHelpers.DefaultTagHelperContent.Clear()
    
        
        :rtype: Microsoft.AspNet.Razor.TagHelpers.TagHelperContent
    
        
        .. code-block:: csharp
    
           public override TagHelperContent Clear()
    
    .. dn:method:: Microsoft.AspNet.Razor.TagHelpers.DefaultTagHelperContent.GetContent()
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public override string GetContent()
    
    .. dn:method:: Microsoft.AspNet.Razor.TagHelpers.DefaultTagHelperContent.GetContent(Microsoft.Extensions.WebEncoders.IHtmlEncoder)
    
        
        
        
        :type encoder: Microsoft.Extensions.WebEncoders.IHtmlEncoder
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public override string GetContent(IHtmlEncoder encoder)
    
    .. dn:method:: Microsoft.AspNet.Razor.TagHelpers.DefaultTagHelperContent.WriteTo(System.IO.TextWriter, Microsoft.Extensions.WebEncoders.IHtmlEncoder)
    
        
        
        
        :type writer: System.IO.TextWriter
        
        
        :type encoder: Microsoft.Extensions.WebEncoders.IHtmlEncoder
    
        
        .. code-block:: csharp
    
           public override void WriteTo(TextWriter writer, IHtmlEncoder encoder)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Razor.TagHelpers.DefaultTagHelperContent
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Razor.TagHelpers.DefaultTagHelperContent.IsEmpty
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public override bool IsEmpty { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.TagHelpers.DefaultTagHelperContent.IsModified
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public override bool IsModified { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.TagHelpers.DefaultTagHelperContent.IsWhiteSpace
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public override bool IsWhiteSpace { get; }
    

