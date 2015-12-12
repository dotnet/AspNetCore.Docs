

IHtmlContentBuilder Interface
=============================



.. contents:: 
   :local:



Summary
-------

A builder for HTML content.











Syntax
------

.. code-block:: csharp

   public interface IHtmlContentBuilder : IHtmlContent





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/httpabstractions/src/Microsoft.AspNet.Html.Abstractions/IHtmlContentBuilder.cs>`_





.. dn:interface:: Microsoft.AspNet.Html.Abstractions.IHtmlContentBuilder

Methods
-------

.. dn:interface:: Microsoft.AspNet.Html.Abstractions.IHtmlContentBuilder
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Html.Abstractions.IHtmlContentBuilder.Append(Microsoft.AspNet.Html.Abstractions.IHtmlContent)
    
        
    
        Appends an :any:`Microsoft.AspNet.Html.Abstractions.IHtmlContent` instance.
    
        
        
        
        :param content: The  to append.
        
        :type content: Microsoft.AspNet.Html.Abstractions.IHtmlContent
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContentBuilder
        :return: The <see cref="T:Microsoft.AspNet.Html.Abstractions.IHtmlContentBuilder" />.
    
        
        .. code-block:: csharp
    
           IHtmlContentBuilder Append(IHtmlContent content)
    
    .. dn:method:: Microsoft.AspNet.Html.Abstractions.IHtmlContentBuilder.Append(System.String)
    
        
    
        Appends a :any:`System.String` value. The value is treated as unencoded as-provided, and will be HTML
        encoded before writing to output.
    
        
        
        
        :param unencoded: The  to append.
        
        :type unencoded: System.String
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContentBuilder
        :return: The <see cref="T:Microsoft.AspNet.Html.Abstractions.IHtmlContentBuilder" />.
    
        
        .. code-block:: csharp
    
           IHtmlContentBuilder Append(string unencoded)
    
    .. dn:method:: Microsoft.AspNet.Html.Abstractions.IHtmlContentBuilder.AppendHtml(System.String)
    
        
    
        Appends an HTML encoded :any:`System.String` value. The value is treated as HTML encoded as-provided, and
        no further encoding will be performed.
    
        
        
        
        :param encoded: The HTML encoded  to append.
        
        :type encoded: System.String
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContentBuilder
        :return: The <see cref="T:Microsoft.AspNet.Html.Abstractions.IHtmlContentBuilder" />.
    
        
        .. code-block:: csharp
    
           IHtmlContentBuilder AppendHtml(string encoded)
    
    .. dn:method:: Microsoft.AspNet.Html.Abstractions.IHtmlContentBuilder.Clear()
    
        
    
        Clears the content.
    
        
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContentBuilder
        :return: The <see cref="T:Microsoft.AspNet.Html.Abstractions.IHtmlContentBuilder" />.
    
        
        .. code-block:: csharp
    
           IHtmlContentBuilder Clear()
    

