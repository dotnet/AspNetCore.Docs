

TaskUtilities Class
===================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure`
Assemblies
    * Microsoft.AspNetCore.Server.Kestrel

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.TaskUtilities`








Syntax
------

.. code-block:: csharp

    public class TaskUtilities








.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.TaskUtilities
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.TaskUtilities

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.TaskUtilities
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.TaskUtilities.GetCancelledTask(System.Threading.CancellationToken)
    
        
    
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public static Task GetCancelledTask(CancellationToken cancellationToken)
    
    .. dn:method:: Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.TaskUtilities.GetCancelledZeroTask(System.Threading.CancellationToken)
    
        
    
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Int32<System.Int32>}
    
        
        .. code-block:: csharp
    
            public static Task<int> GetCancelledZeroTask(CancellationToken cancellationToken = null)
    

Fields
------

.. dn:class:: Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.TaskUtilities
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.TaskUtilities.CompletedTask
    
        
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public static Task CompletedTask
    
    .. dn:field:: Microsoft.AspNetCore.Server.Kestrel.Internal.Infrastructure.TaskUtilities.ZeroTask
    
        
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Int32<System.Int32>}
    
        
        .. code-block:: csharp
    
            public static Task<int> ZeroTask
    

