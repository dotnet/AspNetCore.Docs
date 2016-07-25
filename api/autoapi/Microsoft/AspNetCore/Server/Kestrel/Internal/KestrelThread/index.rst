

KestrelThread Class
===================






Summary description for KestrelThread


Namespace
    :dn:ns:`Microsoft.AspNetCore.Server.Kestrel.Internal`
Assemblies
    * Microsoft.AspNetCore.Server.Kestrel

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Server.Kestrel.Internal.KestrelThread`








Syntax
------

.. code-block:: csharp

    public class KestrelThread








.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Internal.KestrelThread
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Internal.KestrelThread

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Internal.KestrelThread
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Server.Kestrel.Internal.KestrelThread.KestrelThread(Microsoft.AspNetCore.Server.Kestrel.Internal.KestrelEngine)
    
        
    
        
        :type engine: Microsoft.AspNetCore.Server.Kestrel.Internal.KestrelEngine
    
        
        .. code-block:: csharp
    
            public KestrelThread(KestrelEngine engine)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Internal.KestrelThread
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.KestrelThread.AllowStop()
    
        
    
        
        .. code-block:: csharp
    
            public void AllowStop()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.KestrelThread.Post(System.Action<System.Object>, System.Object)
    
        
    
        
        :type callback: System.Action<System.Action`1>{System.Object<System.Object>}
    
        
        :type state: System.Object
    
        
        .. code-block:: csharp
    
            public void Post(Action<object> callback, object state)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.KestrelThread.PostAsync(System.Action<System.Object>, System.Object)
    
        
    
        
        :type callback: System.Action<System.Action`1>{System.Object<System.Object>}
    
        
        :type state: System.Object
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public Task PostAsync(Action<object> callback, object state)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.KestrelThread.StartAsync()
    
        
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public Task StartAsync()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.KestrelThread.Stop(System.TimeSpan)
    
        
    
        
        :type timeout: System.TimeSpan
    
        
        .. code-block:: csharp
    
            public void Stop(TimeSpan timeout)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.KestrelThread.Walk(System.Action<System.IntPtr>)
    
        
    
        
        :type callback: System.Action<System.Action`1>{System.IntPtr<System.IntPtr>}
    
        
        .. code-block:: csharp
    
            public void Walk(Action<IntPtr> callback)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Internal.KestrelThread
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Internal.KestrelThread.FatalError
    
        
        :rtype: System.Runtime.ExceptionServices.ExceptionDispatchInfo
    
        
        .. code-block:: csharp
    
            public ExceptionDispatchInfo FatalError { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Internal.KestrelThread.Loop
    
        
        :rtype: Microsoft.AspNetCore.Server.Kestrel.Internal.Networking.UvLoopHandle
    
        
        .. code-block:: csharp
    
            public UvLoopHandle Loop { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.Internal.KestrelThread.QueueCloseHandle
    
        
        :rtype: System.Action<System.Action`2>{System.Action<System.Action`1>{System.IntPtr<System.IntPtr>}, System.IntPtr<System.IntPtr>}
    
        
        .. code-block:: csharp
    
            public Action<Action<IntPtr>, IntPtr> QueueCloseHandle { get; }
    

