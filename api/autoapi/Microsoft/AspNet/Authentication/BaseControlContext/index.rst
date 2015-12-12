

BaseControlContext Class
========================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Authentication.BaseContext`
* :dn:cls:`Microsoft.AspNet.Authentication.BaseControlContext`








Syntax
------

.. code-block:: csharp

   public class BaseControlContext : BaseContext





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/security/src/Microsoft.AspNet.Authentication/Events/BaseControlContext.cs>`_





.. dn:class:: Microsoft.AspNet.Authentication.BaseControlContext

Constructors
------------

.. dn:class:: Microsoft.AspNet.Authentication.BaseControlContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Authentication.BaseControlContext.BaseControlContext(Microsoft.AspNet.Http.HttpContext)
    
        
        
        
        :type context: Microsoft.AspNet.Http.HttpContext
    
        
        .. code-block:: csharp
    
           protected BaseControlContext(HttpContext context)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Authentication.BaseControlContext
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Authentication.BaseControlContext.HandleResponse()
    
        
    
        Discontinue all processing for this request and return to the client.
        The caller is responsible for generating the full response.
        Set the :dn:prop:`Microsoft.AspNet.Authentication.BaseControlContext.AuthenticationTicket` to trigger SignIn.
    
        
    
        
        .. code-block:: csharp
    
           public void HandleResponse()
    
    .. dn:method:: Microsoft.AspNet.Authentication.BaseControlContext.SkipToNextMiddleware()
    
        
    
        Discontinue processing the request in the current middleware and pass control to the next one.
        SignIn will not be called.
    
        
    
        
        .. code-block:: csharp
    
           public void SkipToNextMiddleware()
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Authentication.BaseControlContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Authentication.BaseControlContext.AuthenticationTicket
    
        
    
        Gets or set the :dn:prop:`Microsoft.AspNet.Authentication.BaseControlContext.AuthenticationTicket` to return if this event signals it handled the event.
    
        
        :rtype: Microsoft.AspNet.Authentication.AuthenticationTicket
    
        
        .. code-block:: csharp
    
           public AuthenticationTicket AuthenticationTicket { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.BaseControlContext.HandledResponse
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool HandledResponse { get; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.BaseControlContext.Skipped
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool Skipped { get; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.BaseControlContext.State
    
        
        :rtype: Microsoft.AspNet.Authentication.EventResultState
    
        
        .. code-block:: csharp
    
           public EventResultState State { get; set; }
    

