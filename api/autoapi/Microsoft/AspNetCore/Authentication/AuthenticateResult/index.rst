

AuthenticateResult Class
========================






Contains the result of an Authenticate call


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
* :dn:cls:`Microsoft.AspNetCore.Authentication.AuthenticateResult`








Syntax
------

.. code-block:: csharp

    public class AuthenticateResult








.. dn:class:: Microsoft.AspNetCore.Authentication.AuthenticateResult
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Authentication.AuthenticateResult

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Authentication.AuthenticateResult
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Authentication.AuthenticateResult.Fail(System.Exception)
    
        
    
        
        :type failure: System.Exception
        :rtype: Microsoft.AspNetCore.Authentication.AuthenticateResult
    
        
        .. code-block:: csharp
    
            public static AuthenticateResult Fail(Exception failure)
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.AuthenticateResult.Fail(System.String)
    
        
    
        
        :type failureMessage: System.String
        :rtype: Microsoft.AspNetCore.Authentication.AuthenticateResult
    
        
        .. code-block:: csharp
    
            public static AuthenticateResult Fail(string failureMessage)
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.AuthenticateResult.Skip()
    
        
        :rtype: Microsoft.AspNetCore.Authentication.AuthenticateResult
    
        
        .. code-block:: csharp
    
            public static AuthenticateResult Skip()
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.AuthenticateResult.Success(Microsoft.AspNetCore.Authentication.AuthenticationTicket)
    
        
    
        
        :type ticket: Microsoft.AspNetCore.Authentication.AuthenticationTicket
        :rtype: Microsoft.AspNetCore.Authentication.AuthenticateResult
    
        
        .. code-block:: csharp
    
            public static AuthenticateResult Success(AuthenticationTicket ticket)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Authentication.AuthenticateResult
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Authentication.AuthenticateResult.Failure
    
        
    
        
        Holds failure information from the authentication.
    
        
        :rtype: System.Exception
    
        
        .. code-block:: csharp
    
            public Exception Failure { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Authentication.AuthenticateResult.Skipped
    
        
    
        
        Indicates that this stage of authentication was skipped by user intervention.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool Skipped { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Authentication.AuthenticateResult.Succeeded
    
        
    
        
        If a ticket was produced, authenticate was successful.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool Succeeded { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Authentication.AuthenticateResult.Ticket
    
        
    
        
        The authentication ticket.
    
        
        :rtype: Microsoft.AspNetCore.Authentication.AuthenticationTicket
    
        
        .. code-block:: csharp
    
            public AuthenticationTicket Ticket { get; }
    

