

RemoteAuthenticationEvents Class
================================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Authentication`
Assemblies
    * Microsoft.AspNetCore.Authentication

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Authentication.RemoteAuthenticationEvents`








Syntax
------

.. code-block:: csharp

    public class RemoteAuthenticationEvents : IRemoteAuthenticationEvents








.. dn:class:: Microsoft.AspNetCore.Authentication.RemoteAuthenticationEvents
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Authentication.RemoteAuthenticationEvents

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Authentication.RemoteAuthenticationEvents
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Authentication.RemoteAuthenticationEvents.OnRemoteFailure
    
        
        :rtype: System.Func<System.Func`2>{Microsoft.AspNetCore.Authentication.FailureContext<Microsoft.AspNetCore.Authentication.FailureContext>, System.Threading.Tasks.Task<System.Threading.Tasks.Task>}
    
        
        .. code-block:: csharp
    
            public Func<FailureContext, Task> OnRemoteFailure { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Authentication.RemoteAuthenticationEvents.OnTicketReceived
    
        
        :rtype: System.Func<System.Func`2>{Microsoft.AspNetCore.Authentication.TicketReceivedContext<Microsoft.AspNetCore.Authentication.TicketReceivedContext>, System.Threading.Tasks.Task<System.Threading.Tasks.Task>}
    
        
        .. code-block:: csharp
    
            public Func<TicketReceivedContext, Task> OnTicketReceived { get; set; }
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Authentication.RemoteAuthenticationEvents
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Authentication.RemoteAuthenticationEvents.RemoteFailure(Microsoft.AspNetCore.Authentication.FailureContext)
    
        
    
        
        Invoked when there is a remote failure
    
        
    
        
        :type context: Microsoft.AspNetCore.Authentication.FailureContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public virtual Task RemoteFailure(FailureContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.RemoteAuthenticationEvents.TicketReceived(Microsoft.AspNetCore.Authentication.TicketReceivedContext)
    
        
    
        
        Invoked after the remote ticket has been received.
    
        
    
        
        :type context: Microsoft.AspNetCore.Authentication.TicketReceivedContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public virtual Task TicketReceived(TicketReceivedContext context)
    

