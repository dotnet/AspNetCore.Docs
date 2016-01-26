

ITicketStore Interface
======================



.. contents:: 
   :local:



Summary
-------

This provides an abstract storage mechanic to preserve identity information on the server
while only sending a simple identifier key to the client. This is most commonly used to mitigate
issues with serializing large identities into cookies.











Syntax
------

.. code-block:: csharp

   public interface ITicketStore





GitHub
------

`View on GitHub <https://github.com/aspnet/security/blob/master/src/Microsoft.AspNet.Authentication.Cookies/ITicketStore.cs>`_





.. dn:interface:: Microsoft.AspNet.Authentication.Cookies.ITicketStore

Methods
-------

.. dn:interface:: Microsoft.AspNet.Authentication.Cookies.ITicketStore
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Authentication.Cookies.ITicketStore.RemoveAsync(System.String)
    
        
    
        Remove the identity associated with the given key.
    
        
        
        
        :param key: The key associated with the identity.
        
        :type key: System.String
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           Task RemoveAsync(string key)
    
    .. dn:method:: Microsoft.AspNet.Authentication.Cookies.ITicketStore.RenewAsync(System.String, Microsoft.AspNet.Authentication.AuthenticationTicket)
    
        
    
        Tells the store that the given identity should be updated.
    
        
        
        
        :type key: System.String
        
        
        :type ticket: Microsoft.AspNet.Authentication.AuthenticationTicket
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           Task RenewAsync(string key, AuthenticationTicket ticket)
    
    .. dn:method:: Microsoft.AspNet.Authentication.Cookies.ITicketStore.RetrieveAsync(System.String)
    
        
    
        Retrieves an identity from the store for the given key.
    
        
        
        
        :param key: The key associated with the identity.
        
        :type key: System.String
        :rtype: System.Threading.Tasks.Task{Microsoft.AspNet.Authentication.AuthenticationTicket}
        :return: The identity associated with the given key, or if not found.
    
        
        .. code-block:: csharp
    
           Task<AuthenticationTicket> RetrieveAsync(string key)
    
    .. dn:method:: Microsoft.AspNet.Authentication.Cookies.ITicketStore.StoreAsync(Microsoft.AspNet.Authentication.AuthenticationTicket)
    
        
    
        Store the identity ticket and return the associated key.
    
        
        
        
        :param ticket: The identity information to store.
        
        :type ticket: Microsoft.AspNet.Authentication.AuthenticationTicket
        :rtype: System.Threading.Tasks.Task{System.String}
        :return: The key that can be used to retrieve the identity later.
    
        
        .. code-block:: csharp
    
           Task<string> StoreAsync(AuthenticationTicket ticket)
    

