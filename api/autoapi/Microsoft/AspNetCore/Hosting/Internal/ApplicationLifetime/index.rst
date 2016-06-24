

ApplicationLifetime Class
=========================






Allows consumers to perform cleanup during a graceful shutdown.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Hosting.Internal`
Assemblies
    * Microsoft.AspNetCore.Hosting

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Hosting.Internal.ApplicationLifetime`








Syntax
------

.. code-block:: csharp

    public class ApplicationLifetime : IApplicationLifetime








.. dn:class:: Microsoft.AspNetCore.Hosting.Internal.ApplicationLifetime
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Hosting.Internal.ApplicationLifetime

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Hosting.Internal.ApplicationLifetime
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Hosting.Internal.ApplicationLifetime.ApplicationStarted
    
        
    
        
        Triggered when the application host has fully started and is about to wait
        for a graceful shutdown.
    
        
        :rtype: System.Threading.CancellationToken
    
        
        .. code-block:: csharp
    
            public CancellationToken ApplicationStarted { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Hosting.Internal.ApplicationLifetime.ApplicationStopped
    
        
    
        
        Triggered when the application host is performing a graceful shutdown.
        All requests should be complete at this point. Shutdown will block
        until this event completes.
    
        
        :rtype: System.Threading.CancellationToken
    
        
        .. code-block:: csharp
    
            public CancellationToken ApplicationStopped { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Hosting.Internal.ApplicationLifetime.ApplicationStopping
    
        
    
        
        Triggered when the application host is performing a graceful shutdown.
        Request may still be in flight. Shutdown will block until this event completes.
    
        
        :rtype: System.Threading.CancellationToken
    
        
        .. code-block:: csharp
    
            public CancellationToken ApplicationStopping { get; }
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Hosting.Internal.ApplicationLifetime
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Hosting.Internal.ApplicationLifetime.NotifyStarted()
    
        
    
        
        Signals the ApplicationStarted event and blocks until it completes.
    
        
    
        
        .. code-block:: csharp
    
            public void NotifyStarted()
    
    .. dn:method:: Microsoft.AspNetCore.Hosting.Internal.ApplicationLifetime.NotifyStopped()
    
        
    
        
        Signals the ApplicationStopped event and blocks until it completes.
    
        
    
        
        .. code-block:: csharp
    
            public void NotifyStopped()
    
    .. dn:method:: Microsoft.AspNetCore.Hosting.Internal.ApplicationLifetime.StopApplication()
    
        
    
        
        Signals the ApplicationStopping event and blocks until it completes.
    
        
    
        
        .. code-block:: csharp
    
            public void StopApplication()
    

