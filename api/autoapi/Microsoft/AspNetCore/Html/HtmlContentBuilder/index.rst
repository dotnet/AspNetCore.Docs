

HtmlContentBuilder Class
========================






An :any:`Microsoft.AspNetCore.Html.IHtmlContentBuilder` implementation using an in memory list.


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
* :dn:cls:`Microsoft.AspNetCore.Html.HtmlContentBuilder`








Syntax
------

.. code-block:: csharp

    public class HtmlContentBuilder : IHtmlContentBuilder, IHtmlContentContainer, IHtmlContent








.. dn:class:: Microsoft.AspNetCore.Html.HtmlContentBuilder
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Html.HtmlContentBuilder

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Html.HtmlContentBuilder
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Html.HtmlContentBuilder.HtmlContentBuilder()
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Html.HtmlContentBuilder`\.
    
        
    
        
        .. code-block:: csharp
    
            public HtmlContentBuilder()
    
    .. dn:constructor:: Microsoft.AspNetCore.Html.HtmlContentBuilder.HtmlContentBuilder(System.Collections.Generic.IList<System.Object>)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Html.HtmlContentBuilder` with the given list of entries.
    
        
    
        
        :param entries: 
            The list of entries. The :any:`Microsoft.AspNetCore.Html.HtmlContentBuilder` will use this list without making a copy.
        
        :type entries: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{System.Object<System.Object>}
    
        
        .. code-block:: csharp
    
            public HtmlContentBuilder(IList<object> entries)
    
    .. dn:constructor:: Microsoft.AspNetCore.Html.HtmlContentBuilder.HtmlContentBuilder(System.Int32)
    
        
    
        
        Creates a new :any:`Microsoft.AspNetCore.Html.HtmlContentBuilder` with the given initial capacity.
    
        
    
        
        :param capacity: The initial capacity of the backing store.
        
        :type capacity: System.Int32
    
        
        .. code-block:: csharp
    
            public HtmlContentBuilder(int capacity)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Html.HtmlContentBuilder
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Html.HtmlContentBuilder.Append(System.String)
    
        
    
        
        :type unencoded: System.String
        :rtype: Microsoft.AspNetCore.Html.IHtmlContentBuilder
    
        
        .. code-block:: csharp
    
            public IHtmlContentBuilder Append(string unencoded)
    
    .. dn:method:: Microsoft.AspNetCore.Html.HtmlContentBuilder.AppendHtml(Microsoft.AspNetCore.Html.IHtmlContent)
    
        
    
        
        :type htmlContent: Microsoft.AspNetCore.Html.IHtmlContent
        :rtype: Microsoft.AspNetCore.Html.IHtmlContentBuilder
    
        
        .. code-block:: csharp
    
            public IHtmlContentBuilder AppendHtml(IHtmlContent htmlContent)
    
    .. dn:method:: Microsoft.AspNetCore.Html.HtmlContentBuilder.AppendHtml(System.String)
    
        
    
        
        :type encoded: System.String
        :rtype: Microsoft.AspNetCore.Html.IHtmlContentBuilder
    
        
        .. code-block:: csharp
    
            public IHtmlContentBuilder AppendHtml(string encoded)
    
    .. dn:method:: Microsoft.AspNetCore.Html.HtmlContentBuilder.Clear()
    
        
        :rtype: Microsoft.AspNetCore.Html.IHtmlContentBuilder
    
        
        .. code-block:: csharp
    
            public IHtmlContentBuilder Clear()
    
    .. dn:method:: Microsoft.AspNetCore.Html.HtmlContentBuilder.CopyTo(Microsoft.AspNetCore.Html.IHtmlContentBuilder)
    
        
    
        
        :type destination: Microsoft.AspNetCore.Html.IHtmlContentBuilder
    
        
        .. code-block:: csharp
    
            public void CopyTo(IHtmlContentBuilder destination)
    
    .. dn:method:: Microsoft.AspNetCore.Html.HtmlContentBuilder.MoveTo(Microsoft.AspNetCore.Html.IHtmlContentBuilder)
    
        
    
        
        :type destination: Microsoft.AspNetCore.Html.IHtmlContentBuilder
    
        
        .. code-block:: csharp
    
            public void MoveTo(IHtmlContentBuilder destination)
    
    .. dn:method:: Microsoft.AspNetCore.Html.HtmlContentBuilder.WriteTo(System.IO.TextWriter, System.Text.Encodings.Web.HtmlEncoder)
    
        
    
        
        :type writer: System.IO.TextWriter
    
        
        :type encoder: System.Text.Encodings.Web.HtmlEncoder
    
        
        .. code-block:: csharp
    
            public void WriteTo(TextWriter writer, HtmlEncoder encoder)
    

