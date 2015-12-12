

KestrelThread Class
===================



.. contents:: 
   :local:



Summary
-------

Summary description for KestrelThread





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Server.Kestrel.KestrelThread`








Syntax
------

.. code-block:: csharp

   public class KestrelThread





GitHub
------

`View on GitHub <https://github.com/aspnet/kestrelhttpserver/blob/master/src/Microsoft.AspNet.Server.Kestrel/Infrastructure/KestrelThread.cs>`_





.. dn:class:: Microsoft.AspNet.Server.Kestrel.KestrelThread

Constructors
------------

.. dn:class:: Microsoft.AspNet.Server.Kestrel.KestrelThread
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Server.Kestrel.KestrelThread.KestrelThread(Microsoft.AspNet.Server.Kestrel.KestrelEngine)
    
        
        
        
        :type engine: Microsoft.AspNet.Server.Kestrel.KestrelEngine
    
        
        .. code-block:: csharp
    
           public KestrelThread(KestrelEngine engine)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Server.Kestrel.KestrelThread
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.KestrelThread.Post(System.Action<System.Object>, System.Object)
    
        
        
        
        :type callback: System.Action{System.Object}
        
        
        :type state: System.Object
    
        
        .. code-block:: csharp
    
           public void Post(Action<object> callback, object state)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.KestrelThread.PostAsync(System.Action<System.Object>, System.Object)
    
        
        
        
        :type callback: System.Action{System.Object}
        
        
        :type state: System.Object
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public Task PostAsync(Action<object> callback, object state)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.KestrelThread.PostAsync<T>(System.Action<T>, T)
    
        
        
        
        :type callback: System.Action{{T}}
        
        
        :type state: {T}
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public Task PostAsync<T>(Action<T> callback, T state)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.KestrelThread.Post<T>(System.Action<T>, T)
    
        
        
        
        :type callback: System.Action{{T}}
        
        
        :type state: {T}
    
        
        .. code-block:: csharp
    
           public void Post<T>(Action<T> callback, T state)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.KestrelThread.Send(System.Action<System.Object>, System.Object)
    
        
        
        
        :type callback: System.Action{System.Object}
        
        
        :type state: System.Object
    
        
        .. code-block:: csharp
    
           public void Send(Action<object> callback, object state)
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.KestrelThread.StartAsync()
    
        
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public Task StartAsync()
    
    .. dn:method:: Microsoft.AspNet.Server.Kestrel.KestrelThread.Stop(System.TimeSpan)
    
        
        
        
        :type timeout: System.TimeSpan
    
        
        .. code-block:: csharp
    
           public void Stop(TimeSpan timeout)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Server.Kestrel.KestrelThread
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.KestrelThread.FatalError
    
        
        :rtype: System.Runtime.ExceptionServices.ExceptionDispatchInfo
    
        
        .. code-block:: csharp
    
           public ExceptionDispatchInfo FatalError { get; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.KestrelThread.Loop
    
        
        :rtype: Microsoft.AspNet.Server.Kestrel.Networking.UvLoopHandle
    
        
        .. code-block:: csharp
    
           public UvLoopHandle Loop { get; }
    
    .. dn:property:: Microsoft.AspNet.Server.Kestrel.KestrelThread.QueueCloseHandle
    
        
        :rtype: System.Action{System.Action{System.IntPtr},System.IntPtr}
    
        
        .. code-block:: csharp
    
           public Action<Action<IntPtr>, IntPtr> QueueCloseHandle { get; }
    

