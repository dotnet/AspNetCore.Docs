

RazorTextWriter Class
=====================



.. contents:: 
   :local:



Summary
-------

An :any:`Microsoft.AspNet.Mvc.ViewFeatures.HtmlTextWriter` that is backed by a unbuffered writer (over the Response stream) and a buffered 
:any:`Microsoft.AspNet.Mvc.ViewFeatures.StringCollectionTextWriter`\. When <c>Flush</c> or <c>FlushAsync</c> is invoked, the writer
copies all content from the buffered writer to the unbuffered one and switches to writing to the unbuffered
writer for all further write operations.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.MarshalByRefObject`
* :dn:cls:`System.IO.TextWriter`
* :dn:cls:`Microsoft.AspNet.Mvc.ViewFeatures.HtmlTextWriter`
* :dn:cls:`Microsoft.AspNet.Mvc.Razor.RazorTextWriter`








Syntax
------

.. code-block:: csharp

   public class RazorTextWriter : HtmlTextWriter, IDisposable, IBufferedTextWriter





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/mvc/src/Microsoft.AspNet.Mvc.Razor/RazorTextWriter.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.Razor.RazorTextWriter

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.Razor.RazorTextWriter
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.Razor.RazorTextWriter.RazorTextWriter(System.IO.TextWriter, System.Text.Encoding, Microsoft.Extensions.WebEncoders.IHtmlEncoder)
    
        
    
        Creates a new instance of :any:`Microsoft.AspNet.Mvc.Razor.RazorTextWriter`\.
    
        
        
        
        :param unbufferedWriter: The  to write output to when this instance
            is no longer buffering.
        
        :type unbufferedWriter: System.IO.TextWriter
        
        
        :param encoding: The character  in which the output is written.
        
        :type encoding: System.Text.Encoding
        
        
        :param encoder: The HTML encoder.
        
        :type encoder: Microsoft.Extensions.WebEncoders.IHtmlEncoder
    
        
        .. code-block:: csharp
    
           public RazorTextWriter(TextWriter unbufferedWriter, Encoding encoding, IHtmlEncoder encoder)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.Razor.RazorTextWriter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.RazorTextWriter.CopyTo(System.IO.TextWriter)
    
        
        
        
        :type writer: System.IO.TextWriter
    
        
        .. code-block:: csharp
    
           public void CopyTo(TextWriter writer)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.RazorTextWriter.CopyToAsync(System.IO.TextWriter)
    
        
        
        
        :type writer: System.IO.TextWriter
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public Task CopyToAsync(TextWriter writer)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.RazorTextWriter.Flush()
    
        
    
        Copies the buffered content to the unbuffered writer and invokes flush on it.
        Additionally causes this instance to no longer buffer and direct all write operations
        to the unbuffered writer.
    
        
    
        
        .. code-block:: csharp
    
           public override void Flush()
    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.RazorTextWriter.FlushAsync()
    
        
    
        Copies the buffered content to the unbuffered writer and invokes flush on it.
        Additionally causes this instance to no longer buffer and direct all write operations
        to the unbuffered writer.
    
        
        :rtype: System.Threading.Tasks.Task
        :return: A <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous copy and flush operations.
    
        
        .. code-block:: csharp
    
           public override Task FlushAsync()
    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.RazorTextWriter.Write(Microsoft.AspNet.Html.Abstractions.IHtmlContent)
    
        
        
        
        :type value: Microsoft.AspNet.Html.Abstractions.IHtmlContent
    
        
        .. code-block:: csharp
    
           public override void Write(IHtmlContent value)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.RazorTextWriter.Write(System.Char)
    
        
        
        
        :type value: System.Char
    
        
        .. code-block:: csharp
    
           public override void Write(char value)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.RazorTextWriter.Write(System.Char[], System.Int32, System.Int32)
    
        
        
        
        :type buffer: System.Char[]
        
        
        :type index: System.Int32
        
        
        :type count: System.Int32
    
        
        .. code-block:: csharp
    
           public override void Write(char[] buffer, int index, int count)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.RazorTextWriter.Write(System.String)
    
        
        
        
        :type value: System.String
    
        
        .. code-block:: csharp
    
           public override void Write(string value)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.RazorTextWriter.WriteAsync(System.Char)
    
        
        
        
        :type value: System.Char
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public override Task WriteAsync(char value)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.RazorTextWriter.WriteAsync(System.Char[], System.Int32, System.Int32)
    
        
        
        
        :type buffer: System.Char[]
        
        
        :type index: System.Int32
        
        
        :type count: System.Int32
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public override Task WriteAsync(char[] buffer, int index, int count)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.RazorTextWriter.WriteAsync(System.String)
    
        
        
        
        :type value: System.String
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public override Task WriteAsync(string value)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.RazorTextWriter.WriteLine()
    
        
    
        
        .. code-block:: csharp
    
           public override void WriteLine()
    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.RazorTextWriter.WriteLine(System.String)
    
        
        
        
        :type value: System.String
    
        
        .. code-block:: csharp
    
           public override void WriteLine(string value)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.RazorTextWriter.WriteLineAsync()
    
        
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public override Task WriteLineAsync()
    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.RazorTextWriter.WriteLineAsync(System.Char)
    
        
        
        
        :type value: System.Char
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public override Task WriteLineAsync(char value)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.RazorTextWriter.WriteLineAsync(System.Char[], System.Int32, System.Int32)
    
        
        
        
        :type value: System.Char[]
        
        
        :type start: System.Int32
        
        
        :type offset: System.Int32
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public override Task WriteLineAsync(char[] value, int start, int offset)
    
    .. dn:method:: Microsoft.AspNet.Mvc.Razor.RazorTextWriter.WriteLineAsync(System.String)
    
        
        
        
        :type value: System.String
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public override Task WriteLineAsync(string value)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.Razor.RazorTextWriter
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.Razor.RazorTextWriter.Encoding
    
        
        :rtype: System.Text.Encoding
    
        
        .. code-block:: csharp
    
           public override Encoding Encoding { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.Razor.RazorTextWriter.IsBuffering
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool IsBuffering { get; }
    

