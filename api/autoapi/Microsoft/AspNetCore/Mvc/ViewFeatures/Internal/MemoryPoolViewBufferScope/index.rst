

MemoryPoolViewBufferScope Class
===============================






A :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.IViewBufferScope` that uses pooled memory.


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
* :dn:cls:`Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.MemoryPoolViewBufferScope`








Syntax
------

.. code-block:: csharp

    public class MemoryPoolViewBufferScope : IViewBufferScope, IDisposable








.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.MemoryPoolViewBufferScope
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.MemoryPoolViewBufferScope

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.MemoryPoolViewBufferScope
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.MemoryPoolViewBufferScope.MemoryPoolViewBufferScope(System.Buffers.ArrayPool<Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ViewBufferValue>, System.Buffers.ArrayPool<System.Char>)
    
        
    
        
        Initializes a new instance of :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.MemoryPoolViewBufferScope`\.
    
        
    
        
        :param viewBufferPool: 
            The :any:`System.Buffers.ArrayPool\`1` for creating :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ViewBufferValue` instances.
        
        :type viewBufferPool: System.Buffers.ArrayPool<System.Buffers.ArrayPool`1>{Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ViewBufferValue<Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ViewBufferValue>}
    
        
        :param charPool: 
            The :any:`System.Buffers.ArrayPool\`1` for creating :any:`Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.PagedBufferedTextWriter` instances.
        
        :type charPool: System.Buffers.ArrayPool<System.Buffers.ArrayPool`1>{System.Char<System.Char>}
    
        
        .. code-block:: csharp
    
            public MemoryPoolViewBufferScope(ArrayPool<ViewBufferValue> viewBufferPool, ArrayPool<char> charPool)
    

Fields
------

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.MemoryPoolViewBufferScope
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.MemoryPoolViewBufferScope.MinimumSize
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public static readonly int MinimumSize
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.MemoryPoolViewBufferScope
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.MemoryPoolViewBufferScope.CreateWriter(System.IO.TextWriter)
    
        
    
        
        :type writer: System.IO.TextWriter
        :rtype: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.PagedBufferedTextWriter
    
        
        .. code-block:: csharp
    
            public PagedBufferedTextWriter CreateWriter(TextWriter writer)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.MemoryPoolViewBufferScope.Dispose()
    
        
    
        
        .. code-block:: csharp
    
            public void Dispose()
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.MemoryPoolViewBufferScope.GetPage(System.Int32)
    
        
    
        
        :type pageSize: System.Int32
        :rtype: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ViewBufferValue<Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ViewBufferValue>[]
    
        
        .. code-block:: csharp
    
            public ViewBufferValue[] GetPage(int pageSize)
    
    .. dn:method:: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.MemoryPoolViewBufferScope.ReturnSegment(Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ViewBufferValue[])
    
        
    
        
        :type segment: Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ViewBufferValue<Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.ViewBufferValue>[]
    
        
        .. code-block:: csharp
    
            public void ReturnSegment(ViewBufferValue[] segment)
    

