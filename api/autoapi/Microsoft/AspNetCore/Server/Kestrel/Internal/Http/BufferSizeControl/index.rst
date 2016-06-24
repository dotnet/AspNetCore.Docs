

BufferSizeControl Class
=======================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Server.Kestrel.Internal.Http`
Assemblies
    * Microsoft.AspNetCore.Server.Kestrel

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Server.Kestrel.Internal.Http.BufferSizeControl`








Syntax
------

.. code-block:: csharp

    public class BufferSizeControl : IBufferSizeControl








.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.BufferSizeControl
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.BufferSizeControl

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.BufferSizeControl
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.BufferSizeControl.BufferSizeControl(System.Int64, Microsoft.AspNetCore.Server.Kestrel.Internal.Http.IConnectionControl, Microsoft.AspNetCore.Server.Kestrel.Internal.KestrelThread)
    
        
    
        
        :type maxSize: System.Int64
    
        
        :type connectionControl: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.IConnectionControl
    
        
        :type connectionThread: Microsoft.AspNetCore.Server.Kestrel.Internal.KestrelThread
    
        
        .. code-block:: csharp
    
            public BufferSizeControl(long maxSize, IConnectionControl connectionControl, KestrelThread connectionThread)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.BufferSizeControl
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.BufferSizeControl.Add(System.Int32)
    
        
    
        
        :type count: System.Int32
    
        
        .. code-block:: csharp
    
            public void Add(int count)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.Http.BufferSizeControl.Subtract(System.Int32)
    
        
    
        
        :type count: System.Int32
    
        
        .. code-block:: csharp
    
            public void Subtract(int count)
    

