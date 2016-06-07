

LoggingThreadPool Class
=======================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Server.Kestrel.Infrastructure`
Assemblies
    * Microsoft.AspNetCore.Server.Kestrel

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Server.Kestrel.Infrastructure.LoggingThreadPool`








Syntax
------

.. code-block:: csharp

    public class LoggingThreadPool : IThreadPool








.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.LoggingThreadPool
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.LoggingThreadPool

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.LoggingThreadPool
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.LoggingThreadPool.LoggingThreadPool(Microsoft.AspNetCore.Server.Kestrel.Infrastructure.IKestrelTrace)
    
        
    
        
        :type log: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.IKestrelTrace
    
        
        .. code-block:: csharp
    
            public LoggingThreadPool(IKestrelTrace log)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.LoggingThreadPool
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.LoggingThreadPool.Cancel(System.Threading.Tasks.TaskCompletionSource<System.Object>)
    
        
    
        
        :type tcs: System.Threading.Tasks.TaskCompletionSource<System.Threading.Tasks.TaskCompletionSource`1>{System.Object<System.Object>}
    
        
        .. code-block:: csharp
    
            public void Cancel(TaskCompletionSource<object> tcs)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.LoggingThreadPool.Complete(System.Threading.Tasks.TaskCompletionSource<System.Object>)
    
        
    
        
        :type tcs: System.Threading.Tasks.TaskCompletionSource<System.Threading.Tasks.TaskCompletionSource`1>{System.Object<System.Object>}
    
        
        .. code-block:: csharp
    
            public void Complete(TaskCompletionSource<object> tcs)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.LoggingThreadPool.Error(System.Threading.Tasks.TaskCompletionSource<System.Object>, System.Exception)
    
        
    
        
        :type tcs: System.Threading.Tasks.TaskCompletionSource<System.Threading.Tasks.TaskCompletionSource`1>{System.Object<System.Object>}
    
        
        :type ex: System.Exception
    
        
        .. code-block:: csharp
    
            public void Error(TaskCompletionSource<object> tcs, Exception ex)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Infrastructure.LoggingThreadPool.Run(System.Action)
    
        
    
        
        :type action: System.Action
    
        
        .. code-block:: csharp
    
            public void Run(Action action)
    

