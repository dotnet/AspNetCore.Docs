

StringCollectionTextWriter Class
================================



.. contents:: 
   :local:



Summary
-------

A :any:`Microsoft.AspNet.Mvc.ViewFeatures.HtmlTextWriter` that stores individual write operations as a sequence of 
:any:`System.String` and :any:`Microsoft.AspNet.Html.Abstractions.IHtmlContent` instances.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.MarshalByRefObject`
* :dn:cls:`System.IO.TextWriter`
* :dn:cls:`Microsoft.AspNet.Mvc.ViewFeatures.HtmlTextWriter`
* :dn:cls:`Microsoft.AspNet.Mvc.ViewFeatures.StringCollectionTextWriter`








Syntax
------

.. code-block:: csharp

   public class StringCollectionTextWriter : HtmlTextWriter, IDisposable





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.ViewFeatures/ViewFeatures/StringCollectionTextWriter.cs>`_





.. dn:class:: Microsoft.AspNet.Mvc.ViewFeatures.StringCollectionTextWriter

Constructors
------------

.. dn:class:: Microsoft.AspNet.Mvc.ViewFeatures.StringCollectionTextWriter
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Mvc.ViewFeatures.StringCollectionTextWriter.StringCollectionTextWriter(System.Text.Encoding)
    
        
    
        Creates a new instance of :any:`Microsoft.AspNet.Mvc.ViewFeatures.StringCollectionTextWriter`\.
    
        
        
        
        :param encoding: The character  in which the output is written.
        
        :type encoding: System.Text.Encoding
    
        
        .. code-block:: csharp
    
           public StringCollectionTextWriter(Encoding encoding)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Mvc.ViewFeatures.StringCollectionTextWriter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.StringCollectionTextWriter.CopyTo(System.IO.TextWriter, Microsoft.Extensions.WebEncoders.IHtmlEncoder)
    
        
    
        If the specified ``writer`` is a :any:`Microsoft.AspNet.Mvc.ViewFeatures.StringCollectionTextWriter` the contents
        are copied. It is just written to the ``writer`` otherwise.
    
        
        
        
        :param writer: The  to which the content must be copied/written.
        
        :type writer: System.IO.TextWriter
        
        
        :param encoder: The  to encode the copied/written content.
        
        :type encoder: Microsoft.Extensions.WebEncoders.IHtmlEncoder
    
        
        .. code-block:: csharp
    
           public void CopyTo(TextWriter writer, IHtmlEncoder encoder)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.StringCollectionTextWriter.CopyToAsync(System.IO.TextWriter, Microsoft.Extensions.WebEncoders.IHtmlEncoder)
    
        
    
        If the specified ``writer`` is a :any:`Microsoft.AspNet.Mvc.ViewFeatures.StringCollectionTextWriter` the contents
        are copied. It is just written to the ``writer`` otherwise.
    
        
        
        
        :param writer: The  to which the content must be copied/written.
        
        :type writer: System.IO.TextWriter
        
        
        :param encoder: The  to encode the copied/written content.
        
        :type encoder: Microsoft.Extensions.WebEncoders.IHtmlEncoder
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public Task CopyToAsync(TextWriter writer, IHtmlEncoder encoder)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.StringCollectionTextWriter.Write(Microsoft.AspNet.Html.Abstractions.IHtmlContent)
    
        
        
        
        :type value: Microsoft.AspNet.Html.Abstractions.IHtmlContent
    
        
        .. code-block:: csharp
    
           public override void Write(IHtmlContent value)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.StringCollectionTextWriter.Write(System.Char)
    
        
        
        
        :type value: System.Char
    
        
        .. code-block:: csharp
    
           public override void Write(char value)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.StringCollectionTextWriter.Write(System.Char[], System.Int32, System.Int32)
    
        
        
        
        :type buffer: System.Char[]
        
        
        :type index: System.Int32
        
        
        :type count: System.Int32
    
        
        .. code-block:: csharp
    
           public override void Write(char[] buffer, int index, int count)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.StringCollectionTextWriter.Write(System.String)
    
        
        
        
        :type value: System.String
    
        
        .. code-block:: csharp
    
           public override void Write(string value)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.StringCollectionTextWriter.WriteAsync(System.Char)
    
        
        
        
        :type value: System.Char
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public override Task WriteAsync(char value)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.StringCollectionTextWriter.WriteAsync(System.Char[], System.Int32, System.Int32)
    
        
        
        
        :type buffer: System.Char[]
        
        
        :type index: System.Int32
        
        
        :type count: System.Int32
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public override Task WriteAsync(char[] buffer, int index, int count)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.StringCollectionTextWriter.WriteAsync(System.String)
    
        
        
        
        :type value: System.String
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public override Task WriteAsync(string value)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.StringCollectionTextWriter.WriteLine()
    
        
    
        
        .. code-block:: csharp
    
           public override void WriteLine()
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.StringCollectionTextWriter.WriteLine(System.String)
    
        
        
        
        :type value: System.String
    
        
        .. code-block:: csharp
    
           public override void WriteLine(string value)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.StringCollectionTextWriter.WriteLineAsync()
    
        
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public override Task WriteLineAsync()
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.StringCollectionTextWriter.WriteLineAsync(System.Char)
    
        
        
        
        :type value: System.Char
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public override Task WriteLineAsync(char value)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.StringCollectionTextWriter.WriteLineAsync(System.Char[], System.Int32, System.Int32)
    
        
        
        
        :type value: System.Char[]
        
        
        :type start: System.Int32
        
        
        :type offset: System.Int32
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public override Task WriteLineAsync(char[] value, int start, int offset)
    
    .. dn:method:: Microsoft.AspNet.Mvc.ViewFeatures.StringCollectionTextWriter.WriteLineAsync(System.String)
    
        
        
        
        :type value: System.String
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public override Task WriteLineAsync(string value)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Mvc.ViewFeatures.StringCollectionTextWriter
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Mvc.ViewFeatures.StringCollectionTextWriter.Content
    
        
    
        Gets the content written to the writer as an :any:`Microsoft.AspNet.Html.Abstractions.IHtmlContent`\.
    
        
        :rtype: Microsoft.AspNet.Html.Abstractions.IHtmlContent
    
        
        .. code-block:: csharp
    
           public IHtmlContent Content { get; }
    
    .. dn:property:: Microsoft.AspNet.Mvc.ViewFeatures.StringCollectionTextWriter.Encoding
    
        
        :rtype: System.Text.Encoding
    
        
        .. code-block:: csharp
    
           public override Encoding Encoding { get; }
    

