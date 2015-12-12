

HtmlContentBuilderExtensions Class
==================================



.. contents:: 
   :local:



Summary
-------

Extension methods for :any:`Microsoft.AspNet.Html.Abstractions.IHtmlContentBuilder`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Html.Abstractions.HtmlContentBuilderExtensions`








Syntax
------

.. code-block:: csharp

   public class HtmlContentBuilderExtensions





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/httpabstractions/src/Microsoft.AspNet.Html.Abstractions/HtmlContentBuilderExtensions.cs>`_





.. dn:class:: Microsoft.AspNet.Html.Abstractions.HtmlContentBuilderExtensions

Methods
-------

.. dn:class:: Microsoft.AspNet.Html.Abstractions.HtmlContentBuilderExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Html.Abstractions.HtmlContentBuilderExtensions.AppendFormat(Microsoft.AspNet.Html.Abstractions.IHtmlContentBuilder, System.IFormatProvider, System.String, System.Object[])
    
        
    
        Appends the specified ``format`` to the existing content with information from the
        ``formatProvider`` after replacing each format item with the HTML encoded 
        :any:`System.String` representation of the corresponding item in the ``args`` array.
    
        
        
        
        :param builder: The .
        
        :type builder: Microsoft.AspNet.Html.Abstractions.IHtmlContentBuilder
        
        
        :param formatProvider: An object that supplies culture-specific formatting information.
        
        :type formatProvider: System.IFormatProvider
        
        
        :param format: The composite format  (see http://msdn.microsoft.com/en-us/library/txafckwd.aspx).
            The format string is assumed to be HTML encoded as-provided, and no further encoding will be performed.
        
        :type format: System.String
        
        
        :param args: The object array to format. Each element in the array will be formatted and then HTML encoded.
        
        :type args: System.Object[]
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContentBuilder
        :return: A reference to this instance after the append operation has completed.
    
        
        .. code-block:: csharp
    
           public static IHtmlContentBuilder AppendFormat(IHtmlContentBuilder builder, IFormatProvider formatProvider, string format, params object[] args)
    
    .. dn:method:: Microsoft.AspNet.Html.Abstractions.HtmlContentBuilderExtensions.AppendFormat(Microsoft.AspNet.Html.Abstractions.IHtmlContentBuilder, System.String, System.Object[])
    
        
    
        Appends the specified ``format`` to the existing content after replacing each format
        item with the HTML encoded :any:`System.String` representation of the corresponding item in the
        ``args`` array.
    
        
        
        
        :param builder: The .
        
        :type builder: Microsoft.AspNet.Html.Abstractions.IHtmlContentBuilder
        
        
        :param format: The composite format  (see http://msdn.microsoft.com/en-us/library/txafckwd.aspx).
            The format string is assumed to be HTML encoded as-provided, and no further encoding will be performed.
        
        :type format: System.String
        
        
        :param args: The object array to format. Each element in the array will be formatted and then HTML encoded.
        
        :type args: System.Object[]
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContentBuilder
        :return: A reference to this instance after the append operation has completed.
    
        
        .. code-block:: csharp
    
           public static IHtmlContentBuilder AppendFormat(IHtmlContentBuilder builder, string format, params object[] args)
    
    .. dn:method:: Microsoft.AspNet.Html.Abstractions.HtmlContentBuilderExtensions.AppendHtmlLine(Microsoft.AspNet.Html.Abstractions.IHtmlContentBuilder, System.String)
    
        
    
        Appends an :dn:prop:`System.Environment.NewLine` after appending the :any:`System.String` value.
        The value is treated as HTML encoded as-provided, and no further encoding will be performed.
    
        
        
        
        :param builder: The .
        
        :type builder: Microsoft.AspNet.Html.Abstractions.IHtmlContentBuilder
        
        
        :param encoded: The HTML encoded  to append.
        
        :type encoded: System.String
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContentBuilder
        :return: The <see cref="T:Microsoft.AspNet.Html.Abstractions.IHtmlContentBuilder" />.
    
        
        .. code-block:: csharp
    
           public static IHtmlContentBuilder AppendHtmlLine(IHtmlContentBuilder builder, string encoded)
    
    .. dn:method:: Microsoft.AspNet.Html.Abstractions.HtmlContentBuilderExtensions.AppendLine(Microsoft.AspNet.Html.Abstractions.IHtmlContentBuilder)
    
        
    
        Appends an :dn:prop:`System.Environment.NewLine`\.
    
        
        
        
        :param builder: The .
        
        :type builder: Microsoft.AspNet.Html.Abstractions.IHtmlContentBuilder
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContentBuilder
        :return: The <see cref="T:Microsoft.AspNet.Html.Abstractions.IHtmlContentBuilder" />.
    
        
        .. code-block:: csharp
    
           public static IHtmlContentBuilder AppendLine(IHtmlContentBuilder builder)
    
    .. dn:method:: Microsoft.AspNet.Html.Abstractions.HtmlContentBuilderExtensions.AppendLine(Microsoft.AspNet.Html.Abstractions.IHtmlContentBuilder, Microsoft.AspNet.Html.Abstractions.IHtmlContent)
    
        
    
        Appends an :dn:prop:`System.Environment.NewLine` after appending the :any:`Microsoft.AspNet.Html.Abstractions.IHtmlContent` value.
    
        
        
        
        :param builder: The .
        
        :type builder: Microsoft.AspNet.Html.Abstractions.IHtmlContentBuilder
        
        
        :param content: The  to append.
        
        :type content: Microsoft.AspNet.Html.Abstractions.IHtmlContent
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContentBuilder
        :return: The <see cref="T:Microsoft.AspNet.Html.Abstractions.IHtmlContentBuilder" />.
    
        
        .. code-block:: csharp
    
           public static IHtmlContentBuilder AppendLine(IHtmlContentBuilder builder, IHtmlContent content)
    
    .. dn:method:: Microsoft.AspNet.Html.Abstractions.HtmlContentBuilderExtensions.AppendLine(Microsoft.AspNet.Html.Abstractions.IHtmlContentBuilder, System.String)
    
        
    
        Appends an :dn:prop:`System.Environment.NewLine` after appending the :any:`System.String` value.
        The value is treated as unencoded as-provided, and will be HTML encoded before writing to output.
    
        
        
        
        :param builder: The .
        
        :type builder: Microsoft.AspNet.Html.Abstractions.IHtmlContentBuilder
        
        
        :param unencoded: The  to append.
        
        :type unencoded: System.String
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContentBuilder
        :return: The <see cref="T:Microsoft.AspNet.Html.Abstractions.IHtmlContentBuilder" />.
    
        
        .. code-block:: csharp
    
           public static IHtmlContentBuilder AppendLine(IHtmlContentBuilder builder, string unencoded)
    
    .. dn:method:: Microsoft.AspNet.Html.Abstractions.HtmlContentBuilderExtensions.SetContent(Microsoft.AspNet.Html.Abstractions.IHtmlContentBuilder, Microsoft.AspNet.Html.Abstractions.IHtmlContent)
    
        
    
        Sets the content to the :any:`Microsoft.AspNet.Html.Abstractions.IHtmlContent` value.
    
        
        
        
        :param builder: The .
        
        :type builder: Microsoft.AspNet.Html.Abstractions.IHtmlContentBuilder
        
        
        :param content: The  value that replaces the content.
        
        :type content: Microsoft.AspNet.Html.Abstractions.IHtmlContent
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContentBuilder
        :return: The <see cref="T:Microsoft.AspNet.Html.Abstractions.IHtmlContentBuilder" />.
    
        
        .. code-block:: csharp
    
           public static IHtmlContentBuilder SetContent(IHtmlContentBuilder builder, IHtmlContent content)
    
    .. dn:method:: Microsoft.AspNet.Html.Abstractions.HtmlContentBuilderExtensions.SetContent(Microsoft.AspNet.Html.Abstractions.IHtmlContentBuilder, System.String)
    
        
    
        Sets the content to the :any:`System.String` value. The value is treated as unencoded as-provided,
        and will be HTML encoded before writing to output.
    
        
        
        
        :param builder: The .
        
        :type builder: Microsoft.AspNet.Html.Abstractions.IHtmlContentBuilder
        
        
        :param unencoded: The  value that replaces the content.
        
        :type unencoded: System.String
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContentBuilder
        :return: The <see cref="T:Microsoft.AspNet.Html.Abstractions.IHtmlContentBuilder" />.
    
        
        .. code-block:: csharp
    
           public static IHtmlContentBuilder SetContent(IHtmlContentBuilder builder, string unencoded)
    
    .. dn:method:: Microsoft.AspNet.Html.Abstractions.HtmlContentBuilderExtensions.SetHtmlContent(Microsoft.AspNet.Html.Abstractions.IHtmlContentBuilder, System.String)
    
        
    
        Sets the content to the :any:`System.String` value. The value is treated as HTML encoded as-provided, and
        no further encoding will be performed.
    
        
        
        
        :param builder: The .
        
        :type builder: Microsoft.AspNet.Html.Abstractions.IHtmlContentBuilder
        
        
        :param encoded: The HTML encoded  that replaces the content.
        
        :type encoded: System.String
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContentBuilder
        :return: The <see cref="T:Microsoft.AspNet.Html.Abstractions.IHtmlContentBuilder" />.
    
        
        .. code-block:: csharp
    
           public static IHtmlContentBuilder SetHtmlContent(IHtmlContentBuilder builder, string encoded)
    

