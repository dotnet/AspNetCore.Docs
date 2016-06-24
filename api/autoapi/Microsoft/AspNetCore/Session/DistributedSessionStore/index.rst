

DistributedSessionStore Class
=============================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Session`
Assemblies
    * Microsoft.AspNetCore.Session

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Session.DistributedSessionStore`








Syntax
------

.. code-block:: csharp

    public class DistributedSessionStore : ISessionStore








.. dn:class:: Microsoft.AspNetCore.Session.DistributedSessionStore
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Session.DistributedSessionStore

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Session.DistributedSessionStore
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Session.DistributedSessionStore.DistributedSessionStore(Microsoft.Extensions.Caching.Distributed.IDistributedCache, Microsoft.Extensions.Logging.ILoggerFactory)
    
        
    
        
        :type cache: Microsoft.Extensions.Caching.Distributed.IDistributedCache
    
        
        :type loggerFactory: Microsoft.Extensions.Logging.ILoggerFactory
    
        
        .. code-block:: csharp
    
            public DistributedSessionStore(IDistributedCache cache, ILoggerFactory loggerFactory)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Session.DistributedSessionStore
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Session.DistributedSessionStore.Create(System.String, System.TimeSpan, System.Func<System.Boolean>, System.Boolean)
    
        
    
        
        :type sessionKey: System.String
    
        
        :type idleTimeout: System.TimeSpan
    
        
        :type tryEstablishSession: System.Func<System.Func`1>{System.Boolean<System.Boolean>}
    
        
        :type isNewSessionKey: System.Boolean
        :rtype: Microsoft.AspNetCore.Http.ISession
    
        
        .. code-block:: csharp
    
            public ISession Create(string sessionKey, TimeSpan idleTimeout, Func<bool> tryEstablishSession, bool isNewSessionKey)
    

