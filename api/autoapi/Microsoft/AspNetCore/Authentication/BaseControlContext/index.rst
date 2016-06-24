

BaseControlContext Class
========================





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
* :dn:cls:`Microsoft.AspNetCore.Authentication.BaseContext`
* :dn:cls:`Microsoft.AspNetCore.Authentication.BaseControlContext`








Syntax
------

.. code-block:: csharp

    public class BaseControlContext : BaseContext








.. dn:class:: Microsoft.AspNetCore.Authentication.BaseControlContext
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Authentication.BaseControlContext

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Authentication.BaseControlContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Authentication.BaseControlContext.BaseControlContext(Microsoft.AspNetCore.Http.HttpContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Http.HttpContext
    
        
        .. code-block:: csharp
    
            protected BaseControlContext(HttpContext context)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Authentication.BaseControlContext
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Authentication.BaseControlContext.CheckEventResult(out Microsoft.AspNetCore.Authentication.AuthenticateResult)
    
        
    
        
        :type result: Microsoft.AspNetCore.Authentication.AuthenticateResult
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool CheckEventResult(out AuthenticateResult result)
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.BaseControlContext.HandleResponse()
    
        
    
        
        Discontinue all processing for this request and return to the client.
        The caller is responsible for generating the full response.
        Set the :dn:prop:`Microsoft.AspNetCore.Authentication.BaseControlContext.Ticket` to trigger SignIn.
    
        
    
        
        .. code-block:: csharp
    
            public void HandleResponse()
    
    .. dn:method:: Microsoft.AspNetCore.Authentication.BaseControlContext.SkipToNextMiddleware()
    
        
    
        
        Discontinue processing the request in the current middleware and pass control to the next one.
        SignIn will not be called.
    
        
    
        
        .. code-block:: csharp
    
            public void SkipToNextMiddleware()
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Authentication.BaseControlContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Authentication.BaseControlContext.HandledResponse
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool HandledResponse { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Authentication.BaseControlContext.Skipped
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool Skipped { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Authentication.BaseControlContext.State
    
        
        :rtype: Microsoft.AspNetCore.Authentication.EventResultState
    
        
        .. code-block:: csharp
    
            public EventResultState State { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Authentication.BaseControlContext.Ticket
    
        
    
        
        Gets or set the :dn:prop:`Microsoft.AspNetCore.Authentication.BaseControlContext.Ticket` to return if this event signals it handled the event.
    
        
        :rtype: Microsoft.AspNetCore.Authentication.AuthenticationTicket
    
        
        .. code-block:: csharp
    
            public AuthenticationTicket Ticket { get; set; }
    

