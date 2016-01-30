

RemoteAuthenticationEvents Class
================================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Authentication.RemoteAuthenticationEvents`








Syntax
------

.. code-block:: csharp

   public class RemoteAuthenticationEvents : IRemoteAuthenticationEvents





GitHub
------

`View on GitHub <https://github.com/aspnet/security/blob/master/src/Microsoft.AspNet.Authentication/Events/RemoteAuthenticationEvents.cs>`_





.. dn:class:: Microsoft.AspNet.Authentication.RemoteAuthenticationEvents

Methods
-------

.. dn:class:: Microsoft.AspNet.Authentication.RemoteAuthenticationEvents
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Authentication.RemoteAuthenticationEvents.RemoteError(Microsoft.AspNet.Authentication.ErrorContext)
    
        
    
        Invoked when there is a remote error
    
        
        
        
        :type context: Microsoft.AspNet.Authentication.ErrorContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public virtual Task RemoteError(ErrorContext context)
    
    .. dn:method:: Microsoft.AspNet.Authentication.RemoteAuthenticationEvents.TicketReceived(Microsoft.AspNet.Authentication.TicketReceivedContext)
    
        
    
        Invoked after the remote ticket has been recieved.
    
        
        
        
        :type context: Microsoft.AspNet.Authentication.TicketReceivedContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public virtual Task TicketReceived(TicketReceivedContext context)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Authentication.RemoteAuthenticationEvents
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Authentication.RemoteAuthenticationEvents.OnRemoteError
    
        
        :rtype: System.Func{Microsoft.AspNet.Authentication.ErrorContext,System.Threading.Tasks.Task}
    
        
        .. code-block:: csharp
    
           public Func<ErrorContext, Task> OnRemoteError { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.RemoteAuthenticationEvents.OnTicketReceived
    
        
        :rtype: System.Func{Microsoft.AspNet.Authentication.TicketReceivedContext,System.Threading.Tasks.Task}
    
        
        .. code-block:: csharp
    
           public Func<TicketReceivedContext, Task> OnTicketReceived { get; set; }
    

