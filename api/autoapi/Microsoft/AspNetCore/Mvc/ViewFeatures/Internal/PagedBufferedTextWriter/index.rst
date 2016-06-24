

PagedBufferedTextWriter Class
=============================





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
* :dn:cls:`Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.PagedBufferedTextWriter`








Syntax
------

.. code-block:: csharp

    public class PagedBufferedTextWriter : TextWriter, IDisposable








.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.PagedBufferedTextWriter
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.PagedBufferedTextWriter

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.PagedBufferedTextWriter
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.PagedBufferedTextWriter.PagedBufferedTextWriter(System.Buffers.ArrayPool<System.Char>, System.IO.TextWriter)
    
        
    
        
        :type pool: System.Buffers.ArrayPool<System.Buffers.ArrayPool`1>{System.Char<System.Char>}
    
        
        :type inner: System.IO.TextWriter
    
        
        .. code-block:: csharp
    
            public PagedBufferedTextWriter(ArrayPool<char> pool, TextWriter inner)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.PagedBufferedTextWriter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.PagedBufferedTextWriter.Dispose(System.Boolean)
    
        
    
        
        :type disposing: System.Boolean
    
        
        .. code-block:: csharp
    
            protected override void Dispose(bool disposing)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.PagedBufferedTextWriter.Flush()
    
        
    
        
        .. code-block:: csharp
    
            public override void Flush()
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.PagedBufferedTextWriter.FlushAsync()
    
        
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public override Task FlushAsync()
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.PagedBufferedTextWriter.Write(System.Char)
    
        
    
        
        :type value: System.Char
    
        
        .. code-block:: csharp
    
            public override void Write(char value)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.PagedBufferedTextWriter.Write(System.Char[])
    
        
    
        
        :type buffer: System.Char<System.Char>[]
    
        
        .. code-block:: csharp
    
            public override void Write(char[] buffer)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.PagedBufferedTextWriter.Write(System.Char[], System.Int32, System.Int32)
    
        
    
        
        :type buffer: System.Char<System.Char>[]
    
        
        :type index: System.Int32
    
        
        :type count: System.Int32
    
        
        .. code-block:: csharp
    
            public override void Write(char[] buffer, int index, int count)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.PagedBufferedTextWriter.Write(System.String)
    
        
    
        
        :type value: System.String
    
        
        .. code-block:: csharp
    
            public override void Write(string value)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.PagedBufferedTextWriter.WriteAsync(System.Char)
    
        
    
        
        :type value: System.Char
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public override Task WriteAsync(char value)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.PagedBufferedTextWriter.WriteAsync(System.Char[], System.Int32, System.Int32)
    
        
    
        
        :type buffer: System.Char<System.Char>[]
    
        
        :type index: System.Int32
    
        
        :type count: System.Int32
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public override Task WriteAsync(char[] buffer, int index, int count)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.PagedBufferedTextWriter.WriteAsync(System.String)
    
        
    
        
        :type value: System.String
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public override Task WriteAsync(string value)
    

Fields
------

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.PagedBufferedTextWriter
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.PagedBufferedTextWriter.PageSize
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public const int PageSize = 1024
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.PagedBufferedTextWriter
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.PagedBufferedTextWriter.Encoding
    
        
        :rtype: System.Text.Encoding
    
        
        .. code-block:: csharp
    
            public override Encoding Encoding { get; }
    

