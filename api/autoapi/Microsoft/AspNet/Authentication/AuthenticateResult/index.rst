

AuthenticateResult Class
========================



.. contents:: 
   :local:



Summary
-------

Contains the result of an Authenticate call





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Authentication.AuthenticateResult`








Syntax
------

.. code-block:: csharp

   public class AuthenticateResult





GitHub
------

`View on GitHub <https://github.com/aspnet/security/blob/master/src/Microsoft.AspNet.Authentication/AuthenticateResult.cs>`_





.. dn:class:: Microsoft.AspNet.Authentication.AuthenticateResult

Methods
-------

.. dn:class:: Microsoft.AspNet.Authentication.AuthenticateResult
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Authentication.AuthenticateResult.Failed(System.Exception)
    
        
        
        
        :type error: System.Exception
        :rtype: Microsoft.AspNet.Authentication.AuthenticateResult
    
        
        .. code-block:: csharp
    
           public static AuthenticateResult Failed(Exception error)
    
    .. dn:method:: Microsoft.AspNet.Authentication.AuthenticateResult.Failed(System.String)
    
        
        
        
        :type errorMessage: System.String
        :rtype: Microsoft.AspNet.Authentication.AuthenticateResult
    
        
        .. code-block:: csharp
    
           public static AuthenticateResult Failed(string errorMessage)
    
    .. dn:method:: Microsoft.AspNet.Authentication.AuthenticateResult.Success(Microsoft.AspNet.Authentication.AuthenticationTicket)
    
        
        
        
        :type ticket: Microsoft.AspNet.Authentication.AuthenticationTicket
        :rtype: Microsoft.AspNet.Authentication.AuthenticateResult
    
        
        .. code-block:: csharp
    
           public static AuthenticateResult Success(AuthenticationTicket ticket)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Authentication.AuthenticateResult
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Authentication.AuthenticateResult.Error
    
        
    
        Holds error information caused by authentication.
    
        
        :rtype: System.Exception
    
        
        .. code-block:: csharp
    
           public Exception Error { get; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.AuthenticateResult.Succeeded
    
        
    
        If a ticket was produced, authenticate was successful.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool Succeeded { get; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.AuthenticateResult.Ticket
    
        
    
        The authentication ticket.
    
        
        :rtype: Microsoft.AspNet.Authentication.AuthenticationTicket
    
        
        .. code-block:: csharp
    
           public AuthenticationTicket Ticket { get; }
    

