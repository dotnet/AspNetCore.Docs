

KestrelThread Class
===================






Summary description for KestrelThread


Namespace
    :dn:ns:`Microsoft.AspNetCore.Server.Kestrel`
Assemblies
    * Microsoft.AspNetCore.Server.Kestrel

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Server.Kestrel.KestrelThread`








Syntax
------

.. code-block:: csharp

    public class KestrelThread








.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.KestrelThread
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.KestrelThread

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.KestrelThread
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.KestrelThread.FatalError
    
        
        :rtype: System.Runtime.ExceptionServices.ExceptionDispatchInfo
    
        
        .. code-block:: csharp
    
            public ExceptionDispatchInfo FatalError
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.KestrelThread.Loop
    
        
        :rtype: Microsoft.AspNetCore.Server.Kestrel.Networking.UvLoopHandle
    
        
        .. code-block:: csharp
    
            public UvLoopHandle Loop
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Server.Kestrel.KestrelThread.QueueCloseHandle
    
        
        :rtype: System.Action<System.Action`2>{System.Action<System.Action`1>{System.IntPtr<System.IntPtr>}, System.IntPtr<System.IntPtr>}
    
        
        .. code-block:: csharp
    
            public Action<Action<IntPtr>, IntPtr> QueueCloseHandle
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.KestrelThread
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Server.Kestrel.KestrelThread.KestrelThread(Microsoft.AspNetCore.Server.Kestrel.KestrelEngine)
    
        
    
        
        :type engine: Microsoft.AspNetCore.Server.Kestrel.KestrelEngine
    
        
        .. code-block:: csharp
    
            public KestrelThread(KestrelEngine engine)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.KestrelThread
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.KestrelThread.AllowStop()
    
        
    
        
        .. code-block:: csharp
    
            public void AllowStop()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.KestrelThread.Post(System.Action<System.Object>, System.Object)
    
        
    
        
        :type callback: System.Action<System.Action`1>{System.Object<System.Object>}
    
        
        :type state: System.Object
    
        
        .. code-block:: csharp
    
            public void Post(Action<object> callback, object state)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.KestrelThread.PostAsync(System.Action<System.Object>, System.Object)
    
        
    
        
        :type callback: System.Action<System.Action`1>{System.Object<System.Object>}
    
        
        :type state: System.Object
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public Task PostAsync(Action<object> callback, object state)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.KestrelThread.StartAsync()
    
        
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public Task StartAsync()
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.KestrelThread.Stop(System.TimeSpan)
    
        
    
        
        :type timeout: System.TimeSpan
    
        
        .. code-block:: csharp
    
            public void Stop(TimeSpan timeout)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.KestrelThread.Walk(System.Action<System.IntPtr>)
    
        
    
        
        :type callback: System.Action<System.Action`1>{System.IntPtr<System.IntPtr>}
    
        
        .. code-block:: csharp
    
            public void Walk(Action<IntPtr> callback)
    

