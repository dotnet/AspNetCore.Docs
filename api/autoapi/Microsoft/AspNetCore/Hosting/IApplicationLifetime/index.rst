

IApplicationLifetime Interface
==============================






Allows consumers to perform cleanup during a graceful shutdown.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Hosting`
Assemblies
    * Microsoft.AspNetCore.Hosting.Abstractions

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IApplicationLifetime








.. dn:interface:: Microsoft.AspNetCore.Hosting.IApplicationLifetime
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Hosting.IApplicationLifetime

Properties
----------

.. dn:interface:: Microsoft.AspNetCore.Hosting.IApplicationLifetime
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Hosting.IApplicationLifetime.ApplicationStarted
    
        
    
        
        Triggered when the application host has fully started and is about to wait
        for a graceful shutdown.
    
        
        :rtype: System.Threading.CancellationToken
    
        
        .. code-block:: csharp
    
            CancellationToken ApplicationStarted
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Hosting.IApplicationLifetime.ApplicationStopped
    
        
    
        
        Triggered when the application host is performing a graceful shutdown.
        All requests should be complete at this point. Shutdown will block
        until this event completes.
    
        
        :rtype: System.Threading.CancellationToken
    
        
        .. code-block:: csharp
    
            CancellationToken ApplicationStopped
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Hosting.IApplicationLifetime.ApplicationStopping
    
        
    
        
        Triggered when the application host is performing a graceful shutdown.
        Requests may still be in flight. Shutdown will block until this event completes.
    
        
        :rtype: System.Threading.CancellationToken
    
        
        .. code-block:: csharp
    
            CancellationToken ApplicationStopping
            {
                get;
            }
    

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Hosting.IApplicationLifetime
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Hosting.IApplicationLifetime.StopApplication()
    
        
    
        
        Requests termination the current application.
    
        
    
        
        .. code-block:: csharp
    
            void StopApplication()
    

