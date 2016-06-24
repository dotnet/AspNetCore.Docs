

ViewBufferTextWriter Class
==========================






<p>
A :any:`System.IO.TextWriter` that is backed by a unbuffered writer (over the Response stream) and/or a 
:any:`Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ViewBuffer`
</p>
<p>
When <code>Flush</code> or <code>FlushAsync</code> is invoked, the writer copies all content from the buffer to
the writer and switches to writing to the unbuffered writer for all further write operations.
</p>


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
* :dn:cls:`System.MarshalByRefObject`
* :dn:cls:`System.IO.TextWriter`
* :dn:cls:`Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ViewBufferTextWriter`








Syntax
------

.. code-block:: csharp

    public class ViewBufferTextWriter : TextWriter, IDisposable








.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ViewBufferTextWriter
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ViewBufferTextWriter

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ViewBufferTextWriter
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ViewBufferTextWriter.ViewBufferTextWriter(Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ViewBuffer, System.Text.Encoding)
    
        
    
        
        Creates a new instance of :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ViewBufferTextWriter`\.
    
        
    
        
        :param buffer: The :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ViewBuffer` for buffered output.
        
        :type buffer: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ViewBuffer
    
        
        :param encoding: The :any:`System.Text.Encoding`\.
        
        :type encoding: System.Text.Encoding
    
        
        .. code-block:: csharp
    
            public ViewBufferTextWriter(ViewBuffer buffer, Encoding encoding)
    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ViewBufferTextWriter.ViewBufferTextWriter(Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ViewBuffer, System.Text.Encoding, System.Text.Encodings.Web.HtmlEncoder, System.IO.TextWriter)
    
        
    
        
        Creates a new instance of :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ViewBufferTextWriter`\.
    
        
    
        
        :param buffer: The :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ViewBuffer` for buffered output.
        
        :type buffer: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ViewBuffer
    
        
        :param encoding: The :any:`System.Text.Encoding`\.
        
        :type encoding: System.Text.Encoding
    
        
        :param htmlEncoder: The HTML encoder.
        
        :type htmlEncoder: System.Text.Encodings.Web.HtmlEncoder
    
        
        :param inner: 
            The inner :any:`System.IO.TextWriter` to write output to when this instance is no longer buffering.
        
        :type inner: System.IO.TextWriter
    
        
        .. code-block:: csharp
    
            public ViewBufferTextWriter(ViewBuffer buffer, Encoding encoding, HtmlEncoder htmlEncoder, TextWriter inner)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ViewBufferTextWriter
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ViewBufferTextWriter.Buffer
    
        
    
        
        Gets the :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ViewBuffer`\.
    
        
        :rtype: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ViewBuffer
    
        
        .. code-block:: csharp
    
            public ViewBuffer Buffer { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ViewBufferTextWriter.Encoding
    
        
        :rtype: System.Text.Encoding
    
        
        .. code-block:: csharp
    
            public override Encoding Encoding { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ViewBufferTextWriter.IsBuffering
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool IsBuffering { get; }
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ViewBufferTextWriter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ViewBufferTextWriter.Flush()
    
        
    
        
        Copies the buffered content to the unbuffered writer and invokes flush on it.
        Additionally causes this instance to no longer buffer and direct all write operations
        to the unbuffered writer.
    
        
    
        
        .. code-block:: csharp
    
            public override void Flush()
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ViewBufferTextWriter.FlushAsync()
    
        
    
        
        Copies the buffered content to the unbuffered writer and invokes flush on it.
        Additionally causes this instance to no longer buffer and direct all write operations
        to the unbuffered writer.
    
        
        :rtype: System.Threading.Tasks.Task
        :return: A :any:`System.Threading.Tasks.Task` that represents the asynchronous copy and flush operations.
    
        
        .. code-block:: csharp
    
            public override Task FlushAsync()
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ViewBufferTextWriter.Write(Microsoft.AspNetCore.Html.IHtmlContent)
    
        
    
        
        Writes an :any:`Microsoft.AspNetCore.Html.IHtmlContent` value.
    
        
    
        
        :param value: The :any:`Microsoft.AspNetCore.Html.IHtmlContent` value.
        
        :type value: Microsoft.AspNetCore.Html.IHtmlContent
    
        
        .. code-block:: csharp
    
            public void Write(IHtmlContent value)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ViewBufferTextWriter.Write(Microsoft.AspNetCore.Html.IHtmlContentContainer)
    
        
    
        
        Writes an :any:`Microsoft.AspNetCore.Html.IHtmlContentContainer` value.
    
        
    
        
        :param value: The :any:`Microsoft.AspNetCore.Html.IHtmlContentContainer` value.
        
        :type value: Microsoft.AspNetCore.Html.IHtmlContentContainer
    
        
        .. code-block:: csharp
    
            public void Write(IHtmlContentContainer value)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ViewBufferTextWriter.Write(System.Char)
    
        
    
        
        :type value: System.Char
    
        
        .. code-block:: csharp
    
            public override void Write(char value)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ViewBufferTextWriter.Write(System.Char[], System.Int32, System.Int32)
    
        
    
        
        :type buffer: System.Char<System.Char>[]
    
        
        :type index: System.Int32
    
        
        :type count: System.Int32
    
        
        .. code-block:: csharp
    
            public override void Write(char[] buffer, int index, int count)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ViewBufferTextWriter.Write(System.Object)
    
        
    
        
        :type value: System.Object
    
        
        .. code-block:: csharp
    
            public override void Write(object value)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ViewBufferTextWriter.Write(System.String)
    
        
    
        
        :type value: System.String
    
        
        .. code-block:: csharp
    
            public override void Write(string value)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ViewBufferTextWriter.WriteAsync(System.Char)
    
        
    
        
        :type value: System.Char
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public override Task WriteAsync(char value)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ViewBufferTextWriter.WriteAsync(System.Char[], System.Int32, System.Int32)
    
        
    
        
        :type buffer: System.Char<System.Char>[]
    
        
        :type index: System.Int32
    
        
        :type count: System.Int32
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public override Task WriteAsync(char[] buffer, int index, int count)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ViewBufferTextWriter.WriteAsync(System.String)
    
        
    
        
        :type value: System.String
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public override Task WriteAsync(string value)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ViewBufferTextWriter.WriteLine()
    
        
    
        
        .. code-block:: csharp
    
            public override void WriteLine()
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ViewBufferTextWriter.WriteLine(System.Object)
    
        
    
        
        :type value: System.Object
    
        
        .. code-block:: csharp
    
            public override void WriteLine(object value)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ViewBufferTextWriter.WriteLine(System.String)
    
        
    
        
        :type value: System.String
    
        
        .. code-block:: csharp
    
            public override void WriteLine(string value)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ViewBufferTextWriter.WriteLineAsync()
    
        
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public override Task WriteLineAsync()
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ViewBufferTextWriter.WriteLineAsync(System.Char)
    
        
    
        
        :type value: System.Char
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public override Task WriteLineAsync(char value)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ViewBufferTextWriter.WriteLineAsync(System.Char[], System.Int32, System.Int32)
    
        
    
        
        :type value: System.Char<System.Char>[]
    
        
        :type start: System.Int32
    
        
        :type offset: System.Int32
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public override Task WriteLineAsync(char[] value, int start, int offset)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ViewBufferTextWriter.WriteLineAsync(System.String)
    
        
    
        
        :type value: System.String
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public override Task WriteLineAsync(string value)
    

