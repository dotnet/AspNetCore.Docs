

ApplicationLifetime Class
=========================



.. contents:: 
   :local:



Summary
-------

Allows consumers to perform cleanup during a graceful shutdown.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Hosting.ApplicationLifetime`








Syntax
------

.. code-block:: csharp

   public class ApplicationLifetime : IApplicationLifetime





GitHub
------

`View on GitHub <https://github.com/aspnet/hosting/blob/master/src/Microsoft.AspNet.Hosting/ApplicationLifetime.cs>`_





.. dn:class:: Microsoft.AspNet.Hosting.ApplicationLifetime

Methods
-------

.. dn:class:: Microsoft.AspNet.Hosting.ApplicationLifetime
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Hosting.ApplicationLifetime.NotifyStarted()
    
        
    
        Signals the ApplicationStarted event and blocks until it completes.
    
        
    
        
        .. code-block:: csharp
    
           public void NotifyStarted()
    
    .. dn:method:: Microsoft.AspNet.Hosting.ApplicationLifetime.NotifyStopped()
    
        
    
        Signals the ApplicationStopped event and blocks until it completes.
    
        
    
        
        .. code-block:: csharp
    
           public void NotifyStopped()
    
    .. dn:method:: Microsoft.AspNet.Hosting.ApplicationLifetime.StopApplication()
    
        
    
        Signals the ApplicationStopping event and blocks until it completes.
    
        
    
        
        .. code-block:: csharp
    
           public void StopApplication()
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Hosting.ApplicationLifetime
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Hosting.ApplicationLifetime.ApplicationStarted
    
        
    
        Triggered when the application host has fully started and is about to wait
        for a graceful shutdown.
    
        
        :rtype: System.Threading.CancellationToken
    
        
        .. code-block:: csharp
    
           public CancellationToken ApplicationStarted { get; }
    
    .. dn:property:: Microsoft.AspNet.Hosting.ApplicationLifetime.ApplicationStopped
    
        
    
        Triggered when the application host is performing a graceful shutdown.
        All requests should be complete at this point. Shutdown will block
        until this event completes.
    
        
        :rtype: System.Threading.CancellationToken
    
        
        .. code-block:: csharp
    
           public CancellationToken ApplicationStopped { get; }
    
    .. dn:property:: Microsoft.AspNet.Hosting.ApplicationLifetime.ApplicationStopping
    
        
    
        Triggered when the application host is performing a graceful shutdown.
        Request may still be in flight. Shutdown will block until this event completes.
    
        
        :rtype: System.Threading.CancellationToken
    
        
        .. code-block:: csharp
    
           public CancellationToken ApplicationStopping { get; }
    

