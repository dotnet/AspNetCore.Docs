

ViewBuffer Class
================






An :any:`Microsoft.AspNetCore.Html.IHtmlContentBuilder` that is backed by a buffer provided by :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.IViewBufferScope`\.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Mvc.ViewFeatures.Internal`
Assemblies
    * Microsoft.AspNetCore.Mvc.ViewFeatures

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ViewBuffer`








Syntax
------

.. code-block:: csharp

    [DebuggerDisplay("{DebuggerToString()}")]
    public class ViewBuffer : IHtmlContentBuilder, IHtmlContentContainer, IHtmlContent








.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ViewBuffer
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ViewBuffer

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ViewBuffer
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ViewBuffer.ViewBuffer(Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.IViewBufferScope, System.String, System.Int32)
    
        
    
        
        Initializes a new instance of :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ViewBuffer`\.
    
        
    
        
        :param bufferScope: The :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.IViewBufferScope`\.
        
        :type bufferScope: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.IViewBufferScope
    
        
        :param name: A name to identify this instance.
        
        :type name: System.String
    
        
        :param pageSize: The size of buffer pages.
        
        :type pageSize: System.Int32
    
        
        .. code-block:: csharp
    
            public ViewBuffer(IViewBufferScope bufferScope, string name, int pageSize)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ViewBuffer
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ViewBuffer.Append(System.String)
    
        
    
        
        :type unencoded: System.String
        :rtype: Microsoft.AspNetCore.Html.IHtmlContentBuilder
    
        
        .. code-block:: csharp
    
            public IHtmlContentBuilder Append(string unencoded)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ViewBuffer.AppendHtml(Microsoft.AspNetCore.Html.IHtmlContent)
    
        
    
        
        :type content: Microsoft.AspNetCore.Html.IHtmlContent
        :rtype: Microsoft.AspNetCore.Html.IHtmlContentBuilder
    
        
        .. code-block:: csharp
    
            public IHtmlContentBuilder AppendHtml(IHtmlContent content)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ViewBuffer.AppendHtml(System.String)
    
        
    
        
        :type encoded: System.String
        :rtype: Microsoft.AspNetCore.Html.IHtmlContentBuilder
    
        
        .. code-block:: csharp
    
            public IHtmlContentBuilder AppendHtml(string encoded)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ViewBuffer.Clear()
    
        
        :rtype: Microsoft.AspNetCore.Html.IHtmlContentBuilder
    
        
        .. code-block:: csharp
    
            public IHtmlContentBuilder Clear()
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ViewBuffer.CopyTo(Microsoft.AspNetCore.Html.IHtmlContentBuilder)
    
        
    
        
        :type destination: Microsoft.AspNetCore.Html.IHtmlContentBuilder
    
        
        .. code-block:: csharp
    
            public void CopyTo(IHtmlContentBuilder destination)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ViewBuffer.MoveTo(Microsoft.AspNetCore.Html.IHtmlContentBuilder)
    
        
    
        
        :type destination: Microsoft.AspNetCore.Html.IHtmlContentBuilder
    
        
        .. code-block:: csharp
    
            public void MoveTo(IHtmlContentBuilder destination)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ViewBuffer.WriteTo(System.IO.TextWriter, System.Text.Encodings.Web.HtmlEncoder)
    
        
    
        
        :type writer: System.IO.TextWriter
    
        
        :type encoder: System.Text.Encodings.Web.HtmlEncoder
    
        
        .. code-block:: csharp
    
            public void WriteTo(TextWriter writer, HtmlEncoder encoder)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ViewBuffer.WriteToAsync(System.IO.TextWriter, System.Text.Encodings.Web.HtmlEncoder)
    
        
    
        
        Writes the buffered content to <em>writer</em>.
    
        
    
        
        :param writer: The :any:`System.IO.TextWriter`\.
        
        :type writer: System.IO.TextWriter
    
        
        :param encoder: The :any:`System.Text.Encodings.Web.HtmlEncoder`\.
        
        :type encoder: System.Text.Encodings.Web.HtmlEncoder
        :rtype: System.Threading.Tasks.Task
        :return: A :any:`System.Threading.Tasks.Task` which will complete once content has been written.
    
        
        .. code-block:: csharp
    
            public Task WriteToAsync(TextWriter writer, HtmlEncoder encoder)
    

Fields
------

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ViewBuffer
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ViewBuffer.PartialViewPageSize
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public static readonly int PartialViewPageSize
    
    .. dn:field:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ViewBuffer.TagHelperPageSize
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public static readonly int TagHelperPageSize
    
    .. dn:field:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ViewBuffer.ViewComponentPageSize
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public static readonly int ViewComponentPageSize
    
    .. dn:field:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ViewBuffer.ViewPageSize
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public static readonly int ViewPageSize
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ViewBuffer
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ViewBuffer.Pages
    
        
    
        
        Gets the backing buffer.
    
        
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ViewBufferPage<Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ViewBufferPage>}
    
        
        .. code-block:: csharp
    
            public IList<ViewBufferPage> Pages { get; }
    

