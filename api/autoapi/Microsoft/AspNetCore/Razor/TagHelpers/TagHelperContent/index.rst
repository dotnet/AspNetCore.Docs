

TagHelperContent Class
======================






Abstract class used to buffer content returned by :any:`Microsoft.AspNetCore.Razor.TagHelpers.ITagHelper`\s.


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








Syntax
------

.. code-block:: csharp

    public abstract class TagHelperContent : IHtmlContentBuilder, IHtmlContentContainer, IHtmlContent








.. dn:class:: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContent
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContent

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContent
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContent.Append(System.String)
    
        
    
        
        Appends <em>unencoded</em> to the existing content.
    
        
    
        
        :param unencoded: The :any:`System.String` to be appended.
        
        :type unencoded: System.String
        :rtype: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContent
        :return: A reference to this instance after the append operation has completed.
    
        
        .. code-block:: csharp
    
            public abstract TagHelperContent Append(string unencoded)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContent.AppendFormat(System.IFormatProvider, System.String, System.Object[])
    
        
    
        
        Appends the specified <em>format</em> to the existing content with information from the
        <em>provider</em> after replacing each format item with the HTML encoded :any:`System.String`
        representation of the corresponding item in the <em>args</em> array.
    
        
    
        
        :param provider: An object that supplies culture-specific formatting information.
        
        :type provider: System.IFormatProvider
    
        
        :param format: 
            The composite format :any:`System.String` (see http://msdn.microsoft.com/en-us/library/txafckwd.aspx).
        
        :type format: System.String
    
        
        :param args: The object array to format.
        
        :type args: System.Object<System.Object>[]
        :rtype: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContent
        :return: A reference to this instance after the append operation has completed.
    
        
        .. code-block:: csharp
    
            public TagHelperContent AppendFormat(IFormatProvider provider, string format, params object[] args)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContent.AppendFormat(System.String, System.Object[])
    
        
    
        
        Appends the specified <em>format</em> to the existing content after
        replacing each format item with the HTML encoded :any:`System.String` representation of the
        corresponding item in the <em>args</em> array.
    
        
    
        
        :param format: 
            The composite format :any:`System.String` (see http://msdn.microsoft.com/en-us/library/txafckwd.aspx).
        
        :type format: System.String
    
        
        :param args: The object array to format.
        
        :type args: System.Object<System.Object>[]
        :rtype: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContent
        :return: A reference to this instance after the append operation has completed.
    
        
        .. code-block:: csharp
    
            public TagHelperContent AppendFormat(string format, params object[] args)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContent.AppendHtml(Microsoft.AspNetCore.Html.IHtmlContent)
    
        
    
        
        Appends <em>htmlContent</em> to the existing content.
    
        
    
        
        :param htmlContent: The :any:`Microsoft.AspNetCore.Html.IHtmlContent` to be appended.
        
        :type htmlContent: Microsoft.AspNetCore.Html.IHtmlContent
        :rtype: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContent
        :return: A reference to this instance after the append operation has completed.
    
        
        .. code-block:: csharp
    
            public abstract TagHelperContent AppendHtml(IHtmlContent htmlContent)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContent.AppendHtml(System.String)
    
        
    
        
        Appends <em>encoded</em> to the existing content. <em>encoded</em> is assumed
        to be an HTML encoded :any:`System.String` and no further encoding will be performed.
    
        
    
        
        :param encoded: The :any:`System.String` to be appended.
        
        :type encoded: System.String
        :rtype: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContent
        :return: A reference to this instance after the append operation has completed.
    
        
        .. code-block:: csharp
    
            public abstract TagHelperContent AppendHtml(string encoded)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContent.Clear()
    
        
    
        
        Clears the content.
    
        
        :rtype: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContent
        :return: A reference to this instance after the clear operation has completed.
    
        
        .. code-block:: csharp
    
            public abstract TagHelperContent Clear()
    
    .. dn:method:: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContent.CopyTo(Microsoft.AspNetCore.Html.IHtmlContentBuilder)
    
        
    
        
        :type destination: Microsoft.AspNetCore.Html.IHtmlContentBuilder
    
        
        .. code-block:: csharp
    
            public abstract void CopyTo(IHtmlContentBuilder destination)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContent.GetContent()
    
        
    
        
        Gets the content.
    
        
        :rtype: System.String
        :return: A :any:`System.String` containing the content.
    
        
        .. code-block:: csharp
    
            public abstract string GetContent()
    
    .. dn:method:: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContent.GetContent(System.Text.Encodings.Web.HtmlEncoder)
    
        
    
        
        Gets the content.
    
        
    
        
        :param encoder: The :any:`System.Text.Encodings.Web.HtmlEncoder`\.
        
        :type encoder: System.Text.Encodings.Web.HtmlEncoder
        :rtype: System.String
        :return: A :any:`System.String` containing the content.
    
        
        .. code-block:: csharp
    
            public abstract string GetContent(HtmlEncoder encoder)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContent.Microsoft.AspNetCore.Html.IHtmlContentBuilder.Append(System.String)
    
        
    
        
        :type unencoded: System.String
        :rtype: Microsoft.AspNetCore.Html.IHtmlContentBuilder
    
        
        .. code-block:: csharp
    
            IHtmlContentBuilder IHtmlContentBuilder.Append(string unencoded)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContent.Microsoft.AspNetCore.Html.IHtmlContentBuilder.AppendHtml(Microsoft.AspNetCore.Html.IHtmlContent)
    
        
    
        
        :type content: Microsoft.AspNetCore.Html.IHtmlContent
        :rtype: Microsoft.AspNetCore.Html.IHtmlContentBuilder
    
        
        .. code-block:: csharp
    
            IHtmlContentBuilder IHtmlContentBuilder.AppendHtml(IHtmlContent content)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContent.Microsoft.AspNetCore.Html.IHtmlContentBuilder.AppendHtml(System.String)
    
        
    
        
        :type encoded: System.String
        :rtype: Microsoft.AspNetCore.Html.IHtmlContentBuilder
    
        
        .. code-block:: csharp
    
            IHtmlContentBuilder IHtmlContentBuilder.AppendHtml(string encoded)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContent.Microsoft.AspNetCore.Html.IHtmlContentBuilder.Clear()
    
        
        :rtype: Microsoft.AspNetCore.Html.IHtmlContentBuilder
    
        
        .. code-block:: csharp
    
            IHtmlContentBuilder IHtmlContentBuilder.Clear()
    
    .. dn:method:: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContent.MoveTo(Microsoft.AspNetCore.Html.IHtmlContentBuilder)
    
        
    
        
        :type destination: Microsoft.AspNetCore.Html.IHtmlContentBuilder
    
        
        .. code-block:: csharp
    
            public abstract void MoveTo(IHtmlContentBuilder destination)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContent.Reinitialize()
    
        
    
        
        Clears the :any:`Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContent`\,  so it can be reused.
    
        
    
        
        .. code-block:: csharp
    
            public abstract void Reinitialize()
    
    .. dn:method:: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContent.SetContent(System.String)
    
        
    
        
        Sets the content.
    
        
    
        
        :param unencoded: 
            The :any:`System.String` that replaces the content. The value is assume to be unencoded
            as-provided and will be HTML encoded before being written.
        
        :type unencoded: System.String
        :rtype: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContent
        :return: A reference to this instance after the set operation has completed.
    
        
        .. code-block:: csharp
    
            public TagHelperContent SetContent(string unencoded)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContent.SetHtmlContent(Microsoft.AspNetCore.Html.IHtmlContent)
    
        
    
        
        Sets the content.
    
        
    
        
        :param htmlContent: The :any:`Microsoft.AspNetCore.Html.IHtmlContent` that replaces the content.
        
        :type htmlContent: Microsoft.AspNetCore.Html.IHtmlContent
        :rtype: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContent
        :return: A reference to this instance after the set operation has completed.
    
        
        .. code-block:: csharp
    
            public TagHelperContent SetHtmlContent(IHtmlContent htmlContent)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContent.SetHtmlContent(System.String)
    
        
    
        
        Sets the content.
    
        
    
        
        :param encoded: 
            The :any:`System.String` that replaces the content. The value is assume to be HTML encoded
            as-provided and no further encoding will be performed.
        
        :type encoded: System.String
        :rtype: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContent
        :return: A reference to this instance after the set operation has completed.
    
        
        .. code-block:: csharp
    
            public TagHelperContent SetHtmlContent(string encoded)
    
    .. dn:method:: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContent.WriteTo(System.IO.TextWriter, System.Text.Encodings.Web.HtmlEncoder)
    
        
    
        
        :type writer: System.IO.TextWriter
    
        
        :type encoder: System.Text.Encodings.Web.HtmlEncoder
    
        
        .. code-block:: csharp
    
            public abstract void WriteTo(TextWriter writer, HtmlEncoder encoder)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContent
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContent.IsEmptyOrWhiteSpace
    
        
    
        
        Gets a value indicating whether the content is empty or whitespace.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public abstract bool IsEmptyOrWhiteSpace { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Razor.TagHelpers.TagHelperContent.IsModified
    
        
    
        
        Gets a value indicating whether the content was modified.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public abstract bool IsModified { get; }
    

