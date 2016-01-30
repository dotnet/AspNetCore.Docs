

ISessionStore Interface
=======================



.. contents:: 
   :local:













Syntax
------

.. code-block:: csharp

   public interface ISessionStore





GitHub
------

`View on GitHub <https://github.com/aspnet/session/blob/master/src/Microsoft.AspNet.Session/ISessionStore.cs>`_





.. dn:interface:: Microsoft.AspNet.Session.ISessionStore

Methods
-------

.. dn:interface:: Microsoft.AspNet.Session.ISessionStore
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Session.ISessionStore.Connect()
    
        
    
        
        .. code-block:: csharp
    
           void Connect()
    
    .. dn:method:: Microsoft.AspNet.Session.ISessionStore.Create(System.String, System.TimeSpan, System.Func<System.Boolean>, System.Boolean)
    
        
        
        
        :type sessionId: System.String
        
        
        :type idleTimeout: System.TimeSpan
        
        
        :type tryEstablishSession: System.Func{System.Boolean}
        
        
        :type isNewSessionKey: System.Boolean
        :rtype: Microsoft.AspNet.Http.Features.ISession
    
        
        .. code-block:: csharp
    
           ISession Create(string sessionId, TimeSpan idleTimeout, Func<bool> tryEstablishSession, bool isNewSessionKey)
    

Properties
----------

.. dn:interface:: Microsoft.AspNet.Session.ISessionStore
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Session.ISessionStore.IsAvailable
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           bool IsAvailable { get; }
    

