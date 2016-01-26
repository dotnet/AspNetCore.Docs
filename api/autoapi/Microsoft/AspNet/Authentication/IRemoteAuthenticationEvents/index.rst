

IRemoteAuthenticationEvents Interface
=====================================



.. contents:: 
   :local:













Syntax
------

.. code-block:: csharp

   public interface IRemoteAuthenticationEvents





GitHub
------

`View on GitHub <https://github.com/aspnet/security/blob/master/src/Microsoft.AspNet.Authentication/Events/IRemoteAuthenticationEvents.cs>`_





.. dn:interface:: Microsoft.AspNet.Authentication.IRemoteAuthenticationEvents

Methods
-------

.. dn:interface:: Microsoft.AspNet.Authentication.IRemoteAuthenticationEvents
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Authentication.IRemoteAuthenticationEvents.RemoteError(Microsoft.AspNet.Authentication.ErrorContext)
    
        
    
        Invoked when the remote authentication process has an error.
    
        
        
        
        :type context: Microsoft.AspNet.Authentication.ErrorContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           Task RemoteError(ErrorContext context)
    
    .. dn:method:: Microsoft.AspNet.Authentication.IRemoteAuthenticationEvents.TicketReceived(Microsoft.AspNet.Authentication.TicketReceivedContext)
    
        
    
        Invoked before sign in.
    
        
        
        
        :type context: Microsoft.AspNet.Authentication.TicketReceivedContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           Task TicketReceived(TicketReceivedContext context)
    

