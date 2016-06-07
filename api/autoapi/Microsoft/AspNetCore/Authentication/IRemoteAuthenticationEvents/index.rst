

IRemoteAuthenticationEvents Interface
=====================================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Authentication`
Assemblies
    * Microsoft.AspNetCore.Authentication

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IRemoteAuthenticationEvents








.. dn:interface:: Microsoft.AspNetCore.Authentication.IRemoteAuthenticationEvents
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Authentication.IRemoteAuthenticationEvents

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Authentication.IRemoteAuthenticationEvents
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Authentication.IRemoteAuthenticationEvents.RemoteFailure(Microsoft.AspNetCore.Authentication.FailureContext)
    
        
    
        
        Invoked when the remote authentication process has an error.
    
        
    
        
        :type context: Microsoft.AspNetCore.Authentication.FailureContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            Task RemoteFailure(FailureContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.IRemoteAuthenticationEvents.TicketReceived(Microsoft.AspNetCore.Authentication.TicketReceivedContext)
    
        
    
        
        Invoked before sign in.
    
        
    
        
        :type context: Microsoft.AspNetCore.Authentication.TicketReceivedContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            Task TicketReceived(TicketReceivedContext context)
    

