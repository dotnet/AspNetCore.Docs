

HttpResponseStreamWriter Class
==============================






Writes to the :any:`System.IO.Stream` using the supplied :dn:prop:`Microsoft.AspNetCore.WebUtilities.HttpResponseStreamWriter.Encoding`\.
It does not write the BOM and also does not close the stream.


Namespace
    :dn:ns:`Microsoft.AspNetCore.WebUtilities`
Assemblies
    * Microsoft.AspNetCore.WebUtilities

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.MarshalByRefObject`
* :dn:cls:`System.IO.TextWriter`
* :dn:cls:`Microsoft.AspNetCore.WebUtilities.HttpResponseStreamWriter`








Syntax
------

.. code-block:: csharp

    public class HttpResponseStreamWriter : TextWriter, IDisposable








.. dn:class:: Microsoft.AspNetCore.WebUtilities.HttpResponseStreamWriter
    :hidden:

.. dn:class:: Microsoft.AspNetCore.WebUtilities.HttpResponseStreamWriter

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.WebUtilities.HttpResponseStreamWriter
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.WebUtilities.HttpResponseStreamWriter.HttpResponseStreamWriter(System.IO.Stream, System.Text.Encoding)
    
        
    
        
        :type stream: System.IO.Stream
    
        
        :type encoding: System.Text.Encoding
    
        
        .. code-block:: csharp
    
            public HttpResponseStreamWriter(Stream stream, Encoding encoding)
    
    .. dn:constructor:: Microsoft.AspNetCore.WebUtilities.HttpResponseStreamWriter.HttpResponseStreamWriter(System.IO.Stream, System.Text.Encoding, System.Int32)
    
        
    
        
        :type stream: System.IO.Stream
    
        
        :type encoding: System.Text.Encoding
    
        
        :type bufferSize: System.Int32
    
        
        .. code-block:: csharp
    
            public HttpResponseStreamWriter(Stream stream, Encoding encoding, int bufferSize)
    
    .. dn:constructor:: Microsoft.AspNetCore.WebUtilities.HttpResponseStreamWriter.HttpResponseStreamWriter(System.IO.Stream, System.Text.Encoding, System.Int32, System.Buffers.ArrayPool<System.Byte>, System.Buffers.ArrayPool<System.Char>)
    
        
    
        
        :type stream: System.IO.Stream
    
        
        :type encoding: System.Text.Encoding
    
        
        :type bufferSize: System.Int32
    
        
        :type bytePool: System.Buffers.ArrayPool<System.Buffers.ArrayPool`1>{System.Byte<System.Byte>}
    
        
        :type charPool: System.Buffers.ArrayPool<System.Buffers.ArrayPool`1>{System.Char<System.Char>}
    
        
        .. code-block:: csharp
    
            public HttpResponseStreamWriter(Stream stream, Encoding encoding, int bufferSize, ArrayPool<byte> bytePool, ArrayPool<char> charPool)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.WebUtilities.HttpResponseStreamWriter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.WebUtilities.HttpResponseStreamWriter.Dispose(System.Boolean)
    
        
    
        
        :type disposing: System.Boolean
    
        
        .. code-block:: csharp
    
            protected override void Dispose(bool disposing)
    
    .. dn:method:: Microsoft.AspNetCore.WebUtilities.HttpResponseStreamWriter.Flush()
    
        
    
        
        .. code-block:: csharp
    
            public override void Flush()
    
    .. dn:method:: Microsoft.AspNetCore.WebUtilities.HttpResponseStreamWriter.FlushAsync()
    
        
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public override Task FlushAsync()
    
    .. dn:method:: Microsoft.AspNetCore.WebUtilities.HttpResponseStreamWriter.Write(System.Char)
    
        
    
        
        :type value: System.Char
    
        
        .. code-block:: csharp
    
            public override void Write(char value)
    
    .. dn:method:: Microsoft.AspNetCore.WebUtilities.HttpResponseStreamWriter.Write(System.Char[], System.Int32, System.Int32)
    
        
    
        
        :type values: System.Char<System.Char>[]
    
        
        :type index: System.Int32
    
        
        :type count: System.Int32
    
        
        .. code-block:: csharp
    
            public override void Write(char[] values, int index, int count)
    
    .. dn:method:: Microsoft.AspNetCore.WebUtilities.HttpResponseStreamWriter.Write(System.String)
    
        
    
        
        :type value: System.String
    
        
        .. code-block:: csharp
    
            public override void Write(string value)
    
    .. dn:method:: Microsoft.AspNetCore.WebUtilities.HttpResponseStreamWriter.WriteAsync(System.Char)
    
        
    
        
        :type value: System.Char
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public override Task WriteAsync(char value)
    
    .. dn:method:: Microsoft.AspNetCore.WebUtilities.HttpResponseStreamWriter.WriteAsync(System.Char[], System.Int32, System.Int32)
    
        
    
        
        :type values: System.Char<System.Char>[]
    
        
        :type index: System.Int32
    
        
        :type count: System.Int32
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public override Task WriteAsync(char[] values, int index, int count)
    
    .. dn:method:: Microsoft.AspNetCore.WebUtilities.HttpResponseStreamWriter.WriteAsync(System.String)
    
        
    
        
        :type value: System.String
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public override Task WriteAsync(string value)
    

Fields
------

.. dn:class:: Microsoft.AspNetCore.WebUtilities.HttpResponseStreamWriter
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNetCore.WebUtilities.HttpResponseStreamWriter.DefaultBufferSize
    
        
    
        
        Default buffer size.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public const int DefaultBufferSize = 1024
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.WebUtilities.HttpResponseStreamWriter
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.WebUtilities.HttpResponseStreamWriter.Encoding
    
        
        :rtype: System.Text.Encoding
    
        
        .. code-block:: csharp
    
            public override Encoding Encoding { get; }
    

