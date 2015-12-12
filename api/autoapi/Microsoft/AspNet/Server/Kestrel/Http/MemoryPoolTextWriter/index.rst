

MemoryPoolTextWriter Class
==========================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.MarshalByRefObject`
* :dn:cls:`System.IO.TextWriter`
* :dn:cls:`Microsoft.AspNet.Server.Kestrel.Http.MemoryPoolTextWriter`








Syntax
------

.. code-block:: csharp

   public class MemoryPoolTextWriter : TextWriter, IDisposable





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/kestrelhttpserver/src/Microsoft.AspNet.Server.Kestrel/Http/MemoryPoolTextWriter.cs>`_





.. dn:class:: Microsoft.AspNet.Server.Kestrel.Http.MemoryPoolTextWriter

Constructors
------------

.. dn:class:: Microsoft.AspNet.Server.Kestrel.Http.MemoryPoolTextWriter
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Server.Kestrel.Http.MemoryPoolTextWriter.MemoryPoolTextWriter(Microsoft.AspNet.Server.Kestrel.Http.IMemoryPool)
    
        
        
        
        :type memory: Microsoft.AspNet.Server.Kestrel.Http.IMemoryPool
    
        
        .. code-block:: csharp
    
           public MemoryPoolTextWriter(IMemoryPool memory)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Server.Kestrel.Http.MemoryPoolTextWriter
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Http.MemoryPoolTextWriter.Dispose(System.Boolean)
    
        
        
        
        :type disposing: System.Boolean
    
        
        .. code-block:: csharp
    
           protected override void Dispose(bool disposing)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Http.MemoryPoolTextWriter.Flush()
    
        
    
        
        .. code-block:: csharp
    
           public override void Flush()
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Http.MemoryPoolTextWriter.Write(System.Char)
    
        
        
        
        :type value: System.Char
    
        
        .. code-block:: csharp
    
           public override void Write(char value)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Http.MemoryPoolTextWriter.Write(System.String)
    
        
        
        
        :type value: System.String
    
        
        .. code-block:: csharp
    
           public override void Write(string value)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Server.Kestrel.Http.MemoryPoolTextWriter
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Http.MemoryPoolTextWriter.Buffer
    
        
        :rtype: System.ArraySegment{System.Byte}
    
        
        .. code-block:: csharp
    
           public ArraySegment<byte> Buffer { get; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Http.MemoryPoolTextWriter.Encoding
    
        
        :rtype: System.Text.Encoding
    
        
        .. code-block:: csharp
    
           public override Encoding Encoding { get; }
    

