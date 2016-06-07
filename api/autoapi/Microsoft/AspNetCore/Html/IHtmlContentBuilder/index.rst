

IHtmlContentBuilder Interface
=============================






A builder for HTML content.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Html`
Assemblies
    * Microsoft.AspNetCore.Html.Abstractions

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IHtmlContentBuilder : IHtmlContentContainer, IHtmlContent








.. dn:interface:: Microsoft.AspNetCore.Html.IHtmlContentBuilder
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Html.IHtmlContentBuilder

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Html.IHtmlContentBuilder
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Html.IHtmlContentBuilder.Append(System.String)
    
        
    
        
        Appends a :any:`System.String` value. The value is treated as unencoded as-provided, and will be HTML
        encoded before writing to output.
    
        
    
        
        :param unencoded: The :any:`System.String` to append.
        
        :type unencoded: System.String
        :rtype: Microsoft.AspNetCore.Html.IHtmlContentBuilder
        :return: The :any:`Microsoft.AspNetCore.Html.IHtmlContentBuilder`\.
    
        
        .. code-block:: csharp
    
            IHtmlContentBuilder Append(string unencoded)
    
    .. dn:method:: Microsoft.AspNetCore.Html.IHtmlContentBuilder.AppendHtml(Microsoft.AspNetCore.Html.IHtmlContent)
    
        
    
        
        Appends an :any:`Microsoft.AspNetCore.Html.IHtmlContent` instance.
    
        
    
        
        :param content: The :any:`Microsoft.AspNetCore.Html.IHtmlContent` to append.
        
        :type content: Microsoft.AspNetCore.Html.IHtmlContent
        :rtype: Microsoft.AspNetCore.Html.IHtmlContentBuilder
        :return: The :any:`Microsoft.AspNetCore.Html.IHtmlContentBuilder`\.
    
        
        .. code-block:: csharp
    
            IHtmlContentBuilder AppendHtml(IHtmlContent content)
    
    .. dn:method:: Microsoft.AspNetCore.Html.IHtmlContentBuilder.AppendHtml(System.String)
    
        
    
        
        Appends an HTML encoded :any:`System.String` value. The value is treated as HTML encoded as-provided, and
        no further encoding will be performed.
    
        
    
        
        :param encoded: The HTML encoded :any:`System.String` to append.
        
        :type encoded: System.String
        :rtype: Microsoft.AspNetCore.Html.IHtmlContentBuilder
        :return: The :any:`Microsoft.AspNetCore.Html.IHtmlContentBuilder`\.
    
        
        .. code-block:: csharp
    
            IHtmlContentBuilder AppendHtml(string encoded)
    
    .. dn:method:: Microsoft.AspNetCore.Html.IHtmlContentBuilder.Clear()
    
        
    
        
        Clears the content.
    
        
        :rtype: Microsoft.AspNetCore.Html.IHtmlContentBuilder
        :return: The :any:`Microsoft.AspNetCore.Html.IHtmlContentBuilder`\.
    
        
        .. code-block:: csharp
    
            IHtmlContentBuilder Clear()
    

