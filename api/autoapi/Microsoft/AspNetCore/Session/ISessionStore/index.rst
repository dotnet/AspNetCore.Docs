

ISessionStore Interface
=======================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Session`
Assemblies
    * Microsoft.AspNetCore.Session

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface ISessionStore








.. dn:interface:: Microsoft.AspNetCore.Session.ISessionStore
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Session.ISessionStore

Properties
----------

.. dn:interface:: Microsoft.AspNetCore.Session.ISessionStore
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Session.ISessionStore.IsAvailable
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            bool IsAvailable
            {
                get;
            }
    

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Session.ISessionStore
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Session.ISessionStore.Create(System.String, System.TimeSpan, System.Func<System.Boolean>, System.Boolean)
    
        
    
        
        :type sessionKey: System.String
    
        
        :type idleTimeout: System.TimeSpan
    
        
        :type tryEstablishSession: System.Func<System.Func`1>{System.Boolean<System.Boolean>}
    
        
        :type isNewSessionKey: System.Boolean
        :rtype: Microsoft.AspNetCore.Http.ISession
    
        
        .. code-block:: csharp
    
            ISession Create(string sessionKey, TimeSpan idleTimeout, Func<bool> tryEstablishSession, bool isNewSessionKey)
    

