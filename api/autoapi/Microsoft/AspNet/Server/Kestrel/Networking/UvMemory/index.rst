

UvMemory Class
==============



.. contents:: 
   :local:



Summary
-------

Summary description for UvMemory





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.Runtime.ConstrainedExecution.CriticalFinalizerObject`
* :dn:cls:`System.Runtime.InteropServices.SafeHandle`
* :dn:cls:`Microsoft.AspNet.Server.Kestrel.Networking.UvMemory`








Syntax
------

.. code-block:: csharp

   public abstract class UvMemory : SafeHandle, IDisposable





GitHub
------

`View on GitHub <https://github.com/aspnet/kestrelhttpserver/blob/master/src/Microsoft.AspNet.Server.Kestrel/Networking/UvMemory.cs>`_





.. dn:class:: Microsoft.AspNet.Server.Kestrel.Networking.UvMemory

Constructors
------------

.. dn:class:: Microsoft.AspNet.Server.Kestrel.Networking.UvMemory
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Server.Kestrel.Networking.UvMemory.UvMemory(Microsoft.AspNet.Server.Kestrel.Infrastructure.IKestrelTrace)
    
        
        
        
        :type logger: Microsoft.AspNet.Server.Kestrel.Infrastructure.IKestrelTrace
    
        
        .. code-block:: csharp
    
           protected UvMemory(IKestrelTrace logger)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Server.Kestrel.Networking.UvMemory
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Networking.UvMemory.CreateMemory(Microsoft.AspNet.Server.Kestrel.Networking.Libuv, System.Int32, System.Int32)
    
        
        
        
        :type uv: Microsoft.AspNet.Server.Kestrel.Networking.Libuv
        
        
        :type threadId: System.Int32
        
        
        :type size: System.Int32
    
        
        .. code-block:: csharp
    
           protected void CreateMemory(Libuv uv, int threadId, int size)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Networking.UvMemory.DestroyMemory(System.IntPtr)
    
        
        
        
        :type memory: System.IntPtr
    
        
        .. code-block:: csharp
    
           protected static void DestroyMemory(IntPtr memory)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Networking.UvMemory.DestroyMemory(System.IntPtr, System.IntPtr)
    
        
        
        
        :type memory: System.IntPtr
        
        
        :type gcHandlePtr: System.IntPtr
    
        
        .. code-block:: csharp
    
           protected static void DestroyMemory(IntPtr memory, IntPtr gcHandlePtr)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Networking.UvMemory.FromIntPtr<THandle>(System.IntPtr)
    
        
        
        
        :type handle: System.IntPtr
        :rtype: {THandle}
    
        
        .. code-block:: csharp
    
           public static THandle FromIntPtr<THandle>(IntPtr handle)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.Networking.UvMemory.Validate(System.Boolean)
    
        
        
        
        :type closed: System.Boolean
    
        
        .. code-block:: csharp
    
           public void Validate(bool closed = false)
    

Fields
------

.. dn:class:: Microsoft.AspNet.Server.Kestrel.Networking.UvMemory
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNet.Server.Kestrel.Networking.UvMemory._log
    
        
    
        
        .. code-block:: csharp
    
           protected IKestrelTrace _log
    
    .. dn:field:: Microsoft.AspNet.Server.Kestrel.Networking.UvMemory._threadId
    
        
    
        
        .. code-block:: csharp
    
           protected int _threadId
    
    .. dn:field:: Microsoft.AspNet.Server.Kestrel.Networking.UvMemory._uv
    
        
    
        
        .. code-block:: csharp
    
           protected Libuv _uv
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Server.Kestrel.Networking.UvMemory
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Networking.UvMemory.IsInvalid
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public override bool IsInvalid { get; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Networking.UvMemory.Libuv
    
        
        :rtype: Microsoft.AspNet.Server.Kestrel.Networking.Libuv
    
        
        .. code-block:: csharp
    
           public Libuv Libuv { get; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.Networking.UvMemory.ThreadId
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int ThreadId { get; }
    

