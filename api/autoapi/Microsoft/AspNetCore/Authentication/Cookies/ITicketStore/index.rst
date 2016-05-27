

ITicketStore Interface
======================






This provides an abstract storage mechanic to preserve identity information on the server
while only sending a simple identifier key to the client. This is most commonly used to mitigate
issues with serializing large identities into cookies.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Authentication.Cookies`
Assemblies
    * Microsoft.AspNetCore.Authentication.Cookies

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface ITicketStore








.. dn:interface:: Microsoft.AspNetCore.Authentication.Cookies.ITicketStore
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Authentication.Cookies.ITicketStore

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Authentication.Cookies.ITicketStore
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Authentication.Cookies.ITicketStore.RemoveAsync(System.String)
    
        
    
        
        Remove the identity associated with the given key.
    
        
    
        
        :param key: The key associated with the identity.
        
        :type key: System.String
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            Task RemoveAsync(string key)
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.Cookies.ITicketStore.RenewAsync(System.String, Microsoft.AspNetCore.Authentication.AuthenticationTicket)
    
        
    
        
        Tells the store that the given identity should be updated.
    
        
    
        
        :type key: System.String
    
        
        :type ticket: Microsoft.AspNetCore.Authentication.AuthenticationTicket
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            Task RenewAsync(string key, AuthenticationTicket ticket)
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.Cookies.ITicketStore.RetrieveAsync(System.String)
    
        
    
        
        Retrieves an identity from the store for the given key.
    
        
    
        
        :param key: The key associated with the identity.
        
        :type key: System.String
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Authentication.AuthenticationTicket<Microsoft.AspNetCore.Authentication.AuthenticationTicket>}
        :return: The identity associated with the given key, or if not found.
    
        
        .. code-block:: csharp
    
            Task<AuthenticationTicket> RetrieveAsync(string key)
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.Cookies.ITicketStore.StoreAsync(Microsoft.AspNetCore.Authentication.AuthenticationTicket)
    
        
    
        
        Store the identity ticket and return the associated key.
    
        
    
        
        :param ticket: The identity information to store.
        
        :type ticket: Microsoft.AspNetCore.Authentication.AuthenticationTicket
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.String<System.String>}
        :return: The key that can be used to retrieve the identity later.
    
        
        .. code-block:: csharp
    
            Task<string> StoreAsync(AuthenticationTicket ticket)
    

