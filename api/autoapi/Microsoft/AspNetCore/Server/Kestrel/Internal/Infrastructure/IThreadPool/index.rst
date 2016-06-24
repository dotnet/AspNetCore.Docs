

IThreadPool Interface
=====================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure`
Assemblies
    * Microsoft.AspNetCore.Server.Kestrel

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IThreadPool








.. dn:interface:: Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.IThreadPool
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.IThreadPool

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.IThreadPool
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.IThreadPool.Cancel(System.Threading.Tasks.TaskCompletionSource<System.Object>)
    
        
    
        
        :type tcs: System.Threading.Tasks.TaskCompletionSource<System.Threading.Tasks.TaskCompletionSource`1>{System.Object<System.Object>}
    
        
        .. code-block:: csharp
    
            void Cancel(TaskCompletionSource<object> tcs)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.IThreadPool.Complete(System.Threading.Tasks.TaskCompletionSource<System.Object>)
    
        
    
        
        :type tcs: System.Threading.Tasks.TaskCompletionSource<System.Threading.Tasks.TaskCompletionSource`1>{System.Object<System.Object>}
    
        
        .. code-block:: csharp
    
            void Complete(TaskCompletionSource<object> tcs)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.IThreadPool.Error(System.Threading.Tasks.TaskCompletionSource<System.Object>, System.Exception)
    
        
    
        
        :type tcs: System.Threading.Tasks.TaskCompletionSource<System.Threading.Tasks.TaskCompletionSource`1>{System.Object<System.Object>}
    
        
        :type ex: System.Exception
    
        
        .. code-block:: csharp
    
            void Error(TaskCompletionSource<object> tcs, Exception ex)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.IThreadPool.Run(System.Action)
    
        
    
        
        :type action: System.Action
    
        
        .. code-block:: csharp
    
            void Run(Action action)
    

