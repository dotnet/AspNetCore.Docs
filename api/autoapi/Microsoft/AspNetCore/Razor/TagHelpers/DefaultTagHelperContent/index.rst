

DefaultTagHelperContent Class
=============================






Default concrete :any:`Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContent`\.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Razor.TagHelpers`
Assemblies
    * Microsoft.AspNetCore.Razor.Runtime

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContent`
* :dn:cls:`Microsoft.AspNetCore.Razor.TagHelpers.DefaultTagHelperContent`








Syntax
------

.. code-block:: csharp

    [DebuggerDisplay("{DebuggerToString(),nq}")]
    public class DefaultTagHelperContent : TagHelperContent, IHtmlContentBuilder, IHtmlContentContainer, IHtmlContent








.. dn:class:: Microsoft.AspNetCore.Razor.TagHelpers.DefaultTagHelperContent
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Razor.TagHelpers.DefaultTagHelperContent

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Razor.TagHelpers.DefaultTagHelperContent
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Razor.TagHelpers.DefaultTagHelperContent.IsEmptyOrWhiteSpace
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public override bool IsEmptyOrWhiteSpace
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.TagHelpers.DefaultTagHelperContent.IsModified
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public override bool IsModified
            {
                get;
            }
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Razor.TagHelpers.DefaultTagHelperContent
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Razor.TagHelpers.DefaultTagHelperContent.Append(System.String)
    
        
    
        
        :type unencoded: System.String
        :rtype: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContent
    
        
        .. code-block:: csharp
    
            public override TagHelperContent Append(string unencoded)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.TagHelpers.DefaultTagHelperContent.AppendHtml(Microsoft.AspNetCore.Html.IHtmlContent)
    
        
    
        
        :type htmlContent: Microsoft.AspNetCore.Html.IHtmlContent
        :rtype: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContent
    
        
        .. code-block:: csharp
    
            public override TagHelperContent AppendHtml(IHtmlContent htmlContent)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.TagHelpers.DefaultTagHelperContent.AppendHtml(System.String)
    
        
    
        
        :type encoded: System.String
        :rtype: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContent
    
        
        .. code-block:: csharp
    
            public override TagHelperContent AppendHtml(string encoded)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.TagHelpers.DefaultTagHelperContent.Clear()
    
        
        :rtype: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContent
    
        
        .. code-block:: csharp
    
            public override TagHelperContent Clear()
    
    .. dn:method:: Microsoft.AspNetCore.Razor.TagHelpers.DefaultTagHelperContent.CopyTo(Microsoft.AspNetCore.Html.IHtmlContentBuilder)
    
        
    
        
        :type destination: Microsoft.AspNetCore.Html.IHtmlContentBuilder
    
        
        .. code-block:: csharp
    
            public override void CopyTo(IHtmlContentBuilder destination)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.TagHelpers.DefaultTagHelperContent.GetContent()
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public override string GetContent()
    
    .. dn:method:: Microsoft.AspNetCore.Razor.TagHelpers.DefaultTagHelperContent.GetContent(System.Text.Encodings.Web.HtmlEncoder)
    
        
    
        
        :type encoder: System.Text.Encodings.Web.HtmlEncoder
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public override string GetContent(HtmlEncoder encoder)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.TagHelpers.DefaultTagHelperContent.MoveTo(Microsoft.AspNetCore.Html.IHtmlContentBuilder)
    
        
    
        
        :type destination: Microsoft.AspNetCore.Html.IHtmlContentBuilder
    
        
        .. code-block:: csharp
    
            public override void MoveTo(IHtmlContentBuilder destination)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.TagHelpers.DefaultTagHelperContent.Reinitialize()
    
        
    
        
        .. code-block:: csharp
    
            public override void Reinitialize()
    
    .. dn:method:: Microsoft.AspNetCore.Razor.TagHelpers.DefaultTagHelperContent.WriteTo(System.IO.TextWriter, System.Text.Encodings.Web.HtmlEncoder)
    
        
    
        
        :type writer: System.IO.TextWriter
    
        
        :type encoder: System.Text.Encodings.Web.HtmlEncoder
    
        
        .. code-block:: csharp
    
            public override void WriteTo(TextWriter writer, HtmlEncoder encoder)
    

