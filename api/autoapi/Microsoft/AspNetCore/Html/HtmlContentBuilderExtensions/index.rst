

HtmlContentBuilderExtensions Class
==================================






Extension methods for :any:`Microsoft.AspNetCore.Html.IHtmlContentBuilder`\.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Html`
Assemblies
    * Microsoft.AspNetCore.Html.Abstractions

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Html.HtmlContentBuilderExtensions`








Syntax
------

.. code-block:: csharp

    public class HtmlContentBuilderExtensions








.. dn:class:: Microsoft.AspNetCore.Html.HtmlContentBuilderExtensions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Html.HtmlContentBuilderExtensions

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Html.HtmlContentBuilderExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Html.HtmlContentBuilderExtensions.AppendFormat(Microsoft.AspNetCore.Html.IHtmlContentBuilder, System.IFormatProvider, System.String, System.Object[])
    
        
    
        
        Appends the specified <em>format</em> to the existing content with information from the
        <em>formatProvider</em> after replacing each format item with the HTML encoded
        :any:`System.String` representation of the corresponding item in the <em>args</em> array.
    
        
    
        
        :param builder: The :any:`Microsoft.AspNetCore.Html.IHtmlContentBuilder`\.
        
        :type builder: Microsoft.AspNetCore.Html.IHtmlContentBuilder
    
        
        :param formatProvider: An object that supplies culture-specific formatting information.
        
        :type formatProvider: System.IFormatProvider
    
        
        :param format: 
            The composite format :any:`System.String` (see http://msdn.microsoft.com/en-us/library/txafckwd.aspx).
            The format string is assumed to be HTML encoded as-provided, and no further encoding will be performed.
        
        :type format: System.String
    
        
        :param args: 
            The object array to format. Each element in the array will be formatted and then HTML encoded.
        
        :type args: System.Object<System.Object>[]
        :rtype: Microsoft.AspNetCore.Html.IHtmlContentBuilder
        :return: A reference to this instance after the append operation has completed.
    
        
        .. code-block:: csharp
    
            public static IHtmlContentBuilder AppendFormat(IHtmlContentBuilder builder, IFormatProvider formatProvider, string format, params object[] args)
    
    .. dn:method:: Microsoft.AspNetCore.Html.HtmlContentBuilderExtensions.AppendFormat(Microsoft.AspNetCore.Html.IHtmlContentBuilder, System.String, System.Object[])
    
        
    
        
        Appends the specified <em>format</em> to the existing content after replacing each format
        item with the HTML encoded :any:`System.String` representation of the corresponding item in the
        <em>args</em> array.
    
        
    
        
        :param builder: The :any:`Microsoft.AspNetCore.Html.IHtmlContentBuilder`\.
        
        :type builder: Microsoft.AspNetCore.Html.IHtmlContentBuilder
    
        
        :param format: 
            The composite format :any:`System.String` (see http://msdn.microsoft.com/en-us/library/txafckwd.aspx).
            The format string is assumed to be HTML encoded as-provided, and no further encoding will be performed.
        
        :type format: System.String
    
        
        :param args: 
            The object array to format. Each element in the array will be formatted and then HTML encoded.
        
        :type args: System.Object<System.Object>[]
        :rtype: Microsoft.AspNetCore.Html.IHtmlContentBuilder
        :return: A reference to this instance after the append operation has completed.
    
        
        .. code-block:: csharp
    
            public static IHtmlContentBuilder AppendFormat(IHtmlContentBuilder builder, string format, params object[] args)
    
    .. dn:method:: Microsoft.AspNetCore.Html.HtmlContentBuilderExtensions.AppendHtmlLine(Microsoft.AspNetCore.Html.IHtmlContentBuilder, System.String)
    
        
    
        
        Appends an :dn:prop:`System.Environment.NewLine` after appending the :any:`System.String` value.
        The value is treated as HTML encoded as-provided, and no further encoding will be performed.
    
        
    
        
        :param builder: The :any:`Microsoft.AspNetCore.Html.IHtmlContentBuilder`\.
        
        :type builder: Microsoft.AspNetCore.Html.IHtmlContentBuilder
    
        
        :param encoded: The HTML encoded :any:`System.String` to append.
        
        :type encoded: System.String
        :rtype: Microsoft.AspNetCore.Html.IHtmlContentBuilder
        :return: The :any:`Microsoft.AspNetCore.Html.IHtmlContentBuilder`\.
    
        
        .. code-block:: csharp
    
            public static IHtmlContentBuilder AppendHtmlLine(IHtmlContentBuilder builder, string encoded)
    
    .. dn:method:: Microsoft.AspNetCore.Html.HtmlContentBuilderExtensions.AppendLine(Microsoft.AspNetCore.Html.IHtmlContentBuilder)
    
        
    
        
        Appends an :dn:prop:`System.Environment.NewLine`\.
    
        
    
        
        :param builder: The :any:`Microsoft.AspNetCore.Html.IHtmlContentBuilder`\.
        
        :type builder: Microsoft.AspNetCore.Html.IHtmlContentBuilder
        :rtype: Microsoft.AspNetCore.Html.IHtmlContentBuilder
        :return: The :any:`Microsoft.AspNetCore.Html.IHtmlContentBuilder`\.
    
        
        .. code-block:: csharp
    
            public static IHtmlContentBuilder AppendLine(IHtmlContentBuilder builder)
    
    .. dn:method:: Microsoft.AspNetCore.Html.HtmlContentBuilderExtensions.AppendLine(Microsoft.AspNetCore.Html.IHtmlContentBuilder, Microsoft.AspNetCore.Html.IHtmlContent)
    
        
    
        
        Appends an :dn:prop:`System.Environment.NewLine` after appending the :any:`Microsoft.AspNetCore.Html.IHtmlContent` value.
    
        
    
        
        :param builder: The :any:`Microsoft.AspNetCore.Html.IHtmlContentBuilder`\.
        
        :type builder: Microsoft.AspNetCore.Html.IHtmlContentBuilder
    
        
        :param content: The :any:`Microsoft.AspNetCore.Html.IHtmlContent` to append.
        
        :type content: Microsoft.AspNetCore.Html.IHtmlContent
        :rtype: Microsoft.AspNetCore.Html.IHtmlContentBuilder
        :return: The :any:`Microsoft.AspNetCore.Html.IHtmlContentBuilder`\.
    
        
        .. code-block:: csharp
    
            public static IHtmlContentBuilder AppendLine(IHtmlContentBuilder builder, IHtmlContent content)
    
    .. dn:method:: Microsoft.AspNetCore.Html.HtmlContentBuilderExtensions.AppendLine(Microsoft.AspNetCore.Html.IHtmlContentBuilder, System.String)
    
        
    
        
        Appends an :dn:prop:`System.Environment.NewLine` after appending the :any:`System.String` value.
        The value is treated as unencoded as-provided, and will be HTML encoded before writing to output.
    
        
    
        
        :param builder: The :any:`Microsoft.AspNetCore.Html.IHtmlContentBuilder`\.
        
        :type builder: Microsoft.AspNetCore.Html.IHtmlContentBuilder
    
        
        :param unencoded: The :any:`System.String` to append.
        
        :type unencoded: System.String
        :rtype: Microsoft.AspNetCore.Html.IHtmlContentBuilder
        :return: The :any:`Microsoft.AspNetCore.Html.IHtmlContentBuilder`\.
    
        
        .. code-block:: csharp
    
            public static IHtmlContentBuilder AppendLine(IHtmlContentBuilder builder, string unencoded)
    
    .. dn:method:: Microsoft.AspNetCore.Html.HtmlContentBuilderExtensions.SetContent(Microsoft.AspNetCore.Html.IHtmlContentBuilder, System.String)
    
        
    
        
        Sets the content to the :any:`System.String` value. The value is treated as unencoded as-provided,
        and will be HTML encoded before writing to output.
    
        
    
        
        :param builder: The :any:`Microsoft.AspNetCore.Html.IHtmlContentBuilder`\.
        
        :type builder: Microsoft.AspNetCore.Html.IHtmlContentBuilder
    
        
        :param unencoded: The :any:`System.String` value that replaces the content.
        
        :type unencoded: System.String
        :rtype: Microsoft.AspNetCore.Html.IHtmlContentBuilder
        :return: The :any:`Microsoft.AspNetCore.Html.IHtmlContentBuilder`\.
    
        
        .. code-block:: csharp
    
            public static IHtmlContentBuilder SetContent(IHtmlContentBuilder builder, string unencoded)
    
    .. dn:method:: Microsoft.AspNetCore.Html.HtmlContentBuilderExtensions.SetHtmlContent(Microsoft.AspNetCore.Html.IHtmlContentBuilder, Microsoft.AspNetCore.Html.IHtmlContent)
    
        
    
        
        Sets the content to the :any:`Microsoft.AspNetCore.Html.IHtmlContent` value.
    
        
    
        
        :param builder: The :any:`Microsoft.AspNetCore.Html.IHtmlContentBuilder`\.
        
        :type builder: Microsoft.AspNetCore.Html.IHtmlContentBuilder
    
        
        :param content: The :any:`Microsoft.AspNetCore.Html.IHtmlContent` value that replaces the content.
        
        :type content: Microsoft.AspNetCore.Html.IHtmlContent
        :rtype: Microsoft.AspNetCore.Html.IHtmlContentBuilder
        :return: The :any:`Microsoft.AspNetCore.Html.IHtmlContentBuilder`\.
    
        
        .. code-block:: csharp
    
            public static IHtmlContentBuilder SetHtmlContent(IHtmlContentBuilder builder, IHtmlContent content)
    
    .. dn:method:: Microsoft.AspNetCore.Html.HtmlContentBuilderExtensions.SetHtmlContent(Microsoft.AspNetCore.Html.IHtmlContentBuilder, System.String)
    
        
    
        
        Sets the content to the :any:`System.String` value. The value is treated as HTML encoded as-provided, and
        no further encoding will be performed.
    
        
    
        
        :param builder: The :any:`Microsoft.AspNetCore.Html.IHtmlContentBuilder`\.
        
        :type builder: Microsoft.AspNetCore.Html.IHtmlContentBuilder
    
        
        :param encoded: The HTML encoded :any:`System.String` that replaces the content.
        
        :type encoded: System.String
        :rtype: Microsoft.AspNetCore.Html.IHtmlContentBuilder
        :return: The :any:`Microsoft.AspNetCore.Html.IHtmlContentBuilder`\.
    
        
        .. code-block:: csharp
    
            public static IHtmlContentBuilder SetHtmlContent(IHtmlContentBuilder builder, string encoded)
    

