

HttpRequestStreamReader Class
=============================





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
* :dn:cls:`System.IO.TextReader`
* :dn:cls:`Microsoft.AspNetCore.WebUtilities.HttpRequestStreamReader`








Syntax
------

.. code-block:: csharp

    public class HttpRequestStreamReader : TextReader, IDisposable








.. dn:class:: Microsoft.AspNetCore.WebUtilities.HttpRequestStreamReader
    :hidden:

.. dn:class:: Microsoft.AspNetCore.WebUtilities.HttpRequestStreamReader

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.WebUtilities.HttpRequestStreamReader
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.WebUtilities.HttpRequestStreamReader.HttpRequestStreamReader(System.IO.Stream, System.Text.Encoding)
    
        
    
        
        :type stream: System.IO.Stream
    
        
        :type encoding: System.Text.Encoding
    
        
        .. code-block:: csharp
    
            public HttpRequestStreamReader(Stream stream, Encoding encoding)
    
    .. dn:constructor:: Microsoft.AspNetCore.WebUtilities.HttpRequestStreamReader.HttpRequestStreamReader(System.IO.Stream, System.Text.Encoding, System.Int32)
    
        
    
        
        :type stream: System.IO.Stream
    
        
        :type encoding: System.Text.Encoding
    
        
        :type bufferSize: System.Int32
    
        
        .. code-block:: csharp
    
            public HttpRequestStreamReader(Stream stream, Encoding encoding, int bufferSize)
    
    .. dn:constructor:: Microsoft.AspNetCore.WebUtilities.HttpRequestStreamReader.HttpRequestStreamReader(System.IO.Stream, System.Text.Encoding, System.Int32, System.Buffers.ArrayPool<System.Byte>, System.Buffers.ArrayPool<System.Char>)
    
        
    
        
        :type stream: System.IO.Stream
    
        
        :type encoding: System.Text.Encoding
    
        
        :type bufferSize: System.Int32
    
        
        :type bytePool: System.Buffers.ArrayPool<System.Buffers.ArrayPool`1>{System.Byte<System.Byte>}
    
        
        :type charPool: System.Buffers.ArrayPool<System.Buffers.ArrayPool`1>{System.Char<System.Char>}
    
        
        .. code-block:: csharp
    
            public HttpRequestStreamReader(Stream stream, Encoding encoding, int bufferSize, ArrayPool<byte> bytePool, ArrayPool<char> charPool)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.WebUtilities.HttpRequestStreamReader
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.WebUtilities.HttpRequestStreamReader.Close()
    
        
    
        
        .. code-block:: csharp
    
            public override void Close()
    
    .. dn:method:: Microsoft.AspNetCore.WebUtilities.HttpRequestStreamReader.Dispose(System.Boolean)
    
        
    
        
        :type disposing: System.Boolean
    
        
        .. code-block:: csharp
    
            protected override void Dispose(bool disposing)
    
    .. dn:method:: Microsoft.AspNetCore.WebUtilities.HttpRequestStreamReader.Peek()
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public override int Peek()
    
    .. dn:method:: Microsoft.AspNetCore.WebUtilities.HttpRequestStreamReader.Read()
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public override int Read()
    
    .. dn:method:: Microsoft.AspNetCore.WebUtilities.HttpRequestStreamReader.Read(System.Char[], System.Int32, System.Int32)
    
        
    
        
        :type buffer: System.Char<System.Char>[]
    
        
        :type index: System.Int32
    
        
        :type count: System.Int32
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public override int Read(char[] buffer, int index, int count)
    
    .. dn:method:: Microsoft.AspNetCore.WebUtilities.HttpRequestStreamReader.ReadAsync(System.Char[], System.Int32, System.Int32)
    
        
    
        
        :type buffer: System.Char<System.Char>[]
    
        
        :type index: System.Int32
    
        
        :type count: System.Int32
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Int32<System.Int32>}
    
        
        .. code-block:: csharp
    
            public override Task<int> ReadAsync(char[] buffer, int index, int count)
    

