

IApplicationLifetime Interface
==============================



.. contents:: 
   :local:



Summary
-------

Allows consumers to perform cleanup during a graceful shutdown.











Syntax
------

.. code-block:: csharp

   public interface IApplicationLifetime





GitHub
------

`View on GitHub <https://github.com/aspnet/hosting/blob/master/src/Microsoft.AspNet.Hosting.Abstractions/IApplicationLifetime.cs>`_





.. dn:interface:: Microsoft.AspNet.Hosting.IApplicationLifetime

Methods
-------

.. dn:interface:: Microsoft.AspNet.Hosting.IApplicationLifetime
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Hosting.IApplicationLifetime.StopApplication()
    
        
    
        Requests termination the current application.
    
        
    
        
        .. code-block:: csharp
    
           void StopApplication()
    

Properties
----------

.. dn:interface:: Microsoft.AspNet.Hosting.IApplicationLifetime
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Hosting.IApplicationLifetime.ApplicationStarted
    
        
    
        Triggered when the application host has fully started and is about to wait
        for a graceful shutdown.
    
        
        :rtype: System.Threading.CancellationToken
    
        
        .. code-block:: csharp
    
           CancellationToken ApplicationStarted { get; }
    
    .. dn:property:: Microsoft.AspNet.Hosting.IApplicationLifetime.ApplicationStopped
    
        
    
        Triggered when the application host is performing a graceful shutdown.
        All requests should be complete at this point. Shutdown will block
        until this event completes.
    
        
        :rtype: System.Threading.CancellationToken
    
        
        .. code-block:: csharp
    
           CancellationToken ApplicationStopped { get; }
    
    .. dn:property:: Microsoft.AspNet.Hosting.IApplicationLifetime.ApplicationStopping
    
        
    
        Triggered when the application host is performing a graceful shutdown.
        Request may still be in flight. Shutdown will block until this event completes.
    
        
        :rtype: System.Threading.CancellationToken
    
        
        .. code-block:: csharp
    
           CancellationToken ApplicationStopping { get; }
    

