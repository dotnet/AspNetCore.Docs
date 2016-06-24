

ThreadPoolBoundHandle Class
===========================





Namespace
    :dn:ns:`System.Threading`
Assemblies
    * Microsoft.Net.Http.Server

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`System.Threading.ThreadPoolBoundHandle`








Syntax
------

.. code-block:: csharp

    public sealed class ThreadPoolBoundHandle : IDisposable








.. dn:class:: System.Threading.ThreadPoolBoundHandle
    :hidden:

.. dn:class:: System.Threading.ThreadPoolBoundHandle

Methods
-------

.. dn:class:: System.Threading.ThreadPoolBoundHandle
    :noindex:
    :hidden:

    
    .. dn:method:: System.Threading.ThreadPoolBoundHandle.AllocateNativeOverlapped(System.Threading.IOCompletionCallback, System.Object, System.Object)
    
        
    
        
        :type callback: System.Threading.IOCompletionCallback
    
        
        :type state: System.Object
    
        
        :type pinData: System.Object
        :rtype: System.Threading.NativeOverlapped<System.Threading.NativeOverlapped>*
    
        
        .. code-block:: csharp
    
            public NativeOverlapped*AllocateNativeOverlapped(IOCompletionCallback callback, object state, object pinData)
    
    .. dn:method:: System.Threading.ThreadPoolBoundHandle.AllocateNativeOverlapped(System.Threading.PreAllocatedOverlapped)
    
        
    
        
        :type preAllocated: System.Threading.PreAllocatedOverlapped
        :rtype: System.Threading.NativeOverlapped<System.Threading.NativeOverlapped>*
    
        
        .. code-block:: csharp
    
            public NativeOverlapped*AllocateNativeOverlapped(PreAllocatedOverlapped preAllocated)
    
    .. dn:method:: System.Threading.ThreadPoolBoundHandle.BindHandle(System.Runtime.InteropServices.SafeHandle)
    
        
    
        
        :type handle: System.Runtime.InteropServices.SafeHandle
        :rtype: System.Threading.ThreadPoolBoundHandle
    
        
        .. code-block:: csharp
    
            public static ThreadPoolBoundHandle BindHandle(SafeHandle handle)
    
    .. dn:method:: System.Threading.ThreadPoolBoundHandle.Dispose()
    
        
    
        
        .. code-block:: csharp
    
            public void Dispose()
    
    .. dn:method:: System.Threading.ThreadPoolBoundHandle.FreeNativeOverlapped(System.Threading.NativeOverlapped*)
    
        
    
        
        :type overlapped: System.Threading.NativeOverlapped<System.Threading.NativeOverlapped>*
    
        
        .. code-block:: csharp
    
            public void FreeNativeOverlapped(NativeOverlapped*overlapped)
    
    .. dn:method:: System.Threading.ThreadPoolBoundHandle.GetNativeOverlappedState(System.Threading.NativeOverlapped*)
    
        
    
        
        :type overlapped: System.Threading.NativeOverlapped<System.Threading.NativeOverlapped>*
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
            public static object GetNativeOverlappedState(NativeOverlapped*overlapped)
    

Properties
----------

.. dn:class:: System.Threading.ThreadPoolBoundHandle
    :noindex:
    :hidden:

    
    .. dn:property:: System.Threading.ThreadPoolBoundHandle.Handle
    
        
        :rtype: System.Runtime.InteropServices.SafeHandle
    
        
        .. code-block:: csharp
    
            public SafeHandle Handle { get; }
    

