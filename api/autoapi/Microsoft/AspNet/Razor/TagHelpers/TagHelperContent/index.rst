

TagHelperContent Class
======================



.. contents:: 
   :local:



Summary
-------

Abstract class used to buffer content returned by :any:`Microsoft.AspNet.Razor.TagHelpers.ITagHelper`\s.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Razor.TagHelpers.TagHelperContent`








Syntax
------

.. code-block:: csharp

   public abstract class TagHelperContent : IHtmlContentBuilder, IHtmlContent





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/razor/src/Microsoft.AspNet.Razor.Runtime/TagHelpers/TagHelperContent.cs>`_





.. dn:class:: Microsoft.AspNet.Razor.TagHelpers.TagHelperContent

Methods
-------

.. dn:class:: Microsoft.AspNet.Razor.TagHelpers.TagHelperContent
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Razor.TagHelpers.TagHelperContent.Append(Microsoft.AspNet.Html.Abstractions.IHtmlContent)
    
        
    
        Appends ``htmlContent`` to the existing content.
    
        
        
        
        :param htmlContent: The  to be appended.
        
        :type htmlContent: Microsoft.AspNet.Html.Abstractions.IHtmlContent
        :rtype: Microsoft.AspNet.Razor.TagHelpers.TagHelperContent
        :return: A reference to this instance after the append operation has completed.
    
        
        .. code-block:: csharp
    
           public abstract TagHelperContent Append(IHtmlContent htmlContent)
    
    .. dn:method:: Microsoft.AspNet.Razor.TagHelpers.TagHelperContent.Append(System.String)
    
        
    
        Appends ``unencoded`` to the existing content.
    
        
        
        
        :param unencoded: The  to be appended.
        
        :type unencoded: System.String
        :rtype: Microsoft.AspNet.Razor.TagHelpers.TagHelperContent
        :return: A reference to this instance after the append operation has completed.
    
        
        .. code-block:: csharp
    
           public abstract TagHelperContent Append(string unencoded)
    
    .. dn:method:: Microsoft.AspNet.Razor.TagHelpers.TagHelperContent.AppendFormat(System.IFormatProvider, System.String, System.Object[])
    
        
    
        Appends the specified ``format`` to the existing content with information from the
        ``provider`` after replacing each format item with the HTML encoded :any:`System.String`
        representation of the corresponding item in the ``args`` array.
    
        
        
        
        :param provider: An object that supplies culture-specific formatting information.
        
        :type provider: System.IFormatProvider
        
        
        :param format: The composite format  (see http://msdn.microsoft.com/en-us/library/txafckwd.aspx).
        
        :type format: System.String
        
        
        :param args: The object array to format.
        
        :type args: System.Object[]
        :rtype: Microsoft.AspNet.Razor.TagHelpers.TagHelperContent
        :return: A reference to this instance after the append operation has completed.
    
        
        .. code-block:: csharp
    
           public TagHelperContent AppendFormat(IFormatProvider provider, string format, params object[] args)
    
    .. dn:method:: Microsoft.AspNet.Razor.TagHelpers.TagHelperContent.AppendFormat(System.String, System.Object[])
    
        
    
        Appends the specified ``format`` to the existing content after
        replacing each format item with the HTML encoded :any:`System.String` representation of the
        corresponding item in the ``args`` array.
    
        
        
        
        :param format: The composite format  (see http://msdn.microsoft.com/en-us/library/txafckwd.aspx).
        
        :type format: System.String
        
        
        :param args: The object array to format.
        
        :type args: System.Object[]
        :rtype: Microsoft.AspNet.Razor.TagHelpers.TagHelperContent
        :return: A reference to this instance after the append operation has completed.
    
        
        .. code-block:: csharp
    
           public TagHelperContent AppendFormat(string format, params object[] args)
    
    .. dn:method:: Microsoft.AspNet.Razor.TagHelpers.TagHelperContent.AppendHtml(System.String)
    
        
    
        Appends ``encoded`` to the existing content. ``encoded`` is assumed
        to be an HTML encoded :any:`System.String` and no further encoding will be performed.
    
        
        
        
        :param encoded: The  to be appended.
        
        :type encoded: System.String
        :rtype: Microsoft.AspNet.Razor.TagHelpers.TagHelperContent
        :return: A reference to this instance after the append operation has completed.
    
        
        .. code-block:: csharp
    
           public abstract TagHelperContent AppendHtml(string encoded)
    
    .. dn:method:: Microsoft.AspNet.Razor.TagHelpers.TagHelperContent.Clear()
    
        
    
        Clears the content.
    
        
        :rtype: Microsoft.AspNet.Razor.TagHelpers.TagHelperContent
        :return: A reference to this instance after the clear operation has completed.
    
        
        .. code-block:: csharp
    
           public abstract TagHelperContent Clear()
    
    .. dn:method:: Microsoft.AspNet.Razor.TagHelpers.TagHelperContent.GetContent()
    
        
    
        Gets the content.
    
        
        :rtype: System.String
        :return: A <see cref="T:System.String" /> containing the content.
    
        
        .. code-block:: csharp
    
           public abstract string GetContent()
    
    .. dn:method:: Microsoft.AspNet.Razor.TagHelpers.TagHelperContent.GetContent(Microsoft.Extensions.WebEncoders.IHtmlEncoder)
    
        
    
        Gets the content.
    
        
        
        
        :param encoder: The .
        
        :type encoder: Microsoft.Extensions.WebEncoders.IHtmlEncoder
        :rtype: System.String
        :return: A <see cref="T:System.String" /> containing the content.
    
        
        .. code-block:: csharp
    
           public abstract string GetContent(IHtmlEncoder encoder)
    
    .. dn:method:: Microsoft.AspNet.Razor.TagHelpers.TagHelperContent.Microsoft.AspNet.Html.Abstractions.IHtmlContentBuilder.Append(Microsoft.AspNet.Html.Abstractions.IHtmlContent)
    
        
        
        
        :type content: Microsoft.AspNet.Html.Abstractions.IHtmlContent
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContentBuilder
    
        
        .. code-block:: csharp
    
           IHtmlContentBuilder IHtmlContentBuilder.Append(IHtmlContent content)
    
    .. dn:method:: Microsoft.AspNet.Razor.TagHelpers.TagHelperContent.Microsoft.AspNet.Html.Abstractions.IHtmlContentBuilder.Append(System.String)
    
        
        
        
        :type unencoded: System.String
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContentBuilder
    
        
        .. code-block:: csharp
    
           IHtmlContentBuilder IHtmlContentBuilder.Append(string unencoded)
    
    .. dn:method:: Microsoft.AspNet.Razor.TagHelpers.TagHelperContent.Microsoft.AspNet.Html.Abstractions.IHtmlContentBuilder.AppendHtml(System.String)
    
        
        
        
        :type encoded: System.String
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContentBuilder
    
        
        .. code-block:: csharp
    
           IHtmlContentBuilder IHtmlContentBuilder.AppendHtml(string encoded)
    
    .. dn:method:: Microsoft.AspNet.Razor.TagHelpers.TagHelperContent.Microsoft.AspNet.Html.Abstractions.IHtmlContentBuilder.Clear()
    
        
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContentBuilder
    
        
        .. code-block:: csharp
    
           IHtmlContentBuilder IHtmlContentBuilder.Clear()
    
    .. dn:method:: Microsoft.AspNet.Razor.TagHelpers.TagHelperContent.SetContent(Microsoft.AspNet.Html.Abstractions.IHtmlContent)
    
        
    
        Sets the content.
    
        
        
        
        :param htmlContent: The  that replaces the content.
        
        :type htmlContent: Microsoft.AspNet.Html.Abstractions.IHtmlContent
        :rtype: Microsoft.AspNet.Razor.TagHelpers.TagHelperContent
        :return: A reference to this instance after the set operation has completed.
    
        
        .. code-block:: csharp
    
           public TagHelperContent SetContent(IHtmlContent htmlContent)
    
    .. dn:method:: Microsoft.AspNet.Razor.TagHelpers.TagHelperContent.SetContent(System.String)
    
        
    
        Sets the content.
    
        
        
        
        :param unencoded: The  that replaces the content. The value is assume to be unencoded
            as-provided and will be HTML encoded before being written.
        
        :type unencoded: System.String
        :rtype: Microsoft.AspNet.Razor.TagHelpers.TagHelperContent
        :return: A reference to this instance after the set operation has completed.
    
        
        .. code-block:: csharp
    
           public TagHelperContent SetContent(string unencoded)
    
    .. dn:method:: Microsoft.AspNet.Razor.TagHelpers.TagHelperContent.SetHtmlContent(System.String)
    
        
    
        Sets the content.
    
        
        
        
        :param encoded: The  that replaces the content. The value is assume to be HTML encoded
            as-provided and no further encoding will be performed.
        
        :type encoded: System.String
        :rtype: Microsoft.AspNet.Razor.TagHelpers.TagHelperContent
        :return: A reference to this instance after the set operation has completed.
    
        
        .. code-block:: csharp
    
           public TagHelperContent SetHtmlContent(string encoded)
    
    .. dn:method:: Microsoft.AspNet.Razor.TagHelpers.TagHelperContent.WriteTo(System.IO.TextWriter, Microsoft.Extensions.WebEncoders.IHtmlEncoder)
    
        
        
        
        :type writer: System.IO.TextWriter
        
        
        :type encoder: Microsoft.Extensions.WebEncoders.IHtmlEncoder
    
        
        .. code-block:: csharp
    
           public abstract void WriteTo(TextWriter writer, IHtmlEncoder encoder)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Razor.TagHelpers.TagHelperContent
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Razor.TagHelpers.TagHelperContent.IsEmpty
    
        
    
        Gets a value indicating whether the content is empty.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public abstract bool IsEmpty { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.TagHelpers.TagHelperContent.IsModified
    
        
    
        Gets a value indicating whether the content was modifed.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public abstract bool IsModified { get; }
    
    .. dn:property:: Microsoft.AspNet.Razor.TagHelpers.TagHelperContent.IsWhiteSpace
    
        
    
        Gets a value indicating whether the content is whitespace.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public abstract bool IsWhiteSpace { get; }
    

